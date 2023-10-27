using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Hosting.Server;
using MySqlConnector;
using DL.EmployeeDL;
using Common.Entities;
using Common.Entities.DTO;
using Common.Enums;
using Common;
using BL.EmployeeBL;
using DocumentFormat.OpenXml.Bibliography;
using Don_Dang_Ky_Lam_Them.API.Controllers;

//test exception
//throw new NotImplementedException();

namespace API.Controllers
{
    [Route("api/v1/[controller]")] //attribute: http://localhost:43154/api/[controller]
    [ApiController]
    public class EmployeesController : BasesController<Employee>
    {
        #region Field

        private IEmployeeBL _employeeBL;

        #endregion

        #region Constructor
        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        #endregion

    }


}
