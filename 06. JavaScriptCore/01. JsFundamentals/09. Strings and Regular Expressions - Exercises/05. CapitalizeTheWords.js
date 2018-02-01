function solve(str) {
    console.log(capitalize(str));

    function capitalize(str) {
        return str.replace(/\w*/g, function(txt){return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();});
    }
}

solve('Capitalize these words');