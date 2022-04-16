 using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using TheBugTrackerProject.Models;

namespace BugTrackerProject.Models
{
    public class BTUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AvatarFormFile { get; set; }

        [DisplayName("Avatar")]
        public string AvatarFileName { get; set; }
        public byte[] AvatarFileData { get; set; }

        [DisplayName("File Extension")]
        public string AvatarContentType { get; set; }

        public int? CompanyId { get; set; }

        //Navigation Properties
        public virtual Company Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
