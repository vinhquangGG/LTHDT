using Common.Entities;
using Common.Entities.DTO;
using DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.OverTimeDetailDL
{
    public class OverTimeDetailDL : IBaseDL<OverTimeDetail>, IOverTimeDetailDL
    {
        public ServiceResult CheckDuplicateID(string id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteRecordById(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public IDbConnection GetOpenConnection()
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
