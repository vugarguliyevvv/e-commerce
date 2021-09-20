using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.ViewModels
{
    public class RegisterVm
    {
        [Required, MaxLength(200)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string UserName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(10, MinimumLength = 5,  ErrorMessage = "minimum 5, maximum 10")]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
