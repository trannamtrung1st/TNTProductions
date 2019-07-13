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
                "s",
                "s");

            var test = client.CreateDeviceGroup("test_group", new List<string>()
            {
                "TNT"
            }).Result;
            var testResp = test.Content.ReadAsStringAsync();
        }
    }
}
