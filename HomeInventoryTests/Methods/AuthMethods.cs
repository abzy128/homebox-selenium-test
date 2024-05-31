namespace HomeInventoryTests.Methods;

public static class AuthMethods
{
    private static readonly TestSettings TestSettings = TestSettingLoader.Load();

    public static void LoginToWebsite(this ChromeDriver driver, string email, string password)
    {
        driver.Navigate().GoToUrl(TestSettings.WebsiteUrl);
        Thread.Sleep(500);
        var loginInput =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[1]/input"));
        var passwordInput =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[2]/div/input"));
        var submitButton =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[4]/button"));
        loginInput.SendKeys(email);
        passwordInput.SendKeys(password);
        submitButton.Click();
        Thread.Sleep(3000);
    }

    public static void RegisterToWebsite(this ChromeDriver driver, string email, string name, string password)
    {
        driver.Navigate().GoToUrl(TestSettings.WebsiteUrl);
        Thread.Sleep(100);
        var registerButton = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/div/button"));
        registerButton.Click();
        Thread.Sleep(500);
        var emailInput =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[1]/input"));
        var nameInput =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[2]/input"));
        var passwordInput =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[3]/div/input"));
        var submitButton =
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/div/div/form/div/div/div[5]/button"));
        emailInput.SendKeys(email);
        nameInput.SendKeys(name);
        passwordInput.SendKeys(password);
        submitButton.Click();
        Thread.Sleep(100);
    }
}