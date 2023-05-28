using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TextMatch.Controllers;
using TextMatch.Models;

namespace TextMatch.Tests.Controllers
{
    [TestClass]
    public class TestMatchControllerTest
    {
        TextMatchModel objModel = new TextMatchModel() { InputText = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have a tea" };


        [TestMethod]
        public void WordTextMatch()
        {
            TextMatchController controller = new TextMatchController();
            //WHEN subtext is Polly
            objModel.SubText = "Polly";
            ViewResult result = controller.MatchText(objModel) as ViewResult;
            var textModel = (TextMatchModel)result.ViewData.Model;


            Assert.AreEqual("1,26,51", textModel.Output);
        }
        [TestMethod]
        public void LetterTextMatch()
        {
            TextMatchController controller = new TextMatchController();
            objModel.SubText = "ll";
            ViewResult result = controller.MatchText(objModel) as ViewResult;
            var textModel = (TextMatchModel)result.ViewData.Model;

            Assert.AreEqual("3,28,53,78,82", textModel.Output);

        }

        [TestMethod]
        public void WordTextNotMatch()
        {
            TextMatchController controller = new TextMatchController();
            objModel.SubText = "Polx";
            ViewResult result = controller.MatchText(objModel) as ViewResult;
            var textModel = (TextMatchModel)result.ViewData.Model;

            Assert.AreEqual("There is no output", textModel.Output);

        }

        [TestMethod]
        public void LetterTextNotMatch()
        {
            TextMatchController controller = new TextMatchController();
            objModel.SubText = "X";
            ViewResult result = controller.MatchText(objModel) as ViewResult;
            var textModel = (TextMatchModel)result.ViewData.Model;

            Assert.AreEqual("There is no output", textModel.Output);

        }


    }
}