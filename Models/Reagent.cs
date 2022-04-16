using System;
using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Reagent
    { 
        [Key]
        [Required(ErrorMessage ="Please enter Reagent ID")]
        public int ReagentID { get; set; }
        [Required(ErrorMessage = "Please enter Reagent Name")]
        public string ReagentName { get; set; }

        [Required(ErrorMessage = "Please enter Reagent Quantity")]
        public int NumberOfVials { get; set; }

        [Required(ErrorMessage = "Please enter Reagent Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter ID of Lab Analyst")] //foreign key 
        public string AnalystID { get; set; }

    }
}

//Reagent ID, Name, Location, lot number, Quantity (current number of vials), user ID that logged the reagent