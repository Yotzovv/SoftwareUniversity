function solve() {
    let obj = {
        extend: function (template) {
            for (const key in template) {
                if (template.hasOwnProperty(key)) {
                    const el = template[key];
                    if (typeof (el) === 'function') {
                        obj.__proto__[key] = el;
                    } else {
                        obj[key] = el;
                    }
                }
            }
        }
    }
    return obj;
}