function solve(input, [x1, y1, x2, y2, x3, y3] = input) {
    let dist12 = Distance(x1, y1, x2, y2);
    let dist13 = Distance(x1, y1, x3, y3);
    let dist23 = Distance(x2, y2, x3, y3);

    if ((dist13 >= dist12 && dist23)) {
        let a = dist12 + dist23;
        console.log('1->2->3: ' + a);
    }
    else if (dist23 > dist12 && dist13) {
        let b = dist13 + dist12;
        console.log('2->1->3: '+ b);
    }
    else {
        let c = dist23 + dist13;
        console.log('1->3->2: ' + c);
    }

    function Distance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
    }
}

solve([-1, -2, 3.5, 0, 0, 2]);