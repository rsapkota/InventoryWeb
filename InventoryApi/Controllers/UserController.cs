using InventoryApi.Data;
using InventoryLogic.DataModels;
using InventoryLogic.Models;
using InventoryLogic.PaginationView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
	{
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
		{
        _context = context;
		}
        [HttpPost]
        [ActionName("Update")]
        public async Task<ActionResult> Update(Users model)
        {
            var status = new Response();
            var result = (from progm in _context.Users
                          where progm.Email == model.Email && progm.UserId != model.UserId
                          select progm.UserId).Count();
            if (result > 0)
            {
                status.StatusCode = 0;
                status.Message = "Email already exists";
            }
            else
            {
                _context.Users.Update(model);
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
                var data = await (from a in _context.Users
                                  select new Users
                                  {
                                      UserId = a.UserId,
                                      Email = a.Email,
                                      FullName = a.FullName,
                                      Role = a.Role,
                                      Gender = a.Gender,
                                      Address = a.Address
                                  }).ToListAsync();
                var totalRecords = data.Count;
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                int skip = (pageNo - 1) * pageSize;
                data = data.Skip(skip).Take(pageSize).ToList();
                var model = new PaginationModel()
                {
                    user = data,
                    SearchTerm = sTerm,
                    TotalPages = totalPages,
                    PageNumber = pageNo
                };
                //if (model != null)
                    return Ok(model);
            }
            else
            {
                sTerm = sTerm.ToLower();
                var data = await (from a in _context.Users
                                  where sTerm == null || a.Email.ToLower().StartsWith(sTerm)
                                  select new Users
                                  {
                                      UserId = a.UserId,
                                      Email = a.Email,
                                      FullName = a.FullName,
                                      Role = a.Role,
                                      Gender = a.Gender,
                                      Address = a.Address
                                  }).ToListAsync();
                var totalRecords = data.Count;
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                int skip = (pageNo - 1) * pageSize;
                data = data.Skip(skip).Take(pageSize).ToList();
                var model = new PaginationModel()
                {
                    user = data,
                    SearchTerm = sTerm,
                    TotalPages = totalPages,
                    PageNumber = pageNo
                };
                //if (model != null)
                    return Ok(model);
            }
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetById(int id)
		{
			if (id > 0)
			{
                Users model = await _context.Users.FindAsync(id);
                return Ok(model);
            }
            return BadRequest();
		}
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(Users model)
		{
            var status = new Response();

                    Users models = await _context.Users.FindAsync(model.UserId);
                    _context.Remove(models);
                    await _context.SaveChangesAsync();
                    status.StatusCode = 1;
                    status.Message = "Deleted Successfully";
                    return Ok(status);
		}
	}
}