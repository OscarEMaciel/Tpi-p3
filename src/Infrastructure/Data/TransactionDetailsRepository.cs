using Domain;
using Domain.Entities;

namespace Infrastructure.Data;

public class TransactionDetailsRepository : EFRepository<TransactionDetail>, ITransactionDetailsRepository
{
    public TransactionDetailsRepository(AppDbContext context) : base(context)
    {
    }
}
