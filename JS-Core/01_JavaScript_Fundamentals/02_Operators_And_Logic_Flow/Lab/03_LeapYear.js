function isLeap(year) {
    let leap = (year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0);

    console.log(leap === true? 'yes': 'no');
}
