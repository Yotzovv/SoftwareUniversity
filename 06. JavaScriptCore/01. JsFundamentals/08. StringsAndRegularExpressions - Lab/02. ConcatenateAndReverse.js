function solve(arr) {
    for(let i = 0; i < arr.length; i++) {
        arr[i] = arr[i].split('').reverse().join('');
    }
        console.log(arr.reverse().join(''));
}

solve(['I', 'am', 'student']);