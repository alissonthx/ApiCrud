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

            var studentReturn = new StudentDto(newStudent.Id, newStudent.Name);

            return Results.Ok(newStudent);
        });

        endpointsStudents.MapGet("", async (AppDbContext context) =>
        {
            var students = await context.Students
            .Where(Student => Student.Active)
            .Select(Student => new StudentDto(Student.Id, Student.Name))
            .ToListAsync();

            return students;
        });

        // Update Student Name
        endpointsStudents.MapPut("{id}", async (Guid id, UpdateStudentRequest request, AppDbContext context) =>
        {
            var student = await context.Students.SingleOrDefaultAsync(student => student.Id == id);

            if (student == null)
                return Results.NotFound();
            student.UpdateName(request.Name);

            await context.SaveChangesAsync();

            return Results.Ok(new StudentDto(student.Id, student.Name));
        });

        endpointsStudents.MapDelete("{id}", async (Guid id, AppDbContext context) =>
        {
            var student = await context.Students.SingleOrDefaultAsync(student => student.Id == id);

            if (student == null)
                return Results.NotFound();

            student.SoftDelete();

            await context.SaveChangesAsync();
            return Results.Ok();
        });
    }
}