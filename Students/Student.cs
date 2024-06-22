namespace ApirCrud.Students;

public class Student
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Student(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Active = true;
    }

    public void SoftDelete()
    {
        Active = false;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}