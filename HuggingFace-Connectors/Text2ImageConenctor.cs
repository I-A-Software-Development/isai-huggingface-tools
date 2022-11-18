using System;
using Entities.Models;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using AutoMapper;
using SixLabors.ImageSharp;

namespace HuggingFace.Connectors
{
    public class Text2ImageConenctor
    {
        public async Task<Stream> PostText2Image([FromBody] TextDescriptionDto req)
        {
            GeneratedImageDto ret = new GeneratedImageDto();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                Stream responseStream = await PostText2Image(client);
                //ret.Img = Image.Load(responseStream);
                return responseStream;
            }            
        }

        private async Task<Stream> PostText2Image(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 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");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("Cookie", "AWSALB=MqMTmOVi0v2R8Y+rXC1lv/ChVJlFt1+JtkVHsOkyg31gUou8uNQWmUkdIx4dCls+C/i0rIkH9yyrvrc4/b6s07fSukvlg9kAWfV+ObCA0lg6xB4Mp5Rmm3VMbsPd; AWSALBCORS=MqMTmOVi0v2R8Y+rXC1lv/ChVJlFt1+JtkVHsOkyg31gUou8uNQWmUkdIx4dCls+C/i0rIkH9yyrvrc4/b6s07fSukvlg9kAWfV+ObCA0lg6xB4Mp5Rmm3VMbsPd");
            string body = @"{" + "\n" +
            @"	""inputs"": ""Sunset""" + "\n" +
            @"}";
            JsonContent content = JsonContent.Create(body);//new StringContent(body, Encoding.UTF8, "application/json");)        

            var response = await client.PostAsync("https://api-inference.huggingface.co/models/CompVis/stable-diffusion-v1-4",content);
            response.EnsureSuccessStatusCode();

            Stream responseStream = await response.Content.ReadAsStreamAsync();

            return responseStream;
        }
    }
}