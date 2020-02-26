using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;
        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "igorwalacec", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "igorwalacec", DateTime.Now.AddDays(-1)));
            _items.Add(new TodoItem("Tarefa 5", "usuarioA", DateTime.Now));
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_do_usuario_fornecido()
        {
            var result = _items.AsQueryable().
                            Where(TodoQueries.GetAll("usuarioA"));
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_nao_completas_do_usuario()
        {
            var result = _items.AsQueryable().
                            Where(TodoQueries.GetAllUndone("igorwalacec"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_filtradas_por_estado_e_data()
        {
            var result = _items.AsQueryable().
                            Where(TodoQueries.GetPeriod("igorwalacec", DateTime.Now.AddDays(-1), false));
            Assert.AreEqual(1, result.Count());
        }
    }
}