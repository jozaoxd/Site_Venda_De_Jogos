using GamesMac.Context;
using GamesMac.Models;
using GamesMac.Repositories.Interfaces;

namespace GamesMac.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext,
            CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    GameId = carrinhoItem.Game.GameId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Game.Preco
                };
                _appDbContext.PedidosDetalhe.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();

        }
    }
}
