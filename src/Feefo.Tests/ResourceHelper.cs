using System.IO;
using System.Reflection;

namespace Feefo.Tests
{
    public class ResourceHelper
    {
        public string GetStringResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();

                    return result;
                }
            }
        }
    }
}