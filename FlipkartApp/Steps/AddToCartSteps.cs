using System;
using System.Threading.Tasks;
using FlipkartApp.Hooks;
using FlipkartApp.POM;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class AddToCartSteps
{
    private IPage _page;
    // private Login _loginPage;
    private HomePage _homePage;
    private SearchResultsPage _searchPage;
    private ProductPage _productPage;
    private CartPage _cartPage;
    public AddToCartSteps()
    {
        _page =  Hook.Page;
        // _loginPage = new LoginPage(_page);
        //  _loginPage = new LoginPage(_page);
        _homePage = new HomePage(_page);
        _searchPage = new SearchResultsPage(_page);
        _productPage = new ProductPage(_page);
        _cartPage = new CartPage(_page);   // have to switch to second tabe
        
    }


    [Given(@"I navigate to Flipkart page")]
    public async Task GivenINavigateToFlipkartPage()
    {        
        await _page.GotoAsync("https://www.flipkart.com/");

    }

    [Given(@"I login with username ""(.*)"" and password ""(.*)""")]
    public void GivenILogin(string username, string password)
    {
        Console.WriteLine($"{username} and {password}");
      //  await _loginPage.Login(username, password);
    }

    [When(@"I search for ""(.*)""")]
    public async Task WhenISearchFor(string product)
    {
        await _homePage.SearchProduct(product);
    }

    [When(@"I select the first product")]
    public async Task WhenISelectFirstProduct()
    {
        await _searchPage.ClickOnFirstProduct();
        // new window open for selected product
         var newTab = await _productPage.SwitchToProductTab();
          _productPage = new ProductPage(newTab);
           _cartPage = new CartPage(newTab); 

    }

    [When(@"I add the product to the cart")]
    public async Task WhenIAddToCart()
    {
        //Thread.Sleep(5000);
        await _productPage.AddToCart();
    }

    [Then(@"I should see the product in the cart")]
    public async Task ThenIShouldSeeProductInCart()
    {
        var result = await _cartPage.IsProductInCart("iPhone");
        Assert.That(result, "Product not found in cart.");
    }
}
