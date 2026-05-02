namespace MinhasFinancasWebApp.Models
{
    public class LancamentoFinanceiro
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Tipo { get; set; } = string.Empty; // Receita ou Despesa
        public string Descricao {  get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data {  get; set; } = DateTime.Now;
        public string Categoria {  get; set; } = string.Empty;
        public bool Pago { get; set; }
    }
}
