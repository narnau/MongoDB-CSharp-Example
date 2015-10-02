﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBExample.Queries;
using MongoDB.Driver;
using MongoDBExample.Models;
using MongoDBExample.Mappers;
using System.Data.SqlClient;
using System.Data;
using MongoDBExample.DBConnection;

namespace MongoDBExample.Repository
{
    public class SQLServerRepository<TEntity> : IRepository<IEnumerable<BsonDocument>, string, IList<FilterQuery>, TEntity>
    {
        private string document;
        private IMapper<TEntity, BsonDocument> mapper;

        public SQLServerRepository(string document, IMapper<TEntity, BsonDocument> mapper)
        {
            this.document = document;
            this.mapper = mapper;
        }

        public IEnumerable<BsonDocument> GetById(string id)
        {
            var sqlServerConnection = new SQLServerConnection();
            using (SqlConnection con = sqlServerConnection.GetDatabase(null))
            {
                //
                // Open the SqlConnection.
                //
                sqlServerConnection.OpenConnection();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT TOP 1000 [Id] FROM[ORMTest].[dbo].[ParameterValues]", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}",
                        reader.GetGuid(0));
                    }
                }
                sqlServerConnection.CloseConnection();
            }
            throw new NotImplementedException();
        }

        public IEnumerable<BsonDocument> GetFiltered(IList<FilterQuery> query)
        {
            throw new NotImplementedException();
        }

        public bool Create(TEntity recurse)
        {
            throw new NotImplementedException();
        }
    }
}