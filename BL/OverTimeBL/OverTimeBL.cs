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

    }
}
