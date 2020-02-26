using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Queries;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTests
    {        
        private readonly FakeTodoRepository _repository = new FakeTodoRepository();        
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_do_usuario_fornecido()
        {
            var result = _repository.GetAll("usuarioA");
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_nao_completas_do_usuario()
        {
            var result = _repository.GetAllUndone("igorwalacec");
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_filtradas_por_estado_e_data()
        {
            var result = _repository.GetByPeriod("igorwalacec", DateTime.Now.AddDays(-1), false);
            Assert.AreEqual(1, result.Count());
        }
    }
}