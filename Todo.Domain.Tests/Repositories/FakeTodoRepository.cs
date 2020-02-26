using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public List<TodoItem> _items =new List<TodoItem>();
        public FakeTodoRepository()
        {
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "igorwalacec", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "igorwalacec", DateTime.Now.AddDays(-1)));
            _items.Add(new TodoItem("Tarefa 5", "usuarioA", DateTime.Now));            
        }
        public void Create(TodoItem todo)
        {         
        }

        public IEnumerable<TodoItem> GetAll(string refUser)
        {
            return _items.AsQueryable().Where(TodoQueries.GetAll(refUser)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string refUser)
        {
            return _items.AsQueryable().Where(TodoQueries.GetAllDone(refUser)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string refUser)
        {
            return _items.AsQueryable().
                    Where(TodoQueries.GetAllUndone(refUser)).OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string refUser)
        {
            return _items.AsQueryable().FirstOrDefault(x => x.Id == id && x.RefUser == refUser);
        }

        public IEnumerable<TodoItem> GetByPeriod(string refUser, DateTime date, bool done)
        {
            return _items.AsQueryable().
                    Where(TodoQueries.GetPeriod(refUser, date, done)).OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {                        
        }
    }
}