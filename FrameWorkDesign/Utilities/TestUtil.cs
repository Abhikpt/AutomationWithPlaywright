
using System.Collections;
using Microsoft.Playwright;
using System.Dynamic;
using FrameWorkDesign;
using FrameWorkDesign.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


public class TestUtil  : BaseConfig
{
    public static IPage _page;

    public TestUtil(IPage page) 
    {
        _page = page;
        
    }  


    public async Task ClickUsingJavaScriptExecutor(string selector )   
    {
        await _page.EvaluateAsync($"document.querySelector('{selector}').click();");
    }
    
    public bool CheckWebElementPresence(string selector)
    {
        bool flag = false;
        try
        {
            var element = _page.Locator(selector);
            if (element.CountAsync().Result > 0)
            {
                LogHelper.Write($"WebElement:{selector} is Present");
                flag = true;
            }
            else
            {
                LogHelper.Write($"WebElement:{selector} is not Present");
                flag = false;
            }
        }
        catch (Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return flag;
    }
  

    public bool CheckWebElementClickable(ILocator element)
    {
        bool flag = false;
        try
        {            
            if (element.IsEnabledAsync().Result && element.IsVisibleAsync().Result)
            {
                LogHelper.Write($"WebElement:{element.InnerTextAsync} is Clickable");
                flag = true;
            }
            else
            {
                LogHelper.Write($"WebElement:{element.InnerTextAsync} is not Clickable");
                flag = false;
            }
        }
        catch (Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return flag;
    }
    
    
    public bool SelectRadioButtonOrCheckBox(ILocator element)
    {
        bool flag = false;
        try
        {
            if (element.IsCheckedAsync().Result)
            {
                LogHelper.Write($"WebElement:{element.InnerTextAsync} is already checked");
                flag = true;
            }
            else
            {
                element.CheckAsync();
                LogHelper.Write($"WebElement:{element.InnerTextAsync} is checked now");
                flag = true;
            }
        }
        catch (Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return flag;

    }

     public string IsAlertDisplay( ILocator locator)
    {  
        string alertText = null;
        try
        {
            if (locator.IsVisibleAsync().Result)
            {
                alertText = locator.InnerTextAsync().Result;
                LogHelper.Write($"Alert is Displayed with text: {alertText}");
            }
            else
            {
                LogHelper.Write($"Alert is not Displayed");
            }
        }
        catch (Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return alertText;

    }

    public ArrayList stringArrayToListConversion(String conversionString)
    {
        char[] seperator = {'\n'};
        string[] strList = conversionString.Split(seperator);
        ArrayList aList = new ArrayList();
        for(int i = 0 ; i< strList.Length ; i++)
        {
            aList.Add(strList.GetValue(i).ToString());
        }
        return aList;
    }

    public Dictionary<string,string> StringArrayToDictionaryConversion(String conversionString)
    {
         char[] seperator = {'=','\n'};
        string[] strList = conversionString.Split(seperator);
        Dictionary<string,string> dict = new Dictionary<string, string>();
        for(int i = 0 ; i< strList.Length ; i++)
        {
           dict.Add(strList.GetValue(i).ToString(), strList.GetValue(i+1).ToString());
           i=i+2;
        }
        return dict;

    }


    public bool CompareTwoArrayList(string expected, string actual)
    {
        bool flag = false;
        ArrayList list1 = stringArrayToListConversion(expected);
        ArrayList list2 = stringArrayToListConversion(actual);

        if(list1.Count == list2.Count)
        {
            for(int i = 0 ; i< list1.Count ; i++)
            {
                if(list1[i].Equals(list2[i]))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
        }
        else
        {
            flag = false;
        }

        return flag;
    }

    // public SelectOptionValue SelectWebElement(ILocator locator)
    // {
    //     SelectOptionValue selectOptionValue = new SelectOptionValue();
    //     try
    //     {
    //         if (locator.IsEnabledAsync().Result && locator.IsVisibleAsync().Result)
    //         {
    //             // selectOptionValue = locator.SelectOptionAsync(new[] { new SelectOptionValue { Index = 0 } }).Result;
    //             LogHelper.Write($"WebElement:{locator.InnerTextAsync} is Selected");
    //         }
    //         else
    //         {
    //             LogHelper.Write($"WebElement:{locator.InnerTextAsync} is not Selected");
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         LogHelper.Write(e.Message);
    //     }
        
       
        
    // }   


    public int GenerateRandomNumber(int Length)
    {

        Random random = new Random();

        if(Length == 1)
        {
            return random.Next(1,10);
        }
       else if(Length == 2)
        {
            return random.Next(10,100);
        }
        else if(Length == 3)
        {
            return random.Next(100,1000);
        }
        else if(Length == 4)
        {
            return random.Next(1000,10000);
        }
        else if(Length == 5)
        {
            return random.Next(10000,100000);
        }
        else if(Length == 6)
        {
            return random.Next(100000,1000000);
        }
        else if(Length == 7)
        {
            return random.Next(1000000,10000000);
        }
        else if(Length == 8)
        {
            return random.Next(10000000,100000000);
        }
        else if(Length == 9)
        {
            return random.Next(100000000,1000000000);
        }
        else if(Length == 10)
        {
            return random.Next(1000000000,1000000000);
        }
        else
        {
            return random.Next(1,10);
        }   
    }

    public String GenerateRandomString(int Length)
    {
        string randomString = "";
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        for(int i = 0 ; i< Length ; i++)
        {
            randomString += characters[random.Next(characters.Length)];
        }
        return randomString;
    }

    public void ScrollToElement(ILocator locator)
    { 
        locator.ScrollIntoViewIfNeededAsync().Wait(); 
    }     
    
  

     public void ScrollToElementByCoordinates(int x, int y)  
     {
        _page.EvaluateAsync($"window.scrollTo({x}, {y})").Wait();
        
     }
    public void scrolltoBottom()
    {
        _page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)").Wait();
    }

    public void scrolltoTop()
    {
        _page.EvaluateAsync("window.scrollTo(0, 0)").Wait();
    }

    public void scrolltoRight()
    {
       _page.EvaluateAsync("window.scrollTo(document.body.scrollWidth, 0)").Wait();
    }

    public void MouseHoverOnElement(ILocator locator)
    {
        locator.HoverAsync().Wait();
    }

    public IPage GetCurrentWindowHandle()
    {
        IPage currentWindowHandle = null;
        try
        {
            currentWindowHandle = _page.Context.Pages[0];
        }
        
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return currentWindowHandle; 
    }

    public IPage WindowHandelForTwoTab()
    {
        IPage currentWindowHandle = GetCurrentWindowHandle();
        IPage newWindowHandle = null;

        try
        {
            foreach(var windowHandle in  _page.Context.Pages)
            {
                if(!windowHandle.Equals(currentWindowHandle))
                {
                    newWindowHandle = windowHandle.Context.Pages[0];
                }
            }
        }
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }

        return newWindowHandle;
    }

    public dynamic ReadConfigFile()
    {
        try{
            appSettingPath = Path.Combine(System.IO.Directory.GetCurrentDirectory().Replace("bin\\debug\\net8.0", "AppSettings.json"));
            string json = File.ReadAllText(appSettingPath);
            jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());
            config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);  
                        
        }
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }
        return config;
    }
   

    public void WriteConfigFile()
    {
        try
        {
            dynamic newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
            File.WriteAllText(appSettingPath, newJson);
        }
        catch(Exception e)
        {
            LogHelper.Write(e.Message);
        }
    }




    
}