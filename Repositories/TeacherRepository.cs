using School.Models;
using Dapper;
using School.Utilities;
using School.Repositories;
using School.DTOs;

namespace School.Repositories;

public interface ITeacherRepository
{
    Task<Teacher> Create(Teacher Item);
    Task<bool> Update(Teacher Item);
    // Task<bool> Delete(long EmployeeNumber);
    Task<Teacher> GetById(long TeacherId);
    Task<List<Teacher>> GetList();

    Task<List<TeacherDTO>> GetTeacherByStudentId(long StudentId);

}
public class TeacherRepository : BaseRepository, ITeacherRepository
{
    public TeacherRepository(IConfiguration config) : base(config)
    {

    }


    public async Task<Teacher> Create(Teacher Item)
    {
       var query = $@"INSERT INTO ""{TableNames.teacher}"" 
        (teacher_id, teacher_name, mobile, date_of_joining) 
        VALUES (@TeacherId, @TeacherName, @Mobile, @DateOfJoining) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Teacher>(query, Item);
            return res;
        }
    }


    public async Task<bool> Update(Teacher Item)
    {
        var query = $@"UPDATE ""{TableNames.teacher}"" SET  
        teacher_name = @TeacherName, gender = @Gender, mobile = @Mobile, 
        date_of_joining = @DateOfJoining WHERE teacher_id = @TeacherId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }

    public async Task<Teacher> GetById(long TeacherId)
    {
      var query = $@"SELECT * FROM ""{TableNames.teacher}"" 
        WHERE teacher_id = @TeacherId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Teacher>(query, new { TeacherId });
    }

    public async Task<List<Teacher>> GetList()
    {
        var query = $@"SELECT * FROM ""{TableNames.teacher}""";

        List<Teacher> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Teacher>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<List<TeacherDTO>> GetTeacherByStudentId(long StudentId)
    {
        var query = $@"SELECT t.*, s.subject_name AS subject_name FROM {TableNames.student_teacher} st 
        LEFT JOIN {TableNames.teacher} t ON t.teacher_id = st.teacher_id
        LEFT JOIN {TableNames.subjects} s ON s.subject_id = t.subject_id
        WHERE st.student_id = @StudentId";

        using (var con = NewConnection)
        {

            return (await con.QueryAsync<TeacherDTO>(query, new { StudentId })).AsList();
        }
    }
}