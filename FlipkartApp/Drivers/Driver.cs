using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using FrameWorkDesign.Config;
using BrowserType = FrameWorkDesign.Config.BrowserType;

namespace FlipkartApp.Drivers
{
    public class Driver
    {
        private static IPage _page;
        private static IBrowser _browser;
        private static IPlaywright _playwright;

        public static async Task<IPage> Initialize()
        {
            if (_page == null)
            {   using var playwright = await Playwright.CreateAsync();
                _playwright = await Playwright.CreateAsync();
                _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
                {  
                  //  ExecutablePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
                    Headless = false 
                
                });
                var context = await _browser.NewContextAsync();
                _page = await context.NewPageAsync();
            }
            return _page;
        }

        public static async Task CloseBrowser()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _page = null;
            }
        }

        public async Task<IBrowser> GetRemoteWebDriver(BrowserType browserType)
        {
            IBrowser browser;

         switch (browserType)
            {
                case BrowserType.ChromeDriver:
                    browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
                                { 
                                    Headless = false              
                                });
                    break; 

                case BrowserType.EdgeDriver:
                    browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
                                { 
                                    ExecutablePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
                                    Headless = false              
                                });
                    break;                
                case BrowserType.FireFoxDriver:
                    browser = await _playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions 
                                { 
                                    Headless = false              
                                });
                    break;
                default:
                    browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
                                { 
                                    ExecutablePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
                                    Headless = false              
                                });
                    break;
            }

        return browser;

        }
    }
}


