using MediatR;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommand : IRequest<CreateToDoCommandResponse>
    {
        public string Title { get; set; } = string.Empty;
    }
}
