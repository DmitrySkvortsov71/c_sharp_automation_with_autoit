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
    
    private const string GroupDeleteTitle = "Delete group";
    private const string GroupDeleteButton = "WindowsForms10.BUTTON.app.0.2c908d51";
    private const string GroupDeleteOkButton = "WindowsForms10.BUTTON.app.0.2c908d53";

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
        var itemLine = $"#0|#{i}";
        var item = aux.ControlTreeView(
            GroupWinTitle, "", GroupTreeView, 
            "GetText", itemLine, ""
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

    public GroupsHelper Remove(int index)
    {
      OpenGroupsDialogue();
      
      var itemLine = $"#0|#{index}";
      
      // select group for deletion
      var item = aux.ControlTreeView(
          GroupWinTitle, "", GroupTreeView, 
          "Select", itemLine, ""
      );
      aux.ControlClick(GroupWinTitle, "", GroupDeleteButton);
      aux.Send("{ENTER}"); // confirm deletion with move contacts into the only group
      
      CloseGroupDialogue();
      return this;
    }
  }
}