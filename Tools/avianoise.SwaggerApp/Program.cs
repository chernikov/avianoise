using System.IO;
using System.Text;
using avianoise.Swagger;

namespace avianoise.SwaggerApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text;
            using var fileStream = new FileStream(@"data/swagger.json", FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            text = streamReader.ReadToEnd();


            var generator = new Generator(text);

            generator.Parse();

            generator.WriteFiles();
        }
    }
}
