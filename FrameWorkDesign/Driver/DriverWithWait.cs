// using FrameworkDesign.Config;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Support.UI;
// using FrameWorkDesign.Driver;
// using FrameWorkDesign.Config;

// namespace FrameWorkDesign.Driver;

// public class DriverWithWait : IDriverWithWait 
// {
//     private readonly IDriverFixture _driverFixture;
//     private readonly TestSetting _testSetting;
//     private readonly Lazy<WebDriverWait> _webdriverWait;

// public DriverWithWait(DriverFixture driverFixture, TestSetting testSetting)
// {
//     _driverFixture= driverFixture;
//         _testSetting = testSetting;
//         _webdriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
// }
  

//     public IWebElement FindWebElement(By elmLocator)
//     {
//         return _webdriverWait.Value.Until(_ => _driverFixture.Driver.FindElement(elmLocator));
//     }

//     public IEnumerable<IWebElement> FindWebElements(By elmLocator)  //enumerable can use to get query 
//     {
//         return _webdriverWait.Value.Until(_ => _driverFixture.Driver.FindElements(elmLocator));
//     }

//     public WebDriverWait GetWaitDriver()
//     {
//         return new WebDriverWait(_driverFixture.Driver, timeout: TimeSpan.FromSeconds(_testSetting.TimeOutInterval ?? 30 ))
//         {
//             PollingInterval = TimeSpan.FromSeconds(_testSetting.TimeOutInterval ?? 1)
//         };
//     }
// }