using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarsectorTranslator.Models
{
    public class CSVTranslation : Translation
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }
}