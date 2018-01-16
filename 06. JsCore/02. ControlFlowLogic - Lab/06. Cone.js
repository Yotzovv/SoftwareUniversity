function calcConeVolAndSurface(r, h) {
    let s = Math.sqrt(r * r + h * h);
    console.log("volume = " + (1/3)*Math.PI*r*r*h);
    console.log("area = " + Math.PI * r * (r + s));
}