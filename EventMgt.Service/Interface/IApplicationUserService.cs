using EventMgt.Core.APIResponse;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Interface
{
    public interface IApplicationUserService
    {
        Task<ResponseModel> AddUser(ApplicationUser applicationUser);
        Task<List<UserDataResponse>> GetAllUsers();
        Task<UserDataResponse> GetUserInfo(int id);
    }
}
