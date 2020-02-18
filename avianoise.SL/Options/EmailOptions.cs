using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL.Options
{
    public class EmailOptions
    {
        public string Server { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Reply { get; set; }

        public string User { get; set; }

        public bool EnableSsl { get; set; }
    }
}
