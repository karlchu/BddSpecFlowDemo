namespace BddSpecFlowDemo.Simulation
{
    public interface ISimulatorDecider
    {
        bool ShouldSimulate(SimulatorKey key);

        void ChangeSimulatorTo(SimulatorKey key, bool isEnabled);
    }

    public class SimulatorDecider : ISimulatorDecider
    {
        private readonly IHttpContext _httpContext;
        private readonly ISimulatorStatusStorage _simulatorStatusStorage;

        public SimulatorDecider(IHttpContext httpContext, ISimulatorStatusStorage simulatorStatusStorage)
        {
            _httpContext = httpContext;
            _simulatorStatusStorage = simulatorStatusStorage;
        }

        public bool ShouldSimulate(SimulatorKey key)
        {
            return _simulatorStatusStorage.StatusFor(key, _httpContext.CurrentIpAddress());
        }

        public void ChangeSimulatorTo(SimulatorKey key, bool isEnabled)
        {
            _simulatorStatusStorage.StoreStatusOf(key, _httpContext.CurrentIpAddress(), isEnabled);
        }
    }
}