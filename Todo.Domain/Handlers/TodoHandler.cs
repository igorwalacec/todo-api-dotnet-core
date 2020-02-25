using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable, 
                    IHandler<CreateTodoCommand>, 
                    IHandler<UpdateTodoCommand>,
                    IHandler<MarkTodoAsDoneCommand>,
                    IHandler<MarkTodoAsUndoneCommand>,
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications
                );
            }

            var todo = new TodoItem(command.Title, command.RefUser, command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(
                true,
                "Tarefa salva!!",
                todo
            );
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false, 
                    "Ops, parece que sua tarefa está errada", 
                    command.Notifications
                );
            }
            //Recurepera TodoItem (Recuperar dados mais atualizadoa)
            var todo =_repository.GetById(command.Id, command.RefUser);

            //Alterar o título
            todo.UpdateTitle(command.Title);

            //Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva!", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false, 
                    "Ops, parece que sua tarefa está errada", 
                    command.Notifications
                );
            }
            //Recurepera TodoItem (Recuperar dados mais atualizadoa)
            var todo =_repository.GetById(command.Id, command.RefUser);

            //Alterar o título
            todo.MarkAsUndone();

            //Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva!", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false, 
                    "Ops, parece que sua tarefa está errada", 
                    command.Notifications
                );
            }
            //Recurepera TodoItem (Recuperar dados mais atualizadoa)
            var todo =_repository.GetById(command.Id, command.RefUser);

            //Alterar o título
            todo.MarkAsDone();

            //Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva!", todo);
        }
    }
}