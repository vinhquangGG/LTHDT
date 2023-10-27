using BL.BaseBL;
using BL.EmployeeBL;
using Dapper;
using Common;
using Common.Entities;
using Common.Entities.DTO;
using Common.Enums;
using DL.BaseDL;
using DL.EmployeeDL;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Common.Attibutes.Attributes;
using Color = System.Drawing.Color;

namespace BL.EmployeeBL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Field

        public IEmployeeDL _employeeDL;
        public IBaseDL<Employee> _baseDL;

        #endregion

        #region Constructor

        public EmployeeBL(IEmployeeDL employeeDL, IBaseDL<Employee> baseDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
            _baseDL = baseDL;
        }

        #endregion
    }
}
