using GreenDonut;
using MTask.Boilerplate.Application.Persons;
using MTask.Boilerplate.Core.People;

namespace MTask.Boilerplate.Api.DataLoaders
{
    public class PersonByIdsDataLoader : BatchDataLoader<int, Person>
    {
        private readonly IPersonService _personService;

        public PersonByIdsDataLoader(IPersonService personService, IBatchScheduler batchScheduler, DataLoaderOptions options =  null) : base(batchScheduler,options)
        {
            _personService = personService;
        }

        protected override async Task<IReadOnlyDictionary<int, Person>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var persons = await _personService.GetPersonsByIds(keys);

            return persons.ToDictionary(p => p.Id);
        }
    }
}
