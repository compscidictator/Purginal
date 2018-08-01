using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purginal.Service;

namespace Purginal.Service
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await new RegCheck().CheckRegistrations();
        }
    }
}
