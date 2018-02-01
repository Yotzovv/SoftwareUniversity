function solve(arr) {
    let values = [];
    for(let row = 0; row < arr.length; row++) {
        values.push(arr[row].reduce((a, b) => a + b, 0))
        for(let col = 0; col < arr[row].length; col++) {
            values.push((arr.reduce((a, b) => a + b[col], 0)));
        }
    }
    console.log(values.every((val, i, arr) => val === arr[0]));
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);