function sum(arr) {
    return arr.reduce((a, b) => a + b);
}


describe('isOddOrEven', function () {
    it('with a number parameter, should return undefined', function () {
        expect(isOddOrEven(13)).to.equal(undefined,
            'Function did not return the correct result!');
    });

    it('takes only an array of numbers as argument', function () {
        expect(sum(['z', 'w', 'w']).to.equal(undefined,
            'Function takes different data types as parameter instead of number'));
    });

    it('sums the values of all elements inside array', function () {
        expect(sum([1, 2, 3]).to.equal(6,
            'Function does not sum array correctly!'))
    });
});