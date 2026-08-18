using MediatR;
using Domain.Entities;
using Application.Contracts;
using Application.Exceptions;

namespace Application.Commands.CreateToDo
{
    public class CreateToDoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<CreateToDoCommand, CreateToDoCommandResponse>   
    {
        public async Task<CreateToDoCommandResponse> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            // Validate the request
            var validator = new CreateToDoCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var toDo = new ToDoItem
            {
                Id = 0, // This will be set by the database or repository
                Title = request.Title
            };
            var createdToDo = await toDoRepository.Create(toDo); 
            var response = new CreateToDoCommandResponse
            {
                Id = createdToDo.Id,
                Title = createdToDo.Title,
                Success = true,
                Message = "ToDo item created successfully."
            };
            return response;
        }
    }
}
