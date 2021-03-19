using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshToken.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndTime { get; set; }
        public DateTime RefreshTokenEndDate { get; internal set; }
    }
}
