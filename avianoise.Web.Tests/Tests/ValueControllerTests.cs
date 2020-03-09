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
    public class ValueControllerTests
    {
        [Test]
        public void ReturnOkWhenCallingGetAction()
        {
            MyController<ValueController>
                .Instance()
                .Calling(p => p.Get())
                .ShouldReturn()
                .Ok();
        }
    }
}
