using System;
using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public enum Location { Lab1, Lab2, Lab3 }
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
        public Location Location { get; set; } //adding as enum to make selections uniform in views

        //Navigation properties for entity framework, to define relationships between tables
        //FK for entity framework

        // one lab analyst to many reagents 
        public LabAnalyst LabAnalyst { get; set; }
        //adding LabAnalyst ID to help APIs (still 1 to many)
        public string UserID { get; set; }

        // one assay to many reagents (reference to Assay)
        public int AssayID { get; set; }
        public Assay Assay { get; set; }

    }
}

//Reagent ID, Name, Location, lot number, Quantity (current number of vials), user ID that logged the reagent