using BL.BaseBL;
using BL.DepartmentBL;
using Common;
using Common.Entities;
using Common.Entities.DTO;
using Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Don_Dang_Ky_Lam_Them.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        public IBaseBL<Department> _baseBL;
        public IDepartmentBL _departmentBL;
        public DepartmentsController(IBaseBL<Department> baseBL, IDepartmentBL departmentBL) : base(baseBL)
        {
            _baseBL = baseBL;
            _departmentBL = departmentBL;
        }
        /// <summary>
        /// API Lấy thông tin chi tiết 1 phòng ban
        /// </summary>
        /// <param name="id">ID phòng ban muốn lấy</param>
        /// <returns>Đối tượng phòng ban</returns>
        [HttpGet("{id}")]
        public IActionResult GetDepartmentById([FromRoute] String id)
        {
            try
            {
                var serviceResult = _departmentBL.GetDepartmentById(id);

                if (serviceResult.IsSuccess == true)
                {
                    return StatusCode(200, serviceResult.Data);
                }
                else
                {
                    if (serviceResult.Data == Resource.ServiceResult_Fail)
                    {
                        return StatusCode(204, new ErrorResult
                        {
                            ErrorCode = ErrorCode.SqlReturnNull,
                            DevMsg = Resource.ServiceResult_Fail,
                            UserMsg = Resource.UserMsg_Exception,
                            TradeId = HttpContext.TraceIdentifier,
                        });
                    }
                    else
                    {
                        return StatusCode(500, new ErrorResult
                        {
                            ErrorCode = ErrorCode.SqlCatchException,
                            DevMsg = Resource.ServiceResult_Exception,
                            UserMsg = Resource.UserMsg_Exception,
                            TradeId = HttpContext.TraceIdentifier,
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TradeId = HttpContext.TraceIdentifier,
                });
            }

        }
    }
}
