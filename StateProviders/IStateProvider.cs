using System.Threading.Tasks;

namespace Purginal.StateProviders
{
    public interface IStateProvider
    {
        Task<Registration> CheckRegistration(RegistrationInfo regInfo);
        State State { get; }
    }
}
