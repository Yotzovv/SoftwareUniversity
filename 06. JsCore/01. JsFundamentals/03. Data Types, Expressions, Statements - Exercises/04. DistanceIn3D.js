function calcDistance(input) {
    let pointA = { x : input[0], y : input[1], z : input[2] };
    let pointB = { x : input[3], y : input[4], z : input[5] };

    let dist = Math.sqrt(Math.pow((pointB.x - pointA.x), 2) + Math.pow((pointB.y - pointA.y), 2) + Math.pow((pointB.z - pointA.z), 2));

    console.log(dist);
}

calcDistance([3.5, 0, 1, 0, 2, -1]);