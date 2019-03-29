// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {

    //**********************************Constants**********************************

    var statusCodes = {
        ok: 200
    };
    var enterKeyCode = 13;
    var expressionJQSelectorId = "#expression";
    var errorMessageQSelectorId = "#errorMessage";
    var equalsResultSeparator = " = ";
    var genericErrorMessage = "The entered expression could not be evaluated";


    //**********************************Functions**********************************


    function evaluateExpression() {
        clearResult();

        //Building the object server is waiting
        var expression = $(expressionJQSelectorId).val();
        var expressionObject = {
            expression: expression
        };

        //Send the request to server
        $.ajax({
            type: "POST",
            url: evaluateUrl,
            data: JSON.stringify(expressionObject),
            contentType: "application/json",
            success: function (jsonResult) {

                //If everything went right I insert the result
                if (jsonResult.statusCode === statusCodes.ok) {
                    setEvaluationResult(jsonResult.result);
                }
                else {
                    showErrorMessage(genericErrorMessage);
                }
            }
        });
    }

    function showErrorMessage(errorMessage) {
        $(errorMessageQSelectorId).text(errorMessage);

        toggleErrorMessageVisibility(true);
    }

    function toggleErrorMessageVisibility(isItVisible) {
        $(errorMessageQSelectorId).toggleClass("hidden", !isItVisible);
    }

    function setEvaluationResult(evaluationResult) {
        toggleErrorMessageVisibility(false);

        var result = equalsResultSeparator + evaluationResult;

        $(expressionJQSelectorId).val($(expressionJQSelectorId).val() + result);
    }

    function clearResult() {
        var expression = $(expressionJQSelectorId).val();
        var splitEqualsPattern = " =";

        //this removes the result from the expression if it exists. 
        expression = expression.split(splitEqualsPattern)[0];

        $(expressionJQSelectorId).val(expression);
    }


    //**********************************Document ready*********************************


    $(document).ready(function () {

        //If enter key is pressed on textarea, I evaluate the expression entered
        $(expressionJQSelectorId).on("keydown", function (event) {
            var keyCode = (event.keyCode ? event.keyCode : event.which);

            if (keyCode === enterKeyCode) {
                event.preventDefault();

                evaluateExpression();
            }
        });

    });

}());