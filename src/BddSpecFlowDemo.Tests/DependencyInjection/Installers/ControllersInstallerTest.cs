using System;
using System.Linq;
using System.Web.Mvc;
using BddSpecFlowDemo.DependencyInjection.Installers;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using NUnit.Framework;

namespace BddSpecFlowDemo.Tests.DependencyInjection.Installers
{
    public class ControllersInstallerTest
    {
        private IWindsorContainer _containerWithControllers;

        [SetUp]
        public void SetUp()
        {
            _containerWithControllers = new WindsorContainer().Install(new ControllersInstaller());
        }

        [Test]
        public void AllControllersImplementIController()
        {
            var allHandlers = GetAllHandlers(_containerWithControllers);
            var controllerHandlers = GetHandlersFor(typeof (IController), _containerWithControllers);

            Assert.That(controllerHandlers, Is.EqualTo(allHandlers));
        }

        [Test]
        public void AllControllersAreRegistered()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementationTypesFor(typeof (IController), _containerWithControllers);

            Assert.That(registeredControllers, Is.EqualTo(allControllers));
        }

        [Test]
        public void AllControllersAreTransient()
        {
            var nonTransientControllers = GetHandlersFor(typeof (IController), _containerWithControllers)
                .Where(controller => controller.ComponentModel.LifestyleType != LifestyleType.Transient)
                .ToArray();

            Assert.That(nonTransientControllers, Is.Empty);
        }

        [Test]
        public void AllControllersExposeThemselvesAsService()
        {
            var controllersWithWrongName = GetHandlersFor(typeof (IController), _containerWithControllers)
                .Where(controller => controller.ComponentModel.Services.Single() != controller.ComponentModel.Implementation)
                .ToArray();

            Assert.That(controllersWithWrongName, Is.Empty);
        }

        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        private Type[] GetImplementationTypesFor(Type type, IWindsorContainer container)
        {
            return GetHandlersFor(type, container)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }

        private Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where)
        {
            return typeof(ControllersInstaller).Assembly.GetExportedTypes()
                .Where(t => t.IsClass)
                .Where(t => t.IsAbstract == false)
                .Where(@where.Invoke)
                .OrderBy(t => t.Name)
                .ToArray();
        }
    }
}
