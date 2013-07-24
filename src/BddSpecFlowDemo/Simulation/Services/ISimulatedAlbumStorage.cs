using System.Collections.Generic;

namespace BddSpecFlowDemo.Simulation.Services
{
    public interface ISimulatedAlbumStorage
    {
        void Add(string title, string artist);
        Dictionary<string, string> GetAll();
        void Clear();
    }
}