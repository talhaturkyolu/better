using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _objectContainer;

    public Hooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void Initialize()
    {
        var options = new ChromeOptions();
        options.AddArgument("headless");

        IWebDriver driver = new ChromeDriver(options);
        _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
    }

    [AfterScenario]
    public void CleanUp()
    {
        var driver = _objectContainer.Resolve<IWebDriver>();
        driver.Quit();
    }
}
