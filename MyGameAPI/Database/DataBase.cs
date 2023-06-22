using MyGameAPI.Models;
using Npgsql;
using System;

namespace MyGameAPI
{
    public class DataBase
    {
        NpgsqlConnection con = new NpgsqlConnection(DBConst.Connect);
        public async Task InsertGameNameAsync(long massage, string gameName, string storeLink)
        {
            if(storeLink=="Not Found")
            {
                return;
            }
            var sql = "insert into public.\"GameList\"(\"ChatId\",\"GameName\",\"StoreLink\")"
                    + $"values(@ChatId, @GameName,@StoreLink)";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("ChatId", massage);
            comm.Parameters.AddWithValue("GameName", gameName);
            comm.Parameters.AddWithValue("StoreLink", storeLink);
            await con.OpenAsync();
            await comm.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
        public async Task Delete(long Id)
        {
            
            var sql = $"DELETE FROM \"GameList\" where \"ChatId\"={Id}";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            await con.OpenAsync();
            comm.ExecuteReader();
             con.Close();
        }
        public async Task<List<Data>> GetDataAsync(long ID)
        {
            List<Data> data = new List<Data>();
            var sql = $"SELECT \"GameName\", \"StoreLink\" FROM \"GameList\" where \"ChatId\"={ID}";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            await con.OpenAsync();
            NpgsqlDataReader npgsqlDataReader = await comm.ExecuteReaderAsync();
            while (await npgsqlDataReader.ReadAsync())
            {
                data.Add(new Data {GameName=npgsqlDataReader.GetString(0), StoreLink = npgsqlDataReader.GetString(1) });
            }
            await con.CloseAsync();
            return data;
        }
    }
}
