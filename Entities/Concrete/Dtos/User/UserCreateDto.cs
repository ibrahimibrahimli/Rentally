using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string BookingName { get; set; }

        public static User ToUser(UserCreateDto dto)
        {
            User user = new User()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                Password = dto.Password
            };

            return user;
        }
    }
}
