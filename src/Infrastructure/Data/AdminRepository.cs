using System;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infraestructure.Data;

public class AdminRepository: BaseRepository<Admin>, IAdminRepository
{
}
