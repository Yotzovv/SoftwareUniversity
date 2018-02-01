function rounding(input) {
    let n = input[0];
    let precision = input[1];

    if(precision > 15) {
        precision = 15;
    }
    console.log(Number(n.toFixed(precision)));
}