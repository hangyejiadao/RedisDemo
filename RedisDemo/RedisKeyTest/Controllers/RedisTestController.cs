using Microsoft.AspNetCore.Mvc;
using Redis;
using System;
using System.Threading.Tasks;

namespace RedisKeyTest.Controllers
{
    [ApiController]
    [Route("RedisTest")]
    public class RedisTestController : Controller
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory + "key.txt";
        private static string mkey = System.IO.File.ReadAllText(path: path);
        private static bool IsExists = false;
        public RedisTestController()
        {
            if (!IsExists)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "key.txt";
                var key = System.IO.File.ReadAllText(path);
                RedisHelperA.GetCSRedisInstance().Set("b", key);
                RedisHelperA.GetCSRedisInstance().Set(key, "123");
                RedisHelperA.GetCSRedisInstance().Set("a", "a");
                IsExists = true;
            }
          
        }

        [Route("GetValue")]
        [HttpGet]
        public async Task<IActionResult> GetValue()
        {
            var value = await RedisHelperA.GetCSRedisInstance().GetAsync(mkey);

            Console.WriteLine(value);
            
            return Json(new { value });
        }


        [Route("GetValueA")]
        [HttpGet]
        public async Task<IActionResult> GetValueA()
        {
            var value = await RedisHelperA.GetCSRedisInstance().GetAsync("a");
            Console.WriteLine(value);
            return Json(new { value });
        }

        [Route("GetValueB")]
        [HttpGet]
        public async Task<IActionResult> GetValueB()
        {
            var value = await RedisHelperA.GetCSRedisInstance().GetAsync("b");
            Console.WriteLine(value);
            return Json(new { value });
        }
    }
}
