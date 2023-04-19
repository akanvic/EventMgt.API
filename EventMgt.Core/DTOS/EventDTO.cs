using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.DTOS
{
    public class EventDTO
    {
        public int EventId { get; set; }
        [Required(ErrorMessage = "EventTitle is required")]
        public string EventTitle { get; set; }
        public string? EventDescription { get; set; }
        [Required(ErrorMessage = "EventStartDate is required")]
        public DateTime EventStartDate { get; set; }
        [Required(ErrorMessage = "EventEndDate is required")]
        public DateTime EventEndDate { get; set; }
        [Required(ErrorMessage = "EventCreatorId is required")]
        public int EventCreatorId { get; set; }
    }
}
