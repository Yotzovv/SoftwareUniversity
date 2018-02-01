function solve(input) {
    let positives = [];
    let negatives = [];

    for(e of input) {
        if(e >= 0) {
            positives.push(e);
        } else {
            negatives.unshift(e);
        }
    }
    console.log(negatives.join('\n'));
    console.log(positives.join('\n'));
}

solve([7, -2, 8, 9]);