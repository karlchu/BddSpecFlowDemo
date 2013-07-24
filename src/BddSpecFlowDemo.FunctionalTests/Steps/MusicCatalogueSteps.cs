using BddSpecFlowDemo.FunctionalTests.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BddSpecFlowDemo.FunctionalTests.Steps
{
    [Binding]
    public class MusicCatalogueSteps
    {
        protected string SearchResponse
        {
            get { return (string) ScenarioContext.Current["SearchResponse"]; }
            set { ScenarioContext.Current.Add("SearchResponse", value); }
        }

        [Given(@"I have the following items in the catalogue")]
        public void GivenIHaveTheFollowingItemsInTheCatalogue(Table table)
        {
            Simulator.ToggleAlbumSimulation(true);
            SimulatedAlbums.Clear();
            foreach (var row in table.Rows)
            {
                SimulatedAlbums.Add(row["Title"], row["Artist"]);
            }
        }

        [When(@"I search the title for the word '(.*)'")]
        public void WhenISearchTheTitleForTheWord(string word)
        {
            SearchResponse = MusicCatalogueService.SearchAlbumByTitle(word);
        }

        [When(@"I search artists for '(.*)'")]
        public void WhenISearchArtistsFor(string word)
        {
            SearchResponse = MusicCatalogueService.SearchAlbumByArtist(word);
        }

        [Then(@"I should get '(.*)' by '(.*)'")]
        public void ThenIShouldGetBy(string title, string artist)
        {
            Assert.That(SearchResponse, Is.EqualTo(string.Format("{0}|{1}", title, artist)));
        }

        [Then(@"I should get an empty response")]
        public void ThenIShouldGetAnEmptyResponse()
        {
            Assert.That(SearchResponse, Is.Empty);
        }

        protected MusicCatalogueService MusicCatalogueService
        {
            get { return new MusicCatalogueService(BaseUrl());}
        }

        protected Simulator Simulator
        {
            get { return new Simulator(BaseUrl()); }
        }

        protected SimulatedAlbums SimulatedAlbums
        {
            get { return new SimulatedAlbums(BaseUrl());}
        }

        private string BaseUrl()
        {
            return "http://russell-pc/BddSpecFlowDemo/";
        }
    }
}
