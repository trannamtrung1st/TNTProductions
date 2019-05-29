using System;
using TNT.Core.WebApi.Social;

namespace TestWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var gg = new Google("58792828120-4sphub998vsn9t5pdh323vbdfl71puut.apps.googleusercontent.com", "DxUV5MXNhk4EVJNOmzLNdAiX");
            var info = gg.Validate("eyJhbGciOiJSUzI1NiIsImtpZCI6IjJjM2ZhYzE2YjczZmM4NDhkNDI2ZDVhMjI1YWM4MmJjMWMwMmFlZmQiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJhY2NvdW50cy5nb29nbGUuY29tIiwiYXpwIjoiNTg3OTI4MjgxMjAtNHNwaHViOTk4dnNuOXQ1cGRoMzIzdmJkZmw3MXB1dXQuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiI1ODc5MjgyODEyMC00c3BodWI5OTh2c245dDVwZGgzMjN2YmRmbDcxcHV1dC5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsInN1YiI6IjEwNzg2MzU2NDYwMTE1MTQxNTIwOCIsImVtYWlsIjoidHJhbm5hbXRydW5nMXN0QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJhdF9oYXNoIjoiYzZHUEpjODJmclNOUm9TN2czTnZlUSIsImlhdCI6MTU1ODI3OTM3NywiZXhwIjoxNTU4MjgyOTc3fQ.tVN4rDQqm47uPKcfug45XGu1DZW9k5K8UyAkdke5kSeY5X25isat_g7kIIpbvqq1E0ZPOoUwsF6EacTv9ZeC8YDTqDlahX8BuxFdBo7ubjG20OC9raqgXHy5Nnyg52r1OVrYnS3-WIT8fTTFN_WMNvZp-U-lyjRunBxHgrSVdkYGYHbkL8WBj3bPVJ5bzA5_bDUpXbPWLwyP-uOfc9r3naPHl7lGjVq5vdmPoA5y0bcJ4TNHBlg_hbbOSkurcONSr1xhSlsAubLoW7qTgjjGlO69KpFv5knWwjuJ0IxgpFa0M6ls2Tz9mhE2WF2B0ypT_EWxe_Z60c9KzcjlJKLZuQ")
                .Result;
        }
    }
}
