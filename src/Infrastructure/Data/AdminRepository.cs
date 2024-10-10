using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data;

public class AdminRepository: BaseRepository<Admin>, IAdminRepository
{
}
