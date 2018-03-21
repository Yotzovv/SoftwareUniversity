function solve() {
    class Melon {
        constructor(weight, sort) {
            if (new.target === Melon) {
                throw Error('Abstract class cannot be instantiated directly');
            }

            this.weight = weight;
            this.sort = sort;
            this.element = this.constructor.name.replace('melon', '');
        }

        get elementIndex() {
            return this.weight * this.sort.length;
        }

        toString() {
            return `Element: ${this.element}\nSort: ${this.sort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, sort) {
            super(weight, sort);
        }
    }

    class Firemelon extends Melon {
        constructor(weight, sort) {
            super(weight, sort);
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, sort) {
            super(weight, sort);
        }
    }

    class Airmelon extends Melon {
        constructor(weight, sort) {
            super(weight, sort);
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, sort) {
            super(weight, sort);
            this.element = 'Water';
        }

        morph() {
            if(this.element == 'Water') {
                this.element = 'Fire';
            } else if(this.element == 'Fire') {
                this.element = 'Earth';
            } else if (this.element == 'Earth') {
                this.element = 'Air';
            } else {
                this.element = 'Water';
            }
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    }
}