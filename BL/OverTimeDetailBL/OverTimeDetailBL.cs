using BL.BaseBL;
using Common.Entities;
using Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.OverTimeDetailBL
{
    public class OverTimeDetailBL : IBaseBL<OverTimeDetail>, IOverTimeDetailBL
    {
        public ServiceResult DeleteRecordById(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public object GetAllRecordById(OverTime data, Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public ServiceResult InsertRecord(OverTimeDetail record)
        {
            throw new NotImplementedException();
        }

        public ServiceResult UpdateRecord(Guid recordId, OverTimeDetail record)
        {
            throw new NotImplementedException();
        }
    }
}
