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
using server.Utils;

namespace server.Persistence
{
    public class AuthDAO
    {

        private static IConfiguration _config;

        public AuthDAO(IConfiguration configuration){
            _config = configuration;
        }
        private static IDbConnection Connection{
            get{
                return new NpgsqlConnection(_config["ConnectionStrings:Postgresql"]);
            }
        }

        public static void AddAccount(LoginCredentials login){
            using(var db = Connection){
                string queryStr = "INSERT INTO auth (\"Username\", \"Email\", \"HashedPw\") VALUES(@Username, @Email, @HashedPw)";
                db.Open();
                db.Execute(queryStr, login);
            }
        }

        public static LoginCredentials ReadAccount(string username){
          using(var db = Connection){
                string queryStr = "SELECT * from auth WHERE \"Username\" = @Username";
                db.Open();
                return db.Query<LoginCredentials>(queryStr, new { Username = username}).FirstOrDefault();
            }
        }

        public static void RemoveAccount(string username){
            using(var db = Connection){
                string queryStr = "DELETE * FROM auth WHERE \"Username\" = @Username";
                db.Open();
                db.Execute(queryStr, new { Username = username });
            }
        }
    }
}