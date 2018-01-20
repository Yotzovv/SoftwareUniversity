function nowPlaying(input) {
    let trackName = input[0];
    let artistName = input[1];
    let durationInMinsAndSecs = input[2];

    console.log('Now Playing: ' + artistName + ' - ' + trackName + ' [' + durationInMinsAndSecs + ']');
}

nowPlaying(['Number One', 'Nelly', '4:09']);