using AuthApp.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Repositories
{
    public class AccountsRepository : IAsyncRepository<User>
    {
        private readonly DesignersShopDbContext _context;

        public AccountsRepository(DesignersShopDbContext context)
        {
            _context = context;
        }

        public async Task Add(User value)
        {
            await _context.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task AddMany(params User[] values)
        {
            await _context.AddRangeAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAll() => await _context.User.ToListAsync();

        public async Task<User> GetByIdentificatorAsync(object identificator) => await _context.User.FindAsync(identificator);

        public async Task Update(User oldValue, User newValue)
        {
            var curr = await _context.FindAsync<User>(oldValue.Login);
            if (curr is null)
                return;
            _context.Entry<User>(curr).CurrentValues.SetValues(newValue);
            await _context.SaveChangesAsync();
        }
    }
}
