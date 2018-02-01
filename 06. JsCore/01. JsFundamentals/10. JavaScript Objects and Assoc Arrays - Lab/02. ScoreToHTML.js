function solve(scoreJSON) {
    let html = '<table>\n';
    html += '\t<tr><th>name</th><th>score</th></tr>\n';
    let arr = JSON.parse(scoreJSON);
    for(let obj of arr) {
        html += `\t<tr><td>${htmlEscape(obj['name'])}</td><td>${obj['score']}</td></tr>\n`;
    }
    html += '</table>';
    
    console.log(html);


    function htmlEscape(obj) {
        return obj.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39');
    }
}

solve('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');
solve('[{"name":"<div>a && b</div>","score":111},{"name":"Jichka Jochkova","score":-50}]');