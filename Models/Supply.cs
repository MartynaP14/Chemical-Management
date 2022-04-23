using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Supply
    {
        [Key]
        public int SupplyId { get; set; }

        [Required]
        public int ReagentId { get; set; }
        public int LabID { get; set; }
        public int ReagnetNumber { get; set; }

        public virtual Reagent Reagent { get; set; }
        public virtual Lab Lab { get; set; }

    }
}
