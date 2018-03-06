let solution = (() => {
    return {
        add: (v1, v2) => [v1[0] + v2[0], v1[1] + v2[1]],
        multiply: (v1, m) => [v1[0] * m, v1[1] * m],
        length: (v) => Math.sqrt(v[0] * v[0] + v[1] * v[1]),
        dot: (v1, v2) => v1[0] * v1[1] + v2[0] * v2[1],
        cross: (v1, v2) => v1[0] * v2[1] - v1[1] * v2[0]
    }
})();

console.log(solution.add([1, 1], [1, 0])); s
console.log(solution.multiply([3.5, -2], 2));
console.log(solution.length([3, -4]));
console.log(solution.dot([1, 0], [0, -1]));
console.log(solution.cross([3, 7], [1, 0]));