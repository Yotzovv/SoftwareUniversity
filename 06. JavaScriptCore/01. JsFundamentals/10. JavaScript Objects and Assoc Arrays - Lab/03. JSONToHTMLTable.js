function solve(json) {
    let html = "<table>\n";
    let arr = JSON.parse(json);
    html += "  <tr>";
    for (let key of Object.keys(arr[0])) {
        html += `<th>${key}</th>`;
        html += "</tr>\n";
    }

    for (let obj of arr) {
        html += `\t<tr><td>${(obj['Name'])}</td><td>${obj['City']}</td></tr>\n`;
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

solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');