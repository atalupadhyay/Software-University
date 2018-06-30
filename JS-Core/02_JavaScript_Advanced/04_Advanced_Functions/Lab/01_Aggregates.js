function aggregateLecturer(arr) {

    function reduce(arr, func) {
        let result = arr[0];
        for (let nextElement of arr.slice(1))
            result = func(result, nextElement);
        return result;
    }

    console.log('Sum = ' + reduce(arr, (a, b) => a + b));
    console.log('Min = ' + reduce(arr, (a, b) => a > b ? b : a));
    console.log('Max = ' + reduce(arr, (a, b) => a > b ? a : b));
    console.log('Product = ' + reduce(arr, (a, b) => a * b));
    console.log('Join = ' + reduce(arr, (a, b) => '' + a + b));

}

function aggregate(arr) {
    function reducer(arr, func) {
        let result = arr[0];
        for (let nextElem of arr.slice(1)) {
            result = func(result, nextElem);
        }
        return result;
    }

    console.log(`Sum = ${reducer(arr, (a, b) => a + b)}`);
    console.log(`Min = ${reducer(arr, (a, b) => a > b ? b : a)}`);
    console.log(`Max = ${reducer(arr, (a, b) => a > b ? a : b)}`);
    console.log(`Join = ${reducer(arr, (a, b) => '' + a + b)}`);
}

let arr = [5, -3, 20, 7, 0.5];
aggregate(arr);