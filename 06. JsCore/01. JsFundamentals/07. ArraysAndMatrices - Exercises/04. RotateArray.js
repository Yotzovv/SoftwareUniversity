function solve(arr, rotations = arr[arr.length-1]) {
    arr.pop();
    for(let i = 0; i < rotations; i++) {
        arr.unshift(arr[arr.length-1]);
        arr.pop();
    }
    console.log(arr.join(' '));
}

solve([1, 2, 3, 4, 2])