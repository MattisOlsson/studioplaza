(function ($) {
	$.fn.extend({
		expandablebox: function (options) {
			options = $.extend({}, $.expandablebox.defaults, options);
			return this.each(function () {
				return new $.expandablebox(this, options);
			});
		}
	});

	$.expandablebox = function (box, options) {
		var $box = $(box),
			$content = options.contentSelector ? $(options.contentSelector, box) : $box,
			$btn,
			initialized = false,
			registerBtnEvents = true,
			registerTabEvents = options.tabSelector != null,
			expandedOuterHeight,
			expandedInnerHeight,
			margin,
			isExpanded = false;

		if (options.boxClass != null)
			$box.addClass(options.boxClass);

		function reset() {
			$content.css({ "height": "auto", "overflow": null });
			expandedOuterHeight = $content.outerHeight();
			expandedInnerHeight = $content.height();
			margin = expandedOuterHeight - expandedInnerHeight;
			isExpanded = $box.hasClass("expanded");

			if (expandedOuterHeight > options.maxContentHeight) {
				addPaddingCover();
				if (!isExpanded) {
					$content.css({ "height": options.maxContentHeight - margin, "overflow": "hidden" });
				}

				$btn.show();
			}
			else {
				$btn.hide();
			}
		}

		function addPaddingCover() {
			var $cover = $(".padding-cover", $content);

			if ($cover.size() == 0)
				$cover = $("<div/>").addClass("padding-cover").appendTo($content);
		}

		function init() {
			if (initialized)
				return;

			initialized = true;
			expandedOuterHeight = $content.outerHeight();
			expandedInnerHeight = $content.height();
			margin = expandedOuterHeight - expandedInnerHeight;
			$btn = $(options.btnClass, box);

			if (registerTabEvents) {
				registerTabEvents = false;
				var $tabs = $(options.tabSelector, box);

				if ($tabs.size() > 0) {
					$tabs.on("click", function (event) {
						reset();
					});
				}
			}

			var expandCollapse = function (event) {
				var expandAnim = options.expandAnim ? options.expandAnim : { height: expandedInnerHeight };
				var collapseAnim = options.collapseAnim ? options.collapseAnim : { height: options.maxContentHeight - margin };
				isExpanded = $box.hasClass("expanded");

				if (!isExpanded) {
					$content.animate(expandAnim, 200, function () {
						$box.addClass("expanded");
						var boxBtmY = $box.offset().top + $box.outerHeight();
						var windowHeight = $(window).height();
						var scrollTop = $(document).scrollTop();

						if (boxBtmY > windowHeight + scrollTop)
							$("html,body").animate({ scrollTop: (boxBtmY - windowHeight) + 5 }, 100);

						isExpanded = true;
					});
				}
				else {
					$content.animate(collapseAnim, 200, function () {
						$box.removeClass("expanded");
						isExpanded = false;
					});
				}
				return false;
			};

			if (expandedOuterHeight > options.maxContentHeight) {
				if ($btn.size() == 0)
					$btn = $("<a/>").attr("href", "javascript:void(0)").addClass(options.btnClass).text("Expandera").appendTo($box);

				$content.height(options.maxContentHeight - margin).css({ "overflow": "hidden" });
				addPaddingCover();

				if (registerBtnEvents) {
					$btn.on("click", expandCollapse).on("focus", function (event) {
						this.blur();
					});

					registerBtnEvents = false;
				}
			}
			else if ($btn.size() > 0) {
				$btn.hide();
			}
		}

		init();
		return this;
	}

	$.expandablebox.defaults = {
		"boxClass": null,
		"btnClass": "btn",
		"expandedClass": "expanded",
		"contentSelector": ".inner",
		"maxContentHeight": 200,
		"expandAnim": null,
		"collapseAnim": null,
		"tabSelector": null,
		"addPaddingCover": false
	};
})(jQuery);