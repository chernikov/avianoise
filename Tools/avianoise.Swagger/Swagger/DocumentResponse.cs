using System.Collections.Generic;

namespace avianoise.Swagger.Swagger
{
    public class DocumentResponse
    {
        public string Description { get; set; }

        public Dictionary<string, DocumentContent> Content { get; set; }
    }
}
