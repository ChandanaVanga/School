using School.Models;
using Dapper;
using School.Utilities;
using School.Repositories;


namespace School.Repositories;

public interface IStudentRepository
{
    Task<Student> Create(Student Item);
    Task<bool> Update(Student Item);
    // Task<bool> Delete(long EmployeeNumber);
    Task<Student> GetById(long StudentId);
    Task<List<Student>> GetList();

}
public class StudentRepository : BaseRepository, IStudentRepository
{
    public StudentRepository(IConfiguration config) : base(config)
    {

    }

  

    public async Task<Student> Create(Student Item)
    {
       var query = $@"INSERT INTO ""{TableNames.student}"" 
        (student_id, student_name, gender, parent_mobile) 
        VALUES (@StudentId, @StudentName, @Gender, @ParentMobile) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Student>(query, Item);
            return res;
        }
    }


    public async Task<bool> Update(Student Item)
    {
       var query = $@"UPDATE ""{TableNames.student}"" SET  
        student_name = @StudentName WHERE student_id = @StudentId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }

    public async Task<Student> GetById(long StudentId)
    {
       var query = $@"SELECT * FROM ""{TableNames.student}"" 
        WHERE student_id = @StudentId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Student>(query, new { StudentId });
    }

     public async Task<List<Student>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.student}""";

        List<Student> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Student>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }
}