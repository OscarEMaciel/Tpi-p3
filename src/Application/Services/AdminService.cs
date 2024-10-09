using System;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        // Inyección de dependencias del repositorio
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // Obtener todos los administradores
        public List<Admin> GetAdmins()
        {
            return _adminRepository.GetAll();
        }

        // Obtener un administrador por ID
        public Admin GetAdminById(int id)
        {
            return _adminRepository.GetbyId(id);
        }

        // Agregar un nuevo administrador
        public void AddAdmin(Admin admin)
        {
            _adminRepository.Add(admin);
        }

        // Actualizar un administrador existente
        public void UpdateAdmin(int id, Admin admin)
        {
            _adminRepository.Update(id, admin);
        }

        // Eliminar un administrador por ID
        public void DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetbyId(id);
            if (admin != null)
            {
                _adminRepository.Delete(admin);
            }
        }
    }
}

