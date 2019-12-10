namespace avianoise.Swagger.Swagger
{
    public class DocumentParameter
    {
        public string Name { get; set; }

        public string In { get; set; }

        public bool Required { get; set; }

        public DocumentSchema Schema { get; set; }
    }
}
