; var map;

(function (d, $) {
	if ($("#map_canvas").size() == 0) {
		window.mapInitialize = function () { };
		return;
	}
		
	window.mapInitialize = function () {
		var Size = google.maps.Size,
			Point = google.maps.Point,
			mapOptions = {
				backgroundColor: "#eee",
				zoom: 16,
				maxZoom: 18,
				minZoom: 1,
				draggable: 1,
				disableDoubleClickZoom: false,
				scrollwheel: false,
				center: new google.maps.LatLng(60.6737425, 17.1423724),
				disableDefaultUI: false,
				streetViewControl: false,
				mapTypeControl: false,
				mapTypeId: google.maps.MapTypeId.ROADMAP
			};

		function redrawMap() {
			google.maps.event.trigger(map, "resize");
		}

		function loadMap(mapOptions) {
			map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

			var mapStyle = [
				{
					featureType: "administrative",
					elementType: "all",
					stylers: [
						{
							visibility: "off"
						}
					]
				},
				{
					featureType: "road",
					elementType: "all",
					stylers: [
						{ hue: "#000000" },
						{ saturation: -100 },
						{ lightness: 0 },
						{ visibility: "on" }
					]
				},
				{
					featureType: "landscape",
					elementType: "geometry",
					stylers: [
						{ hue: "#999999" },
						{ saturation: -100 },
						{ lightness: -38 },
						{ visibility: "on" }
					]
				},
				{
					featureType: "landscape.natural",
					elementType: "all",
					stylers: [
						{ visibility: "off" }
					]
				},
				{
					featureType: "water",
					elementType: "geometry",
					stylers: [
						{ hue: "#f2f0ef" },
						{ saturation: -77 },
						{ lightness: 76 },
						{ visibility: "on" }
					]

				}
			];

			var styledMapOptions = {
				"name": "studioplaza"
			},
			mapType = new google.maps.StyledMapType(mapStyle, styledMapOptions);

			map.mapTypes.set('studioplaza', mapType);
			map.setMapTypeId('studioplaza');
			placeMarker();
		}

		function placeMarker() {
			var latlng = new google.maps.LatLng(60.6737425, 17.1423724),
				studioPlazaMarker = new google.maps.Marker({
					"icon": new google.maps.MarkerImage('/Templates/UI/Assets/map-marker.png', new Size(17, 17), new Point(0, 0), new Point(8, 8)),
					"position": latlng
				});

			studioPlazaMarker.setMap(map);
		}

		loadMap(mapOptions);
	}

	var el = d.createElement("script");
	el.src = d.location.protocol + "//maps.googleapis.com/maps/api/js?key=AIzaSyB4H82OyoaDN80qhCQpzBQDIfb11WSzUhw&callback=mapInitialize";
	d.body.appendChild(el);
})(document, jQuery);