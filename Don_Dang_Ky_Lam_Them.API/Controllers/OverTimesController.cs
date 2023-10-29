using Common.Entities.DTO;
using Common.Entities;
using Common.Enums;
using Common;
using Don_Dang_Ky_Lam_Them.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using BL.OverTimeBL;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OverTimesController : BasesController<OverTime>
    {
        #region Field

        private IOverTimeBL _overTimeBL;

        #endregion

        #region Constructor
        public OverTimesController(IOverTimeBL overTimeBL) : base(overTimeBL)
        {
            _overTimeBL = overTimeBL;
        }
        #endregion
    }
}
