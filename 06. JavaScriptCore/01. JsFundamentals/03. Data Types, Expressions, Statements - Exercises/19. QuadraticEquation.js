function quadraticEquasion(a, b, c) {
    let d = Math.pow(b, 2) - 4 * a * c;

    let x1 = (-b + Math.sqrt(d))/(2*a);

    if(d > 0) {
        var x2 = (-b - Math.sqrt(d))/(2*a);
    }
    else if(d < 0) {
        return "No";
    }

    console.log(d == 0 ? x1 : Math.min(x1, x2));
    if(d > 0) { console.log(Math.max(x1, x2)) };
}

quadraticEquasion(6, 11, -35);