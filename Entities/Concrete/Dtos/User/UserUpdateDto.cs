using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string BookingName { get; set; }

        public static User ToUser(UserUpdateDto dto)
        {
            User user = new User()
            {
                Id = dto.Id,
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
