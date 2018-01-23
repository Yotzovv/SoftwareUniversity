function solve(input) {
    console.log(input.filter((e, i) => i % 2 != 0)
        .map(e => e * 2).reverse());
}

solve([10, 15, 20, 25]);