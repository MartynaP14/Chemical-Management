using System;
using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Reagent
    {
        [Key]
        public int ReagentID { get; set; }
        [Required]
        public string ReagentName { get; set; }

        [Required]
        public int NumberOfVials { get; set; }

        [Required]
        public string Location { get; set; }

        [Required] //foreign key 
        public int AnalystID { get; set; }

        [Required]
        public string ReagentType { get; set;}

    }
}

//Reagent ID, Name, Location, lot number, Quantity (current number of vials), user ID that logged the reagent, Reagent type.