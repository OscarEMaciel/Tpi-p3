using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Infraestructure.Data;

public class AdminRepository: BaseRepository<Admin>, IAdminRepository
{
}
