using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purginal.Common.StateProviders;

namespace Purginal.Service
{
    public class RegCheck
    {        
        public async Task CheckRegistrations()
        {            
            var regInfos = GetRegistrationInfos();
            
            foreach(var regInfo in regInfos)
            {
                await CheckRegistration(regInfo);
            }
        }

        private static IEnumerable<IStateProvider> Providers = new List<IStateProvider>{
            new WARegistrationProvider(),
            new MORegistrationProvider()
        };

        private async Task CheckRegistration(RegistrationInfo regInfo)
        {
            var providers = Providers.Where(p => p.State == regInfo.State);
            if(providers.Count() == 0)
            {
                Console.WriteLine($"No State provider for {regInfo.State}.");
            }
            else{
                var provider = providers.First();
                var registration = await provider.CheckRegistration(regInfo);
                Console.WriteLine($"{registration.FirstName} {registration.LastName} is {registration.Active }");
            }
        }

        private IEnumerable<RegistrationInfo> GetRegistrationInfos()
        {
            return new List<RegistrationInfo>{
            };
        }
    }
}
