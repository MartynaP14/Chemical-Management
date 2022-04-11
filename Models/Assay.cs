using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Assay
    {
        [Key]
        public int AssayId { get; set; }

        [Required(ErrorMessage = "Assay name is required to enter")]
        public string AssayName { get; set; }

        [Required(ErrorMessage = "Assay date and time is required to enter")]
        public DateTime AssayDate { get; set; }

        [Required(ErrorMessage = "Analyst ID is required to enter")]
        public int AnalystID { get; set; }

        [Required(ErrorMessage = "Assay name is required to enter")]
        public int ReagentIdA { get; set; }

        [Required(ErrorMessage = "Assay name is required to enter")]
        public int ReagentIdB { get; set; }

    }

}