using BddSpecFlowDemo.FunctionalTests.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BddSpecFlowDemo.FunctionalTests.Steps
{
    [Binding]
    public class MusicCatalogueSteps
    {
        protected string SearchByTitleResponse
        {
            get { return (string) ScenarioContext.Current["SearchByTitleResponse"]; }
            set { ScenarioContext.Current.Add("SearchByTitleResponse", value); }
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
            SearchByTitleResponse = MusicCatalogueService.SearchAlbumByTitle(word);
        }

        [Then(@"I should get '(.*)' by '(.*)'")]
        public void ThenIShouldGetBy(string title, string artist)
        {
            Assert.That(SearchByTitleResponse, Is.EqualTo(string.Format("{0}|{1}", title, artist)));
        }

        [Then(@"I should get an empty response")]
        public void ThenIShouldGetAnEmptyResponse()
        {
            Assert.That(SearchByTitleResponse, Is.Empty);
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
