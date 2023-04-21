using MTask.Boilerplate.Core.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Persons
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersonsByIds(IReadOnlyList<int> keys);
    }
}
