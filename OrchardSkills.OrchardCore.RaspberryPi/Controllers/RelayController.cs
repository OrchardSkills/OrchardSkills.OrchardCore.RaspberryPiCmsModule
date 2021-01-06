using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrchardSkills.OrchardCore.RaspberryPi.Devices;

namespace OrchardSkills.OrchardCore.RaspberryPi.Controllers
{
    public class RelayController : Controller
    {
        private readonly LedDevice _ledDevice;

        public RelayController(LedDevice ledDevice)
        {
            _ledDevice = ledDevice;
        }

        public IActionResult Index()
        {
            ViewBag.ReplaySupported = _ledDevice.IsReplaySupported ? "Yes" : "No";
            ViewBag.ReplayState = _ledDevice.IsReplayOn ? "On" : "Off";
            return View();
        }

        public IActionResult ReplayOn()
        {
            _ledDevice.ReplayOn();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReplayOff()
        {
            _ledDevice.ReplayOff();

            return RedirectToAction(nameof(Index));
        }
    }
}
