function makeCard(face, suit) {
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const validSuits = ['S', 'H', 'D', 'C'];

    if(!validFaces.includes(face)){
        throw new Error('Invalid face.')
    }
    if(!validSuits.includes(suit)){
        throw new Error('Invalid suit.')
    }
    let card = {
        face:face,
        suit:suit,
        toString: function () {
            let suitToChar = {
                'S': '\u2660', //(♠)
                'H': '\u2665',   //(♥)
                'D': '\u2666', //(♦)
                'C':'\u2663'   //(♣)
        };

            return `${card.face}${suitToChar[suit]}`
        }
    };
    return card;
}

try{
    console.log('' + makeCard('1', 'S'));

}catch (e) {
    console.error(e.message);
}
