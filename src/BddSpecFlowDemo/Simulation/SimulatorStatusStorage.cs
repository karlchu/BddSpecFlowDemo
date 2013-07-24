using System.Collections.Generic;
using System.Linq;

namespace BddSpecFlowDemo.Simulation
{
    public class SimulatorStatusStorage : ISimulatorStatusStorage
    {
        private struct SimulatorStatus
        {
            public string IpAddress;
            public SimulatorKey Key;
        }

        private readonly List<SimulatorStatus> _simulatorsStatus = new List<SimulatorStatus>();

        public bool StatusFor(SimulatorKey key, string ipAddress)
        {
            return _simulatorsStatus.Any(x => x.IpAddress == ipAddress && x.Key == key);
        }

        public void StoreStatusOf(SimulatorKey key, string ipAddress, bool isEnabled)
        {
            if (isEnabled)
            {
                _simulatorsStatus.Add(new SimulatorStatus { IpAddress = ipAddress, Key = key });
            }
            else
            {
                _simulatorsStatus.RemoveAll(x => x.IpAddress == ipAddress && x.Key == key);
            }
        }
    }
}
