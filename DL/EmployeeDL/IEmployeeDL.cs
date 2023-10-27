using Common.Entities;
using Common.Entities.DTO;
using DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DL.EmployeeDL
{
    public interface IEmployeeDL : IBaseDL<Employee>
    {
       
    }
}
