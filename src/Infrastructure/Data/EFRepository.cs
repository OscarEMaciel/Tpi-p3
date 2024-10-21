namespace Infrastructure.Data
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public EfRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
