using InventoryApi.Data;
using InventoryApi.Repository.Interface;
using InventoryLogic.DataModels;
using InventoryLogic.PaginationView;
using InventoryLogic.Setting;
using InventoryLogic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
	{
        private readonly ApplicationDbContext _context;

        public BrandController(ApplicationDbContext context)
		{
        _context = context;
		}
        [HttpPost]
        [ActionName("Save")]
        public async Task<ActionResult> Save(Brand model)
		{
            var status = new Response();
            var result = (from progm in _context.Brand
                          where progm.Name == model.Name
                          select progm.BrandId).Count();
            if (result > 0)
            {
                status.StatusCode = 0;
                status.Message = "Brand name already exists";
            }
            else
            {
                await _context.Brand.AddAsync(model);
                await _context.SaveChangesAsync();
                int id = model.BrandId;
                _context.Entry(model).State = EntityState.Detached;
                if (id > 0)
                {
                    status.StatusCode = 1;
                    status.Message = "Saved successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Failed";
                }
            }
            return Ok(status);
		}
        [HttpPost]
        [ActionName("Update")]
        public async Task<ActionResult> Update(Brand model)
        {
            var status = new Response();
            var result = (from progm in _context.Brand
                          where progm.Name == model.Name && progm.BrandId != model.BrandId
                          select progm.BrandId).Count();
            if (result > 0)
            {
                status.StatusCode = 0;
                status.Message = "Brand name already exists";
            }
            else
            {
                _context.Brand.Update(model);
                await _context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Updated successfully";
            }
            return Ok(status);

        }
        [HttpGet("{sTerm}/{pageNo}")]
        [ActionName("GetAll")]
        public async Task<ActionResult> GetAll(string sTerm = "", int pageNo = 1)
		{
            if(sTerm == "All")
            {
                var data = await (from a in _context.Brand
                                  select new BrandView
                                  {
                                      BrandId = a.BrandId,
                                      Name = a.Name,
                                      Image = a.Image
                                  }).ToListAsync();
                var totalRecords = data.Count;
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                int skip = (pageNo - 1) * pageSize;
                data = data.Skip(skip).Take(pageSize).ToList();
                var model = new BrandPagination()
                {
                    Brands = data,
                    SearchTerm = sTerm,
                    TotalPages = totalPages,
                    PageNumber = pageNo
                };
                if (model != null)
                    return Ok(model);
            }
            else
            {
                sTerm = sTerm.ToLower();
                var data = await (from a in _context.Brand
                                  where sTerm == null || a.Name.ToLower().StartsWith(sTerm)
                                  select new BrandView
                                  {
                                      BrandId = a.BrandId,
                                      Name = a.Name,
                                      Image = a.Image
                                  }).ToListAsync();
                var totalRecords = data.Count;
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                int skip = (pageNo - 1) * pageSize;
                data = data.Skip(skip).Take(pageSize).ToList();
                var model = new BrandPagination()
                {
                    Brands = data,
                    SearchTerm = sTerm,
                    TotalPages = totalPages,
                    PageNumber = pageNo
                };
                if (model != null)
                    return Ok(model);
            }
            return BadRequest();
        }
        [HttpGet]
        [ActionName("BrandAll")]
        public async Task<ActionResult> BrandAll()
        {
                var data = await (from a in _context.Brand
                                  select new BrandView
                                  {
                                      BrandId = a.BrandId,
                                      Name = a.Name,
                                      Image = a.Image
                                  }).ToListAsync();
                    return Ok(data);
        }

        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetById(int id)
		{
			if (id > 0)
			{
                Brand model = await _context.Brand.FindAsync(id);
                return Ok(model);
            }
            return BadRequest();
		}
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Brand model)
		{
            var status = new Response();
                Brand models = await _context.Brand.FindAsync(model.BrandId);
                _context.Remove(models);
                await _context.SaveChangesAsync();
                status.StatusCode = 1;
                status.Message = "Deleted Successfully";
                return Ok(status);
		}
	}
}