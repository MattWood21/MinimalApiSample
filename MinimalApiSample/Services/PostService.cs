using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalApiSample.Interfaces;

namespace MinimalApiSample.Services
{
    public class PostService : IRouteableService
    {
        public const string BaseRoute = "/api/post";
        private RandomNumberService _randomNumberService;

        public PostService(RandomNumberService randomNumberService)
        {
            _randomNumberService = randomNumberService;
        }

        public void MapRoutes(WebApplication app)
        {
            app.MapGet(BaseRoute, GetAllPosts)
                .WithName("GetAllPosts");

            app.MapGet(BaseRoute + "/{id}", GetPost)
                .WithName("GetPost");
        }

        private IResult GetAllPosts()
        {
            return Results.Ok(new { Post = "testPost" + _randomNumberService.GetNext() });
        }

        private IResult GetPost(int id)
        {
            return Results.Ok(new { PostId = id });
        }
    }
}
