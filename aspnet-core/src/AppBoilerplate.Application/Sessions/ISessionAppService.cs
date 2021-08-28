using System.Threading.Tasks;
using Abp.Application.Services;
using AppBoilerplate.Sessions.Dto;

namespace AppBoilerplate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
