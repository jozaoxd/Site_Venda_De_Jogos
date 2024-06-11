using System.ComponentModel.DataAnnotations.Schema;

namespace GamesMac.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int GameId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public virtual Games Game { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
