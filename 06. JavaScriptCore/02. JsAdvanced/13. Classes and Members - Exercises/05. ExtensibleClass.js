(function () {
    let id = 0;

    return class Extensible {
        constructor() {
            this.id++;
        }

        extend(template) {
            for (const key in template) {
                if (template.hasOwnProperty(key)) {
                    const element = template[key];
                    if (typeof (element) === 'function') {
                        Extensible.prototype[key] = element;
                    } else {
                        this[key] = element;
                    }
                }
            }
        }
    }
})();



let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);