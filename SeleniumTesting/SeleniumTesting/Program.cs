using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

double totalVotes = 0;

double votesLastCheck = 0;
int totalRunTime = 0;
double avgVotes = 0;

var taskList = new List<Task>();

Console.WriteLine("Target Submissionnumber (default 25803): ");
var submissionNumber = Console.ReadLine() ?? "25803";
Console.WriteLine("Amount of Threads (default 5): ");
var threadAmount = short.Parse(Console.ReadLine() ?? "5");
Console.WriteLine("Total amount of votes.(They get split up for each thread. default 5)");
var numVotes = short.Parse(Console.ReadLine() ?? "5");

if (numVotes == -1) numVotes = short.MaxValue;

var votesPerThread = Math.Round((decimal)numVotes / threadAmount);

System.Timers.Timer timer = new();
timer.Interval = 1000;
timer.Elapsed += Timer_Elapsed;

timer.Start();

while(taskList.Count < threadAmount)
{
    taskList.Add(Task.Factory.StartNew(VotingThread));
}

Task.WaitAll(taskList.ToArray());

async void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
{
    if (totalVotes != 0)
    {
        votesLastCheck = totalVotes;
        totalRunTime++;
        avgVotes = totalVotes / totalRunTime;
    }

    if (totalRunTime % 10 == 0)
    {
        await Task.Run(CheckCurrentLikes);
    }
}

ChromeOptions GenerateChromeOptions()
{
    ChromeOptions options = new();
    options.PageLoadStrategy = PageLoadStrategy.Normal;
    options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
    options.AddArgument("--no-sandbox");
    options.AddArgument("--disable-gpu");
    options.AddArgument("--disable-crash-reporter");
    options.AddArgument("--disable-extensions");
    options.AddArgument("--disable-in-process-stack-traces");
    options.AddArgument("--disable-logging");
    options.AddArgument("--disable-dev-shm-usage");
    options.AddArgument("--log-level=3");
    options.AddArgument("--output=/dev/null");
    options.AddArgument("headless");
    options.AddArgument("--window-size=1920,1080");

    return options;
}

void CheckCurrentLikes()
{
    var opts = GenerateChromeOptions();

    IWebDriver driver = new ChromeDriver(opts);

    driver.Navigate().GoToUrl($"https://lehrlingshackathon.at/submission/{submissionNumber}/");

    driver.Manage().Cookies.DeleteAllCookies();
    driver.Navigate().Refresh();

    var like = driver.FindElement(By.CssSelector($"a[data-post-id='{submissionNumber}']"));
    Thread.Sleep(2000);

    like.Click();

    Thread.Sleep(2000);

    var totalLikes = driver.FindElement(By.CssSelector($"span[pld-like-count-wrap pld-count-wrap]"));
    Console.WriteLine($"Current Like Count: {totalLikes.Text}");
}

void VotingThread()
{
    var opts = GenerateChromeOptions();

    IWebDriver driver = new ChromeDriver(opts);

    driver.Navigate().GoToUrl($"https://lehrlingshackathon.at/submission/{submissionNumber}/");

    for (int i = 0; i < votesPerThread; i++)
    {        
        var like = driver.FindElement(By.CssSelector($"a[data-post-id='{submissionNumber}']"));        
        like.Click();
        totalVotes++;
        Console.WriteLine($"Total Votes: [{totalVotes} / {numVotes}]  with an avg of {avgVotes}");
        driver.Manage().Cookies.DeleteCookieNamed($"pld_{submissionNumber}");
        driver.Navigate().Refresh();
    }

    driver.Quit();
}