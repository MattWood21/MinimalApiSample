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

        public int RandomNumber => _random.Next();
    }
}
