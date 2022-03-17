using School.Models;
using Dapper;
using School.Utilities;
using School.Repositories;


namespace School.Repositories;

public interface IClassRoomRepository
{

    Task<ClassRoom> GetById(long ClassId);
    Task<List<ClassRoom>> GetList();

}
public class ClassRoomRepository : BaseRepository, IClassRoomRepository
{
    public ClassRoomRepository(IConfiguration config) : base(config)
    {

    }




    public async Task<ClassRoom> GetById(long ClassId)
    {
       var query = $@"SELECT * FROM ""{TableNames.classroom}"" 
        WHERE class_id = @ClassId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<ClassRoom>(query, new { ClassId });
    }

    public async Task<List<ClassRoom>> GetList()
    {
        var query = $@"SELECT * FROM ""{TableNames.classroom}""";

        List<ClassRoom> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<ClassRoom>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }
}