function solve(matrix) {
    let neighbours = 0;
    for(let row = 0; row < matrix.length-1; row++) {
        for(let col = 0; col < matrix[row].length; col++) {
            if(matrix[row][col] == matrix[row + 1][col]) {
                neighbours++;
            }
            if(col > 0 && matrix[row][col] == matrix[row][col - 1]) {
                neighbours++;
            }
            if(matrix[row][col] == matrix[row][col + 1]) {
                neighbours++;
            }
        }
    }
    console.log(neighbours);
}

solve([['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]);

solve([['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]);