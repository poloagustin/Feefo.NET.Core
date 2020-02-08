using System;
using System.IO;

namespace Feefo.Tests
{
    public class ResourceHelper
    {
        public string GetStringResource(string resourceName)
        {
            var path = Path.IsPathRooted(resourceName) ? resourceName : Path.GetRelativePath(Directory.GetCurrentDirectory(), resourceName);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(resourceName);

            return fileData;
        }
    }
}