function solve(arr) {
    let text = arr.join('\n').toLowerCase();
    let words = text.split(/[^A-Za-z0-9_]+/).filter(w => w != '');
    let wordsCount = new Map();
    for(let word of words) {
        wordsCount.has(word.toLowerCase()) ? wordsCount.set(word, wordsCount.get(word)+1) : wordsCount.set(word, 1);
    }
    let allWords = Array.from(wordsCount.keys()).sort();
    allWords.forEach(w => console.log(`\'${w}\' -> ${wordsCount.get(w)} times`));
}

solve(['Far too slow, you\'re far too slow.']);