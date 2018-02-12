using AutoMapper;
using Market.Data;
using Market.Data.Models;
using Market.Services.Implementation;
using Market.Services.Model;
using Market.Web.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Tests.Services
{
    [TestFixture]
    public class PostServiceTests
    {
        [SetUp]
        public void Init()
        {
            AutoMapper.Mapper.Reset();
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public ApplicationDbContext DbInit()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new ApplicationDbContext(dbOptions);

            return db;
        }

        [Test]
        public async Task AddsPostSuccessfully()
        {
            // Arrange
            var db = this.DbInit();

            var firstPost = new Post { Id = 1, Title = "First" };
            var secondPost = new Post { Id = 2, Title = "Second" };
            var thirdPost = new Post { Id = 3, Title = "Third" };

            db.AddRange(firstPost, secondPost, thirdPost);

            await db.SaveChangesAsync();

            var postService = new PostService(db);

            // Act
            var result = await postService.GetAllPostsAsync();

            // Assert
            Assert.IsTrue((result as List<ProductListingServiceModel>).Count == 3);
        }

        [Test]
        public async Task DeletesPostSuccessfully()
        {
            //Arrange
            var db = this.DbInit();
            var postService = new PostService(db);

            var post = new Post { Id = 1, Title = "First" };

            await db.AddAsync(post);
            await db.SaveChangesAsync();

            //Act
            await postService.DeletePost(1);

            //Assert
            var result = await postService.GetAllPostsAsync();

            Assert.IsTrue((result as List<ProductListingServiceModel>).Count == 0);
        }

        [Test]
        public async Task GetsPostById()
        {
            //Arrange
            var db = this.DbInit();
            var postService = new PostService(db);

            //Act
            await db.AddAsync(new Post { Id = 1, Title = "First" });
            var post = postService.GetPostById(1);

            //Assert
            Assert.IsTrue(post.Result.Id == 1 && post.Result.Title == "First");
        }

        //[Test]
        //public async Task GetsPostByTitle()
        //{
        //    //Arange
        //    var db = this.DbInit();
        //    var postService = new PostService(db);

        //    //Act
        //    await db.AddAsync(new Post { Id = 1, Title = "GotByTitle" });
        //    var post = postService.GetPostByTitle("GotByTitle");

        //    //Assert
        //    Assert.IsTrue(await db.Posts.AnyAsync());  
        //}

        [Test]
        public async Task GetsPostId()
        {
            //Arrange
            var db = this.DbInit();
            var postService = new PostService(db);

            //Act
            await db.AddAsync(new Post { Id = 1, Title = "First" });
            var postId = postService.GetPostId("First");

            //Assert
            Assert.IsTrue(postId == 1);
        }

        [Test]
        public async Task GetsAllPostsAsync()
        {
            //Arrange
            var db = this.DbInit();
            var postService = new PostService(db);

            //Act
            await db.AddAsync(new Post { Id = 1, Title = "First" });
            var allPosts = await postService.GetAllPostsAsync();

            //Assert
            Assert.IsTrue((allPosts as List<ProductListingServiceModel>).Count == 0);
        }

        [Test]
        public async Task GetsAllUsersPostsAsync()
        {
            //Arrange
            var db = this.DbInit();
            var postService = new PostService(db);
            var user = new ApplicationUser()
            {
                UserName = "Asd",
                Email = "asd@abv.bg",
                Country = "Romania",
            };

            //Act
            await db.AddAsync(user);

            //Assert
            Assert.IsTrue((postService.GetAllUsersPostsAsync(user.UserName).Result as List<ProductListingServiceModel>).Count == 0);
        }

        //[Test]
        //public async Task SearchesPost()
        //{
        //    //Arrange
        //    var db = this.DbInit();
        //    var postService = new PostService(db);

        //    //Act
        //    await db.Posts.AddAsync(new Post { Id = 1, Title = "First" });
        //    var posts = await postService.SearchAsync("First");

        //    //Assert
        //    Assert.IsTrue((posts as List<ProductListingServiceModel>).Count == 1);
        //}
    }
}
