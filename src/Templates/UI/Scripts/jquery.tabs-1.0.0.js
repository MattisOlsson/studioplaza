(function ($) {
	$.fn.extend({
		tabs: function (options) {
			options = $.extend({}, $.tab.defaults, options);
			return this.each(function () {
				return new $.tab(this, options);
			});
		}
	});

	$.tab = function (tab, options) {
		var $tab = $(tab),
			$content = $("#" + $tab.attr("id") + "-content"),
			initialized = false,
			registerEvents = true,
			isActive = false;

		if (options.boxClass != null)
			$box.addClass(options.boxClass);

		function init() {
			if (initialized)
				return;

			initialized = true;

			if (registerEvents) {
				function click() {
					isActive = $tab.hasClass("active");

					if (!isActive) {
						$tab.addClass("active");
						$content.addClass("active");
					}

					$tab.siblings().each(function (idx) {
						var id = $(this).removeClass("active").attr("id");
						$("#" + id + "-content").removeClass("active");
					});
					return false;
				};

				$tab.on("click", click).bind("activate", click);
			}
		}

		init();
		return this;
	}

	$.tab.defaults = {
	};
})(jQuery);