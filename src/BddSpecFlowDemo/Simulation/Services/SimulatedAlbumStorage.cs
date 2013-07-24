using System.Collections.Generic;

namespace BddSpecFlowDemo.Simulation.Services
{
    public class SimulatedAlbumStorage : ISimulatedAlbumStorage
    {
        private Dictionary<string, string> data = new Dictionary<string, string>(); 

        public void Add(string title, string artist)
        {
            data.Add(title, artist);
        }

        public Dictionary<string, string> GetAll()
        {
            return data;
        }

        public void Clear()
        {
            data.Clear();
        }
    }
}