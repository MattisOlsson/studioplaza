/// Url encoding
; var Url = {

	// public method for url encoding
	encode: function (string) {
		return encodeURIComponent(this._utf8_encode(string));
	},

	// public method for url decoding
	decode: function (string) {
		return this._utf8_decode(decodeURIComponent(string));
	},

	// private method for UTF-8 encoding
	_utf8_encode: function (string) {
		string = string.replace(/\r\n/g, "\n");
		var utftext = "";

		for (var n = 0; n < string.length; n++) {

			var c = string.charCodeAt(n);

			if (c < 128) {
				utftext += String.fromCharCode(c);
			}
			else if ((c > 127) && (c < 2048)) {
				utftext += String.fromCharCode((c >> 6) | 192);
				utftext += String.fromCharCode((c & 63) | 128);
			}
			else {
				utftext += String.fromCharCode((c >> 12) | 224);
				utftext += String.fromCharCode(((c >> 6) & 63) | 128);
				utftext += String.fromCharCode((c & 63) | 128);
			}

		}

		return utftext;
	},

	// private method for UTF-8 decoding
	_utf8_decode : function (utftext) {
		var string = "";
		var i = 0;
		var c = c1 = c2 = 0;
 
		while ( i < utftext.length ) {
 
			c = utftext.charCodeAt(i);
 
			if (c < 128) {
				string += String.fromCharCode(c);
				i++;
			}
			else if((c > 191) && (c < 224)) {
				c2 = utftext.charCodeAt(i+1);
				string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
				i += 2;
			}
			else {
				c2 = utftext.charCodeAt(i+1);
				c3 = utftext.charCodeAt(i+2);
				string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
				i += 3;
			}
 
		}
 
		return string;
	}
}

///
/// Array extensions
///
Array.prototype.GetParam = function (paramName) {
	for (var i = 0; i < this.length; i++) {
		if (this[i].Name == paramName)
			return this[i];
	}

	return null;
}
Array.prototype.ContainsParam = function (paramName) {
	for (var i = 0; i < this.length; i++) {
		if (this[i].Name == paramName)
			return true;
	}

	return false;
};
Array.prototype.IndexOfParam = function (paramName) {
	for (var i = 0; i < this.length; i++) {
		if (this[i].Name == paramName)
			return i;
	}

	return -1;
};
Array.prototype.IndexOf = function (value) {
	for (var i = 0; i < this.length; i++) {
		if (this[i] == value)
			return i;
	}

	return -1;
};
Array.prototype.shuffle = function () {
	for (var j, x, i = this.length; i; j = parseInt(Math.random() * i), x = this[--i], this[i] = this[j], this[j] = x);
	return this;
};

///
/// String extensions
///
String.prototype.AddQueryString = function (key, value) {
	var urlEncode = (arguments.length > 2) ? arguments[2] : true;
	var chr;

	if (this.indexOf('?') > -1)
		chr = "&";
	else
		chr = "?";

	if (urlEncode)
		value = Url.encode(value);

	return this.valueOf() + chr + key + "=" + value;
};
String.prototype.Append = function (str) {
	return this.valueOf() + str;
};
String.prototype.padZero = function () {
	var str = this.valueOf();
	if (str.length == 1)
		return "0" + str;
	return str;
};
///
/// Date extensions
///
Date.prototype.toFormattedDateString = function () {
	return this.getFullYear() + "-" + (this.getMonth() + 1).toString().padZero() + "-" + this.getDate().toString().padZero();
};