using School.Models;
using Dapper;
using School.Utilities;
using School.Repositories;
using School.DTOs;

namespace School.Repositories;

public interface ISubjectsRepository
{

    Task<Subjects> GetById(long SubjectId);
    Task<List<Subjects>> GetList();

    Task<List<SubjectsDTO>> GetSubjectsByStudentId(long StudentId);

}
public class SubjectsRepository : BaseRepository, ISubjectsRepository
{
    public SubjectsRepository(IConfiguration config) : base(config)
    {

    }



    public async Task<Subjects> GetById(long SubjectId)
    {
       var query = $@"SELECT * FROM ""{TableNames.subjects}"" 
        WHERE subject_id = @SubjectId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Subjects>(query, new { SubjectId });
    }

    public async Task<List<Subjects>> GetList()
    {
        var query = $@"SELECT * FROM ""{TableNames.subjects}""";

        List<Subjects> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Subjects>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<List<SubjectsDTO>> GetSubjectsByStudentId(long StudentId)
    {
         var query = $@"SELECT * FROM {TableNames.student_subject} ss 
        LEFT JOIN {TableNames.subjects} s ON s.subject_id = ss.subject_id
         WHERE ss.student_id = @StudentId";

        using (var con = NewConnection)
        {
           // var ids =(await con.QueryAsync(query, new { Id })).AsList();
           // query = $@"SELECT * FROM {TableNames.teacher} WHERE id = {ids}";
            return (await con.QueryAsync<SubjectsDTO>(query, new { StudentId })).AsList();
       }
    }
}