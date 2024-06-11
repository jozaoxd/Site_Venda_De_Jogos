using GamesMac.Models;
using GamesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesMac.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;
        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }


        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            //usar o código abaixo somente para checar a exibição do carrinho de compras
            //var itens = new List<CarrinhoCompraItem>()
            //{
               // new CarrinhoCompraItem(),
                //new CarrinhoCompraItem()
            //};
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
    }
}
