using System;
using System.Collections.Generic;

namespace SocialNetworkSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Аліса", "alice@example.com", "@alice");
            User user2 = new User("Боб", "bob@example.com", "@bob");

            // Створення постів
            user1.CreatePost("Перший пост Аліси");
            user1.CreatePost("Другий пост Аліси");
            user1.CreatePost("Третій пост Аліси");
            user1.CreatePost("Четвертий пост Аліси");
            user1.CreatePost("П'ятий пост Аліси");
            user1.CreatePost("Шостий пост Аліси");

            user2.CreatePost("Перший пост Боба");
            user2.CreatePost("Другий пост Боба");

            Console.WriteLine("Останні 5 постів Аліси:");
            user1.GetLastPosts(5);

            Console.WriteLine("\nОстанні 5 постів Боба:");
            user2.GetLastPosts(5);

            Console.WriteLine("\nБоб ставить лайк до посту Аліси:");
            user2.LikePost(user1.Posts[0]);

            Console.WriteLine("\nБоб коментує пост Аліси:");
            user2.CommentOnPost(user1.Posts[0], "Чудовий пост!");

            Console.WriteLine("\nАліса видаляє свій пост:");
            user1.DeletePost(user1.Posts[0]);

            Console.WriteLine("\nОстанні 5 постів Аліси після видалення:");
            user1.GetLastPosts(5);
        }
    }

    class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Nickname { get; private set; }
        public List<Post> Posts { get; private set; }

        public User(string name, string email, string nickname)
        {
            Name = name;
            Email = email;
            Nickname = nickname;
            Posts = new List<Post>();
        }

        public void CreatePost(string content)
        {
            Posts.Add(new Post(content));
            Console.WriteLine($"{Name} створив пост: {content}");
        }

        public void DeletePost(Post post)
        {
            Posts.Remove(post);
            Console.WriteLine($"{Name} видалив пост: {post.Content}");
        }

        public void LikePost(Post post)
        {
            post.Likes++;
            Console.WriteLine($"{Nickname} поставив лайк до посту: {post.Content}");
        }

        public void CommentOnPost(Post post, string comment)
        {
            post.Comments.Add(comment);
            Console.WriteLine($"{Nickname} коментує пост: {post.Content} - \"{comment}\"");
        }

        public void GetLastPosts(int count)
        {
            for (int i = Math.Max(0, Posts.Count - count); i < Posts.Count; i++)
            {
                Posts[i].DisplayPost();
            }
        }
    }

    class Post
    {
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int Likes { get; set; }
        public List<string> Comments { get; private set; }

        public Post(string content)
        {
            Content = content;
            CreatedAt = DateTime.Now;
            Likes = 0;
            Comments = new List<string>();
        }

        public void DisplayPost()
        {
            Console.WriteLine($"Дата: {CreatedAt}, Пост: {Content}, Лайки: {Likes}, Коментарі: {string.Join(", ", Comments)}");
        }
    }
}

