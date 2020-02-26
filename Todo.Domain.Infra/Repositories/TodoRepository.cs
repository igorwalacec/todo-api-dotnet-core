using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext context;
        public TodoRepository(TodoContext _context)
        {
            context = _context;
        }
        public void Create(TodoItem todo)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string refUser)
        {
            return context.Todos.AsNoTracking().Where(TodoQueries.GetAll(refUser)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string refUser)
        {
            return context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(refUser)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string refUser)
        {
            return context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(refUser)).OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string refUser)
        {
            return context.Todos.AsNoTracking().FirstOrDefault(x => x.Id == id && x.RefUser == refUser);
        }

        public IEnumerable<TodoItem> GetByPeriod(string refUser, DateTime date, bool done)
        {
            return context.Todos.AsNoTracking().
                    Where(TodoQueries.GetPeriod(refUser, date, done)).OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {            
            context.Entry(todo).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}