using System;
using System.Threading.Tasks;
using FlipkartApp.Drivers;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace FlipkartApp.Hooks
{
    [Binding]
    public class Hook
    {

        public static IPage Page ;

        [BeforeScenario]
        public static async Task BeforeScenario()
        {
            Page = await Driver.Initialize();
          //  await Page.GotoAsync("https://www.flipkart.com/");
        }

        [AfterScenario]
        public  async Task AfterScenario()
        {
            await Driver.CloseBrowser();
        }
        
    }
}
