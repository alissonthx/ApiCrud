namespace ApirCrud.Students;

public static class StudentsEndpoints
{
    public static void AddEndpointsStudents(this WebApplication app)
    {
        app.MapGet("students", () => new Student("Alisson"));
    }
}