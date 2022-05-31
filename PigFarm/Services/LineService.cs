using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PigFarm.Constants;
using PigFarm.Data;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Models;
using PigFarm.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PigFarm.Services
{
      public class LineNotifyConfig
    {
        public string grant_type { get; set; }
        public string code { get; set; }
        public string redirect_uri { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
    /// <summary>訊息</summary>
    public class MessageParams
    {
        /// <summary>令牌</summary>
        public string Token { get; set; }
        /// <summary>文字訊息</summary>
        public string Message { get; set; }
        /// <summary>貼圖包識別碼</summary>
        public string StickerPackageId { get; set; }
        /// <summary>貼圖識別碼</summary>
        public string StickerId { get; set; }
        /// <summary>圖片檔案路徑。限 jpg, png 檔</summary>
        public string FileUri { get; set; }
        /// <summary>圖片檔案名稱</summary>
        public string Filename { get; set; }
    }
    public interface ILineService
    {
        Task SendMessage(MessageParams msg);
        Task SendWithSticker(MessageParams msg);
        Task SendWithPicture(MessageParams msg);
        Task<string> FetchToken(string code);
    }
    public class LineService : ILineService
    {
        private readonly IConfiguration _config;
        private readonly string _notifyUrl;
        private readonly string _tokenUrl;

        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;

        public LineService(IConfiguration config)
        {
            _config = config;
            var lineConfig = _config.GetSection("LineNotifyConfig");
            _notifyUrl = lineConfig.GetValue<string>("notifyUrl");
            _tokenUrl = lineConfig.GetValue<string>("tokenUrl");
            _clientId = lineConfig.GetValue<string>("client_id");
            _clientSecret = lineConfig.GetValue<string>("client_secret");
            _redirectUri = lineConfig.GetValue<string>("redirect_uri");

        }

        public async Task SendMessage(MessageParams msg)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(_notifyUrl)
            };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + msg.Token);

            var form = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("message", msg.Message)
                });

            var response = await client.PostAsync("", form);
            var data = await response.Content.ReadAsStringAsync();
        }

        public async Task SendWithPicture(MessageParams msg)
        {
            using var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 60),
                BaseAddress = new Uri(_notifyUrl)
            };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + msg.Token);

            var form = new MultipartFormDataContent
                {
                    {new StringContent(msg.Message), "message"},
                    {new ByteArrayContent(await new HttpClient().GetByteArrayAsync(msg.FileUri)), "imageFile", msg.Filename}
                };

            await client.PostAsync("", form);

        }

        public async Task SendWithSticker(MessageParams msg)
        {
            using var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 60),
                BaseAddress = new Uri(_notifyUrl)
            };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + msg.Token);
            var form = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("message", msg.Message),
                    new KeyValuePair<string, string>("stickerPackageId", msg.StickerPackageId),
                    new KeyValuePair<string, string>("stickerId", msg.StickerId)
                });
            var response = await client.PostAsync("", form);
            var data = await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FetchToken(string code)
        {
            using var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 60),
                BaseAddress = new Uri(_tokenUrl)
            };

            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("redirect_uri", _redirectUri),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("client_secret", _clientSecret)
                });
            var response = await client.PostAsync("", content);
            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<JObject>(data)["access_token"].ToString();
        }
    }
}