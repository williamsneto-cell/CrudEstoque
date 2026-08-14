namespace EstoqueApi.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public int QuantidadeEstoque { get; set; }

    public int CategoriaId { get; set; }

    public int FornecedorId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Fornecedore? Fornecedor { get; set; }
}