using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MinhaDemoMVC.ViewComponents
{
    [ViewComponent(Name="Carrinho")]
    public class CarrinhoViewCompoment : ViewComponent
    {

        public int ItensCarrinho { get; set; }

        public CarrinhoViewCompoment()
        {
            ItensCarrinho = 3;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItensCarrinho);

        }
    }
}
