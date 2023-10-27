using Dapper;
using Common;
using Common.Entities;
using Common.Entities.DTO;
using DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Attibutes.Attributes;

namespace DL.BaseDL
{
    public class BaseDL<T> : IBaseDL<T>
    {

        #region Method
        /// <summary>
        /// Kết nối tới database
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenConnection()
        {
            var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString);
            mySqlConnection.Open();
            return mySqlConnection;
        }

        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        /// <returns>Danh sách toàn bộ các bản ghi</returns>
        public ServiceResult GetAllRecords()
        {
            //chuẩn bị tên stored
            String storedProcedureName = $"Proc_{typeof(T).Name}_GetAll";

            var dbConnection = GetOpenConnection();

            //thực hiện câu lệnh sql
            //var trans = dbConnection.BeginTransaction();
            try
            {

                var response = dbConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();
                if (response != null)
                {
                    return new ServiceResult(true, response);
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
        /// Xoá bản ghi theo id 
        /// </summary>
        /// <param name="recordId">id bản ghi muốn xoá</param>
        /// <returns>trạng thái thực hiện câu lệnh sql</returns>
        public ServiceResult DeleteRecordById(Guid recordId)
        {
            //chuẩn bị tên stored
            String storedProcedureName = $"Proc_{typeof(T).Name}_DeleteById";

            //chuẩn bị tham số đầu vào
            var paprameters = new DynamicParameters();
            paprameters.Add($"v_{typeof(T).Name}Id", recordId);

            var dbConnection = GetOpenConnection();

            //thực hiện câu lệnh sql
            try
            {
                var affectedRow = dbConnection.Execute(storedProcedureName, paprameters, commandType: System.Data.CommandType.StoredProcedure);

                dbConnection.Close();

                if (affectedRow > 0)
                {
                    return new ServiceResult(true, Resource.ServiceResult_Success);
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
        #endregion
    }
}
