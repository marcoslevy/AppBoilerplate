using Abp.Application.Services;
using AppBoilerplate.MultiTenancy.Dto;

namespace AppBoilerplate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

