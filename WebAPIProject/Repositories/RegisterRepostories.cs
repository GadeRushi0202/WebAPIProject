using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public class RegisterRepostories : IRegisterRepostories
    {
        private readonly ApplicationDbContext db;

        public RegisterRepostories(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Register> GetLogin(Register r)
        {
            var result = await db.Registers.Where(x => x.UserName == r.UserName && x.Password == r.Password).FirstOrDefaultAsync();
           
            return result;
        }

        public async Task<int> Register(Register r)
        {
            r.Roleid = 2;
            db.Registers.Add(r);
            int result = await db.SaveChangesAsync();
            return result;
        }
    }
}
