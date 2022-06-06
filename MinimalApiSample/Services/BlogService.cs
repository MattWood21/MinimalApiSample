using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalApiSample.Interfaces;

namespace MinimalApiSample.Services
{
    public class BlogService : IRouteableService
    {
        public const string BaseRoute = "/api/blog";
        private RandomNumberService _randomNumberService;

        public BlogService(RandomNumberService randomNumberService)
        {
            _randomNumberService = randomNumberService;
        }

        public void MapRoutes(WebApplication app)
        {
            app.MapGet(BaseRoute, GetAllBlogs)
                .WithName("GetAllBlogs");
        }

        private IResult GetAllBlogs()
        {
            return Results.Ok(new { Blog = "testBlog" + _randomNumberService.RandomNumber });
        }
    }
}
