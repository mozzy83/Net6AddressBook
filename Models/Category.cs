using System.ComponentModel.DataAnnotations;

namespace Net6AddressBook.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string? AppUserId { get; set; }
        [Required]
        [Display(Name="Category Name")]
        public string? Name { get; set; }

        //Virtuals
        //Create foreign key to AppUser Model
        public virtual AppUser? AppUser { get; set; }
        //Creat foreign key to Contacts table. Since its a collection it will create a join table. Must create DbContext for Contacts table in ApplicationDvContext so migration generates database table.
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

    }
}
