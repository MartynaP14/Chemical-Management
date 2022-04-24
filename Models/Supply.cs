using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Supply
    {
        [Key]
        public int SupplyId { get; set; }

        [Required]
        public int ReagentId { get; set; }

        [Required]
        public int LabID { get; set; }
        [Required]
        public int ReagnetNumber { get; set; }

        //Navigation
        public virtual Reagent Reagent { get; set; }
        public virtual Lab Lab { get; set; }

    }
}
