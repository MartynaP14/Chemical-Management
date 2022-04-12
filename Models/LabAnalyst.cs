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
        [Required(ErrorMessage = "User ID is a required field")]
        private string userid = string.Empty;
        public string UserID
        {
            get { return userid; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Z]{3}(-+[0-9]{3})$")) //basic validation true == JON001
                {
                    throw new ArgumentException("User ID must match 'USR-001' Format");
                }
                userid = value;
            }
        }
        [Required(ErrorMessage = "User Name details required.")]
        public string Name { get; set; } = string.Empty;
        private Permissions permissions;
        public Permissions Permissions
        {
            get { return permissions; }
            set { permissions = value; }
        }
    }
}
