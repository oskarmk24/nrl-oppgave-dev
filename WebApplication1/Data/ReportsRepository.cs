using MySqlConnector;
using Dapper;

namespace WebApplication1.Data
{
    public class ReportsRepository
    {
        private readonly MySqlDataSource _ds;
        public ReportsRepository(MySqlDataSource ds) { _ds = ds; }

        public async Task<int> CreateAsync(string? name, decimal? height, string? desc, string? locJson)
        {
            const string sql = @"INSERT INTO obstacledb.Reports (ObstacleName, ObstacleHeight, ObstacleDescription, ObstacleLocation)VALUES (@ObstacleName, @ObstacleHeight, @ObstacleDescription, @ObstacleLocation);";

            await using var conn = await _ds.OpenConnectionAsync();
            int rows = await conn.ExecuteAsync(sql, new
            {
                ObstacleName = name,
                ObstacleHeight = height,
                ObstacleDescription = desc,
                ObstacleLocation = locJson
            });
            int id = await conn.ExecuteScalarAsync<int>("SELECT LAST_INSERT_ID();");
            return rows == 1 ? id : 0;
        }
    }
}
