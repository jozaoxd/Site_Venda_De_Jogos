﻿using GamesMac.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GamesMac.Models
{
    public class CarrinhoCompra
    {
        public readonly AppDbContext _context;
       
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtém um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtém ou gera um Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

           
        }
        public void AdicionarAoCarrinho(Games game)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens
                                     .SingleOrDefault(s => s.Game.GameId == game.GameId && 
                                     s.CarrinhoCompraId == CarrinhoCompraId);
            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Game = game,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        //antes estava usando um método int, caso venha a falhar trarei de volta.
        public int RemoverDoCarrinho(Games game)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Game.GameId == game.GameId &&
                s.CarrinhoCompraId == CarrinhoCompraId);
            var quantidadeLocal = 0;

            if(carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                   (CarrinhoCompraItems =
                      _context.CarrinhoCompraItens
                     .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                     .Include(s => s.Game)
                     .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                                        .Where(carrinho => carrinho.CarrinhoCompraId
                                               == CarrinhoCompraId);
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                .Select(c => c.Game.Preco * c.Quantidade).Sum();

            return total;
        }
    }
}
