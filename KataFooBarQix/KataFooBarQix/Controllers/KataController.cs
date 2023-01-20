using KataFooBarQix.Services;
using Microsoft.AspNetCore.Mvc;

namespace KataFooBarQix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KataController : ControllerBase
    {
        private readonly IComputer _computer = new KataComputer();
        public KataController(IComputer newComputer)
        {
            _computer = newComputer;
        }
        [HttpGet(Name="Compute")]
        public string Index(string rawInput)
        {
            return _computer.Compute(rawInput);
        }
    }
}
