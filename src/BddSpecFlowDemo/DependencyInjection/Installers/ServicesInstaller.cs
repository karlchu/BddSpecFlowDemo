using BddSpecFlowDemo.Services;
using BddSpecFlowDemo.Simulation;
using BddSpecFlowDemo.Simulation.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BddSpecFlowDemo.DependencyInjection.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISimulatedAlbumStorage>().ImplementedBy<SimulatedAlbumStorage>());
            container.Register(Component.For<ISimulatorStatusStorage>().ImplementedBy<SimulatorStatusStorage>());
            container.Register(Component.For<ISimulatorDecider>().ImplementedBy<SimulatorDecider>());
            container.Register(Component.For<IAlbumsService>().ImplementedBy<SimulatedAlbumsService>());

            container.Register(Component.For<IHttpContext>().ImplementedBy<HttpContextWrapper>());
            container.Register(Component.For<IAlbumsService>().ImplementedBy<AlbumsService>());
        }
    }
}