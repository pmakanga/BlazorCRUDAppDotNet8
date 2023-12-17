using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDAppDotNet8.Shared.Models
{
    public class Developer
    {
        public Guid Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,63}", ErrorMessage = "Please enter a correct email")]
        public string? Email { get; set; }

        [Required]
        public int Experience { get; set; }
    }
}
