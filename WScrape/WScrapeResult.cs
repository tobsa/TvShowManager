﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WScrape
{
    public class WScrapeResult
    {
        public string Url { get; set; }
        public string Content { get; set; }
        public List<string> Result { get; set; } = new List<string>();
    }
}
