using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextMatch.Models;

namespace TextMatch.Controllers
{
    public class TextMatchController : Controller
    {
        // GET: Text
        public ActionResult Index()
        {
            var textTemp = new TextMatchModel();
            return View(textTemp);
        }

        [HttpPost]
        public ActionResult MatchText(TextMatchModel textModel)
        {
            string output = "";
            bool match;
            try
            {
                if (ModelState.IsValid)
                {
                    var inputText = textModel.InputText.ToString().ToUpper();
                    var subText = textModel.SubText.ToString().ToUpper();

                    //determine the comparison length for each iteration
                    var comparisonLength = inputText.Length - subText.Length + 1;

                    for (int i = 0; i < comparisonLength; i++)
                    {
                        //assuming the text match by default
                        match = true;

                        // iterate through the subText and compare each letter with the inputText and check whether they match
                        for (int j = 0; j < subText.Length; j++)
                        {
                            //move to the next comparison if there is no match
                            if (inputText[i + j] != subText[j])
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            int indexAtMatch = i + 1;
                            output += output == "" ? Convert.ToString(indexAtMatch) : "," + Convert.ToString(indexAtMatch);
                        }
                    }
                    textModel.Output = output == "" ? "There is no output" : output; 
                }
                return View("Index", textModel);
            }
            catch(Exception ex) 
            {
                textModel.ErrorMessage =ex.Message.ToString();
                return View(textModel);
            }
          
        }
    }
}