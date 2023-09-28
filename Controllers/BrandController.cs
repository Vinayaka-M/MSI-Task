using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeSkull.Data;
using SafeSkull.Models;

namespace SafeSkull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public BrandController(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if(_DbContext.Brands == null)
            {
                return NotFound();
            }
            return await _DbContext.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrands(int id)
        {
            if (_DbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _DbContext.Brands.FindAsync(id);
            if(brand == null)
            {
                return NotFound();
            }
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _DbContext.Brands.Add(brand);
            await _DbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new {id=brand.Id}, brand);
        }

        [HttpPut]
        public async Task<ActionResult> PutBrand(int id,Brand brand)
        {
            if(id!= brand.Id)
            {
                return BadRequest();

            }
            _DbContext.Entry(brand).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                if((_DbContext.Brands?.Any(x => x.Id==id)).GetValueOrDefault()==false)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            if(_DbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _DbContext.Brands.FindAsync(id);
            if(brand == null)
            {
                return NotFound();
            }
            _DbContext.Brands.Remove(brand);
            await _DbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
