namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
    }
}
