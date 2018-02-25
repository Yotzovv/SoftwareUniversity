function solve(arr) {
    let sum = arr.reduce((a, b) => a += b);
    let min = Math.min(...arr);
    let max = Math.max(...arr);
    let product = arr.reduce((a,b) => a *= b);
    let joined = arr.join('');

    console.log(`Sum = ${sum}`);
    console.log(`Min = ${min}`);
    console.log(`Max = ${max}`);
    console.log(`Product = ${product}`);
    console.log(`Join = ${joined}`);    
}

solve([2, 3, 10, 5]);