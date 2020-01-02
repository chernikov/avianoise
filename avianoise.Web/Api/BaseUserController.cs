using avianoise.BL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Api
{
    public class BaseUserController : BaseController
    {
        protected IUserBL userBL;

        private readonly Lazy<User> currentUser;

        public User CurrentUser => currentUser.Value;

        protected int? CurrentUserId
        {
            get
            {
                var idStr = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid)?.Value;//[ClaimTypes.Sid];
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    return null;
                }
                var id = Int32.Parse(idStr);
                return id;
            }
        }

        public BaseUserController(IUserBL userBL) : base()
        {
            this.userBL = userBL;

            currentUser = new Lazy<User>(() =>
            {
                if (CurrentUserId == null)
                {
                    return null;
                }
                return userBL.GetById(CurrentUserId.Value);
            });
        }
    }
}
