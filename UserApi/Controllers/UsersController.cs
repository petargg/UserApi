namespace UserApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FizzWare.NBuilder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "user1", "user2" };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<IActionResult> Get(int id)
        {
            var user = Builder<User>.CreateNew()
                .With(x => x.Id = id)
                .With(x => x.Name = Faker.Name.FullName())
                .With(x => x.Email = Faker.Internet.Email())
                .With(x => x.Phone = Faker.Phone.Number())
                .Build();

            return Ok(user);
        }

        // POST api/users/getmany
        [HttpPost("getmany")]
        public IActionResult Post([FromBody] List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return Ok(new List<User>());
            }

            var users = Builder<User>.CreateListOfSize(ids.Count)
                .All()
                    .With(x => x.Id = Helper.RemoveFromList(ids))
                    .With(x => x.Name = Faker.Name.FullName())
                    .With(x => x.Email = Faker.Internet.Email())
                    .With(x => x.Phone = Faker.Phone.Number())
                    .Build();

            return Ok(users);
        }
    }
}