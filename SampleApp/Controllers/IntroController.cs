using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class IntroController : ControllerBase
    {
        private Person _person;

        public IntroController(IOptions<Person> config)
        {
            _person = config.Value;
        }

        [HttpGet]
        public string Get()
        {
            return $"{_person.Name}, age {_person.Age}, loves to eat {_person.Food}.";
        }
    }
}
