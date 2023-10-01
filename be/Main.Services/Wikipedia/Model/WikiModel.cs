using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Services.Wikipedia.Model
{
    using System.Collections.Generic;

    public class Thumbnail
    {
        public string source { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Pages
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string pageimage { get; set; }
        public string extract { get; set; }
    }

    public class Query
    {
        public Dictionary<string, Pages> pages { get; set; }
    }

    public class Root
    {
        public string batchcomplete { get; set; }
        public Continue @continue { get; set; }
        public Query query { get; set; }
        public Limits limits { get; set; }
    }

    public class Continue
    {
        public int gsroffset { get; set; }
        public string @continue { get; set; }
    }

    public class Limits
    {
        public int extracts { get; set; }
    }
}
