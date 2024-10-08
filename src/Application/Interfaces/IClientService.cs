using System;
using Domain.Entities;
namespace Application.Interfaces;

public interface IClientService
{

    public List<Client> GetClients();
    public Client GetClientById(int id);
    public void AddClient(Client client);
    public void UpdateClient(int id ,Client client);
    public void DeleteClient(int id);

    
}
