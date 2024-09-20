using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputsController : ControllerBase
    {

        /// <summary>
        /// Receives a number and outputs the lucky version of that number (x 2)
        /// </summary>
        /// <returns>The lucky number</returns>
        /// <example>
        /// GET : api/Inputs/Lucky/206 -> 412
        /// GET : api/Inputs/Lucky/100 -> 200
        /// GET : api/Inputs/Lucky/-3 -> -6 
        /// GET : api/Inputs/Lucky/{UserInput}
        /// </example>
        [HttpGet(template: "Lucky/{UserInput}")]
        public int Lucky(int UserInput)
        {
            int LuckyNumber = UserInput * 2;
            return LuckyNumber;
        }



        // POST: api/Inputs/Example2 -> "Lucky is 50"
        [HttpPost(template:"Example2")]
        public string Example2()
        {
            int LuckyNumber = 50;
            return "Lucky is "+LuckyNumber;
        }

        /// <summary>
        /// Receives a user input and outputs the unlucky version of that number (10 less)
        /// </summary>
        /// <returns>
        /// The unlucky number
        /// </returns>
        /// <example>
        /// GET: api/Inputs/Unlucky?UserInput=10 -> 0
        /// GET: api/Inputs/Unlucky?UserInput=100 -> 90
        /// GET: api/Inputs/Unlucky?UserInput=11 -> 1
        /// </example>
        [HttpGet(template:"Unlucky")]
        public int Unlucky(int UserInput)
        {
            int UnluckyNumber = UserInput - 10;
            return UnluckyNumber;
        }



        /// <summary>
        /// Returns the product of two numbers
        /// </summary>
        /// <param name="FirstNumber">The first input number</param>
        /// <param name="SecondNumber">The second input number</param>
        /// <returns>the product of {FirstNumber}*{SecondNumber}</returns>
        /// <example>
        /// GET: api/Inputs/Multiply/5/10 -> 50
        //  GET: api/Inputs/Multiply/5/9 -> 45

        /// GET: api/Inputs/Multiply?FirstNumber=5&SecondNumber=9 -> 45
        /// </example>
        [HttpGet(template:"Multiply")]
        public int Multiply(int FirstNumber, int SecondNumber)
        {
            int Product = FirstNumber * SecondNumber;
            return Product;
        }

    }
}
