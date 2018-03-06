function solve(face, suit) {
    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let validSuits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\w2663',
    }

    if (!validFaces.includes(face)) {
        throw new Error('Invalid card suit: ' + suit);
    }

    let card = {
        face,
        suit,
        toString: function () {
            return face + validSuits[suit];
        }
    }

    return card;
}