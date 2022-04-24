using System;
using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    //public enum ReagentType { Organic, Inorganic, Acid, Base, Corrosive, Toxic } will add type as class so we can have a type controller/views
    public class Reagent
    { 
        [Key]
        public int ReagentID { get; set; }
        [Required(ErrorMessage = "Please enter Reagent Name")]
        public string ReagentName { get; set; }

        [Required(ErrorMessage = "Please enter Reagent the lot number")]
        public int LotNumber { get; set; }

        //[Required(ErrorMessage = "Please enter Vendor")] not needed vendor id in supply table can connect Reagents and Vendors
        //public string Vendor { get; set; }

        //[Required(ErrorMessage = "Reagent type field is required")]
        //public ReagentType Reagent_Type { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; } //represents many side of reagent to supply 
        public virtual ICollection< Type> Types { get; set; } //represents many side of type to reagent 

        //Navigation properties for entity framework, to define relationships between tables
        //FK for entity framework

    }
}

