using CacheAsidePattern.API.Cache.Interfaces;
using CacheAsidePattern.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheAsidePattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICacheManager _cacheManager;


        public UsersController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetUserInfos()
        {
            var userInfosFromCache = this._cacheManager.GetFromCache<List<UserInfoModel>>("userinfos");

            if (userInfosFromCache == null)
            {
                List<UserInfoModel> userInfos = this.GetUsersFromDatabase();
                this._cacheManager.SetToCache<List<UserInfoModel>>("userinfos", userInfos);
                return Ok(userInfos);
            }

            return Ok(userInfosFromCache);        
        }


        private List<UserInfoModel> GetUsersFromDatabase()
        {
            return new List<UserInfoModel>()
            {
                new UserInfoModel(){UserId = 1, Name = "User 1", LastName = "User 1", Age = 30, Gender = 0},
                new UserInfoModel(){UserId = 2, Name = "User 2", LastName = "User 2", Age = 30, Gender = 1},
                new UserInfoModel(){UserId = 3, Name = "User 3", LastName = "User 3", Age = 30, Gender = 2},
                new UserInfoModel(){UserId = 4, Name = "User 4", LastName = "User 4", Age = 30, Gender = 0},
                new UserInfoModel(){UserId = 5, Name = "User 5", LastName = "User 5", Age = 30, Gender = 1},
                new UserInfoModel(){UserId = 6, Name = "User 6", LastName = "User 6", Age = 30, Gender = 2},
                new UserInfoModel(){UserId = 7, Name = "User 7", LastName = "User 7", Age = 30, Gender = 0},
                new UserInfoModel(){UserId = 8, Name = "User 8", LastName = "User 8", Age = 30, Gender = 1},
                new UserInfoModel(){UserId = 9, Name = "User 9", LastName = "User 9", Age = 30, Gender = 2},
                new UserInfoModel(){UserId = 10, Name = "User 10", LastName = "User 10", Age = 30, Gender = 0},
            };
        }
    }
}
