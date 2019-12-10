using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using avianoise.Swagger.Swagger;

namespace avianoise.Swagger.Output
{
    public class OutputServiceActionParameter
    {
        public string Name { get; set; }

        public bool InPath { get; set; }

        public bool Required { get; set; }

        public BaseOutputClass Class { get; set; }
    }
}
