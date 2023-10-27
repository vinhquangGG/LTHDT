using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DTO
{
    public class ExportBody
    {
        public OverTimesExportDataParams param { get; set; }

        public List<HeaderType> header { get; set; }
    }
}
