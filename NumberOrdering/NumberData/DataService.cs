using NumberOrdering.Models;
using System.IO;
using System.Linq;
using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using NumberOrdering.NumberData;

namespace NumberOrdering.Data
{
    public class DataService : IDataService
    {
        //Fetching the latest saved file
        public string GetTextFile()
        {
            string folder = @"D:\temp\";
            string latestfile = "";
            DateTime lastUpdated = DateTime.MinValue;

            var files = new DirectoryInfo(folder).GetFiles("*.*");

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastUpdated)
                {
                    lastUpdated = file.LastWriteTime;

                    latestfile = file.Name;
                }
            }
            string txt = " ";
            try
            {
                txt = System.IO.File.ReadAllText(folder + latestfile);
            }
            catch(Exception e)
            {
                return e.Message + "Folder is empty. Please POST data first";
            }
            
            return txt;
        }

        //Saving text file with name int.txt where int is an integer value
        public Numbers PostArrayData(Numbers num)
        {
            int ids = num.arList.Count;
            num.arList = MergeSort.SortMerge(num.arList, 0, ids-1);

            //By default saving data in D drive and temp folder
            string folder = @"D:\temp\";
            int latestfile = 0;
            DateTime lastUpdated = DateTime.MinValue;
            var files = new DirectoryInfo(folder).GetFiles("*.*");

            foreach(FileInfo file in files)
            {
                if(file.LastWriteTime > lastUpdated)
                {
                    lastUpdated = file.LastWriteTime;

                    int.TryParse(file.Name.Substring(0 , file.Name.IndexOf(".") ) , out latestfile);
                }
            }

            string path = folder + latestfile.ToString() + ".txt";
            if (System.IO.File.Exists(path))
            {
                path =folder+(latestfile +1).ToString() + ".txt";
               
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    for (int i = 0; i < ids; i++)
                    {
                        sw.Write(num.arList[i] + " ");

                    }

                }
            }
            else 
            {
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    for (int i = 0; i < ids; i++)
                    {
                        sw.Write(num.arList[i] + " ");

                    }
                }
            }
            return num;
        }
    }
}
