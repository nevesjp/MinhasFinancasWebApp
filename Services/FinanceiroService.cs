using MinhasFinancasWebApp.Models;

namespace MinhasFinancasWebApp.Services
{
    public class FinanceiroService
    {
        private static List<LancamentoFinanceiro> _lancamentos = new();

        //Add lancamento
        public void Adicionar(LancamentoFinanceiro lancamento)
        {
            _lancamentos.Add(lancamento);
        }
        //Lista tudo
        public List<LancamentoFinanceiro> Listar()
        {
            return _lancamentos
                    .OrderByDescending(l => l.Tipo)
                    .ThenBy(l => l.Data)
                    .ToList();
        }
        //total de receitas e despesas
        #region Totais
        public decimal TotalReceitas()
        {
            return _lancamentos.Where(l => l.Tipo == "Receita").Sum(l => l.Valor);
        }
        public decimal TotalDespesas()
        {
            return _lancamentos.Where(l => l.Tipo == "Despesa").Sum(l => l.Valor);
        }
        public decimal Saldo() 
        {
            return TotalReceitas() - TotalDespesas();
        }
        #endregion
        public void Remover(Guid id)
        {
            var lancamento = _lancamentos.FirstOrDefault(l => l.Id == id);

            if (lancamento != null)
            {
                _lancamentos.Remove(lancamento);
            }
        }
    }
}
