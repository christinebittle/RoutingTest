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
        /// <param name="UserInput">The number to make lucky</param>
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




        /// <summary>
        /// Receives a lucky word as POST data
        /// </summary>
        /// <returns>
        /// A sentence acknowledging the lucky word
        /// </returns>
        /// <param name="LuckyWord">The lucky word. Must be enclosed with quotations</param>
        /// <example>
        /// POST: api/Inputs/Lucky
        /// HEADER: Content-Type: application/json
        /// FORM DATA: 'cat'
        /// -> "Lucky word is cat"
        /// </example>
        /// <example>
        /// cURL (windows)
        /// curl -d "\"cat\"" -H "Content-Type: application/json" https://localhost:xx/api/inputs/lucky
        /// </example>
        [HttpPost(template:"Lucky")]
        public string Lucky([FromBody]string LuckyWord)
        {
            return "Lucky word is "+LuckyWord;
        }

        /// <summary>
        /// Receives a user input and outputs the unlucky version of that number (10 less)
        /// </summary>
        /// <param name="UserInput">The number to make unlucky</param>
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
        /// GET: api/Inputs/Multiply?FirstNumber=5&SecondNumber=9 -> 45
        /// GET: api/Inputs/Multiply?FirstNumber=0&SecondNumber=0 -> 0
        /// </example>
        [HttpGet(template:"Multiply")]
        public int Multiply(int FirstNumber, int SecondNumber)
        {
            int Product = FirstNumber * SecondNumber;
            return Product;
        }

    }
}
