using System.Linq;
using BddSpecFlowDemo.Models;
using BddSpecFlowDemo.Services;

namespace BddSpecFlowDemo.Simulation.Services
{
    public class SimulatedAlbumsService : IAlbumsService
    {
        private readonly ISimulatorDecider _simulatorDecider;
        private readonly IAlbumsService _albumsService;
        private readonly ISimulatedAlbumStorage _albumStorage;

        public SimulatedAlbumsService(ISimulatorDecider simulatorDecider, IAlbumsService albumsService, ISimulatedAlbumStorage albumStorage)
        {
            _simulatorDecider = simulatorDecider;
            _albumsService = albumsService;
            _albumStorage = albumStorage;
        }

        public Album SearchByTitle(string title)
        {
            if (_simulatorDecider.ShouldSimulate(SimulatorKey.Albums))
            {
                return SearchInSimulatedStorage(title);
            }
            return _albumsService.SearchByTitle(title);
        }

        private Album SearchInSimulatedStorage(string searchString)
        {
            var allAlbums = _albumStorage.GetAll();
            var foundTitle = allAlbums.Keys.FirstOrDefault(title => title.ToUpper().Contains(searchString.ToUpper()));
            return string.IsNullOrEmpty(foundTitle)
                       ? null
                       : new Album {Title = foundTitle, Artist = allAlbums[foundTitle]};
        }
    }
}