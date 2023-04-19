using EventMgt.Repo.Data;
using EventMgt.Repo.Data.GenericRepository.Interface;
using EventMgt.Repo.Data.Repository.Implementation;
using EventMgt.Repo.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.GenericRepository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventMgtContext _eventMgtContext;
        public UnitOfWork(EventMgtContext eventMgtContext)
        {
            _eventMgtContext = eventMgtContext;
            UsersRepository = new UserRepository(_eventMgtContext);
            EventsRepository = new EventRepository(_eventMgtContext);
            EventParticipantsRepository = new EventParticipantRepository(_eventMgtContext);
            ParticipantInvitationsRepo = new ParticipantInvitationRepo(_eventMgtContext);
        }
        public IUserRepository UsersRepository { get; private set; }
        public IEventRepository EventsRepository { get; private set; }
        public IEventParticipantRepository EventParticipantsRepository { get; private set; }

        public IParticipantInvitationRepo ParticipantInvitationsRepo { get; private set; }

        public void Dispose()
        {
            _eventMgtContext.Dispose();
        }
        public async Task<int> Save()
        {
            return await _eventMgtContext.SaveChangesAsync();
        }
    }
}
