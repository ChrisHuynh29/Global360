using MediatR;
using Domain.Entities;

namespace Application.Queries.GetToDoDetail
{
    public class GetToDoDetailQuery : IRequest<ToDoItem>
    {
        public int Id { get; set; }
    }
}
