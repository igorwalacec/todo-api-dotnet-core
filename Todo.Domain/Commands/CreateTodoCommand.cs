using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  public class CreateTodoCommand : Notifiable, ICommand
  {
    public CreateTodoCommand()
    {

    }
    public CreateTodoCommand(string title, DateTime date, string refUser)
    {
      Title = title;
      Date = date;
      RefUser = refUser;
    }
    public string Title { get; set; }
    public string RefUser { get; set; }
    public DateTime Date { get; set; }

    public void Validate()
    {
      AddNotifications(
        new Contract()
            .Requires()
            .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor sua tarefa")
            .HasMinLen(RefUser, 6, "RefUser", "Usuário inválido"));
    }
  }
}