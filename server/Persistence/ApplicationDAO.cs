
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
                // builder["User ID"] = "manager";
                // builder["Password"] = "manager";
                // builder["Host"] = "localhost:5432";
                // builder["Database"] = "ResumeManager";
                // return new NpgsqlConnection(builder.ConnectionString);
                return new NpgsqlConnection("Username=manager;Password=manager;Server=127.0.0.1;Port=5432;Database=ResumeManager;Integrated Security=true;Pooling=true;");
            }
        }
        public static Application ReadApplication(int id){
            using(var db = Connection){
                string queryStr = "SELECT * FROM application WHERE ApplicationId = @Id";
                db.Open();
                return db.Query<Application>(queryStr, new { Id = id }).FirstOrDefault();
            }
        }

        public static IEnumerable<Application> ReadAllApplications(){
            IEnumerable<Application> applications = null;
            try{
                using(var db = Connection){
                    string queryStr = "SELECT * FROM application";
                    db.Open();
                    applications = db.Query<Application>(queryStr);
                }
            }catch(NpgsqlException e){
                Console.Write(e.StackTrace);
            }
            return applications;
        }

        public static void CreateApplication(Application application){
            using(var db = Connection){
                string queryStr = "INSERT INTO application (FirstName, LastName, Email, PositionId, ResumePath) VALUES(@FirstName, @LastName, @Email, @PositionId, @ResumePath)";
                db.Open();
                db.Execute(queryStr, application);
            }
        }

        public static void DeleteApplication(int id){
            using(var db = Connection){
                string queryStr = "DELETE * FROM application WHERE ApplicationId = @ Id";
                db.Open();
                db.Execute(queryStr, new { Id = id });
            }
        }
    }
}