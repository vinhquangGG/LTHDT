using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DTO
{
    public class ExportDataParams
    {
        /// <summary>
        /// Từ khoá tìm kiếm
        /// </summary>
        public string keyword { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int total { get; set; }
    }
}
