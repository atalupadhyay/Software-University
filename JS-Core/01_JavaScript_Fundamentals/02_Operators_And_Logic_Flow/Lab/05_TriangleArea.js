function calculateTriangleArea(a, b, c) {
    let sp = (a + b + c) / 2;
    let area = Math.sqrt(sp * (sp - a) * (sp - b) * (sp - c));

    return area;
}

console.log(calculateTriangleArea(2, 3.5, 4));