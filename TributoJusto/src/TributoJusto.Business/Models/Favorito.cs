﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TributoJusto.Business.Models
{
    public class Favorito :  Entity
    {
        public Guid? FilmeId { get; set; }
        public Guid? LivroId { get; set; }
        public Guid UsuarioId { get; set; }

        /* EF Relation */
        public virtual Livro Livro { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
