function solve(goldMined) {
    goldMined = goldMined.map(Number);
    let goldPrice = 67.51;    //For Gram in BGN
    let btcPrice = 11949.16; //In BGN

    let currentMoney = 0;
    let currentBTC = 0;
    let dayOfFirstPurchasedBTC = 0;

    for(let gold = 0; gold < goldMined.length; gold++) {
        if ((gold + 1) % 3 === 0) {
            goldMined[gold] = goldMined[gold] * 0.7;
        }

        currentMoney += goldMined[gold] * goldPrice;

        while (currentMoney > btcPrice) {
            currentMoney -= btcPrice;
            currentBTC++;

            if (dayOfFirstPurchasedBTC === 0) {
                dayOfFirstPurchasedBTC = gold + 1;
            }
        }
    }

    console.log(`Bought bitcoins: ${currentBTC}`);
    if(currentBTC !== 0) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchasedBTC}`);
    }

    console.log(`Left money: ${parseFloat(currentMoney.toString()).toFixed(2)} lv.`);

    console.log();
}

solve(['100', '200', '300']);
solve(['50', '100']);
solve(['3124.15', '504.212', '2511.124']);