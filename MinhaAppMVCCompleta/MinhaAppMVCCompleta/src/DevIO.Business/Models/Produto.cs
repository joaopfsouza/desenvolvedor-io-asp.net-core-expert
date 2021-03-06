﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }


        public string Descricao { get; set; }


        public string Image { get; set; }


        public decimal Valor { get; set; }


        public DateTime DataCadastro { get; set; }


        public bool Ativo { get; set; }


        /* EF Relation */
        public Guid FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }

    }
}
