using FluentAssertions;
using Market.Data;
using Market.Data.Models;
using Market.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using Market.Web.Infrastructure.Mapper;

namespace Market.Tests.Services
{
    public class PostServiceTests
    {
      public PostServiceTests()
      {
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
         
        [Fact]
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
          result.Should().HaveCount(3);
        }
     
      [Fact]
        public async Task DeletesPostSuccessfully()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            var db = new ApplicationDbContext(dbOptions);

            var postService = new PostService(db);

            var post = new Post { Id = 1, Title = "First" };

            await db.AddAsync(post);
            await db.SaveChangesAsync();

            //Act
            await postService.DeletePost(1);

            //Assert
            var result = await postService.GetAllPostsAsync();

            result.Should().HaveCount(0);
        }
    }
}
