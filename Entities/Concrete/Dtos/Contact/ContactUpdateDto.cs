using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool IsAnswered { get; set; } = false;

        public static Contact ToContact(ContactUpdateDto dto)
        {
            Contact contact  = new Contact()
            {
                Id = dto.Id,
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
