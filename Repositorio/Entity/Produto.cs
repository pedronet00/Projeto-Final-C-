//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositorio.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int IdFornecedor { get; set; }
        public decimal Valor { get; set; }
    }
}
