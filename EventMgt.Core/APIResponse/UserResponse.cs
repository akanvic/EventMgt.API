using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.APIResponse
{
    public class UserDataResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AddressDataResponse Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyDataResponse Company { get; set; }
    }
    public class AddressDataResponse
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public GeoDataResponse Geo { get; set; }
    }
    public class GeoDataResponse
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
    public class CompanyDataResponse
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
