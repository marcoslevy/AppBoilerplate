using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AppBoilerplate.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppBoilerplate.Persons
{
    [AbpAuthorize]
    public class PersonAppService : AppBoilerplateAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;

        public PersonAppService(IRepository<Person, Guid> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreateAsync(PersonDto input)
        {
            var person = Person.Create(input.Name, input.Age);
            await _personRepository.InsertAsync(person);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<PersonDto>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllListAsync();

            return new ListResultDto<PersonDto>(
                ObjectMapper.Map<List<PersonDto>>(persons)
            );
        }

        public Task UpdateAsync(PersonDto input)
        {
            throw new NotImplementedException();
        }
    }
}
