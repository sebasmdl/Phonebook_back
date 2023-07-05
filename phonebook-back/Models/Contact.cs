using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using phonebook_back.Data;

namespace phonebook_back.Models
{
    [PrimaryKey(nameof(Id))]
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string? FirstName { get; set; }
        [StringLength(60)]
        public string? LastName { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Comments { get; set; }
        // public string? OwnerID { get; set; }
    }
}
