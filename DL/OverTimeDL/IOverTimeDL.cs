using Common.Entities.DTO;
using Common.Entities;
using DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.OverTimeDL
{
    public interface IOverTimeDL : IBaseDL<OverTime>
    {
        /// <summary>
        /// Lấy thông tin làm thêm theo id
        /// </summary>
        /// <param name="recordId">id làm thêm muốn lấy thông tin</param>
        /// <returns>thông tin làm thêm</returns>
        public ServiceResult GetOverTimeById(Guid recordId);

        /// <summary>
        /// Phân trang bảng làm thêm
        /// </summary>
        /// <param name="keyword">Tên hoặc mã nhân viên</param>
        /// <param name="MISACode">mã phòng ban</param>
        /// <param name="status">trạng thái</param>
        /// <param name="pageSize">số bản ghi trên trang</param>
        /// <param name="offSet">bản ghi bắt đầu</param>
        /// <returns>mảng các bản ghi được lọc</returns>
        public Dictionary<string, object> GetPaging(
            String? keyword,
            String? MISACode,
            int? status,
            int pageSize = 10,
            int offSet = 0
            );
    }
}
