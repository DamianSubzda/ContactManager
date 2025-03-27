using System.Collections.ObjectModel;

namespace ContactManager.Models
{
    public class Group
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<ContactGroup> ContactGroups { get; set; } = new List<ContactGroup>();

    }
}
