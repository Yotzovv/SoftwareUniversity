function solve() {
    let summary = {};
    let sortedTypes = [];

    for (let i = 0; i < arguments.length; i++) {
        var obj = arguments[i];
        var type = typeof obj;

        console.log(`${type}: ${obj}`);

        if (!summary[type]) {
            summary[type] = 0;
        }

        summary[type]++;
    }

    for (var currType in summary) {
        sortedTypes.push([currType, summary[currType]]);
    }

    for (let [type, occurances] of sortedTypes) {
        console.log(`${type} = ${occurances}`);
    }
}

//solve('cat', 42, 11, { a: 1, b: 3 }, function () { console.log('Hello world!'); });
solve({ name: 'bob' }, 3.333, 9.999);