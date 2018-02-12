function solve(matrix, forces) {
    for(let i = 0; i < matrix.length; i++) {
        matrix[i] = matrix[i].split(' ').map(Number);
    }

    for(let element of forces) {
        let force = element.split(' ')[0];
        let value = Number(element.split(' ')[1]);

        if(force === "breeze") {
            for(let i = 0; i < matrix[value].length; i++) {
                if(matrix[value][i] - 15 >= 0) {
                    matrix[value][i] -= 15;
                }
            }
        } else if(force === "gale") {
            for(let row = 0; row < matrix.length; row++) {
                if(matrix[row][value] - 20 >= 0) {
                    matrix[row][value] -= 20;
                }
            }
        } else if(force === "smog") {
            for(let row = 0; row < matrix.length; row++) {
                for(let col = 0; col < matrix[row].length; col++) {
                    matrix[row][col] += value;
                }
            }
        }
    }

    let pollutedBlocks = [];

    for(let row = 0; row < matrix.length; row++) {
        for(let col = 0; col < matrix[row].length; col++) {
            if(matrix[row][col] >= 50) {
                pollutedBlocks.push(`[${row}-${col}]`);
            }
        }
    }

    if(pollutedBlocks.length > 0) {
        console.log(`Polluted areas: ${pollutedBlocks.join(', ')}`);
    } else {
        console.log(`No polluted areas`);
    }
}


solve(["5 7 72 14 4",
    "41 35 37 27 33",
    "23 16 27 42 12",
    "2 20 28 39 14",
    "16 34 31 10 24",], ["breeze 1", "gale 2", "smog 25"]);


solve([
        "5 7 3 28 32",
        "41 12 49 30 33",
        "3 16 20 42 12",
        "2 20 10 39 14",
        "7 34 4 27 24",
    ],
    [
        "smog 11", "gale 3",
        "breeze 1", "smog 2"
    ]);

solve([
        "5 7 2 14 4",
        "21 14 2 5 3",
        "3 16 7 42 12",
        "2 20 8 39 14",
        "7 34 1 10 24",
    ],
    ["breeze 1", "gale 2", "smog 35"]);
