function printCardsDeck(cards) {
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

    let deck = [];

    for (let cardStr of cards) {
        let face = cardStr.substring(0, cardStr.length - 1);
        let suit = cardStr.substr(cardStr.length - 1, 1);

        try {
            deck.push(solve(face, suit));
        } catch (err) {
            console.log('Invalid card: ' + cardStr);
            return;
        }
    }
    console.log(deck.join(' '));
}