using BL.BaseBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Don_Dang_Ky_Lam_Them.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        public IBaseBL<Department> _baseBL;
        public DepartmentsController(IBaseBL<Department> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }
    }
}
