using System.Runtime.CompilerServices;

namespace HomeInventoryTests.Methods
{
    public static class ItemMethods
    {
        private static TestSettings _testSettings = TestSettingLoader.Load();
        public static void CreateItem(this ChromeDriver _driver, string location, string itemName)
        {
            _driver.Navigate().GoToUrl(_testSettings.WebsiteURL);
            Thread.Sleep(500);
            var createItemButton = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[2]/div/div/div[2]/div/div/label"));
            createItemButton.Click();
            Thread.Sleep(500);
            var itemNameButton = _driver.FindElement(By.XPath("/html/body/div/div/div[6]/div[2]/div/div/div[2]/div/div/ul/li[1]/button"));
            Thread.Sleep(100);
            itemNameButton.Click();
            Thread.Sleep(500);
            var locationInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/form/div[1]/div/input"));
            locationInput.SendKeys(Keys.Enter);
            var itemNameInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/form/div[2]/input"));
            var submitButton = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/form/div[5]/div/button"));
            locationInput.SendKeys(location);
            itemNameInput.SendKeys(itemName);
            submitButton.Click();
            Thread.Sleep(500);
        }
        public static void ChangeQuantity(this ChromeDriver _driver)
        {
            var changeQuantityButton = _driver.FindElement(By.XPath("/html/body/div[1]/div/div[6]/div[1]/div[2]/section[2]/div/div[1]/div[2]/div/dl/div[1]/dd/span/button[2]"));
            changeQuantityButton.Click();
            Thread.Sleep(500);
        }
    }
}
