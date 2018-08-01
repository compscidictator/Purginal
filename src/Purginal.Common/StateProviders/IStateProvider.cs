using System.Threading.Tasks;

namespace Purginal.Common.StateProviders
{
    public interface IStateProvider
    {
        Task<Registration> CheckRegistration(RegistrationInfo regInfo);
        State State { get; }
    }
}
