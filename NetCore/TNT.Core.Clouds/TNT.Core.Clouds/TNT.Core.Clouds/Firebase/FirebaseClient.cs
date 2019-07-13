using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.Core.Http;

namespace TNT.Core.Clouds.Firebase
{
    public class FirebaseClient
    {
        private readonly HttpClient _client;
        private readonly string _senderId;
        public FirebaseClient(
            string senderId,
            string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + apiKey);
            _senderId = senderId;
        }

        public async Task<HttpResponseMessage> CreateDeviceGroup(
            string name,
            IEnumerable<string> registrationIds)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/notification")
            {
                Content = new JsonContent(new
                {
                    operation = "create",
                    notification_key_name = name,
                    registration_ids = registrationIds
                })
            };
            req.Headers.TryAddWithoutValidation("project_id", _senderId);
            var resp = await _client.SendAsync(req);
            return resp;
        }

        public async Task<HttpResponseMessage> AddToDeviceGroup(string name,
            string key, IEnumerable<string> registrationIds)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/notification")
            {
                Content = new JsonContent(new
                {
                    operation = "add",
                    notification_key_name = name,
                    notification_key = key,
                    registration_ids = registrationIds
                })
            };
            req.Headers.TryAddWithoutValidation("project_id", _senderId);
            var resp = await _client.SendAsync(req);
            return resp;
        }

        public async Task<HttpResponseMessage> RemoveFromDeviceGroup(string name,
            string key, IEnumerable<string> registrationIds)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/notification")
            {
                Content = new JsonContent(new
                {
                    operation = "remove",
                    notification_key_name = name,
                    notification_key = key,
                    registration_ids = registrationIds
                })
            };
            req.Headers.TryAddWithoutValidation("project_id", _senderId);
            var resp = await _client.SendAsync(req);
            return resp;
        }

        public async Task<HttpResponseMessage> GetNotificationKey(string keyName)
        {
            keyName = HttpUtility.UrlEncode(keyName);
            var resp = await _client.GetAsync(
                $"https://fcm.googleapis.com/fcm/notification?notification_key_name={keyName}");
            return resp;
        }

        public async Task<HttpResponseMessage> SendToDeviceGroup(SendToDeviceGroupRequest req)
        {
            var resp = await _client.PostAsync("https://fcm.googleapis.com/fcm/send",
                new JsonContent(req));
            return resp;
        }

    }
}
