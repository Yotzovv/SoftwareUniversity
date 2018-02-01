function solve(arr) {
    let n = arr[0];
    for(let operator of arr.slice(1)) {
        n = calc(operator, n);
        console.log(n);
    }

    function calc(operator, n) {
        switch (operator) {
            case 'chop': return n/2;
            case 'dice': return Math.sqrt(n);
            case 'spice': return n+1;
            case 'bake': return n*3;
            case 'fillet': return n - n*0.2;
        }
    }
}

solve([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);