using CatelogWebAppliction.Models;
using CatelogWebAppliction.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace CatelogWebAppliction.Repositories.Services
{
    public class UserRepository : IUserRepository
    {
        static HttpClient httpClient = new HttpClient();
        private readonly string baseUrl = "https://localhost:7074";
        public Task LoginAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool>  RegisterUserAsync(User user)
        {
            
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                var postTask = await httpClient.PostAsJsonAsync<User>("signup", user);
                return postTask.IsSuccessStatusCode;
            }
        }
    }
}


//using (var client = new HttpClient())
//{
//    client.BaseAddress = new Uri("http://localhost:64189/api/student");

//    //HTTP POST
//    var postTask = client.PostAsJsonAsync<StudentViewModel>("student", student);
//    postTask.Wait();

//    var result = postTask.Result;
//    if (result.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }
//}