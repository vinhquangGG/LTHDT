using BL.BaseBL;
using Common.Entities.DTO;
using Common.Entities;
using Common.Enums;
using Common;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DL.OverTimeDL;
using BL.OverTimeDetailBL;

namespace BL.OverTimeBL
{
    public class OverTimeBL : BaseBL<OverTime>, IOverTimeBL
    {
        #region Field

        public IOverTimeDL _overTimeDL;
        public IOverTimeDetailBL _overTimeDetailBL;


        #endregion

        #region Constructor

        public OverTimeBL(IOverTimeDL overTimeDL, IOverTimeDetailBL overTimeDetailBL) : base(overTimeDL)
        {
            _overTimeDL = overTimeDL;
            _overTimeDetailBL = overTimeDetailBL;
        }
        public OverTimeBL(IOverTimeDL overTimeDL) : base(overTimeDL)
        {
            _overTimeDL = overTimeDL;
        }
        #endregion
        /// <summary>
        /// Lấy thông tin làm thêm theo id
        /// </summary>
        /// <param name="recordId">id làm thêm muốn lấy thông tin</param>
        /// <returns>thông tin làm thêm</returns>
        public ServiceResult GetOverTimeById(Guid recordId)
        {
            var record = _overTimeDL.GetOverTimeById(recordId);
            if (record.IsSuccess == true)
            {
                var overtime = _overTimeDetailBL.GetAllRecordById((OverTime)record.Data, (Guid)recordId);
                return new ServiceResult(true, overtime);
            }
            else
            {
                return record;
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
        public OverTimeFilterResult GetPaging(string? keyword, String? MISACode, int? status, int pageSize = 10, int offSet = 0)
        {
            var result = _overTimeDL.GetPaging(keyword, MISACode, status, pageSize, offSet);

            var totalRecord = result["Total"];
            var resultArray = (List<OverTime>)result["PageData"];


            foreach (OverTime record in resultArray)
            {
                //gán tên trạng thái theo trạng thái
                if (record.Status == Status.All)
                {
                    record.StatusName = Resource.Status_All;
                }
                else if (record.Status == Status.Wait)
                {
                    record.StatusName = Resource.Status_Wait;
                }
                else if (record.Status == Status.Approved)
                {
                    record.StatusName = Resource.Status_Approved;
                }
                else
                {
                    record.StatusName = Resource.Status_Denied;
                }

                //gán tên thời điểm làm thêm theo thời điểm làm thêm
                if (record.OverTimeInWorkingShiftName == OverTimeInWorkingShift.BeforeShift)
                {
                    record.OverTimeInWorkingShift = Resource.OverTimeInWorkingShift_BeforeShift;
                }
                else if (record.OverTimeInWorkingShiftName == OverTimeInWorkingShift.AfterShift)
                {
                    record.OverTimeInWorkingShift = Resource.OverTimeInWorkingShift_AfterShift;
                }
                else if (record.OverTimeInWorkingShiftName == OverTimeInWorkingShift.MiddleShift)
                {
                    record.OverTimeInWorkingShift = Resource.OverTimeInWorkingShift_MiddleShift;
                }
                else
                {
                    record.OverTimeInWorkingShift = Resource.OverTimeInWorkingShift_DayOff;
                }

                //gán tên Ca làm thêm theo Ca làm thêm
                if (record.WorkingShiftName == WorkingShift.FirstCase)
                {
                    record.WorkingShift = Resource.WorkingShift_FirstCase;
                }
                else if (record.WorkingShiftName == WorkingShift.SecondCase)
                {
                    record.WorkingShift = Resource.WorkingShift_SecondCase;
                }
                else if (record.WorkingShiftName == WorkingShift.NightCase)
                {
                    record.WorkingShift = Resource.WorkingShift_NightCase;
                }
                else
                {
                    record.WorkingShift = Resource.WorkingShift_InWork;
                }
            }

            //index bản ghi đầu của trang luôn >=1
            var begin = (offSet + 1) > 0 ? (offSet + 1) : 1;

            //index bản ghi cuối của trang luôn <= tổng số bản ghi
            var end = (begin + pageSize) <= Convert.ToInt32(totalRecord) ? (begin + pageSize - 1) : Convert.ToInt32(totalRecord);

            return new OverTimeFilterResult(resultArray, Convert.ToInt32(totalRecord), begin, end);
        }
    }
}
