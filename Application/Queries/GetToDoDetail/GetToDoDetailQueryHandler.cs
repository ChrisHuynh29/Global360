using MediatR;
using Domain.Entities;
using Application.Contracts;
using Application.Exceptions;

namespace Application.Queries.GetToDoDetail
{
    public class GetToDoDetailQueryHandler : IRequestHandler<GetToDoDetailQuery, ToDoItem>
    {
        private readonly IToDoRepository _toDoRepository;

        public GetToDoDetailQueryHandler(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<ToDoItem> Handle(GetToDoDetailQuery request, CancellationToken cancellationToken)
        {
            var toDo = await _toDoRepository.GetByIdAsync(request.Id);
            return toDo ?? throw new NotFoundException(request.Id);
        }
    }
}
