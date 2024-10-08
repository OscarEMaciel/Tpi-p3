using System;
using Domain.Entities;
using Domain.Interfaces;
namespace Infrastructure.Data;

public class ClientRepository :BaseRepository<Client> ,IClientRepository
{
    
}
