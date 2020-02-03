using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  public class UpdateTodoCommand : Notifiable, ICommand
  {
    public UpdateTodoCommand()
    {

    }
    public UpdateTodoCommand(Guid id, string title, string refUser)
    {
      Id = id;
      Title = title;
      RefUser = refUser;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string RefUser { get; set; }
    public void Validate()
    {
      AddNotifications(
          new Contract()
            .Requires()
            .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor sua tarefa")
            .HasMinLen(RefUser, 6, "User", "Usuário Inválido")
      );
    }
  }
}