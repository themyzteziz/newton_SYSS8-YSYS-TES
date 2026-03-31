using Microsoft.VisualStudio.TestTools.UnitTesting;
using RickAndMortyEpisodes;

namespace RickAndMortyEpisodes.IntegrationTests;

[TestClass]
public class EpisodeServiceIntegrationTests
{
    private static EpisodeService _service = null!;

    [ClassInitialize]
    public static void Setup(TestContext _)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://rickandmortyapi.com/api/")
        };

        var client = new RickAndMortyClient(httpClient);
        _service = new EpisodeService(client);
    }

    [TestMethod]
    public async Task GetEpisodesWhereCharacterIsPresentAsync_Squanchy_ReturnsEpisodes()
    {
        var result = await _service.GetEpisodesWhereCharacterIsPresentAsync("Squanchy");

        Assert.IsTrue(result.Count > 0);
        Assert.IsTrue(result.All(e => e.StartsWith("S") && e.Contains("E")));
    }

  
    [TestMethod]
    public async Task GetEpisodesWhereCharacterIsPresentAsync_FakeCharacter_ReturnsEmptyList()
    {
        var result = await _service.GetEpisodesWhereCharacterIsPresentAsync("DefinitelyNotARealCharacter123");

        Assert.AreEqual(0, result.Count);
    }
}