﻿using ProjTeste2.Models;
using System.Web.Mvc;
using ProjTeste2.Context;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ProjTeste2.Controllers
{
    public class PessoasController : Controller
    {
        private readonly ConexaoDb conexaoDb;

        public PessoasController()
        {
            conexaoDb = new ConexaoDb();
        }
        // GET: Pessoas
        public ActionResult Index()
        {
            IEnumerable<Pessoas> pessoas = conexaoDb.Pessoas;
            return View(pessoas);
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Pessoas pessoas)
        {
            conexaoDb.Entry(pessoas).State = EntityState.Added; 
            conexaoDb.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int pessoaId)
        {
            Pessoas pessoa = conexaoDb.Pessoas.Find(pessoaId);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Deletar(Pessoas pessoa)
        {
            Pessoas pessoaAtual = conexaoDb.Pessoas.Find(pessoa.PessoasId);
            conexaoDb.Entry(pessoaAtual).State = EntityState.Deleted;
            conexaoDb.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Editar(int pessoaId)
        {
            Pessoas pessoas = conexaoDb.Pessoas.Find(pessoaId);
            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Editar(Pessoas pessoa)
        {
            conexaoDb.Entry(pessoa).State = EntityState.Modified;
            conexaoDb.SaveChanges();
            return RedirectToAction("Index");   
        }            

        public ActionResult Detalhes(int pessoaId)
        {
            Pessoas pessoas = conexaoDb.Pessoas.Find(pessoaId);
            return View(pessoas);
        }
    }
}