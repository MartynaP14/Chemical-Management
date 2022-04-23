﻿using System.ComponentModel.DataAnnotations;

namespace Chemical_Management.Models
{
    public class Lab

    {
        [Key]
        public int LabID { get; set; }

        [Required]
        [Display(Name ="Lab name")]
        public string LabName { get; set; }

        [Display(Name ="Site the lab belongs to")]
        public string LabSite { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }

    }
}
