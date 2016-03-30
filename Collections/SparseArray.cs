using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class SparseArray
    {
        private Dictionary<long, double> nonEmptyValues =
            new Dictionary<long, double>();
        
        public double this[long index]
        {
            get
            {
                double result;
                nonEmptyValues.TryGetValue(index, out result);
                return result;
            }
            set
            {
                nonEmptyValues[index] = value;
            }
        }

        public void ShowArrayContents()
        {
            foreach (var item in nonEmptyValues)
            {
                Console.WriteLine("Key: {0}, Value: {1}.",
                    item.Key, item.Value);
            }
        }
    }
}
