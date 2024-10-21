using Application.Models;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISysAdminService
    {
        IEnumerable<SysAdminDTO> GetAllSysAdmins();
        SysAdminDTO GetSysAdminById(int id);
        void CreateSysAdmin(SysAdminCreateRequest sysadminCreateRequest);
        void UpdateSysAdmin(int id, SysAdminUpdateRequest sysadminUpdateRequest);
        void DeleteSysAdmin(int id);
    }
}
