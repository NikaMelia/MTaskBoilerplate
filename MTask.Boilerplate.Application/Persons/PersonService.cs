using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Persons
{
    public class PersonService : IPersonService
    {
        private readonly BoilerplateDbContext _dbContext;

        public PersonService(BoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> GetPersonsByIds(IReadOnlyList<int> keys)
        {
            var query = _dbContext.People.Where(p => keys.Contains(p.Id));

            return await query.ToListAsync();
        }
    }
}
