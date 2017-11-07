using ModPanel.App.Data.Models;
using ModPanel.App.Models;
using System;
using System.Collections.Generic;

namespace ModPanel.App.Services.Contracts
{
    public interface IPostService
    {
        void Create(int userId, string title, string content, string email, DateTime CreatedOn);

        void Update(PostModel model);

        IEnumerable<Post> All();
    }
}
