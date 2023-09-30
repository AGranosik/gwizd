using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Services.Wikipedia.Interfaces
{
    public interface IWikipediaService
    {
        public Task<string> Search(string searchString);
    }
}
