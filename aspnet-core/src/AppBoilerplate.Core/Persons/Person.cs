using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBoilerplate.Persons
{
    [Table("Persons")]
    public class Person : Entity<Guid>, IHasCreationTime
    {
        public const int MaxNameLength = 100;

        [StringLength(MaxNameLength)]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreationTime { get; set; }

        public Person()
        {
            CreationTime = Clock.Now;
        }

        public static Person Create(string name, int age)
        {
            var person = new Person
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
