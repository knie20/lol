
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using server.Models;

namespace server.Persistence
{
    public class ApplicationDAO
    {
        private static IDbConnection Connection{
            get{
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Username"] = "manager";
                builder["Password"] = "manager";
                builder["Host"] = "localhost";
                builder["Port"] = 5432;
                builder["Database"] = "ResumeManager.dev";
                return new SqlConnection(builder.ConnectionString);
                // return new SqlConnection("Username=manager;Password=manager;Server=localhost;Port=5432;Database=ResumeManager.Dev;Integrated Security=true;Pooling=true;");
            }
        }
        public static Application ReadApplication(int id){
            using(var db = Connection){
                string queryStr = "SELECT * FROM public.Application WHERE ApplicationID = @Id";
                db.Open();
                return db.Query<Application>(queryStr, new { Id = id }).FirstOrDefault();
            }
        }

        public static IEnumerable<Application> ReadAllApplications(){
            using(var db = Connection){
                string queryStr = "SELECT * FROM public.Applcation";
                db.Open();
                return db.Query<Application>(queryStr);
            }
        }

        public static void CreateApplication(Application application){
            using(var db = Connection{
                string queryStr = "INSERT INTO public.Application (FirstName, LastName, Email, PositionId, ResumePath) VALUES(@FirstName, @LastName, @Email, @PositionId, @ResumePath)";
                db.Open();
                db.Execute(queryStr, application);
            }
        }

        public static void DeleteApplication(int id){
            using(var db = Connection{
                string queryStr = "DELETE * FROM public.Application WHERE ApplicationId = @ Id";
                db.Open();
                db.Execute(queryStr, new { Id = id });
            }
        }
    }
}