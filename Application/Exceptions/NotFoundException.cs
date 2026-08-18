namespace Application.Exceptions
{
    public class NotFoundException(int id) : Exception($"ToDo item with Id {id} not found.")
    {
    }
}
