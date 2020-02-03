using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  public class MarkTodoAsDoneCommand : Notifiable, ICommand
  {
    public MarkTodoAsDoneCommand()
    {

    }
    public MarkTodoAsDoneCommand(Guid id, string refUser)
    {
      Id = id;
      RefUser = refUser;
    }
    public Guid Id { get; set; }
    public string RefUser { get; set; }
    public void Validate()
    {
      AddNotifications(
          new Contract()
            .Requires()
            .HasMinLen(RefUser, 6, "User", "Usuário Inválido")
      );
    }
  }
}