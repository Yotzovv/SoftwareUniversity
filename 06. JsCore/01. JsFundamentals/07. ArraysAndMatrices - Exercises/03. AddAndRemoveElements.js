function solve(input) {
    let arr = [];
    for(let i = 1; i <= input.length; i++) {
        if(input[i-1] == 'add') {
            arr.push(i);
        } else if(input[i-1] == 'remove') {
            arr.pop();
        }
    }
    console.log(arr.length == 0 ? 'Empty' : arr.join('\n'))
}

solve(['add', 'add', 'remove', 'add', 'add'])