using BL.BaseBL;
using BL.OverTimeDetailBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Don_Dang_Ky_Lam_Them.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverTimeDetailsController : BasesController<OverTimeDetail>
    {
        public IBaseBL<OverTimeDetail> _baseBL;
        public IOverTimeDetailBL _overtimebl;
        public OverTimeDetailsController(IBaseBL<OverTimeDetail> baseBL) : base(baseBL)
        {
            _baseBL = baseBL;
        }
    }
}
