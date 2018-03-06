function solve(n) {
    let first = 0;
    let second = 1;

    return function () {
        let next = first + second;
        first = second;
        second = next;
        return first;
    }
}

let result = solve();
result();
result();
result();