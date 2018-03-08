using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoConnection
{
    public static class MongoConnection
    {
        private static MongoClient Client;
        private static List<ticks> fullQuery;
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static bool Connect()
        {
            Client = new MongoClient("mongodb://localhost:27017");
            var db = Client.GetDatabase("chipre");
            var ticks = db.GetCollection<ticks>("ticks");
            fullQuery = ticks.AsQueryable<ticks>().ToList();
            return true;
        }

        public static List<string> SymbolList()
        {
            var result = fullQuery.GroupBy(o => o.symbol).Select(p => p.First()).ToList();
            List<string> resultList = new List<string>();
            foreach (ticks tick in result)
            {
                resultList.Add(tick.symbol);
            }
            return resultList;
        }

        public static DateTime GetMinDate()
        {
            var result = fullQuery.Min(o => o.epoch);
            return FromUnixTime(result);
        }

        public static DateTime GetMaxDate()
        {
            var result = fullQuery.Max(o => o.epoch);
            return FromUnixTime(result);
        }

        public static int GetTicksCount()
        {
            return fullQuery.Count();
        }

        private static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }

        public static long calculateSeconds(DateTime date)

        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            TimeSpan result = date.Subtract(dt);
            long seconds = Convert.ToInt32(result.TotalSeconds);

            return seconds;

        }

        public static List<double[]> GetAllTicksRangeCompressed(DateTime startTime, DateTime endTime)
        {
            long startEpoch = calculateSeconds(startTime);
            long endEpoch = calculateSeconds(endTime);
            List<ticks> result = fullQuery.Where(o => o.epoch >= startEpoch && o.epoch < endEpoch).OrderBy(o => o.epoch).ThenBy(o => o.symbol).ToList();

            List<double[]> response = new List<double[]>();

            var epochList = result.GroupBy(o => o.epoch).Select(p => p.First()).ToList();

            foreach (long epoch in epochList.Select(o => o.epoch))
            {
                var values = result.Where(o => o.epoch == epoch).Select(o => o.quote).ToArray();
                response.Add(values);
            }

            return response;
        }

        public static List<long> GetAllTicksEpochsRangeCompressed(DateTime startTime, DateTime endTime)
        {
            long startEpoch = calculateSeconds(startTime);
            long endEpoch = calculateSeconds(endTime);
            List<ticks> result = fullQuery.Where(o => o.epoch >= startEpoch && o.epoch < endEpoch).OrderBy(o => o.epoch).ThenBy(o => o.symbol).ToList();

            List<long> response = new List<long>();

            var epochList = result.GroupBy(o => o.epoch).Select(p => p.First()).ToList();

            foreach (long epoch in epochList.Select(o => o.epoch))
            {
                var values = result.Where(o => o.epoch == epoch).Select(o => o.epoch).First();
                response.Add(values);
            }

            return response;
        }

        public static List<double[]> GetPredictions(List<long> inputTrainSetEpochs, int fowardSeconds, string symbol)
        {
            List<double[]> result = new List<double[]>();
            double actualSymbolValue;
            double forwardSymbolValue;

            foreach (long epoch in inputTrainSetEpochs)
            {
                actualSymbolValue = fullQuery.Where(o => o.epoch == epoch).Select(o => o.quote).First();
                forwardSymbolValue = fullQuery.Where(o => o.epoch <= epoch + fowardSeconds).OrderByDescending(o => o.epoch).Select(o => o.quote).Take(1).First();

                result.Add(new double[] { actualSymbolValue - forwardSymbolValue });
            }

            return result;
        }
    }

    public class ticks
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public long epoch { get; set; }

        public string symbol { get; set; }

        public double quote { get; set; }
    }
}
