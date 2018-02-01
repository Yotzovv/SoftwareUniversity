function solve(arr) {
    console.log(arr.sort().sort((a, b) => a.length - b.length).join('\n'));
}

solve(['aaa', 'a', 'aa'])