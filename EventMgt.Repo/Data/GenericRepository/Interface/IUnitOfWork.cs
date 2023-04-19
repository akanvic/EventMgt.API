using EventMgt.Repo.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.GenericRepository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UsersRepository { get; }
        IEventRepository EventsRepository { get; }
        IEventParticipantRepository EventParticipantsRepository { get; }
        IParticipantInvitationRepo ParticipantInvitationsRepo { get; }
        Task<int> Save();
    }
}
