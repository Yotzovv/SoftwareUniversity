function multiplicationTable(n) {
    let output = '<table border=\"1\">\n';

    for(let i = 0;i<=n;i++) {
        output += '\t<tr>\n\t\t<th>' + (i == 0 ? 'x' : i) + '</th>\n'
        output += Array.from(new Array(n),(val,index)=>`\t\t${(i == 0 ? '<th>' : '<td>')}${(i == 0 ? 1 : i) * (index+1)}${(i == 0 ? '</th>' : '</td>')}\n`);
        output += '\t</tr>\n'
    }
    output += '</table>';
    console.log(output);
}

multiplicationTable(3);