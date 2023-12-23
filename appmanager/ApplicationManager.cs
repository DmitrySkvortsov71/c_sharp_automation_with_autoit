using AutoItX3Lib; // install/register separately & add to References

namespace c_sharp_automation_with_autoit
{
  public class ApplicationManager
  {
    public const string WinTitle = "Free Address Book";

    private AutoItX3 aux;
    private GroupsHelper groupHelper;

    public ApplicationManager()
    {
      const string appFullPath = @"C:\Users\dscwo\source\repos\+addressbook_app_soft\AddressBook.exe";
      aux = new AutoItX3();

      // run application
      aux.Run(appFullPath, "", aux.SW_SHOW);
      
      aux.WinWait(WinTitle);
      // aux.WinActivate(WinTitle);
      aux.WinWaitActive(WinTitle);

      groupHelper = new GroupsHelper(this);
    }

    public void Stop()
    {
      // stop application by click "Exit" button
      aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d5");
    }

    public AutoItX3 Aux => aux;
    public GroupsHelper Groups => groupHelper;
  }
}