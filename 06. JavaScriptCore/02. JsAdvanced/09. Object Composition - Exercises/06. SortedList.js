function solve() {
    let arr = [];

    let obj = {
        add: function add(element) {
            arr.push(element);
            arr.sort((a, b) => a - b);
            this.size++;
        },

        remove: function remove(index) {
            if (index >= 0 && index < arr.length) {
                arr.splice(index, 1);
                this.size--;
            }
        },

        get: function get(index) {
            if (index >= 0 && index < arr.length) {
                return (arr[index]);
            }
        },

        size: 0,
    }

    return obj;
}