; (function($) {
	$.fn.extend({
		gallery: function(options) {
		    options = $.extend({}, $.gallery.defaults, options);
			return this.each(function() {
				new $.gallery(this, options);
			});
		}
	});
	
	$.gallery = function (element, options) {
		var $gallery = $(element),
			$items = $gallery.children(),
			transform,
			startZ = 400,
			items = [];

	    options.startIndex = parseInt($gallery.attr("data-start-index") || "1");
		$gallery.css({ "height": $gallery.height() + options.startY + 30, "position": "relative" });
		$items.css({ "visibility": "hidden", "position": "absolute", "left": options.startX, "top": options.startY });
		
		if ($.browser.webkit) transform = "-webkit-transform";
		else if ($.browser.mozilla) transform = "-moz-transform";
		else if ($.browser.msie) transform = "-ms-transform";
		else if ($.browser.opera) transform = "-o-transform";
		else transform = "transform";
		
		$items.each(function(idx) {
			var $t = $(this);

			if (options.rotateObjects) {
				var delta = Math.random(),
					deg = Math.random() * 15.0;
				
				if (delta < 0.5) delta = -1;
				else if (delta == 0.5) delta = 0;
				else delta = 1;
				$t.css(transform, "rotate(" + (delta * deg) + "deg)");
			}
				
			$t.css({ "visibility": "visible" });
			
			if (idx >= options.startIndex)
				items.push( { $item: $t, idx: idx - options.startIndex} );
		});

		if (options.shuffleOrder)
			items.shuffle();
					
		$.each(items, function(idx, itm) {
			itm.$item.css({ "left": "-=" + (items.length - idx) * 12, "top": "+=" + (items.length - idx) * 12, "z-index": startZ - idx });
		});
		
		function animate() {
			var itm = items.shift(),
				col = itm.idx % options.numCols,
				row = Math.floor(itm.idx * (1 / options.numCols)),
				left = col * itm.$item.outerWidth(true),
				top = row * itm.$item.outerHeight(true);
				
			itm.$item.animate({ left: left, top: top + 20 }, options.speed, options.easing);
			
			if (items.length > 0)
				setTimeout(animate, 60);
		}
		
		animate();
	};
	
	$.gallery.defaults = {
		rotateObjects: true,
		shuffleOrder: true,
		startX: 0,
		startY: 0,
		startIndex: 1,
		numCols: 3,
		speed: 900,
		easing: "easeInOutBack"
	};
})(jQuery);