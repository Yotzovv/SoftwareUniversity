function solve(input, k = input[0]) {
    input = input.slice(1);
    console.log(input.slice(0, k).join(' '));
    console.log(input.reverse().slice(0, k).reverse().join(' '));
}

solve([2, 7, 8, 9]);