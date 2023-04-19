using EventMgt.Core.Models;
using EventMgt.Repo.Data.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.Repository.Interface
{
    public interface IUserRepository: IGenericRepository<ApplicationUser>
    {

    }
}
