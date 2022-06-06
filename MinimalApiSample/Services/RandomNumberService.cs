using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiSample.Services
{
    public class RandomNumberService
    {
        private Random _random;

        public RandomNumberService()
        {
            _random = new Random();
        }

        public int GetNext()
        {
            // You can do this in better ways, this adds thread safety though
            // The random number is just for "demonstration" purposes anyhow
            lock(_random)
            {
                return _random.Next();
            }
        }
    }
}
