"use strict";
exports.__esModule = true;
var RequestData = /** @class */ (function () {
    function RequestData(method, uri, version, message) {
        this.response = undefined;
        this.fulfilled = false;
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
    }
    return RequestData;
}());
exports["default"] = RequestData;
