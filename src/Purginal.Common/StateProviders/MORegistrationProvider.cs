using System.Threading.Tasks;

namespace Purginal.Common.StateProviders
{
    public class MORegistrationProvider : IStateProvider
    {
        public State State => State.MO;

        public async Task<Registration> CheckRegistration(RegistrationInfo regInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}