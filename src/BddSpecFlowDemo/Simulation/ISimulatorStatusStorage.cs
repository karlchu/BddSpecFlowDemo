namespace BddSpecFlowDemo.Simulation
{
    public interface ISimulatorStatusStorage
    {
        bool StatusFor(SimulatorKey key, string ipAddress);

        void StoreStatusOf(SimulatorKey key, string ipAddress, bool isEnabled);
    }
}