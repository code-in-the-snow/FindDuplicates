using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        //class RecordCache
        //{
        //    private Dictionary<int, Record> cachedRecords =
        //        new Dictionary<int, Record>();

        //    public Record GetRecord(int recordId)
        //    {
        //        Record result;
        //        if (cachedRecords.TryGetValue(recordId, out result))
        //        {
        //            // Found item in cache. Check if it is stale
        //            if (IsStale(result))
        //            {
        //                result = null;
        //            }
        //        }
        //        if (result == null)
        //        {
        //            result = LoadRecord(recordId);
        //            // Add newly loaded record to cache
        //            cachedRecords[recordId] = result;
        //        }

        //        DiscardAnyOldCacheEntries();
        //        return result;
        //    }

        //    private Record LoadRecord(int recordId)
        //    {
        //        // code to load record
        //    }

        //    private bool IsStale(Record result)
        //    {
        //        // code to work out whether record is stale
        //    }

        //    private void DiscardAnyOldCacheEntries()
        //    {
        //        // Calling ToList() on source in order to query a copu
        //        // of the enumeration, to avoid exceptions due to calling
        //        // Remove in the foreach loop that follows.
        //        var staleKeys = from entry in cachedRecords.ToList()
        //                        where IsStale(entry.Value)
        //                        select entry.Key;
        //        foreach (int staleKey in staleKeys)
        //        {
        //            cachedRecords.Remove(staleKey);
        //        }
        //    }
        //}
        
        static void Main(string[] args)
        {
            SparseArray big = new SparseArray();
            big[0] = 123;
            big[10000000000] = 456;

            big.ShowArrayContents();
            Console.ReadKey();
        }
    }
}
;
