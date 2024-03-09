using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarsectorTranslator.Models
{
    public class File
    {
        public string Path { get; set; }
        public List<Translation>? Translations { get; set; }
    }
}