using System;
using PagedList;
using System.Linq;
using ToDo.Domain;
using System.Web.Mvc;
using ToDo.App.Models;
using ToDo.Core.Business.Services;
using System.Text;

namespace ToDo.App.Controllers
{
    public class HomeController : Controller
    {
        #region Private Read-Only fields

        private readonly IObservacaoService _appObservacao;
        private readonly ITarefaService _appTarefa;

        #endregion

        #region Constructors

        public HomeController(ITarefaService tarefaService, IObservacaoService observacaoService)
        {
            this._appTarefa = tarefaService;
            this._appObservacao = observacaoService;
        }

        #endregion

        #region Actions

        public ActionResult Index(int? page)
        {
            HomeViewModel model = new HomeViewModel();

            model.FiltraTarefas = _appTarefa.Listar();
            model.PageNumber = page ?? 1;
            model.Concluido = true;
            model.Andamento = true;

            model.RelatorioTarefas = model.FiltraTarefas.ToPagedList(model.PageNumber, 30);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? page, HomeViewModel model)
        {
            model.FiltraTarefas = _appTarefa.Listar();

            if (!model.Concluido || !model.Andamento)
            {
                if (model.Concluido)
                    model.FiltraTarefas = model.FiltraTarefas.Where(x => x.Finalizado == true);

                if (model.Andamento)
                    model.FiltraTarefas = model.FiltraTarefas.Where(x => x.Finalizado == false);
            }

            model.PageNumber = page ?? 1;
            model.Concluido = true;
            model.Andamento = true;

            model.RelatorioTarefas = model.FiltraTarefas.ToPagedList(model.PageNumber, 30);

            return View(model);
        }

        [HttpGet, Route("AddTarefa")]
        public ActionResult AddTarefa()
        {
            return PartialView("_PartialModelAddTarefa");
        }

        [HttpPost, Route("AddTarefa")]
        [ValidateAntiForgeryToken]
        public ActionResult AddTarefa(TarefaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Tarefa tf = new Tarefa()
                {
                    Titulo = model.Titulo,
                    Finalizado = model.Finalizado
                };

                var id = _appTarefa.SalvarTarefa(tf);

                var observacao = new Observacao()
                {
                    Descricao = model.Observacao,

                    IdTarefa = _appTarefa.Listar()
                    .Where(x => x.Id == id)
                    .FirstOrDefault().Id
                };

                if (!String.IsNullOrEmpty(observacao.Descricao))
                    _appObservacao.Salvar(observacao);

                model.Titulo = "";

                return PartialView("_PartialModelAddTarefa", model);
            }

            ModelState.AddModelError("", "Preencha os campos obrigatorios");

            return PartialView("_PartialModelAddTarefa", model);
        }

        [HttpGet, Route("AltTarefa")]
        public ActionResult AltTarefa(int id)
        {
            var tarefa = _appTarefa.Pesquisar(id);

            TarefaViewModel model = new TarefaViewModel()
            {
                IdTarefa = tarefa.Id,
                Titulo = tarefa.Titulo,
                Finalizado = tarefa.Finalizado
            };

            return PartialView("_PartialModelAltTarefa", model);
        }

        [HttpPost, Route("AltTarefa")]
        [ValidateAntiForgeryToken]
        public ActionResult AltTarefa(TarefaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Tarefa tf = new Tarefa()
                {
                    Id = model.IdTarefa,
                    Titulo = model.Titulo,
                    Finalizado = model.Finalizado
                };

                _appTarefa.Salvar(tf);

                var observacao = new Observacao()
                {
                    Descricao = model.Observacao,
                    IdTarefa = model.IdTarefa
                };

                if (!String.IsNullOrEmpty(observacao.Descricao))
                    _appObservacao.Salvar(observacao);

                model.Finalizado = false;
                model.Titulo = "";

                return PartialView("_PartialModelAltTarefa", model);
            }

            ModelState.AddModelError("", "Preencha os campos obrigatorios");

            return PartialView("_PartialModelAltTarefa", model);
        }

        [HttpGet, Route("UpLista")]
        public ActionResult UpLista(int id)
        {
            var tarefa = _appTarefa.Pesquisar(id);

            var model = new ListaViewModel()
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Finalizado = tarefa.Finalizado,
                Data = tarefa.Date.ToString()
            };

            return PartialView("_PartialListaAtualizada", model);
        }

        [HttpGet, Route("ObsTarefa")]
        public ActionResult ObsTarefa(int id)
        {
            var listaObs = _appObservacao.ListarPorTarefa(id);

            var model = new ObsViewModel()
            {
                Id = id,
            };

            model.Observacoes = listaObs.OrderByDescending(x => x.Id).ToList();

            return PartialView("_PartialModelObs", model);
        }

        #endregion

    }
}