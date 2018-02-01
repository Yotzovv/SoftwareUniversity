function solve(input, [currSpeed, area] = input) {
    let limit = getLimit(area);

    console.log(getInfraction(currSpeed, limit));

    function getLimit(zone) {
        switch (zone) {
            case 'motorway':
                return 130;
            case 'interstate':
                return 90;
            case 'city':
                return 50;
            case 'residential':
                return 20;
        }
    }

    function getInfraction(speed, limit) {
        let overSpeed = speed - limit;
        if (overSpeed > 0) {
            if(overSpeed <= 20) {
                    return 'speeding';
            } else if(overSpeed <= 40) {
                    return 'excessive speeding';
            } else {
                return 'reckless driving';
            }
        }
        return '';
    }
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);