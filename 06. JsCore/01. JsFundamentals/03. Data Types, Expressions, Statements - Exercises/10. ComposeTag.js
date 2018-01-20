function composeTag(input) {
    let locationOfFile = input[0];
    let alternateTxt = input[1];

    console.log('<img src=' + '\"' + locationOfFile + '\"'  + ' alt=' + '\"' + alternateTxt + '\">');
}

composeTag(['smiley.gif', 'Smiley Face']);