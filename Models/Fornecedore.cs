using System;
using System.Collections.Generic;

namespace EstoqueApi.Models;

public partial class Fornecedore
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string? Telefone { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}