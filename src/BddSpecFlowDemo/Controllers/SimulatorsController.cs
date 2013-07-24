using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BddSpecFlowDemo.Simulation;

namespace BddSpecFlowDemo.Controllers
{
    public class SimulatorsController : Controller
    {
        private readonly ISimulatorDecider _simulatorDecider;

        public SimulatorsController(ISimulatorDecider simulatorDecider)
        {
            _simulatorDecider = simulatorDecider;
        }

        public ActionResult Index()
        {
            var simulators = Enum.GetValues(typeof (SimulatorKey))
                .Cast<SimulatorKey>()
                .ToDictionary(key => key, key => _simulatorDecider.ShouldSimulate(key));
            var model = new SimulatorsViewModel {Simulators = simulators, Ip = Request.UserHostAddress};
            return View(model);
        }

        public ActionResult Switch(SimulatorKey simulatorKey, bool value)
        {
            _simulatorDecider.ChangeSimulatorTo(simulatorKey, value);
            return RedirectToAction("Index");
        }
    }

    public class SimulatorsViewModel
    {
        public Dictionary<SimulatorKey, bool> Simulators { get; set; }

        public string Ip { get; set; }
    }

}
