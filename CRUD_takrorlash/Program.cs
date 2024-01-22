using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CRUD_takrorlash
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Bu post  uchun:
                HttpResponseMessage response = await client.GetAsync("/posts");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(responseBody);
                    Console.WriteLine("Posts:");
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"Posts\n- Title: {post.Title}\n- Body: {post.Body}");
                    }
                }
                else
                {
                    Console.WriteLine($"Postlarni olib bo'lmadi: {response.StatusCode}");
                }

                // Bu comment uchun:
                HttpResponseMessage responses = await client.GetAsync("/comments");
                if (responses.IsSuccessStatusCode)
                {
                    string responsesBody = await responses.Content.ReadAsStringAsync();
                    List<Comments> comments = JsonConvert.DeserializeObject<List<Comments>>(responsesBody);
                    Console.WriteLine("Comments:");
                    foreach (var comment in comments)
                    {
                        Console.WriteLine($"Comment:\n- Name: {comment.name}\n-vEmail: {comment.email}");
                    }
                }
                else
                {
                    Console.WriteLine($"Commentlarni olib bo'lmadi: {responses.StatusCode}");
                }
                // Bu albums uchun:
                HttpResponseMessage responses2 = await client.GetAsync("/albums");
                if (responses2.IsSuccessStatusCode)
                {
                    string responses2Body = await responses2.Content.ReadAsStringAsync();
                    List<Albums> albums = JsonConvert.DeserializeObject<List<Albums>>(responses2Body);
                    Console.WriteLine("albums:");
                    foreach (var album in albums)
                    {
                        Console.WriteLine($"Album:- Title: {album.title}");
                    }
                }
                else
                {
                    Console.WriteLine($"Albumslarni olib bo'lmadi: {responses2.StatusCode}");
                }
                // Bu photos uchun:
                HttpResponseMessage responses3 = await client.GetAsync("/photos");
                if (responses3.IsSuccessStatusCode)
                {
                    string responses3Body = await responses3.Content.ReadAsStringAsync();
                    List<Photos> photos = JsonConvert.DeserializeObject<List<Photos>>(responses3Body);
                    Console.WriteLine("Photos:");
                    foreach (var photo in photos)
                    {
                        Console.WriteLine($"Photo:\n- Title: {photo.title}\n- Url: {photo.url}\n- thumbnailUrl: {photo.thumbnailUrl}");
                    }
                }
                else
                {
                    Console.WriteLine($"Photoslarni olib bo'lmadi: {responses3.StatusCode}");
                }
                // Bu todos uchun:
                HttpResponseMessage responses4 = await client.GetAsync("/todos");
                if (responses4.IsSuccessStatusCode)
                {
                    string responses4Body = await responses4.Content.ReadAsStringAsync();
                    List<Todos> todos = JsonConvert.DeserializeObject<List<Todos>>(responses4Body);
                    Console.WriteLine("Todos:");
                    foreach (var todo in todos)
                    {
                        Console.WriteLine($"Todo:\n- Title: {todo.title}\n- complected: {todo.completed}");
                    }
                }
                else
                {
                    Console.WriteLine($"Todoslarni olib bo'lmadi: {responses4.StatusCode}");
                }
                // Bu users uchun:
                HttpResponseMessage responses5 = await client.GetAsync("/users");
                if (responses5.IsSuccessStatusCode)
                {
                    string responses5Body = await responses5.Content.ReadAsStringAsync();
                    List<Users> users = JsonConvert.DeserializeObject<List<Users>>(responses5Body);
                    Console.WriteLine("Users:");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"User:\n- Name: {user.name}\n- username: {user.username}\n- email: {user.email}\n- adress:\n\tstreet:{user.address.street}\n" +
                            $"\tsuite:{user.address.suite}\n\tcity:{user.address.city}\n -phone: {user.phone}\n -website: {user.website}\n" +
                            $" -company:\n\tname:{user.company.name}\n\tcatchPhrase: {user.company.catchPhrase}\n\tbs:{user.company.bs}");
                    }
                }
                else
                {
                    Console.WriteLine($"Userslarni olib bo'lmadi: {responses4.StatusCode}");
                }
            }
        }
    }

    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public class Comments
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }

    public class Albums
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
    }
    public class Photos
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
    public class Todos
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }



}
