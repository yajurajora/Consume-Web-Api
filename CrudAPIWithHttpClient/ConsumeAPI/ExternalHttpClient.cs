using CrudAPIWithHttpClient.ConsumeAPI;
using CrudAPIWithHttpClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CrudAPIWithHttpClient.ConsumeAPI
{
    public class ExternalHttpClient : IExternalHttpClient
    {
        public List<Student> GetExternalAsync(List<Student> data, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(url).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<Student>>(stringData);
                return data;
            }
        }
        public Student PostExternalAsync(Student student, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string stringData = JsonConvert.SerializeObject(student);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, contentData).Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return student;
            }
        }
        public Student PutExternalAsyncGet(int id,string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(url + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Student data = JsonConvert.DeserializeObject<Student>(stringData);
                return data;
            }
        }
        public Student PutExternalAsync(Student student, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string stringData = JsonConvert.SerializeObject(student);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url + student.StudentId, contentData).Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return student;
            }
        }
        public Student DeleteExternalAsync(Student student, string url,int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.DeleteAsync(url + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<Student>(stringData);
                return student;
            }
        }
    }
}
