namespace HomeInventoryTests.Methods
{
    public static class AuthMethods
    {
        private static TestSettings _testSettings = TestSettingLoader.Load();
        public static void LoginToWebsite(this ChromeDriver _driver, string email, string password)
        {
            _driver.Navigate().GoToUrl(_testSettings.WebsiteURL);
            Thread.Sleep(500);
            var loginInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[1]/input"));
            var passwordInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[2]/div/input"));
            var submitButton = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[4]/button"));
            loginInput.SendKeys(email);
            passwordInput.SendKeys(password);
            submitButton.Click();
            Thread.Sleep(3000);
        }
        public static void RegisterToWebsite(this ChromeDriver _driver, string email, string name, string password)
        {
            _driver.Navigate().GoToUrl(_testSettings.WebsiteURL);
            Thread.Sleep(100);
            var registerButton = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/button"));
            registerButton.Click();
            Thread.Sleep(500);
            var emailInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[1]/input"));
            var nameInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[2]/input"));
            var passwordInput = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[3]/div/input"));
            var submitButton = _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[5]/button"));
            emailInput.SendKeys(email);
            nameInput.SendKeys(name);
            passwordInput.SendKeys(password);
            submitButton.Click();
            Thread.Sleep(100);
        }
    }
}
