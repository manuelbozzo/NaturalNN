using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnection
{
    public class SqlConnection
    {
        static ChipreDataSetTableAdapters.RatesSymbolsTableAdapter RSTA = new ChipreDataSetTableAdapters.RatesSymbolsTableAdapter();
        static ChipreDataSetTableAdapters.RatesByDateTableAdapter RBDTA = new ChipreDataSetTableAdapters.RatesByDateTableAdapter();
        static ChipreDataSetTableAdapters.RatesLastValueTableAdapter RLVTA = new ChipreDataSetTableAdapters.RatesLastValueTableAdapter();

        public static List<string> SymbolList()
        {
            var response = RSTA.GetDataSymbols();
            return response.AsEnumerable().Select(o => o.rateName).ToList();
        }

        public static List<double[]> GetAllTicksRangeCompressed(DateTime startTime, DateTime endTime)
        {
            var symbolList = SymbolList();
            Dictionary<string, double?> lastValues = new Dictionary<string, double?>();

            foreach (var symbol in symbolList)
            {
                lastValues.Add(symbol, null);
            }

            var response = RBDTA.GetDataBySP(startTime, endTime);

            foreach (var date in response)
            {
                if (date.rateValue == null)
                {
                    if (lastValues[date.rateName] == null)
                    {
                        date.rateValue = GetLastValue(date.rateName, date.rateDate);
                    }
                    else
                    {
                        date.rateValue = (double)lastValues[date.rateName];
                    }
                }
            }

            return null;
        }

        private static double GetLastValue(string rateName, DateTime rateDate)
        {
            throw new NotImplementedException();
        }
    }
}
