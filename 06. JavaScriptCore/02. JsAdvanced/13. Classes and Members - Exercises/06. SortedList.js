class Sorted {
    constructor() {
        this.arr = [];
        this.size = 0;
    }

    add(value) {
        this.arr.push(value);
        this.size++;
        this.arr.sort((a, b) => {
            return a - b;
        })
    }

    remove(index) {
        if(index >= 0 && index < this.arr.length) {
            this.arr.splice(index, 1);
            this.size--;
        }
    }

    get(index) {
        if(index >= 0 && index < this.arr.length) {
            return this.arr[index];
        }
    }
}

let x = new Sorted();

x.add(5);
x.add(8);
x.add(15);
x.remove(2);
x.add(1);


console.log(Object.__proto__.valueOf(x));

console.log(Object.prototype.valueOf(x));