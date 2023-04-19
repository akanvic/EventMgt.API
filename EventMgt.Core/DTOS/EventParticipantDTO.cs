using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.DTOS
{
    public class EventParticipantDTO
    {
        [Required(ErrorMessage = "EventId is required")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "ParticipantId is required")]
        public int ParticipantId { get; set; }
    }
}
