using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;

namespace AppBoilerplate.Persons.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonDto : EntityDto<Guid>, IHasCreationTime
    {        
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreationTime { get; set; }

        public static PersonDto Create(string name, int age)
        {
            var person = new PersonDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                CreationTime = Clock.Now
            };

            return person;
        }
    }
}
