using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StarsectorTranslator.Models;

namespace StarsectorTranslator
{
    public static class Scanner
    {
        public static List<Models.File> ScanGameFolder(string path)
        {
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            var scvFiles = files.Where(x => x.EndsWith(".csv"));
            var jsonFiles = files.Where(x => x.EndsWith(".json"));
            var variantFiles = files.Where(x => x.EndsWith(".variant"));
            var javaFiles = files.Where(x => x.EndsWith(".java"));

            var result = new List<Models.File>();
            result.AddRange(scvFiles.Select(x => ProcessSCVFile(x)));

            return result;
        }

        public static Models.File ProcessSCVFile(string file)
        {
            var reader = new StreamReader(file);

            var headers = reader.ReadLine().Split(",");
            var cells = reader
                .ReadToEnd()
                .Split("\r\n")
                .Where(x => !string.IsNullOrEmpty(x) && !x.StartsWith("#"))
                .Select(x => Regex.Split(x, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .ToArray();

            reader.Close();

            var translations = headers
                .Select((x, i) => (item: x, index: i))
                .Where(x => Settings.Instance.TranslationFields.Contains(x.item))
                .SelectMany(x =>
                    cells
                        .Where(y => y.Length == headers.Length && !string.IsNullOrEmpty(y[x.index]))
                        .Select(
                            (y, i) =>
                                new CSVTranslation()
                                {
                                    Original = y[x.index],
                                    Translated = y[x.index],
                                    Column = x.index,
                                    Row = i
                                }
                        )
                )
                .ToList<Translation>();

            var result = new Models.File { Path = file, Translations = translations };

            return result;
        }
    }
}
