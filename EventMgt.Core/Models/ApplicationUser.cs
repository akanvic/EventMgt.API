using EventMgt.Core.Responses;
using System.ComponentModel.DataAnnotations;

namespace EventMgt.Core.Models
{
    public class ApplicationUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string UserEmail { get;  set; }
    }
}
