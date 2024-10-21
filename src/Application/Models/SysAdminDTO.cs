using Domain.Entities;

namespace Application.Models
{
    public class SysAdminDTO
    {
        public int Id { get; set; }
        public string SysAdminname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static SysAdminDTO Create(SysAdmin sysadmin)
        {
            return new SysAdminDTO
            {
                Id = sysadmin.Id,
                SysAdminname = sysadmin.Username,
                Name = sysadmin.Name,
                LastName = sysadmin.LastName,
                Email = sysadmin.Email,
            };
        }

        public static List<SysAdminDTO> CreateList(IEnumerable<SysAdmin> sysAdmins)
        {
            List<SysAdminDTO> listDto = new List<SysAdminDTO>();
            foreach (var sysAdmin in sysAdmins)
            {
                listDto.Add(Create(sysAdmin));
            }
            return listDto;
        }
    }
}
