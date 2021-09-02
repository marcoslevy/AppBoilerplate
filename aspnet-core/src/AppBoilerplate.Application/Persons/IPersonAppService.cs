using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AppBoilerplate.Persons.Dto;
using System;
using System.Threading.Tasks;

namespace AppBoilerplate.Persons
{
    public interface IPersonAppService : IApplicationService
    {
        Task<ListResultDto<PersonDto>> GetAllAsync();
        Task CreateAsync(PersonDto input);
        Task UpdateAsync(PersonDto input);
        Task DeleteAsync(EntityDto<Guid> input);

    }
}
