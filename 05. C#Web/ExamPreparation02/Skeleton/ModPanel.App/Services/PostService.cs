using ModPanel.App.Data;
using ModPanel.App.Data.Models;
using ModPanel.App.Models;
using ModPanel.App.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ModPanel.App.Services
{
    public class PostService : IPostService
    {
        public IEnumerable<Post> All()
        {
            using (var db = new ModPanelContext())
            {
                return db.Posts
                         .Where(p => p.IsActive)
                         .Select(p =>
                                    new Post
                                    {
                                        Id = p.Id,
                                        UserId = p.UserId,
                                        Title = p.Title,
                                        Content = p.Content,
                                        CreatedOn = p.CreatedOn,
                                        IsActive = true,
                                    })
                                    .ToList();
            }
        }

        public void Update(PostModel model)
        {
            using (var db = new ModPanelContext())
            {              
                var post = db.Posts.First(p => p.Title == model.Title);
                post.Content = model.Content;

                db.SaveChanges();
            }
        }

        public void Create(int userID, string title, string content, string email, DateTime CreatedOn)
        {
            using (var db = new ModPanelContext())
            {
                var post = new Post
                {
                    UserId = userID,
                    Title = title,
                    Content = content,
                    CreatedOn = CreatedOn,
                };

                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
    }
}
