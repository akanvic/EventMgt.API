using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.DTOS
{
    public class ListOfCurrentUsersEventDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
        public PaginationDTO? pagination { get; set; }
    }
}
