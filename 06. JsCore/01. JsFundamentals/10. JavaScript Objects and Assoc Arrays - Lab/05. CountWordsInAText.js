function solve(arr) {
    let text = arr.join('\n');
    let words = text.split(/[^A-Za-z0-9_]+/).filter(w => w != '');
    let wordsCount = {};
    for(let word of words) {
        wordsCount[word] ? wordsCount[word]++ : wordsCount[word] = 1;
    }
    console.log(JSON.stringify(wordsCount));
}

solve(['Far too slow, you\'re far too slow.']);