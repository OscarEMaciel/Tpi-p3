
using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class SysAdminRepository : EfRepository<SysAdmin>, ISysAdminRepository
{
    public SysAdminRepository(AppDbContext context) : base(context)
    {
    }
}
