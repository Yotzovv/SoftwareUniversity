function solve(arr) {
    let biggestNum = 0;
    for(let i = 0; i <= arr.length; i++) {
        if(arr[i] >= biggestNum) {
            biggestNum = arr[i];
            console.log(biggestNum);
        }
    }
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24])