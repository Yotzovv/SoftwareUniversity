function solve(arr) {
    let result = [];

    for(element of arr.slice(1)) {
        let parts = element.split('|');
        let town = parts[1].trim();
        let latitude = Number(parts[2].trim())
        let longitude = Number(parts[3].trim());
        result.push({Town: town, Latitude: latitude, Longitude: longitude});
    }
    console.log(JSON.stringify(result));
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);