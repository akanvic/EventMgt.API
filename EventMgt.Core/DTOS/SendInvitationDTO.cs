using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.DTOS
{
    public class SendInvitationDTO
    {
        [Required(ErrorMessage = "EventCreatorId is required")]
        public int EventCreatorId { get; set; }
        [Required(ErrorMessage = "EventId is required")]
        public int EventId { get; set; }
        public List<int> ParticipantIds { get; set; }
    }
}
