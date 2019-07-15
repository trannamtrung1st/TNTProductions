using System;
using System.Collections.Generic;
using TNT.Core.Clouds.Firebase;

namespace TNT.Core.Clouds
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FirebaseClient(
                "731298291546",
                "AIzaSyDP7am_OqJdKgGRLTtr4JT9AMJtGcazMRE");

            var test = client.GetNotificationKey("test_group").Result;
            var testResp = test.Content.ReadAsStringAsync();
        }
    }
}
