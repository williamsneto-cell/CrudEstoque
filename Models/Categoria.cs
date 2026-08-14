using System;
using System.Collections.Generic;

namespace EstoqueApi.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
