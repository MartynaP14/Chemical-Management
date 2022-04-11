using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Assay
    {
        [Key]
        public int AssayId { get; set; }

        [Required]
        public string AssayName { get; set; }

        [Required]
        public DateTime AssayDate { get; set; }

        [Required]
        public int AnalystID { get; set; }

        [Required]
        public int ReagentIdA { get; set; }

        [Required]
        public int ReagentIdB { get; set; }

    }

}