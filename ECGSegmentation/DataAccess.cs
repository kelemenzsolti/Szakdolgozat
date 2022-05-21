using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECGSegmentation
{
    public class DataAccess
    {
        public List<string> LoadDatas(String path,int dataNumber)
        {
            String line;
            int counter = 0;
            List<string> datas = new List<string>();
            StreamReader sr = new StreamReader(path);
            while (counter != dataNumber+1)
            {
                line = sr.ReadLine();
                if(line == null)
                {
                    break;
                }
                datas.Add(line);
                counter++;
            }
            sr.Close();
            return datas;
        }
    }
}
