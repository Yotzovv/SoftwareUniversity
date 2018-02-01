function solve(targetStr, text) {
    let count = 0;
    let index = text.indexOf(targetStr);
    while(index > -1) {
        count++;
        index = text.indexOf(targetStr, index + 1);
    }
    return count;
}

solve(1233, 'The quick brown fox jumps over the lay dog.');