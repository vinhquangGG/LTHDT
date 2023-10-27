using BL.BaseBL;
using Common.Entities;
using DL.BaseDL;
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
        public DepartmentBL(IBaseDL<Department> baseDL) : base(baseDL)
        {
            _baseDL = baseDL;
        }
    }
}
