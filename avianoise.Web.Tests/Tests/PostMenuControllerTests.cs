using avianoise.Web.Api;
using avianoise.Web.Dto;
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
    public class PostMenuControllerTests
    {
        [Test]
        public void ReturnOkWhenCallingGetAction()
        {
            MyPipeline
            .Configuration()
            .ShouldMap(request => request
                .WithMethod(HttpMethod.Get)
                .WithPath("/api/post-menu"))
            .To<PostMenuController>(c => c.Get())
            .Which(controller => controller
                .ShouldReturn()
                .Ok(result => result.WithModelOfType<List<PostDto>>()
                        .Passing(data => data.Count == 1)));

        }
    }
}
