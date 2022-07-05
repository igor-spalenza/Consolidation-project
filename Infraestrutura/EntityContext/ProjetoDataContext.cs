using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Infraestrutura.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Infraestrutura.EntityContext
{
    public class ProjetoDataContext : DbContext
    {
        public ProjetoDataContext() : base("dbconnection")
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Concurso> Concursos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }


        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Concurso>().ToTable("Concurso");
            modelBuilder.Entity<Inscricao>().ToTable("Inscricao");

            //modelBuilder.Entity<Curso>().HasRequired(c => c.ConcursoId).WithMany;
        }

    }
}
