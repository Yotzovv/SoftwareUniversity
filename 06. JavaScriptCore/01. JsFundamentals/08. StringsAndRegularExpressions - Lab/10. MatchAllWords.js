function solve(str) {
    const pattern = /\w+/g;
    let m;
    let result = '';

    while((m = pattern.exec(str)) !== null) {
        if(m.index === pattern.lastIndex) {
            pattern.lastIndex++;
        }

        m.forEach((match, groupIndex) => {
            result += match + '|';
        });
    }
    console.log(result.substring(0, result.length-1))
}

solve("huichec ( ) 545 kakawwos odsko __")