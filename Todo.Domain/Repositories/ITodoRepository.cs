using System;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
  public interface ITodoRepository
  {
    void Create(TodoItem todo);
    void Update(TodoItem todo);
    TodoItem GetById(Guid id, string refUser);
    IEnumerable<TodoItem> GetAll(string refUser);
    IEnumerable<TodoItem> GetAllDone(string refUser);
    IEnumerable<TodoItem> GetAllUndone(string refUser);
    IEnumerable<TodoItem> GetByPeriod(string refUser, DateTime date, bool done);

  }
}