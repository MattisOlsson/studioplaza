// Simple jquery scroller by Mattias Olsson
; (function ($) {
	var timerId,
		interval = 13,
		timers = [],
		KEY = {
			PAGEUP: 33,
			PAGEDOWN: 34,
			UP: 38,
			DOWN: 40
		};

	$.fn.extend({
		scroller: function (options) {
			options = $.extend({}, $.scroller.defaults, options);
			return this.each(function () {
				new $.scroller(this, options);
			});
		},
		updatescroll: function () {
			return this.trigger("updatescroll");
		}
	});

	$.tick = function () {
		var timer,
			i = 0;

		for (; i < timers.length; i++) {
			timer = timers[i];
			if (!timer() && timers[i] === timer) {
				timers.splice(i--, 1);
			}
		}

		if (!timers.length) {
			clearInterval(timerId);
			timerId = null;
		}
	}

	$.timer = function (timer) {
		if (timer() && timers.push(timer) && !timerId) {
			timerId = setInterval($.tick, interval);
		}
	}

	$.scroller = function (element, options) {
		var $element = $(element),
			$scrollElement,
			$scrollBar,
			$scrollHiddenInput,
			scrollDragging = false,
			scrollbarVisible = false,
			scrollbarHeight = 0,
			elementHeight,
			scrollHeight = 0,
			scrollbarY = 0,
			scrollbarMaxY = 0,
			scrollbarFactor,
			grabY = 0,
			scrollbarHideTimer,
			hasFocus = false,
			isScrolling = false,
			inputFocused = false;

		if ($element.outerHeight() <= options.maxHeight)
			return false;

		function scroll(amount) {
			var currScrollHeight = scrollHeight;
			update();
			var y = scrollbarY + amount;
			var diff = scrollHeight - currScrollHeight;

			if (diff > 3 || diff < -3) {
				y *= currScrollHeight / scrollHeight;
			}

			scrollTo(adjustScrollbarY(y));
		}

		function scrollTo(y, force) {
			force = force || false;

			if (y == scrollbarY && !force)
				return;

			scrollbarY = y;
			options.onscroll && options.onscroll(scrollbarY, scrollbarHeight);
			$scrollBar.css("top", scrollbarY);
			$element.css("top", -scrollbarY * scrollbarFactor);
		}

		function adjustScrollbarY(y) {
			if (y < 0)
				y = 0;
			else if (y > scrollbarMaxY)
				y = scrollbarMaxY;

			return y;
		}

		function initScrollDrag(event) {
			grabY = event.pageY - $scrollBar.offset().top;
		}

		function dragScroll(event) {
			update();

			if (!scrollDragging)
				return false;

			var y = normalize(event.pageY) - grabY;
			scrollTo(adjustScrollbarY(y));
		}

		function swipeScroll(amount, duration) {
			var start = scrollbarY,
				now = start,
				end = adjustScrollbarY(scrollbarY + amount),
				pos;

			function tick() {
				var eased,
					currTime = $.now(),
					remaining = Math.max(0, animation.startTime + animation.duration - currTime),
					percent = 1 - (remaining / animation.duration || 0);
				
				pos = eased = $.easing.swing(percent, animation.duration * percent, 0, 1, animation.duration);
				now = (end - start) * eased + start;
				scrollTo(now);

				if (percent < 1) {
					return remaining;
				}
				else {
					return false;
				}
			}

			var animation = {
				startTime: $.now(),
				duration: duration
			};

			$.timer(tick);
		}

		function normalize(y) {
			return y - $scrollElement.offset().top;
		}

		function normalizeX(x) {
			return x - $scrollElement.offset().left;
		}

		function update() {
			var currScrollHeight = scrollHeight;
			elementHeight = $element.outerHeight();
			scrollHeight = elementHeight - options.maxHeight;
			scrollbarFactor = scrollHeight / (options.maxHeight - scrollbarHeight);
			scrollbarMaxY = options.maxHeight - scrollbarHeight;

			var diff = scrollHeight - currScrollHeight;

			if (diff > 3 || diff < -3) {
				var y = scrollbarY * (currScrollHeight / scrollHeight);
				scrollDragging = false;
				scrollTo(adjustScrollbarY(y), true);
			}
		}

		function showScrollbar() {
			clearTimeout(scrollbarHideTimer);

			elementHeight = $element.outerHeight();
			scrollHeight = elementHeight - options.maxHeight;
			scrollbarHeight = Math.max(50, options.maxHeight - scrollHeight);
			scrollbarFactor = scrollHeight / (options.maxHeight - scrollbarHeight);
			$scrollBar.height(scrollbarHeight);
			scrollbarMaxY = options.maxHeight - scrollbarHeight;
			$scrollBar.show().stop().animate({ opacity: 0.75 }, 200, function () {
				scrollbarVisible = true;
			});

		}

		function hideScrollbar() {
			scrollbarHideTimer = setTimeout(function () {
				scrollbarVisible = false;
				$scrollBar.animate({ opacity: 0 }, 200, function () {
					$scrollBar.hide();
				});
			}, 1500);
		}

		(function () {
			if ($element.outerHeight() <= options.maxHeight)
				return;

			$scrollElement = $("<div/>")
				.css({ "width": $element.outerWidth(), "height": options.maxHeight, "position": "relative", "overflow": "hidden" });

			var swipeDiff;
			var swipeStartY;

			var swipe = function (event, direction, distance, duration, fingerCount) {
				var delta = direction == "up" ? 1 : direction == "down" ? -1 : 0;
				var acceleration = (distance / duration) * 0.2;
				var amount = distance * acceleration * delta;
				swipeScroll(amount, 400);
			}

			$element = $element
				.css({ "width": $element.width(), "position": "absolute", "left": 0, "top": 0 })
				.wrap($scrollElement)
				.bind("updatescroll", function (event) {
					event.preventDefault();
					update();
					return false;
				}).bind("mousedown", function (event) {
					var x = normalizeX(event.pageX);
					if (x > $element.outerWidth() - 10) {
						var y = normalize(event.pageY);

						if (y < scrollbarY)
							delta = -1;
						else
							delta = 1;

						var amount = options.maxHeight * 0.85 * delta;
						scroll(amount / scrollbarFactor);
					}
				}).swipe({
					threshold: 50,
					maxTimeThreshold: 300,
					fallbackToMouseEvents: false,
					swipeStatus: function (event, phase, direction, distance, duration, fingerCount) {
						var y = normalize(event.pageY);

						switch (phase) {
							case "start":
								swipeDiff = scrollbarY + y - scrollbarY;
								swipeStartY = scrollbarY;
								showScrollbar();
								break;
							case "end":
								// We have a swipe
								swipe(event, direction, distance, duration, fingerCount);
								break;
							default:
								y -= y - (y - swipeDiff) + swipeStartY;
								scrollTo(adjustScrollbarY(-y), true);
								break;
						}
					}
				}).bind("focus mouseenter mousedown", function (event) {
					hasFocus = true;
					showScrollbar();
				}).bind("blur mouseleave", function () {
					hasFocus = false;
					if (!scrollDragging)
						hideScrollbar();
				}).delegate("textarea", "focus", function () {
					inputFocused = true;
				}).delegate("textarea", "blur", function () {
					inputFocused = false;
				});

			$scrollElement = $element.parent();

			$scrollBar = $("<span/>")
				.addClass(options.scrollBarClass)
				.css({ "position": "absolute", "cursor": "pointer", "right": 0, "top": 0 })
				.animate({ opacity: 0 }, 0)
				.insertAfter($element)
				.html("&nbsp;")
				.bind("mousedown", function (event) {
					event.preventDefault();
					initScrollDrag(event);
					scrollDragging = true;
					clearTimeout(scrollbarHideTimer);
					return false;
				}).bind("mouseup", function (event) {
					event.preventDefault();
					scrollDragging = false;
					return false;
				});

			$(document).bind("mousemove", function (event) {
				if (!scrollDragging)
					return;
				event.preventDefault();
				dragScroll(event);
				return false;
			}).bind("mousedown", function (event) {
				if (typeof (event.target) == "object") {
					if (event.target.type && (event.target.type == "textarea" || event.target.type == "input")) {
						$element.swipe("disable");
						event.target.focus();
					}
				}
				else {
					$element.find("textarea").blur();
				}
			}).bind("mouseup", function (event) {
				scrollDragging = false;
				$element.swipe("enable");
			}).bind("mousewheel", function (event, delta) {
				if (!hasFocus)
					return;
				event.preventDefault();
				scroll((60 * -delta) / scrollbarFactor);
				return false;
			}).bind($.browser.opera ? "keypress" : "keydown", function (event) {
				if (!hasFocus || inputFocused)
					return;

				var amount = 0;

				switch (event.keyCode) {
					case KEY.UP:
						amount = -30;
						break;
					case KEY.DOWN:
						amount = 30;
						break;
					case KEY.PAGEUP:
						amount = -options.maxHeight * 0.85;
						break;
					case KEY.PAGEDOWN:
						amount = options.maxHeight * 0.85;
						break;
				}

				if (amount != 0) {
					event.preventDefault();
					scroll(amount / scrollbarFactor);
					return false;
				}
			});
		})();
	}

	$.scroller.defaults = {
		maxHeight: 500,
		scrollBarClass: "scrollbar"
	};
})(jQuery);