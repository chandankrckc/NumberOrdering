using NumberOrdering.Data;
using NumberOrdering.Models;
using NumberOrdering.NumberData;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberOrderingUnitTests
{
    class IDataServiceFake : IDataService
    {
        public Numbers num = new Numbers()
        {
            arList = new List<int> { 43, 21, 36 }
        };

        public string GetTextFile()
        {
            return num.ToString();
        }

        public Numbers PostArrayData(Numbers num)
        {
            int ids = num.arList.Count;
            num.arList = MergeSort.SortMerge(num.arList, 0, ids - 1);
            return num;
        }
    }
}
