using InventoryApi.Data;
using InventoryApi.Repository.Interface;
using InventoryLogic.DataModels;
using InventoryLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApi.Repository.Service
{
	public class UserService : IUser
	{
		private readonly ApplicationDbContext _context;

		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Response> Delete(int id)
		{
				Users model = await _context.Users.FindAsync(id);
				_context.Remove(model);
				await _context.SaveChangesAsync();
				return new Response { Success = true, Message = $"{model.Email} Deleted successfully" };
		}

		public async Task<List<UserModel>> GetAll()
		{
			var result = await(from a in _context.Users
							   select new UserModel
							   {
								   UserId = a.UserId,
								  FullName = a.FullName,
								  Address = a.Address,
								   Email = a.Email,
								   Role = a.Role,
								   Gender = a.Gender,
								   City = a.City,
								   MobileNo = a.MobileNo,
								   Phone = a.Phone,
								   ShopName = a.ShopName,
								   IsActive = a.IsActive,
								   Image = a.Image,
								   CreatedOn = a.CreatedOn,
								   ModifiedOn = a.ModifiedOn
							   }).ToListAsync();
			return result;
		}

		public async Task<Users> GetById(int id)
		{
			Users model = await _context.Users.FindAsync(id);
			return model;
		}

		public async Task<Response> Save(Users model)
		{
			await _context.Users.AddAsync(model);
			await _context.SaveChangesAsync();
			int id = model.UserId;
			_context.Entry(model).State = EntityState.Detached;
			if(id > 0)
			{
				return new Response { Success = true, Message = $"{model.FullName} Saved successfully" };
			}
			else
			{
				return new Response { Success = false, Message = $"{model.FullName} Failed" };
			}
		}

		public async Task<Response> Update(Users model)
		{
			_context.Users.Update(model);
			await _context.SaveChangesAsync();
			return new Response { Success = true, Message = $"{model.FullName} Updated successfully" };
		}
	}
}
