function sumArr(arr, startIndex, endIndex) {
    Array.isArray(arr) === false ? NaN : 0;

    startIndex < 0 ? startIndex = 0 : startIndex;
    endIndex > arr.length - 1 ? endIndex = arr.length - 1 : endIndex;

    let sum = 0;
    for (let i = startIndex; i <= endIndex; i++) {
        sum += Number(arr[i]);
    }

    return sum;
}