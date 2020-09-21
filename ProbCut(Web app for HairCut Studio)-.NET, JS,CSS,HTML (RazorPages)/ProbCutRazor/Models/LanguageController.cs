using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Resources;
using System.Web;
using System.Windows;


namespace ProbCut.Models
{
    public enum SupportedLanguages
    {
        en,
        sr
    }

    public static class LanguageController
    {

        static LanguageController()
        {

        }

        public static string Get(string lang, string page, string resourceKey)
        {
            Dictionary<string, string> resourceFiles = new Dictionary<string, string>();
            SupportedLanguages language;
            if (!Enum.TryParse(lang, out language))
                language = SupportedLanguages.en;

            // getting files into the dictionary resourceFiles
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@".\Resources\");
                FileInfo[] files = dirInfo.GetFiles("*.resx");
                foreach (FileInfo fileInfo in files)
                {
                    if (fileInfo.Name.Contains(language.ToString()))
                    {
                        string key = fileInfo.Name.Remove(fileInfo.Name.Length - 8);
                        string value = @".\Resources\" + fileInfo.Name;

                        resourceFiles.Add(key, value);
                    }
                }
            }
            catch (Exception e)
            {
                resourceFiles = null;
            }

            // getting the value from the selected resource
            string result = null;
            string resourcePath;
            if (resourceFiles.TryGetValue(page, out resourcePath))
            {
                using (ResXResourceReader resxReader = new ResXResourceReader(resourcePath))
                {
                    foreach (DictionaryEntry entry in resxReader)
                    {
                        if (((string)entry.Key).Equals(resourceKey))
                        {
                            result = (string)entry.Value;
                            break;
                        }
                    }
                }
            }
            else
                return null;

            return result;
        }

        public static void WritePricingData(Dictionary<string, string> data)
        {
            using (ResXResourceWriter writer = new ResXResourceWriter(@".\Resources\PricingData.resx"))
            {
                foreach(KeyValuePair<string, string> entry in data)
                {
                    writer.AddResource(entry.Key, entry.Value);
                }
            }
        }

        public static Dictionary<string, string> GetPricingData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (ResXResourceReader reader = new ResXResourceReader(@".\Resources\PricingData.resx"))
            {
                foreach(DictionaryEntry entry in reader)
                {
                    result.Add((string)entry.Key, (string)entry.Value);
                }
            }
            return result;
        }
    }
}
