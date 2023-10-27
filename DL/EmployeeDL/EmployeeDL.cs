using Dapper;
using MySqlConnector;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using Common.Entities.DTO;
using Common.Entities;
using DL.BaseDL;
//using LicenseContext = OfficeOpenXml.LicenseContext;

namespace DL.EmployeeDL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
        
    }
}
