using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetToDoList
{
    public class GetToDoListQuery : IRequest<List<ToDoItem>>
    {
        public GetToDoListQuery() { }
    }
}
