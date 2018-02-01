function modifyAvg(n) {
    let numStr = String(n);
    let getAvg = (numString) => numStr.split('').map(Number).reduce((a, b) => a + b)/numStr.length;

    while (getAvg(numStr) <= 5) {
        numStr += '9';
    }
    console.log(numStr);
}

modifyAvg(101);