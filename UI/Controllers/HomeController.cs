using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Factories.Abstractions;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        #region Attributes

        private ICalculator _calculator;

        #endregion

        #region Public methods

        public HomeController(ICalculatorFactory calculatorFactory)
        {
            this._calculator = calculatorFactory.CreateAndGetInstance();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult EvaluateAndGetResult([FromBody] ExpressionViewModel expression)
        {
            try
            {
                double result = this._calculator.Evaluate(expression.Expression);

                return new JsonResult(new { StatusCode = StatusCodes.Status200OK, Result = result });
            }
            // I know catching every exception (no matter the type or why it was thrown) and returning a generic error is WRONG in most cases. 
            //But for this simple example I'll do it anyway.
            //DO NOT do it!
            catch(Exception)
            {
                return new JsonResult(new { StatusCode = StatusCodes.Status500InternalServerError});
            }         
        }

        #endregion
    }
}
