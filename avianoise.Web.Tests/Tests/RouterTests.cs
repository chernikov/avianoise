using avianoise.Web.Api;
using MyTested.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Tests.Tests
{
    [TestFixture]
    public class RouterTests
    {
        [Test]
        public void PostControllerIsPublishedFalse()
        {
            MyPipeline
            .Configuration()
            .ShouldMap(request => request
                .WithMethod(HttpMethod.Get)
                .WithPath("/api/post")
                .WithQuery("isPublished", "false"))
            .To<PostController>(c => c.Get(false));
        }

        [Test]
        public void PostControllerIsPublishedTrue()
        {
            MyPipeline
            .Configuration()
            .ShouldMap(request => request
                .WithMethod(HttpMethod.Get)
                .WithPath("/api/post")
                .WithQuery("isPublished", "true"))
            .To<PostController>(c => c.Get(true));
        }

        [Test]
        public void PostControllerGetElement()
        {
            MyPipeline
            .Configuration()
            .ShouldMap(request => request
                .WithMethod(HttpMethod.Get)
                .WithPath("/api/post/1"))
            .To<PostController>(c => c.Get(1));
        }
    }
}
