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
    public class PostControllerTests
    {
        [Test]
        public void ReturnOkWhenCallingGetAction()
        {
            MyController<PostController>
                .Instance()
                .Calling(p => p.Get(false))
                .ShouldReturn()
                .Ok(result => result.WithModelOfType<List<PostDto>>()
                    .Passing(data => data.Count == 1));
        }

        [Test]
        public void ReturnOkWhenCallingGetPublishedAction()
        {
            MyController<PostController>
                .Instance()
                .Calling(p => p.Get(true))
                .ShouldReturn()
                .Ok(result => result.WithModelOfType<List<PostDto>>()
                    .Passing(data => data.Count == 1));
        }

        [Test]
        public void ReturnOkWhenCallingGetNonPublishedAction()
        {
            MyController<PostController>
                .Instance()
                .Calling(p => p.Get(false))
                .ShouldReturn()
                .Ok(result => result.WithModelOfType<List<PostDto>>()
                    .Passing(data => data.Count == 1));
        }
    }
}
