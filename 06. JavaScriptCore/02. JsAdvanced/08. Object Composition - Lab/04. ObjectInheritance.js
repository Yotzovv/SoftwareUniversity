function solve(input) {
    let cmdExec = (function () {
        let store = {};

        function create(arr) {
            if (arr.length > 2) {
                store[arr[0]] = Object.create(store[arr[2]]);
            } else {
                store[arr[0]] = {};
            }
        }

        function set(arr) {
            store[arr[0]][arr[1]] = arr[2];
        }

        function print(arr) {
            let result = [];
            let obj = store[arr[0]];

            for (let key in obj) {
                result.push(key + ':' + obj[key]);
            }

            console.log(result.join(', '));
        }

        return { create, set, print }
    })()

    for (let str of input) {
        let args = str.split(' ');
        let cmd = args.shift();
        cmdExec[cmd](args);
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'])