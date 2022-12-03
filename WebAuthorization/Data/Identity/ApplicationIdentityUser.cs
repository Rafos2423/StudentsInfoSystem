using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAuthorization.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long ApplicationId { get; set; }
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }

        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = true; }
    }
}
