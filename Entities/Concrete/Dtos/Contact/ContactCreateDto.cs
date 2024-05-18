using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool IsAnswered { get; set; } = false;

        public static Contact ToCarCategory(ContactCreateDto dto)
        {
            Contact contact = new Contact()
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Message = dto.Message,
                IsAnswered = dto.IsAnswered
            };

            return contact;
        }
    }

}
