using EventMgt.Core.Models;
using EventMgt.Repo.Data.GenericRepository.Implementation;
using EventMgt.Repo.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.Repository.Implementation
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly EventMgtContext _eventMgtContext;
        public UserRepository(EventMgtContext eventMgtContext) : base(eventMgtContext)
        {
            _eventMgtContext = eventMgtContext;
        }
    }
}
