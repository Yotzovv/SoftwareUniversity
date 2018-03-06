(function () {

    String.prototype.ensureStart = function (str) {
        if (!this.toString().startsWith(str)) {
            return result = str + this.toString();
        }
        return this.toString();
    }

    String.prototype.ensureEnd = function (str) {
        if (!this.toString().endsWith(str)) {
            return result = this.toString() + str;
        }
        return this.toString();
    }

    String.prototype.isEmpty = function () {
        if (this.toString() === '') {
            return true;
        }
        return false;
    }

    String.prototype.truncate = function (n) {
        let currentString = this.toString();
        if (n > currentString.length - 1) {
            return currentString;
        }

        if (n < 4) {
            return '.'.repeat(n);
        }

        while (currentString.lastIndexOf(' ') != -1) {
            if (currentString.lastIndexOf(' ') <= n - 2) {
                return currentString.slice(0, currentString.lastIndexOf(' ')) + '...';
            }
            currentString = currentString.slice(0, currentString.lastIndexOf(' '));
        }
        return currentString.slice(0, n - 3) + '...';
    }

    String.format = function (string, ...arguments) {
        for (let i = 0; i < arguments.length; i++) {
            let index = string.indexOf('{' + i + '}');
            while (index != -1) {
                string = string.replace('{' + i + '}', arguments[i]);
                index = string.indexOf('{' + i + '}');
            }
        }
        return string;
    }
})();