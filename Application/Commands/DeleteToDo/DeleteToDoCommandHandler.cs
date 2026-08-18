using Application.Contracts;
using Application.Exceptions;
using MediatR;

namespace Application.Commands.DeleteToDo
{
    public class DeleteToDoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<DeleteToDoCommand, DeleteToDoCommandResponse>
    {
        public async Task<DeleteToDoCommandResponse> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new DeleteToDoCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            await toDoRepository.DeleteAsync(request.Id);

            var response = new DeleteToDoCommandResponse
            {
                Success = true,
                Message = "To-do item deleted successfully."
            };
            return response;
        }
    }
}