function solve(arr) {
    console.log('<table>');
    for (let row of arr) {
        let data = JSON.parse(row);
        let keys = Object.values(data);
        console.log('\t<tr>');
        console.log(`\t\t<td>${keys[0]}</td>`);
        console.log(`\t\t<td>${keys[1]}</td>`);
        console.log(`\t\t<td>${keys[2]}</td>`);
        console.log(`\t<tr>`)
    }
    console.log('</table>');
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']);