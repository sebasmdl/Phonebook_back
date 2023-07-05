using Microsoft.AspNetCore.Mvc;
using phonebook_back.Data;

namespace phonebook_back.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var resource = await repository.Get(id);
            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity resource)
        {
            if (id != resource.Id)
            {
                return BadRequest();
            }
            await repository.Update(resource);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity resource)
        {
            await repository.Add(resource);
            return CreatedAtAction("Get", new { id = resource.Id }, resource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var resource = await repository.Delete(id);
            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }

    }
}
