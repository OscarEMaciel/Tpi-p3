using System;
using Domain.Entities;
namespace Application.Interfaces;

public interface IAdminService()
{
    public List<Admin> GetAdmins();
    public Admin GetAdminById(int id);
    public void AddAdmin(Admin admin);
    public void UpdateAdmin(int id, Admin admin);
    public void DeleteAdmin(int id);
}
