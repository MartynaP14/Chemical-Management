using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Supply //represents relationship between reagent and lab with added property of stock/supply
    {
        [Key]
        public int SupplyId { get; set; }

        [Required]
        [Display(Name = "Reagent ID")]
        public int ReagentId { get; set; } //FK to tie to Reagent ref in supply class / also allows us to see which labs have certain reagents
        [Display(Name = "Lab ID")]
        public int LabID { get; set; } //FK to tie Lab reference in supply class (needed to see what labs have certain stocks)
        [Display(Name = "Reagent Stock")]
        public int ReagentStock { get; set; }

        //Navigation
        public virtual Reagent Reagent { get; set; }
        public virtual Lab Lab { get; set; }

    }
}
