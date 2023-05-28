using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextMatch.Models
{
    public class TextMatchModel
    {
        [Required(ErrorMessage = "Please enter Input Text")]
        public string InputText { get; set; }
        [Required(ErrorMessage = "Please enter Sub Text")]
        public string SubText { get; set; }

        public string Output { get; set; }

        public string ErrorMessage { get; set; }
    }
}