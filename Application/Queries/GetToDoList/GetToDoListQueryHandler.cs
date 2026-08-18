using Application.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Queries.GetToDoList
{
    public class GetToDoListQueryHandler(IToDoRepository toDoRepository) : IRequestHandler<GetToDoListQuery, List<ToDoItem>>
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task<List<ToDoItem>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            return await _toDoRepository.GetAllAsync();
        }
    }
}
