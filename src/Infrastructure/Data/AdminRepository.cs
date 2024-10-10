using System;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Data;

public class AdminRepository: BaseRepository<Admin>, IAdminRepository
{
}
