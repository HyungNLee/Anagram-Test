using Microsoft.AspNetCore.Mvc;
using Anagram.Models;
namespace Anagram.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Form()
        {
            return View();
        }
        [Route("/result")]
        public ActionResult Result()
        {
            AnagramProgram myAnagramProgram = new AnagramProgram(Request.Query["initialWord"]);
            myAnagramProgram.AddPotentialWord(Request.Query["potentialAnagram01"]);
            myAnagramProgram.AddPotentialWord(Request.Query["potentialAnagram02"]);
            myAnagramProgram.AddPotentialWord(Request.Query["potentialAnagram03"]);
            

            return View("Result", myAnagramProgram);
        
        }
    }
}
