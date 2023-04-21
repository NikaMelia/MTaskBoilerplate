using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MTask.Boilerplate.Application.Films;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;
using MTGames.Boilerplate.Api;

namespace MTask.Boilerplate.Api.Services;

public class BoilerplateService : BoilerplateRpcService.BoilerplateRpcServiceBase
{
    private readonly IFilmService _filmService;
    private readonly ILogger<BoilerplateService> _logger;
    
    public BoilerplateService(IFilmService filmService, ILogger<BoilerplateService> logger)
    {
        _filmService = filmService;
        _logger = logger;
    }

    public override async Task<GetFilmReply> GetFilm(GetFilmRequest request, ServerCallContext context)
    {
        var film = await _filmService.GetFilmByTitleWithCharacters(request.Title);
        if (film != null) return BuildFrom(film);
        _logger.LogError("requested film with title {Title} do not exists", request.Title);
        throw new RpcException(new Status(StatusCode.Cancelled, "film does not exists"));

    }

    private static GetFilmReply BuildFrom(Film film)
    {
        var releaseDate = DateTime.SpecifyKind(film.ReleaseDate, DateTimeKind.Utc);
        return new GetFilmReply()
        {
            Director = film.Director,
            Title = film.Title,
            ReleaseDate = releaseDate.ToTimestamp(),
            Producer = film.Producer,
            Characters = {CastToCharacters(film.Characters)}
        };
    }

    private static IEnumerable<CharactersMessage> CastToCharacters(List<Person> filmCharacters)
    {
        return filmCharacters.Select(c =>
        {
            var gender = c.Gender == Gender.Male ? GenderMessage.Male : GenderMessage.Female;
            return new CharactersMessage()
            {
                Gender = gender,
                Height = c.Height,
                Name = c.Name,
                BirthYear = c.BirthYear
            };
        });
    }
}