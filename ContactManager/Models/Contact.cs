using System.Collections.ObjectModel;

namespace ContactManager.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ContactGroup> ContactGroups { get; set; } = new List<ContactGroup>();

    }
}
