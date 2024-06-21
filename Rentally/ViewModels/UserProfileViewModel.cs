using Entities.Concrete.Dtos.Membership;
using Entities.Concrete.TableModels.Membership;

namespace Rentally.WEB.ViewModels
{
    public class UserProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
