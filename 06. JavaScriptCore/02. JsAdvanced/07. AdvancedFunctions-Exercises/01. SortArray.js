function solve(arr, order) {
    switch (order) {
        case 'asc':
            return arr.sort((a, b) => a - b);
        case 'desc':
            return arr.sort((a, b) => b - a);
    }
}

solve([14, 7, 17, 6, 8], 'asc');
solve([14, 7, 17, 6, 8], 'desc');