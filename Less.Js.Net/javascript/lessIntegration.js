//TODO ensure that javascript module pattern is correctly applied.

//mock declarations to make less.js happy:
window = this;
window.location = { href: "file://", port: "" };
document = { getElementsByTagName: function () { return [] } };

var lessJsNet = (function () {

    var defaultEvalOptions = {
        strictMath: true
    };

    return {
        lessIt : function(css, evalOptions) {
            evalOptions = evalOptions || defaultEvalOptions;

            var result;

            var parser = new less.Parser(evalOptions);

            parser.parse(css, function(error, tree) {
                if (error) {
                    console.warn(error);
                } else {
                    result = tree.toCSS(evalOptions);
                }
            });
            return result;
        }
    }
})();