function solve(n, k) {
    let arr = [1];

    for (let i = 1; i < n; i++) {
        let lastNumbers = arr.reverse().slice(0, k).reverse();
        arr.reverse();
        arr.push(lastNumbers.reduce((a, b) => a + b, 0));
    }
    console.log('\n' + arr);
}

solve(6, 3);
//solve(8, 2)