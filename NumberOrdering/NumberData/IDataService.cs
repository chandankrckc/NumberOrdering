using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NumberOrdering.Models;

namespace NumberOrdering.Data
{
    public interface IDataService
    {
        public Numbers PostArrayData(Numbers num);

        public string GetTextFile();

    }
}
