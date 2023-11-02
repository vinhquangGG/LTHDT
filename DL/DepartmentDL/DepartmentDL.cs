using Common;
using Common.Entities;
using Common.Entities.DTO;
using Dapper;
using DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DepartmentDL
{
    public class DepartmentDL: BaseDL<Department>, IDepartmentDL
    {
        /// <summary>
        /// Lấy thông tin phòng ban theo id
        /// </summary>
        /// <param name="departmentId">id phòng ban muốn lấy thông tin</param>
        /// <returns>thông tin nhân viên</returns>
        public ServiceResult GetDepartmentById(String departmentId)
        {
            //chuẩn bị tên stored
            String storedProcedureName = $"Proc_Department_GetById";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_DepartmentId", departmentId);

            //khởi tạo kết nối tới DB

            var dbConnection = GetOpenConnection();


            //thực hiện câu lệnh sql
            try
            {
                Department record = dbConnection.QueryFirstOrDefault<Department>(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (record != null)
                {
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
    }
}
