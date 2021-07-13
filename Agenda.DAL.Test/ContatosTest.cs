using System;
using NUnit.Framework;
using Agenda.Domain;
using System.Collections.Generic;
using AutoFixture;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        //IncluirContatoTest
        [Test]
        public void AdicionarContatoTest()          
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Ocione"
            };
            
            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        //ObterContatoTest
        [Test]
        public void ObterContatoTest()
        {
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Maria"
            };

            Contato contatoResultado;

            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            var contato1 = new Contato(){ Id = Guid.NewGuid(), Nome = "Maria" };
            var contato2 = new Contato(){ Id = Guid.NewGuid(), Nome = "João" };

            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContato = _contatos.ObterTodos();
            var contatoResultado = lstContato.Find(c => c.Id == contato1.Id);

            Assert.IsTrue(lstContato.Count > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
