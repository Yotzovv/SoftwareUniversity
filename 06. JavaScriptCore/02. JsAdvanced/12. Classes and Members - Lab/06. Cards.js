let output = (function () {
    const Suits = {
        CLUBS: "\u2663",
        DIAMONDS: "\u2666",
        HEARTS: "\u2665",
        SPADES: "\u2660"
    };

    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card {
        constructor(face, suits) {
            this.face = face;
            this.suits = suits;
        }

        set face(f) {
            if (!faces.includes(f)) {
                throw new TypeError(`Invalid card face: ${f}`);
            }
            this.face = f;
        }

        get face() {
            return this.face
        }

        set suits(s) {
            if (!Object.keys(Suits).map(k => k = Suits[k]).includes(s)) {
                throw new TypeError(`Invalid card suits: ${s}`);
            }
            this.suits = s;
        }

        get suits() {
            return this.suits;
        }

        toString() {
            return `${this.face}${this.suit}`;
        }
    }

    return { Suits, Card };
}());