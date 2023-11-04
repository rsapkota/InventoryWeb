﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace InventoryApi
{
	public class DataAccess
    {
        public static string connString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private SqlDataReader sdr;

        public int NoOfRowAffected;
        private readonly IConfiguration _configuration;

        public string DbConn;
        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            DbConn = _configuration.GetConnectionString("DefaultConnection");
            NoOfRowAffected = 0;
        }
        public int ExecuteNonQuerySP(string sql, List<SqlParameter> param)
        {
            SqlConnection conn = new SqlConnection(DbConn);
           conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in param)
            {
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            }
            NoOfRowAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return NoOfRowAffected;
        }

        public DataTable ExecuteDataTable(string sql, List<SqlParameter> param)
        {
            SqlConnection conn = new SqlConnection(DbConn);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter p in param)
            {
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            }
            DataTable dtResult = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dtResult);
            conn.Close();
            return dtResult;
        }
    }
}
