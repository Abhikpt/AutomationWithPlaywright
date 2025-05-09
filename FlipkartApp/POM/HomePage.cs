using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace FlipkartApp.POM;
public class HomePage
{
    private readonly IPage _page;

    private ILocator SearchBox => _page.Locator("input.Pke_EE");
    private ILocator SearchButton => _page.Locator("button[type='submit']");

    private ILocator SearchSuggestion => _page.Locator("//ul[@class='_1sFryS _2x2Mmc _3ofZy1']/li//div[@class='YGcVZO _2VHNef']");

    public HomePage(IPage page) => _page = page;

    public async Task SearchProduct(string productName)
    {
        await SearchBox.FillAsync(productName);
        await DisplaySuggestions(productName);
        await SearchBox.PressAsync("Enter");
    }


    public async Task DisplaySuggestions(string productName)
    {
        // await SearchBox.FillAsync(productName);

         var Suggestions = await SearchSuggestion.AllAsync();
         Console.WriteLine("-------- Search suggestions ----------");
         foreach(var s in Suggestions)
         {
            string res = await s.InnerTextAsync();
            Console.WriteLine(res);
         }



    }
}
