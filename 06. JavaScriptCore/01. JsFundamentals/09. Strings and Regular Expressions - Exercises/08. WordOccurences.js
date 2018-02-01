function solve(sentence, word) {
    console.log(sentence.match(new RegExp('\\b' + word + '\\b', 'gi')).length);
}

solve('There was one. Therefore I bought it. I wouldn�t buy it otherwise.', 'there');