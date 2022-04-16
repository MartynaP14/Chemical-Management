using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Assay
    {
        [Key]
        [Required(ErrorMessage = "Please enter Assay ID")]
        public int AssayId { get; set; }

        [Required(ErrorMessage = "Please enter Assay Name")]
        public string AssayName { get; set; }

        [Required(ErrorMessage = "Please enter Assay Assay Date")]
        public DateTime AssayDate { get; set; }

        [Required(ErrorMessage = "Please enter Assay Create Date")]
        public string AnalystID { get; set; }

        [Required(ErrorMessage = "Please enter Reagent A ID")]
        public int ReagentIdA { get; set; }

        [Required(ErrorMessage = "Please enter Reagent B ID")]
        public int ReagentIdB { get; set; }

    }

}