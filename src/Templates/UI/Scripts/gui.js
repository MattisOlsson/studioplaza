; var GUI;

(function ($) { 
	$.fn.setAllToMaxHeight = function () {
		return this.height(Math.max.apply(this, $.map(this, function (e) {
			return $(e).height();
		})));
	}

	var blockSubmit = false;
	var keyDownEventName = ($.browser.opera ? "keypress" : "keydown");
	var KEY = {
		TAB: 9,
		RETURN: 13,
		ESC: 27,
		LEFT: 37,
		RIGHT: 39
	};

	GUI = {
		init: function () {
			GUI.global();
			GUI.forms();
			GUI.plugins();
			//GUI.gallery();
			GUI.employees();
			GUI.ope();
		},

		global: function () {
			$("a[rel=external]").attr("target", "_blank");
		},

		forms: function () {
			$("form").on("submit", function (event) {
				if (blockSubmit) {
					blockSubmit = false;
					return false;
				}
			});
		},

		plugins: function () {
			// Cycle
			$('.cycle').plusSlider({
				sliderEasing: "easeInOutExpo",
				fullWidth: false,
				createArrows: false,
				infiniteSlide: true,
				displayTime: 11000,
				speed: 750,
				paginationPosition: "afterParent",
				sliderType: 'slider',
				beforeSlide: function(slider, toLeft, callback) {
					var currLeft = slider.$el.position().left;
					var $currSlide = slider.$currentSlide;
					
					if (currLeft < toLeft) {
						$currSlide.animate({ left: "-=25" }, 200, function() {
							$currSlide.animate({ left: "+=25" }, 100);
							callback && callback();
						});
					}
					else {
						$currSlide.animate({ left: "+=25" }, 200, function() {
							$currSlide.animate({ left: "-=25" }, 100);
							callback && callback();
						});
					}
				}
			}).swipe({
				swipeLeft: function(event, direction, duration) {
					var slider = $(this).data("plusSlider");
					slider.toSlide("next");
				},
				swipeRight: function(event, direction, duration) {
					var slider = $(this).data("plusSlider");
					slider.toSlide("prev");
				}	
			});
			
			// fancybox
			$(".fancy").fancybox();
		},

		scrollTo: function (top, callback) {
			$("html,body").animate({ scrollTop: top }, 100, callback);
		},

		scrollToElementTop: function ($element, callback, add) {
			var top = $element.offset().top;
			var scrollTop = $(document).scrollTop();

			if (add == undefined)
				add = -5;

			if (top < scrollTop) {
				GUI.scrollTo(top + add, callback);
			}
			else
				callback && callback();
		},

		scrollToElementBottom: function ($element, callback) {
			var btm = $element.offset().top + $element.outerHeight();
			var windowHeight = $(window).height();
			var scrollTop = $(document).scrollTop();

			if (btm > windowHeight + scrollTop) {
				GUI.scrollTo(btm - windowHeight + 50, callback);
			}
		},
		
		gallery: function() {
			$(".gallery").gallery({
				startIndex: 1,
				startX: 640,
				startY: -215,
				rotateObjects: false,
				speed: 1000
			});
		},
		
		employees: function () {
			var $employees = $(".employee-list img");

			$employees.each(function () {
				var $t = $(this),
					$p = $t.parent(),
					overflow = $p.width() - $t.outerWidth();

				if (overflow < 0)
					$t.css("left", overflow / 2);
			});
		},

		ope: function () {
			var $zones = $(".dropZone, .zoneItem");

			$zones.each(function () {
				var $t = $(this);
				$("<div/>").html("&nbsp;").addClass("clearboth").appendTo($t);
			});
		}
	};

	$(document).ready(function(event) {
		GUI.init();	
	});
})(jQuery);