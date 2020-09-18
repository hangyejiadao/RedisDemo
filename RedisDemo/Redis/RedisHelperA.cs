using CSRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redis
{
    public class RedisHelperA
    {

        public static CSRedisClient GetCSRedisInstance()
        { 
            var csredis = new CSRedisClient("127.0.0.1:6379");
            RedisHelper.Initialization(csredis);
            return csredis;
        }


    }
}
