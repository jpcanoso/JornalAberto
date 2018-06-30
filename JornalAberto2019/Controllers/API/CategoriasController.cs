using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using JornalAberto2019.Models;

namespace JornalAberto2019.Controllers.API
{
    public class CategoriasController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriasController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/categorias
        public IEnumerable<Categorias> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        // GET /api/categorias/{id}
        public Categorias GetCategoria(int id)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.CategoriaID == id);

            if (categoria == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return categoria;
        }

        // POST /api/categorias
        [HttpPost]
        public Categorias CreateCategoria(Categorias categoria)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        // PUT /api/categorias/{id}
        [HttpPut]
        public void UpdateCategoria(int id, Categorias categoria)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var categoriaIdDB = _context.Categorias.SingleOrDefault(c => c.CategoriaID == id);

            if (categoriaIdDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            categoriaIdDB.NomeCategoria = categoria.NomeCategoria;

            _context.SaveChanges();
        }

        // DELETE /api/categorias/{id}
        [HttpDelete]
        public void DeleteCategoria(int id)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.CategoriaID == id);

            if (categoria == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }
}