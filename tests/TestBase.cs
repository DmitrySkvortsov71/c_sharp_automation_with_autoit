using System;
using NUnit.Framework;

namespace c_sharp_automation_with_autoit
{
  public class TestBase
  {
    public ApplicationManager app;

    [SetUp]
    public void InitApplication()
    {
      app = new ApplicationManager();
    }

    [TearDown]
    public void StopApplication()
    {
      app.Stop();
    }
    
    public static readonly Random Rnd = new Random();
    public static string GenerateRandomNumber(int min, int max)
    {
      return Convert.ToString(Rnd.Next(min, max));
    }
  }
}