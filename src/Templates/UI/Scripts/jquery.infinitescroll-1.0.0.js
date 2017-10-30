; (function ($) {
	$.fn.extend({
		infiniteScroll: function (getDataUrl, options) {
			options = $.extend({ getDataUrl: getDataUrl }, $.infiniteScroll.defaults, options);
			return this.each(function () {
				new $.infiniteScroll(this, options);
			});
		},
		uninfiniteScroll: function () {
			return this.trigger("uninfiniteScroll");
		}
	});

	$.infiniteScroll = function (list, options) {
		var $list = $(list),
			$items = $(options.itemSelector, $list),
			$loading,
			isLoading = false,
			loadMoreTimer = null;

		if ($items.size() < options.maxItems)
			return;

		function documentOverflow() {
			return $(document).height() - $(window).height()
		}

		function atBottom() {
			if (options.atBottom)
				return options.atBottom();

			var scrollTop = $(window).scrollTop();
			var listBtm = $(document).height() - ($list.offset().top + $list.outerHeight());
			return scrollTop > 0 && scrollTop >= documentOverflow() - listBtm + 50;
		}

		function beginLoadMore(event) {
			clearTimeout(loadMoreTimer);
			loadMoreTimer = setTimeout(loadMore, 100);
		}

		function loadMore(event) {
			if (isLoading || !atBottom())
				return;

			var extraParams = {};
			options.beforeGetData && options.beforeGetData(extraParams);
			isLoading = true;

			$.ajax({
				url: options.getDataUrl,
				type: "POST",
				dataType: "json",
				data: $.param(extraParams),
				success: function (response) {
					options.response && options.response(response.data);

					if (response.data && response.data.length < options.maxItems) {
						$list.uninfiniteScroll();
					}
				},
				complete: function () {
					isLoading = false;
				}
			});
		}

		(function () {
			$loading = $("<div/>").addClass(options.loadingCssClass).html(options.loadingMoreText).insertAfter($list);

			$list.bind("uninfiniteScroll", function () {
				$loading.remove();
				options.onunbind && options.onunbind();
				$(window).unbind("scroll.infiniteScroll");
			}).bind("loadmore", beginLoadMore);

			$(window).bind("scroll.infiniteScroll", function () {
				$list.trigger("loadmore");
			});
		})();
	}

	$.infiniteScroll.defaults = {
		loadingCssClass: "loading",
		loadingMoreText: "Laddar äldre inlägg",
		maxItems: 10,
		itemSelector: "li"
	};
})(jQuery);