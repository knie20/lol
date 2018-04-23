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
    public class PositionDAO
    {

        private static IConfiguration _config;

        public PositionDAO(IConfiguration configuration){
            _config = configuration;
        }
        private static IDbConnection Connection{
            get{
                return new NpgsqlConnection(_config["ConnectionStrings:Postgresql"]);
            }
        }

        public static IEnumerable<Position> ReadAllPositions(){
                using(var db = Connection){
                    string queryStr = "SELECT * FROM position";
                    db.Open();
                    return db.Query<Position>(queryStr);
                }
        }

        public static Position ReadPosition(string positionName){
            using(var db = Connection){
                    string queryStr = "SELECT * FROM position WHERE \"PositionName\" = @PositionName";
                    db.Open();
                    return db.Query<Position>(queryStr, new { PositionName = positionName }).FirstOrDefault();
            }
        }

        public static void AddPosition(Position position){
            using(var db = Connection){
                string queryStr = "INSERT INTO position (PositionId, PositionName) VALUES(@PositionId, @PositionName)";
                db.Open();
                db.Execute(queryStr, position);
            }
        }

        public static void RemovePosition(int id){
            using(var db = Connection){
                string queryStr = "DELETE * FROM position WHERE PositionId = @Id";
                db.Open();
                db.Execute(queryStr, new { Id = id });
            }
        }
    }
}