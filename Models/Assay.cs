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

        //Navigation properties for entity framework, to define relationships between tables
        //FK for entity framework

        //one assay to many reagents
        
        public List<Reagent> _reagents { get; set; }
        
       
        //one assay to one user/lab analyst
        [Required] //adding required as Assay must have one UserID(creator), cannot be nullable
        public string UserID { get; set; }
        
        public LabAnalyst LabAnalyst { get; set; }

        public Assay()
        {
            _reagents = new List<Reagent>();
        }

        public void AddReagent(Reagent reagent)
        {
            var match = _reagents.FirstOrDefault(x => x.ReagentID == reagent.ReagentID);
            if (match == null && reagent.NumberOfVials > 1)
            {
                _reagents.Add(reagent);  // (new Reagent() { ReagentID = reagent.ReagentID, Location });
            }
        }
    }

}