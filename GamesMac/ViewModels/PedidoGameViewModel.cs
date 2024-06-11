using GamesMac.Models;

namespace GamesMac.ViewModels
{
    public class PedidoGameViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
