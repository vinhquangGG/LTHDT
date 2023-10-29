using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.OverTimeDetailBL
{
    public interface IOverTimeDetailBL
    {
        public object GetAllRecordById(OverTime data, Guid id);
    }
}
