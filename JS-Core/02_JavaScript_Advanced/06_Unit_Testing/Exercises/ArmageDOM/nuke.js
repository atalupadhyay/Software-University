let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');
let nuke = function nuke(selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
};

describe('ArmageDOM unit test', () => {
    let targetHtml;
    beforeEach(function () {
        document.body.innerHTML = `
       <body>
<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>
</body>`
        targetHtml = $('#target');
    });

    it('with valid and invalid selector', function () {
        let selector1 = $('.inside');
        let selector2 = 2;
        let oldHtml = targetHtml.html();
        nuke(selector1, selector2);
        expect(targetHtml.html()).to.be.equal(oldHtml);
    });
    it('with two equal selectors', function () {
        let selector1 = $('.inside');
        let oldHtml = targetHtml.html();
        nuke(selector1, selector1);
        expect(targetHtml.html()).to.be.equal(oldHtml);
    });
    it('with two valid selectors', function () {
        let selector1 = $('.nested');
        let selector2 = $('.target');
        let oldValue =targetHtml.html();
            nuke(selector1, selector2);
        expect(targetHtml.html()).to.not.equal(oldValue);
    });
    it('with two valid selector, shoudnt remove anything', function () {
        let selector1 = $('.nested');
        let selector2 = $('.inside');
        let oldHtml = targetHtml.html();
        nuke(selector1,selector2);
        expect(targetHtml.html()).to.be.equal(oldHtml);
    });
});