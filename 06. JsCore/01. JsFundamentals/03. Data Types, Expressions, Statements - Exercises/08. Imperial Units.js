function convert(inches) {
    console.log(Math.floor(inches/12) + "'-" + (inches % 12) +"\"");
}

convert(55);