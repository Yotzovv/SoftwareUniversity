function solve(input) {
    let targetSize = input[0];

    let cut = (num) => num / 4;
    let lap = (num) => num * 0.8;
    let grind = (num) => num - 20;
    let etch = (num) => num - 2;
    let transportAndWash = (num) => {
        console.log(`Transporting and washing`);
        return Math.floor(num);
    }
     let xray = (num) => {
        console.log(`X-ray x1`);
        return ++num;
    }

    for(let idx = 1; idx < input.length; idx++) {
        let microns = input[idx];
        console.log()
        microns = executeOperation(targetSize, microns, 'Cut', cut)
        microns = executeOperation(targetSize, microns, 'Lap', lap)
        microns = executeOperation(targetSize, microns, 'Grind', grind)
        microns = executeOperation(targetSize, microns, 'Etch', etch)

        if(microns + 1 == targetSize) {
            microns = xray(microns);
        }
        console.log(`Finished crystal ${microns} microns`);
    }

    function executeOperation(targetSize, size, operationName, operation) {
        let counter = 0;
        size = operation(size);
        while (operation(size) >= targetSize) {
            size = operation(size);
            counter++;
        }
        if(counter > 0) {
            console.log(`${operationName} x${counter}`);
            size = transportAndWash(size);
        }
    }
}

solve([1000, 4000, 8100]);