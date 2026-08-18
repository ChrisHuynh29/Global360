using MediatR;

namespace Application.Commands.DeleteToDo
{
    public class DeleteToDoCommand : IRequest<DeleteToDoCommandResponse>
    {
        public int Id { get; set; }
    }
}
