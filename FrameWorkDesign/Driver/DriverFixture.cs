// using System;
// using FrameWorkDesign.Config;

// namespace FrameWorkDesign.Driver
// {
//      public class DriverFixture
//     {
//         private static Ipage _page;
//         private static IBrowser _browser;
//         private static IPlaywright _playwright;
//        public TestSetting _testsetting;

//         public DriverFixture(TestSetting testSetting)
//         {
//             _testsetting = testSetting; 
//        //     Driver = _testsetting.TestRunType == TestRunType.Local ? GetWebDriver(testSetting.browserType) : GetRemoteWebDriver(testSetting.browserType);
//             Driver =  GetWebDriver(testSetting.browserType) ;

//             Driver.Manage().Window.Maximize();
//             Driver.Navigate().GoToUrl(testSetting.ApplicationURL);
//             Thread.Sleep(5000);
//             Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(testSetting.TimeOutInterval ?? 30 )); 
            
//         }  

//          public static async Task<IPage> Initialize()
//         {
//             if (_page == null)
//             {   using var playwright = await Playwright.CreateAsync();
//                 _playwright = await Playwright.CreateAsync();
//                 _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
//                 {  
//                     ExecutablePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe",
//                     Headless = false 
                
//                 });
//                 var context = await _browser.NewContextAsync();
//                 _page = await context.NewPageAsync();
//             }
//             return _page;
//         }
//         public IBrowser GetWebDriver(BrowserType browserType)
//         {

//             return browserType switch
//             {
//                 BrowserType.ChromeDriver => new ChromeDriver(),
//                 BrowserType.EdgeDriver => new EdgeDriver(),
//                 BrowserType.FireFoxDriver => new FirefoxDriver(), 
//                     _ => new ChromeDriver()

//             } ;     

//         }

//          public IWebDriver GetRemoteWebDriver(BrowserType browserType)
//         {
//             IWebDriver driver;

//          switch (browserType)
//             {
//                 case BrowserType.ChromeDriver:
//                     driver = new RemoteWebDriver(_testsetting.GridUri, new ChromeOptions());
//                     break;                
//                 case BrowserType.EdgeDriver:
//                     driver = new RemoteWebDriver(_testsetting.GridUri, new EdgeOptions());
//                     break;                
//                 case BrowserType.FireFoxDriver:
//                     driver = new RemoteWebDriver(_testsetting.GridUri, new FirefoxOptions());
//                     break;
//                 default:
//                     driver = new RemoteWebDriver(_testsetting.GridUri, new ChromeOptions());
//                     break;
//             }

//         return driver;

//         }


       
//     }
// }