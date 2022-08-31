using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Services
{
    public class Queries
    {
        public static string
            Init = "CREATE TABLE IF NOT EXISTS Post (\r\n    Id   INTEGER      PRIMARY KEY AUTOINCREMENT\r\n                      NOT NULL,\r\n    Name VARCHAR (60) NOT NULL\r\n);" +
            "CREATE TABLE IF NOT EXISTS Staff (\r\n    Id           INTEGER      PRIMARY KEY AUTOINCREMENT\r\n                              NOT NULL,\r\n    Name         VARCHAR (60) NOT NULL,\r\n    Surname      VARCHAR (60) NOT NULL,\r\n    Lastname     VARCHAR (60) NOT NULL,\r\n    Birthdate    DATETIME     NOT NULL,\r\n    Hireddate    DATETIME     NOT NULL,\r\n    PostId       INTEGER,\r\n    Money        DECIMAL,\r\n    DepartmentId INTEGER\r\n);" +
            "CREATE TABLE IF NOT EXISTS Department (\r\n    Id        INTEGER      PRIMARY KEY AUTOINCREMENT\r\n                           NOT NULL,\r\n    Name      VARCHAR (60) NOT NULL,\r\n    MasterId  INTEGER      NOT NULL,\r\n    CompanyId INTEGER      NOT NULL\r\n);" +
            "CREATE TABLE IF NOT EXISTS Company (\r\n    Id           INTEGER       PRIMARY KEY AUTOINCREMENT\r\n                               NOT NULL,\r\n    Name         VARCHAR (60)  NOT NULL,\r\n    LunticDate   DATETIME      NOT NULL,\r\n    PaperAddress VARCHAR (300) NOT NULL\r\n);",
            GetDepartments = "",
            GetCompanies = "",
            GetStaff = "",
            GetPosts = "",
            InsertDepartment = "",
            InsertCompany = "",
            InsertStaff = "",
            InsertPost = "",
            UpdateCompany = "",
            UpdateStaff = "",
            UpdatePost = "",
            UpdateDepartment = "",
            DeleteCompany = "",
            DeleteStaff = "",
            DeletePost = "",
            DeleteDepartment = "";
    }
}
