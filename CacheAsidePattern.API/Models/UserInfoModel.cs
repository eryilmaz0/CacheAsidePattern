using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheAsidePattern.API.Models
{
    public class UserInfoModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; } //0-->Man 1-->Woman 2-->Other 
    }
}
