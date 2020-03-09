using avianoise.Data;
using avianoise.Web.Api;
using avianoise.Web.Dto;
using avianoise.Web.Tests.InMemory;
using Microsoft.EntityFrameworkCore;
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
    public class PostOrderControllerTests
    {
        [Test]
        public void ReturnSavedOrder()
        {
            MyController<PostController>
              .Instance()
              .Calling(p => p.Get(false))
              .ShouldReturn()
              .Ok(result => result.WithModelOfType<List<PostDto>>()
              .Passing(data =>
              {
                  var isOk = true;

                  isOk &= data[0].Posts.FirstOrDefault(p => p.Id == 2).Order == 1;
                  isOk &= data[0].Posts.FirstOrDefault(p => p.Id == 3).Order == 2;
                  return isOk;
              }));
        }

        [Test]
        public void ReturnOkWhenCallingGetAction()
        {
            List<PostDto> list = null;
            MyController<PostController>
                .Instance()
                .Calling(p => p.Get(false))
                .ShouldReturn()
                .Ok(result => result.WithModelOfType<List<PostDto>>()
                    .Passing(data =>
                    {
                        list = data;
                        return true;
                    }));

            list[0].Posts[0].Order = 2;
            list[0].Posts[1].Order = 1;

            MyController<PostOrderController>.
                Instance()
                .Calling(p => p.Post(list))
                .ShouldReturn()
                .Ok(result => result.WithModelOfType<List<PostDto>>());
        }
    }
}
