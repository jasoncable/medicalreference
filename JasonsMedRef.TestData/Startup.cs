using JasonsMedRef.Models.JsonModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Core;
using Newtonsoft.Json;

namespace JasonsMedRef.TestData
{
    public static class Startup
    {
        public static JsonDrugs LoadData()
        {
            string baseDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string zipOnDisk = Path.Combine(baseDir, "drugs.zip");
            string jsonOnDisk = Path.Combine(baseDir, "drugs.json");
            byte[] buffer = new byte[64 * 1024];
            using Stream stream = Assembly.GetAssembly(typeof(Startup)).GetManifestResourceStream("JasonsMedRef.TestData.drugs.zip");
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
