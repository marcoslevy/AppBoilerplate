using AppBoilerplate.EntityFrameworkCore;
using AppBoilerplate.Persons;

namespace AppBoilerplate.Tests
{
    public class TestDataBuilder
    {
        private readonly AppBoilerplateDbContext _context;

        public TestDataBuilder(AppBoilerplateDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.Persons.AddRange(
                Person.Create("Marcos Levy", 35),
                Person.Create("Otilia Freitas", 35),
                Person.Create("Anna Caroline", 8),
                Person.Create("Anna Elisa", 1)
                );
        }
    }
}
