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
        static ChipreDataSetTableAdapters.SelectQueryTableAdapter SQTA = new ChipreDataSetTableAdapters.SelectQueryTableAdapter();
        static ChipreDataSetTableAdapters.RatesLastValueTableAdapter RLVTA = new ChipreDataSetTableAdapters.RatesLastValueTableAdapter();

        public static List<string> SymbolList()
        {
            var response = RSTA.GetDataSymbols();
            return response.AsEnumerable().Select(o => o.rateName).ToList();
        }

        public static List<double[]> GetAllTicksRangeCompressed(DateTime startTime, DateTime endTime)
        {
            var symbolList = SymbolList();
            Dictionary<string, double> lastValues = new Dictionary<string, double>();

            foreach (var symbol in symbolList)
            {
                lastValues.Add(symbol, 0);
            }

            var response = SQTA.GetData(startTime, endTime);

            foreach (var date in response)
            {
                if (date.rateValue == 0)
                {
                    if (lastValues[date.rateName] == 0)
                    {
                        date.rateValue = GetLastValue(date.rateName, date.rateDate);
                        lastValues[date.rateName] = date.rateValue;
                    }
                    else
                    {
                        date.rateValue = lastValues[date.rateName];
                    }
                }
                else
                {
                    lastValues[date.rateName] = date.rateValue;
                }
            }

            return null;
        }

        private static double GetLastValue(string rateName, DateTime rateDate)
        {
            var response = RLVTA.GetData(rateName, rateDate);

            if (response.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return response.AsEnumerable().Select(o => o.rateValue).First();
            }
        }
    }
}
