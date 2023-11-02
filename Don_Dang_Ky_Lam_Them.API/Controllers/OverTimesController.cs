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
        /// <summary>
        /// API Lấy thông tin chi tiết làm thêm
        /// </summary>
        /// <param name="id">ID làm thêm muốn lấy</param>
        /// <returns>Đối tượng làm thêm</returns>
        [HttpGet("{id}")]
        public IActionResult GetOverTimeById([FromRoute] Guid id)
        {
            try
            {
                var serviceResult = _overTimeBL.GetOverTimeById(id);

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


        /// <summary>
        /// Phân trang bảng làm thêm
        /// </summary>
        /// <param name="keyword">Tên hoặc mã nhân viên</param>
        /// <param name="MISACode">mã phòng ban</param>
        /// <param name="status">trạng thái</param>
        /// <param name="pageSize">số bản ghi trên trang</param>
        /// <param name="offSet">bản ghi bắt đầu</param>
        /// <returns>mảng các bản ghi được lọc</returns>
        [HttpGet("Filter")]
        public IActionResult GetPaging(
            [FromQuery] String? keyword,
            [FromQuery] String? MISACode,
            [FromQuery] int? status,
            [FromQuery] int pageSize = 10,
            [FromQuery] int offSet = 0
            )
        {
            try
            {
                var pagingData = _overTimeBL.GetPaging(keyword, MISACode, status, pageSize, offSet);

                if (pagingData != null)
                {
                    return StatusCode(200, pagingData);
                }
                else
                {
                    return StatusCode(204, new ErrorResult
                    {
                        ErrorCode = ErrorCode.SqlReturnNull,
                        DevMsg = Resource.ServiceResult_Fail,
                        UserMsg = Resource.UserMsg_Exception,
                        TradeId = HttpContext.TraceIdentifier,
                    });
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
