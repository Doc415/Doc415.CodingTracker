﻿using Dapper;
using Microsoft.Data.Sqlite;

namespace Doc415.CodingTracker;

internal class DataAccess
{
    private string ConnectionString;
    public DataAccess(string _connectionString)
    {
        ConnectionString = _connectionString;
    }
    internal void CreateDatabase()
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS records(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DateStart TEXT NOT NULL,
                    DateEnd TEXT NOT NULL)";
            connection.Execute(createTableQuery);
        }
    }

    internal void InsertRecord(CodingRecord record)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            string insertQuery = @"
        INSERT INTO records (DateStart, DateEnd)
        VALUES (@DateStart, @DateEnd)";

            connection.Execute(insertQuery, new { record.DateStart, record.DateEnd });
        }
    }
}
