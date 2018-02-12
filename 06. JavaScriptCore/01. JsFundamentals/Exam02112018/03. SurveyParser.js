function solve(data) {
    const regex = /<svg>.*<\/svg>/g;
    const catRGX = /(<cat>.*?<\/cat>)/g;
    const labelRGX = /<text>.*\[([a-zA-Z\s].*)\]<\/text>/g;
    const valsRGX = /<val>([1-90-9]*?)<\/val>(\d*)/g;

    data = regex.exec(data);

    if (data === null) {
        console.log('No survey found');
        return;
    }

    let currMatch;
    let matches = [];
    let label = '';
    let valuesCount = [];


    while (currMatch = catRGX.exec(data)) {
        matches.push((decodeURIComponent(currMatch[1])));
    }

    label = labelRGX.exec(matches[0]);

    if(label === null) {
        label = labelRGX.exec(matches[0]);
    } else {
        label = labelRGX.exec(matches[0])[1];
    }


    if (label === null) {
        console.log('Invalid format');
        return;
    }


    while (currMatch = valsRGX.exec(matches[1])) {
        valuesCount.push(currMatch[1] + ' ' + currMatch[2]);
    }

    let sum = 0;
    let c = 0;

    for (let i = 0; i < valuesCount.length; i++) {
        let rating = Number(valuesCount[i].split(' ')[0]);
        let count = Number(valuesCount[i].split(' ')[1]);

        c += count;
        sum += rating * count;
    }

    console.log(`${label}: ${+(parseFloat((sum / c).toString())).toFixed(2)}`);
}

solve('<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>3</g><g><val>4</val>10</g><g><val>5</val>7</g></cat></svg><p>Some more random text</p>');
solve('<svg><cat><text>How do you rate the special menu? [Food - Special]</text></cat> <cat><g><val>1</val>5</g><g><val>5</val>13</g><g><val>10</val>22</g></cat></svg>');
solve(`<p>How do you suggest we improve our service?</p><p>More tacos.</p><p>Its great, dont mess with it!</p><p>Id like to have the option for delivery</p>`);
solve(`<svg><cat><text>Which is your favourite meal from our selection?</text></cat><cat><g><val>Fish</val>15</g><g><val>Prawns</val>31</g><g><val>Crab Langoon</val>12</g><g><val>Calamari</val>17</g></cat></svg>`);