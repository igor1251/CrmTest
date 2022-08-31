using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using CRM.Core.Models;

namespace CRM.Core.Services
{
    public class CrmRepo
    {
        const string 
            logFolder = "log", 
            dbFolder = "db", 
            dbPath = @$"{dbFolder}\db.sqlite", 
            logPath = @$"{logFolder}\info.log";
        readonly SQLiteConnection dbConnection = new($"Data Source = {dbPath}");

        #region Auxiliary methods

        async Task LogAsync(LogMessageType type, string message)
        {
            var messageType = "[ EXECUTING ]";
            switch (type)
            {
                case LogMessageType.Error: messageType = "[ ERROR ]"; break;
                case LogMessageType.Warning: messageType = "[ WARNING ]"; break;
                case LogMessageType.Success: messageType = "[ SUCCESS ]"; break;
            }
            await File.AppendAllTextAsync(logPath, $"{messageType}\t{DateTime.Now}\t{message}\n");
        }

        public async Task InvokeAsync(Func<Task> func, string taskDescription)
        {
            try
            {
                await LogAsync(LogMessageType.None, taskDescription);
                await func.Invoke();
                await LogAsync(LogMessageType.None, "Done.");
            }
            catch (Exception ex)
            {
                await LogAsync(LogMessageType.Error, ex.Message);
            }
        }

        public async Task<T> InvokeAsync<T>(Func<Task<T>> func, string taskDescription) where T : new()
        {
            try
            {
                await LogAsync(LogMessageType.None, taskDescription);
                var result = await func.Invoke();
                await LogAsync(LogMessageType.None, "Done.");
                return result ?? new();
            }
            catch (Exception ex)
            {
                await LogAsync(LogMessageType.Error, ex.Message);
            }
            return new();
        }

        #endregion

        public CrmRepo()
        {
            if (!Directory.Exists(logFolder)) Directory.CreateDirectory(logFolder);
            if (!Directory.Exists(dbFolder)) Directory.CreateDirectory(dbFolder);
        }

        public async Task InitRepoAsync() => await InvokeAsync(async () => await dbConnection.ExecuteAsync(Queries.Init), "Initializing repo....");


        async Task<List<T>> LoadDefaultAsync<T>(string query, string taskDescription)
        {
            return await InvokeAsync(async () => (await dbConnection.QueryAsync<T>(query)).ToList(), taskDescription);
        }

        public async Task<List<Company>> LoadCompaniesAsync()
        {
            return await LoadDefaultAsync<Company>(Queries.GetCompanies, "Loading companies list...");
        }

        public async Task<List<Department>> LoadDepartmentsAsync()
        {
            return await LoadDefaultAsync<Department>(Queries.GetDepartments, "Loading departments list...");
        }

        public async Task<List<Post>> LoadPostsAsync()
        {
            return await LoadDefaultAsync<Post>(Queries.GetPosts, "Loading posts list...");
        }

        public async Task<List<Staff>> LoadStaffAsync()
        {
            return await LoadDefaultAsync<Staff>(Queries.GetStaff, "Loading staffs list...");
        }

        public async Task InsertCompanyAsync(Company company)
        {
            await InvokeAsync(async () =>
            {
                await dbConnection.ExecuteAsync(Queries.InsertCompany, new
                {
                    Id = company.Id,
                    Name = company.Name,
                    LunticDate = company.LunticDate,
                    PaperAddress = company.PaperAddress,
                });
            }, 
            $"Inserting new company: \"{company.Info.Replace("\n", "; ")}\"");
        }

        public async Task InsertDepartmentAsync(Department department)
        {
            await InvokeAsync(async () =>
            {
                await dbConnection.ExecuteAsync(Queries.InsertDepartment, new
                {
                    Id = department.Id,
                    Name = department.Name,
                    MasterId = department.Master.Id,
                });
            },
            $"Inserting new department: \"{department.Info.Replace("\n", "; ")}\"");
        }

        public async Task InsertStaffAsync(Staff staff)
        {
            await InvokeAsync(async () =>
            {
                await dbConnection.ExecuteAsync(Queries.InsertStaff, new
                {
                    Id = staff.Id,
                    Name = staff.Name,
                    Surname = staff.Surname,
                    Lastname = staff.Lastname,
                    Birthdate = staff.Birthdate,
                    Hireddate = staff.Hireddate,
                    Money = staff.Money,
                });
            },
            $"Inserting new staff: \"{staff.Info.Replace("\n", "; ")}\"");
        }
    }
}
