using System.Threading.Tasks;
using Abp.Application.Services;
using AppBoilerplate.Authorization.Accounts.Dto;

namespace AppBoilerplate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
