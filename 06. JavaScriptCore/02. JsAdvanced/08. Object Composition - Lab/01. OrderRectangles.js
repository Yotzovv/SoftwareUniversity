function solve(matrix) {
    let rectangles = [];

    for (let [w, h] of matrix) {
        rectangles.push(createRectangle(w, h));
    }

    rectangles.sort((a,b) => a.compareTo(b))

    function createRectangle(w, h) {
        let rectangle = {
            width: w,
            height: h,
            area: () => rectangle.width * rectangle.height,
            compareTo: function (other) {
                let result = other.area() - rectangle.area();
                return result || (other.width - rectangle.width);
            }
        };
        return rectangle;
    }

    return rectangles;
}
solve([[10, 5], [5, 12]]);
//solve([[10,5], [3,20], [5,12]]);