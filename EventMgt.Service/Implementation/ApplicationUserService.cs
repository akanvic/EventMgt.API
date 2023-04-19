using EventMgt.Core.APIResponse;
using EventMgt.Core.Config;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
using EventMgt.Repo.Data.GenericRepository.Interface;
using EventMgt.Service.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Implementation
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<APIConfig> _apiConfig;
        public ApplicationUserService(IUnitOfWork unitOfWork, 
            IHttpClientFactory httpClientFactory, IOptions<APIConfig> apiConfig)
        {
            _httpClientFactory = httpClientFactory; 
            _unitOfWork = unitOfWork;
            _apiConfig = apiConfig;
        }

        public async Task<ResponseModel> AddUser(ApplicationUser applicationUser)
        {            
            var response = await _unitOfWork.UsersRepository.CreateAsync(applicationUser);

            var ret = await _unitOfWork.Save();
            
            if(ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error creating application user", Data = ret };
            
            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Application user created successfully", Data = response };
        }

        public async Task<List<UserDataResponse>> GetAllUsers()
        {
            var url = $"{_apiConfig.Value.APIURL}users";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var serviceResponse = JsonConvert.DeserializeObject<List<UserDataResponse>>(responseContent);

            if (response.IsSuccessStatusCode)
                return serviceResponse;

            return serviceResponse;
        }

        public async Task<UserDataResponse> GetUserInfo(int id)
        {
            //var appuser = ApplicationUser.AddUser(applicationUser);
            var url = $"{_apiConfig.Value.APIURL}users/{id}";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var serviceResponse = JsonConvert.DeserializeObject<UserDataResponse>(responseContent);

            
            if (response.IsSuccessStatusCode)
                return serviceResponse;

            return serviceResponse;
        }
    }
}
