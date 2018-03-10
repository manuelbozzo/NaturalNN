using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnection
{
    public class SqlConnection
    {
        static ChipreDataSetTableAdapters.RatesTableAdapter RTA = new ChipreDataSetTableAdapters.RatesTableAdapter();

        public static List<string> SymbolList()
        {
            var res = RTA.GetDataSymbols();
            return res.AsEnumerable().Select(o => o.rateName).ToList();
        }
    }
}
