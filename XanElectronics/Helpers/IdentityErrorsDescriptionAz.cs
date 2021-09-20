using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Helpers
{
    public class IdentityErrorsDescriptionAz : IdentityErrorDescriber
    {
        //public override IdentityError DuplicateEmail(string email)
        //{
        //    return new IdentityError
        //    {
        //        Code = nameof(DuplicateEmail),
        //        Description = $"{email} artiq movcuddur"
        //    };
        //}

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = $"Kichik herf teleb olunur"
            };

        }
    }
}
