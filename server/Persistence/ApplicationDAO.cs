
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
                return new NpgsqlConnection("Username=manager;Password=manager;Server=127.0.0.1;Port=5432;Database=ResumeManager;Integrated Security=true;Pooling=true;");
            }
        }

        // reads application with the given ID
        public static Application ReadApplication(int id){
            using(var db = Connection){
                string queryStr = "SELECT * FROM application WHERE ApplicationId = @Id";
                db.Open();
                return db.Query<Application>(queryStr, new { Id = id }).FirstOrDefault();
            }
        }

        //reads the most recent application AKA the one with the largest ID
        public static Application ReadApplication(){
            using(var db = Connection){
                string queryStr = "SELECT * FROM application ORDER BY \"ApplicationId\" DESC LIMIT 1;";
                db.Open();
                return db.Query<Application>(queryStr).FirstOrDefault();
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
                string queryStr = "INSERT INTO application "
                + "(\"ApplicationId\", \"FirstName\", \"LastName\", \"Email\", \"PositionId\", \"ResumePath\") "
                + "VALUES(@ApplicationId, @FirstName, @LastName, @Email, @PositionId, @ResumePath)";
                db.Open();
                db.Execute(queryStr, application);
            }
        }

        public static void DeleteApplication(int id){
            using(var db = Connection){
                string queryStr = "DELETE * FROM application WHERE ApplicationId = @Id";
                db.Open();
                db.Execute(queryStr, new { Id = id });
            }
        }
    }
}