using System.Collections.Generic;

namespace c_sharp_automation_with_autoit
{
  public class GroupsHelper : HelperBase
  {
    private const string GroupWinTitle = "Group editor";
    private const string EditGroupButton = "WindowsForms10.BUTTON.app.0.2c908d512";
    private const string GroupEditorButtonNew = "WindowsForms10.BUTTON.app.0.2c908d53";
    private const string GroupEditorButtonClose = "WindowsForms10.BUTTON.app.0.2c908d54";
    private const string GroupTreeView = "WindowsForms10.SysTreeView32.app.0.2c908d51";

    public GroupsHelper(ApplicationManager manager) : base(manager)
    {
    }

    public List<GroupData> GetGroupList()
    {
      var groups = new List<GroupData>();

      OpenGroupsDialogue();

      var count = aux.ControlTreeView(
          GroupWinTitle,
          "",
          GroupTreeView,
          "GetItemCount",
          "#0",
          ""
      );
      for (var i = 0; i < int.Parse(count); i++)
      {
        var item = aux.ControlTreeView(
            GroupWinTitle,
            "",
            GroupTreeView,
            "GetText",
            "#0#"+i,
            ""
        );
        groups.Add(new GroupData() {Name = item} );
      }

      CloseGroupDialogue();
      return groups;
    }

    public GroupsHelper Add(GroupData newGroup)
    {
      OpenGroupsDialogue();

      aux.ControlClick(GroupWinTitle, "", GroupEditorButtonNew);
      aux.Send(newGroup.Name);
      aux.Send("{ENTER}");

      CloseGroupDialogue();
      return this;
    }

    private void CloseGroupDialogue()
    {
      aux.ControlClick(GroupWinTitle, "", GroupEditorButtonClose);
    }

    private GroupsHelper OpenGroupsDialogue()
    {
      aux.ControlClick(WinTitle, "", EditGroupButton);
      aux.WinWait(GroupWinTitle);
      return this;
    }
  }
}