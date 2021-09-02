using AppBoilerplate.Persons;
using AppBoilerplate.Persons.Dto;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AppBoilerplate.Tests.Persons
{
    public class PersonAppService_Tests : AppBoilerplateTestBase
    {
        private readonly IPersonAppService _personAppService;
        public PersonAppService_Tests()
        {
            _personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public async Task GetAll_Persons_Test()
        {
            //Act
            var output = await _personAppService.GetAllAsync();

            //Asset
            output.Items.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Create_Person_Test()
        {
            await _personAppService.CreateAsync(PersonDto.Create("José", 45));

            UsingDbContext(context =>
            {
                var person = context.Persons.FirstOrDefault(t => t.Name == "José");
                person.ShouldNotBeNull();
            });
        }
    }
}
