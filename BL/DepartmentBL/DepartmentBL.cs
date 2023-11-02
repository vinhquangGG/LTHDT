using BL.BaseBL;
using Common.Entities;
using Common.Entities.DTO;
using DL.BaseDL;
using DL.DepartmentDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DepartmentBL
{
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        public IBaseDL<Department> _baseDL;
        public IDepartmentDL _departmentDL; 
        public DepartmentBL(IBaseDL<Department> baseDL, IDepartmentDL departmentDL) : base(baseDL)
        {
            _baseDL = baseDL;
            _departmentDL = departmentDL;
        }
        /// <summary>
        /// Lấy thông tin phòng ban theo id
        /// </summary>
        /// <param name="departmentId">id phòng ban muốn lấy thông tin</param>
        /// <returns>thông tin nhân viên</returns>
        public ServiceResult GetDepartmentById(String departmentId)
        {
            return _departmentDL.GetDepartmentById(departmentId);
        }
    }
}
