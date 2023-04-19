using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.Models
{
    public class EventParticipant
    {
        [Key]
        public int EventParticipantId { get; set; }
        [ForeignKey("EventId")]
        public Event? Event { get; set; }
        public int EventId { get; set; }

        [ForeignKey("ParticipantId")]
        public ApplicationUser? Participant { get; set; }
        public int ParticipantId { get; set; }
        public bool EventParticipantStatus { get; set; }
    }
}
