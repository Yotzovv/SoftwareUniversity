function chessBoard(n) {
    console.log('<div class="chessboard">');
    for(let i = 0; i < n; i++) {
            console.log('<div>');
            let color = (i % 2 == 0) ? 'black' : 'white';
            for(let col = 0; col < n; col++) {
                console.log('<span class=\"' + color + '\"></span>')
                color = (color == 'white') ? 'black' : 'white';
            }
            console.log('</div>')
    }
    console.log('</div>')
}

chessBoard(8);