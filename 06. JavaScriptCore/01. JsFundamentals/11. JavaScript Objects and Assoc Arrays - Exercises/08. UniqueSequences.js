function solve(input) {

    let set = new Set();

    for(let arr of input) {
        set.add(arr);
    }

    console.log(Array.from(new Set([...set])).sort().map(a => `[${a}]`).join('\n'))
}

solve(['[-3, -2, -1, 0, 1, 2, 3, 4]',
    '[10, 1, -17, 0, 2, 13]',
    '[4, -3, 3, -2, 2, -1, 1, 0]']);