using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesstree
{
    class Program
    {
        public struct AccessData
        {
            public int CountryCode;
            public int ObjectCode;
            public int OwnerCode;
            public int CustCode;
        }
        public class ADComp : Comparer<AccessData>
        {
            public override int Compare(AccessData x, AccessData y)
            {
                if (x.CountryCode - y.CountryCode == 0)
                {
                    if (x.ObjectCode - y.ObjectCode == 0)
                    {
                        if (x.OwnerCode - y.OwnerCode == 0)
                        {
                            return x.CustCode - y.CustCode;
                        }
                        return x.OwnerCode - y.OwnerCode;
                    }
                    return x.ObjectCode - y.ObjectCode;
                }
                return x.CountryCode - y.CountryCode;
            }
        }
        static void Main(string[] args)
        {
            List<AccessData> adl = new List<AccessData>();
            var sw = Stopwatch.StartNew();
            for(var i = 0; i < 10000000; i++)
            {
                adl.Add(new AccessData() { CountryCode = i, ObjectCode = i, OwnerCode = i, CustCode = i });
            }
            Console.WriteLine(string.Format("elapsed - {0}", sw.Elapsed));
            Console.ReadLine();
        }
    }
}
