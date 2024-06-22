using ApiCrud.Students;
using ApirCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApirCrud.Students;

public static class StudentsEndpoints
{
    public static void AddEndpointsStudents(this WebApplication app)
    {
        var endpointsStudents = app.MapGroup("students");

        endpointsStudents.MapPost("", async (AddStudentRequest request, AppDbContext context) =>
        {
            var isNameTaken = await context.Students.AnyAsync(Student => Student.Name == request.Name);

            if (isNameTaken)
                return Results.Conflict("Name Already Exists!");

            var newStudent = new Student(request.Name);

            await context.Students.AddAsync(newStudent);
            await context.SaveChangesAsync();

            return Results.Ok(newStudent);
        });
    }
}