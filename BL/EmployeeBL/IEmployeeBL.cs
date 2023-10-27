using BL.BaseBL;
using Common.Entities;
using Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace BL.EmployeeBL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        
    }
}
