using System;
using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public enum Reagent_Type { Organic, Inorganic, Acid, Base, Corrosive, Toxic }
    public class Reagent
    { 
        [Key]
        public int ReagentID { get; set; }
        [Required(ErrorMessage = "Please enter Reagent Name")]
        public string ReagentName { get; set; }

        [Required(ErrorMessage = "Please enter Reagent the lot number")]
        public int LotNumber { get; set; }

        [Required(ErrorMessage = "Please enter Vendor")]
        public string Vendor { get; set; }

        [Required(ErrorMessage = "Reagent type field is required")]
        public Reagent_Type Reagent_Type { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }

        //Navigation properties for entity framework, to define relationships between tables
        //FK for entity framework

    }
}

