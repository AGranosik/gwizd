using Main.Services.Wikipedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Services.Wikipedia.Interfaces
{
    public interface IWikipediaService
    {
        public Task<WikiViewModel> Search(string searchString);
    }
}
