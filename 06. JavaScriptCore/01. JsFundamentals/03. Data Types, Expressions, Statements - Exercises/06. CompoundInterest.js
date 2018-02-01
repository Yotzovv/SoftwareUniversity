function calcInterest(input) {
    let [sum, interest, period, years] = input;
    period = 12/period;
    let compoundInterest = sum*Math.pow((1 + ((interest/100)/period)), (period*years))

    console.log(compoundInterest.toFixed(2));
}

calcInterest([1500, 4.3, 3, 6]);