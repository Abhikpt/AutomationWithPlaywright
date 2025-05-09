using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace FlipkartApp.POM;
public class ProductPage
{
    public  IPage _page;
    public ProductPage(IPage page) => _page = page;

    public async Task<IPage> SwitchToProductTab()
    {
        var pages = _page.Context.Pages;
        if (pages.Count > 1)
        {
           await pages[1].BringToFrontAsync();  // Optional: bring it to the front
           return pages[1];  // ✅ Set _page to the new tab   
        }
      return _page;
    }

    public async Task AddToCart()
    { 
      // Thread.Sleep(6000);
       Console.WriteLine("Page title:" + await _page.TitleAsync());
       var addToCartBtn =   _page.Locator("ul.row >li.col");
      //  foreach(var s in await addToCartBtn.AllInnerTextsAsync())
      //  {           
      //       Console.WriteLine(s);
      //  }
       await addToCartBtn.Nth(0).ClickAsync();
    }
}
