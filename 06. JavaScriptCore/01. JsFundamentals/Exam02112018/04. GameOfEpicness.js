function solve(kingdomsInput, battles) {
    let kingdoms = new Map();

    for (let element of kingdomsInput) {
        if (!kingdoms.has(element.kingdom)) {
            kingdoms.set(element.kingdom, new Map());
        }

        if (!kingdoms.get(element.kingdom).has(element.general)) {
            kingdoms.get(element.kingdom).set(element.general, 0);
        }

        let oldArmyCount = kingdoms.get(element.kingdom).get(element.general);

        kingdoms.get(element.kingdom).set(element.general, oldArmyCount + element.army);
    }

    let generals = new Map();

    for (let battle of battles) {
        let attacker = battle[0];
        let attackerGeneral = battle[1];
        let attackerArmy = kingdoms.get(attacker).get(attackerGeneral);

        let defender = battle[2];
        let defenderGeneral = battle[3];
        let defenderArmy = kingdoms.get(defender).get(defenderGeneral);

        if (attacker === defender) {
            continue;
        }

        if (!generals.has(attackerGeneral)) {
            generals.set(attackerGeneral, [0, 0]);    // generals wins and loses
        }

        if (!generals.has(defenderGeneral)) {
            generals.set(defenderGeneral, [0, 0]);
        }

        if (attackerArmy > defenderArmy) {
            attackerArmy += attackerArmy * 0.1;
            kingdoms.get(attacker).set(attackerGeneral, attackerArmy);
            generals.get(attackerGeneral)[0] += 1;

            defenderArmy -= defenderArmy * 0.1;
            kingdoms.get(defender).set(defenderGeneral, defenderArmy);
            generals.get(defenderGeneral)[1] += 1;

        } else if (defenderArmy > attackerArmy) {
            defenderArmy += defenderArmy * 0.1;
            kingdoms.get(defender).set(defenderGeneral, defenderArmy);
            generals.get(defenderGeneral)[0] += 1;

            attackerArmy -= attackerArmy * 0.1;
            kingdoms.get(attacker).set(attackerGeneral, attackerArmy);
            generals.get(attackerGeneral)[1] += 1;
        }
    }

    //console.log(generals);

    let scores = new Map();

    for(let [kingdom, gs] of kingdoms) {
        for(let [g,a] of gs) {
            for(let [gen, score] of generals) {
                if(g === gen) {
                    if(!scores.has(kingdom)) {
                        scores.set(kingdom, 0);
                    }

                    let oldScore = scores.get(kingdom);

                    scores.set(kingdom, oldScore + Number(score[0]));
                }
            }
        }
    }

    let winner = null;

    for(let [k,wins] of scores) {
        if(winner === null) {
            winner = {k, wins};
        }

        if(wins > winner.wins) {
            winner = {k, wins};
        }
    }

    console.log('Winner: ' + winner.k);

    for(let [gens] of kingdoms.get(winner.k)) {
        console.log("/\\general: " + gens);
        console.log('---army: ' + gens.army);
        console.log('---wins: ' + winner.wins);
        console.log('---loses: ');

    }
}

solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
        { kingdom: "Stonegate", general: "Ulric", army: 4900 },
        { kingdom: "Stonegate", general: "Doran", army: 70000 },
        { kingdom: "YorkenShire", general: "Quinn", army: 0 },
        { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
        { kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
    [ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
        ["Stonegate", "Ulric", "Stonegate", "Doran"],
        ["Stonegate", "Doran", "Maiden Way", "Merek"],
        ["Stonegate", "Ulric", "Maiden Way", "Merek"],
        ["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]);