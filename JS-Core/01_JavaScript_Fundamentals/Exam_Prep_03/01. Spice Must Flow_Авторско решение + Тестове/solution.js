function solve([startingYield]) {
    startingYield = Number(startingYield);
    let total = 0;
    let c = 0;

    while(startingYield >= 100) {
        c++;
        total += startingYield;
        startingYield -= 10;
        total -= 26;
    }
    total -= 26;
    if (total < 0) total = 0;

    console.log(c);
    console.log(total);
}