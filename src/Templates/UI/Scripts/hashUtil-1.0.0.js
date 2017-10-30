$.hashUtil = {
	currentHash: location.hash,
	callbacks: [],
	addCallback: function (callback) {
		if (typeof(callback) == "function")
			$.hashUtil.callbacks.push(callback);
	},
	_onHashChange: function (newHash, oldHash) {
		var nameValueCollection = $.hashUtil.convertHashToParams(newHash);

		for (var idx = 0; idx < $.hashUtil.callbacks.length; idx++) {
			$.hashUtil.callbacks[idx](nameValueCollection);
		}
	},
	convertHashToParams: function (hash) {
		var nameValueCollection = {
			params: [],
			namedParams: {},
			toQueryString: function () {
				return this.params.join("&");
			}
		};

		if (hash && hash.length > 0 && hash.indexOf("#!") == 0) {
			var parts = hash.substring(2).split("/");
			var count = 0;

			for (var idx = 0; idx < parts.length; idx++) {
				var keyValueString = parts[idx];
				var keyValue = keyValueString.split("=");

				if (keyValue.length == 2) {
					nameValueCollection.params.push(decodeURIComponent(keyValueString));
					nameValueCollection.namedParams[keyValue[0]] = decodeURIComponent(keyValue[1]);
				}
			}
		}

		return nameValueCollection;
	},
	convertQueryStringToHash: function (queryString) {
		var keyValues = queryString.split("&");
		var a = [];

		for (var idx = 0; idx < keyValues.length; idx++) {
			var keyValue = keyValues[idx].split("=");

			if (keyValue.length == 2) {
				a.push(keyValue[0] + "=" + encodeURIComponent(decodeURIComponent($.hashUtil._replaceSpecialChars(keyValue[1]))));
			}
		}

		return "#!" + a.join("/");
	},
	_replaceSpecialChars: function (str) {
		var re = /\+/ig;
		return str.replace(re, "%20");
	},
	setHashFromQueryString: function (url) {
		var parts = url.split("?");

		if (parts.length == 2)
			location.hash = $.hashUtil.convertQueryStringToHash(parts[1]);
	},
	setHash: function (hash) {
		location.hash = "#!" + hash;
	},
	startMonitorChanges: function () {
		if (location.hash && location.hash.length > 0)
			$.hashUtil._onHashChange(location.hash);
		$.hashChangeTimer = setInterval($.hashUtil.monitorChanges, 250);
	},
	monitorChanges: function () {
		if ($.hashUtil.currentHash != location.hash) {
			$.hashUtil._onHashChange(location.hash, $.hashUtil.currentHash);
			$.hashUtil.currentHash = location.hash;
		}
	}
};