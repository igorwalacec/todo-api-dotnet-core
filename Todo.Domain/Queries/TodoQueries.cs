using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string refUser)
        {
            return x => x.RefUser == refUser;
        }
        public static Expression<Func<TodoItem, bool>> GetAllDone(string refUser)
        {
            return x => x.RefUser == refUser && x.Done;
        }
        public static Expression<Func<TodoItem, bool>> GetAllUndone(string refUser)
        {
            return x => x.RefUser == refUser && !x.Done;
        }
        public static Expression<Func<TodoItem,bool>> GetPeriod(string refUser, DateTime date, bool done)
        {
            return x =>
                    x.RefUser == refUser &&
                    x.Done == done &&
                    x.Date.Date == date.Date;
        }
    }
}