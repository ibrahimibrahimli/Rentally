namespace Rentally.WEB.ViewModels
{
    public class UserWithRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Roles { get; set; }
    }
}
