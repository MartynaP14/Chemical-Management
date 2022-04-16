using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Chemical_Management.Models
{
    public enum Permissions { Admin, Basic }
    public class LabAnalyst
    {
        [Key]
        [RegularExpression(@"^[A-Z]{2}[\d]{3}$",
         ErrorMessage = "User ID format must match 'AA111' format")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "User Name details required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="User Permissions Required")]
        public Permissions Permissions { get; set; }
        
    }
}
