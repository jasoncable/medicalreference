using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Jaxosoft.TestData;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace Jaxosoft.TestData
{
    public static class Startup
    {
        public static JsonDrugs LoadData()
        {
            string baseDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string zipOnDisk = Path.Combine(baseDir, "drugs.zip");
            string jsonOnDisk = Path.Combine(baseDir, "drugs.json");
            byte[] buffer = new byte[64 * 1024];
            using Stream stream = Assembly.GetAssembly(typeof(Startup)).GetManifestResourceStream("Jaxosoft.TestData.drugs.zip");
            using ZipInputStream zipStream = new ZipInputStream(stream);
            using FileStream fileStream = new FileStream(jsonOnDisk, FileMode.Create, FileAccess.ReadWrite);
            ZipEntry entry = zipStream.GetNextEntry();
            //int currentSize = zipStream.Read(buffer, 0, buffer.Length);
            //while (currentSize > 0)
            //    fileStream.Write(buffer);
            StreamUtils.Copy(zipStream, fileStream, buffer);
            fileStream.Flush();
            zipStream.Close();
            fileStream.Close();
            stream.Close();
            buffer = null;

            using StreamReader sr = new StreamReader(jsonOnDisk);
            JsonSerializer jsz = new JsonSerializer();
            JsonDrugs drugs = jsz.Deserialize<JsonDrugs>(new JsonTextReader(sr));
            sr.Close();

            return drugs;
        }
    }
}
