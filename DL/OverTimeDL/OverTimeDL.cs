using Common.Entities.DTO;
using Common.Entities;
using Common.Enums;
using Common;
using Dapper;
using DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.OverTimeDL
{
    public class OverTimeDL : BaseDL<OverTime>, IOverTimeDL
    {
        /// <summary>
        /// Lấy thông tin làm thêm theo id
        /// </summary>
        /// <param name="recordId">id làm thêm muốn lấy thông tin</param>
        /// <returns>thông tin làm thêm</returns>
        public ServiceResult GetOverTimeById(Guid recordId)
        {
            //chuẩn bị tên stored
            String storedProcedureName = $"Proc_Overtime_GetById";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_OverTimeId", recordId);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                OverTime record = dbConnection.QueryFirstOrDefault<OverTime>(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (record != null)
                {
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
                    return new ServiceResult(true, record);
                }
                else
                {
                    return new ServiceResult(false, Resource.ServiceResult_Fail);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(false, Resource.ServiceResult_Exception);
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
        public Dictionary<string, object> GetPaging(string? keyword, String? MISACode, int? status, int pageSize = 10, int offSet = 0)
        {
            if (MISACode == null)
            {
                MISACode = Resource.DefaultMISACode;
            }

            //chuẩn bị tên stored
            String storedProcedureName = "Proc_OverTime_Filter";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add("v_Where", keyword);
            paprameters.Add("v_Offset", offSet);
            paprameters.Add("v_Limit", pageSize);
            paprameters.Add("v_Status", status);
            paprameters.Add("v_Departmentid", MISACode);

            //kết nối tới database
            var dbConnection = GetOpenConnection();

            {
                //thực hiện câu lệnh sql
                var res = dbConnection.QueryMultiple(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                {
                    var overTimes = res.Read<OverTime>().ToList();
                    var amountData = res.Read<int>().First();

                    //đóng kết nối tới db
                    dbConnection.Close();

                    return new Dictionary<string, object>{
                    { "PageData", overTimes},
                    { "Total", amountData },
                    };
                }
            };

        }
    }
}
