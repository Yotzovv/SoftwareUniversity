function convert(grads) {
    let gradToDeg = (Number(grads) / (400/360)) % 360;
    if(gradToDeg < 0) { gradToDeg += 360; };
    console.log(gradToDeg);
}

convert(100);