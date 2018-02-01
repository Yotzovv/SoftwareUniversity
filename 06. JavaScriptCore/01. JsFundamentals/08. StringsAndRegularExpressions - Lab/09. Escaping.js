function solve(arr) {
    String.prototype.htmlEscape = function () {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39');
    }

    console.log(`<ul>`)
    for(let i = 0;i < arr.length;i++) {
        console.log(` <li>${arr[i].htmlEscape()}</li>`)
    }
    console.log(`</ul>`)
}

solve(['<b>unescaped text</b>', 'normal text']);