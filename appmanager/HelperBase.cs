using AutoItX3Lib;

namespace c_sharp_automation_with_autoit
{
  public class HelperBase
  {
    protected ApplicationManager manager;
    protected readonly string WinTitle;
    protected AutoItX3 aux;

    public HelperBase(ApplicationManager manager)
    {
      this.manager = manager;
      aux = manager.Aux;
      WinTitle = ApplicationManager.WinTitle;
    }
  }
}