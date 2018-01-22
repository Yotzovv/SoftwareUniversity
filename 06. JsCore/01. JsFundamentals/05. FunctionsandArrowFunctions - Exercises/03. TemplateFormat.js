function quiz(input) {
    let output = '<?xml version="1.0" encoding="UTF-8"?>\n<quiz>\n';
    for(let i=0;i<input.length;i+=2) {
        output += '\t<question>\n' + '\t\t' + input[i] + '\n\t</question>\n';
        output += '\t<answer>\n' + '\t\t' + input[i+1] + '\n\t</answer>\n';
    }
    output += '</quiz>';

    console.log(output);
}

quiz(["Dry ice is a frozen form of which gas?",
    "Carbon Dioxide",
    "What is the brightest star in the night sky?",
    "Sirius"]);
