using Common.Entities;
using Common.Entities.DTO;
using DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DepartmentDL
{
    public interface IDepartmentDL : IBaseDL<Department>
    {
        /// <summary>
        /// Lấy thông tin phòng ban theo id
        /// </summary>
        /// <param name="departmentId">id phòng ban muốn lấy thông tin</param>
        /// <returns>thông tin nhân viên</returns>
        public ServiceResult GetDepartmentById(String departmentId);
    }
}
