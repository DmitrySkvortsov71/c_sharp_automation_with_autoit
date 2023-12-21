using System.Collections.Generic;
using NUnit.Framework;

namespace c_sharp_automation_with_autoit
{
  public class GroupCreationTests : TestBase
  {
    [Test]
    public void TestGroupCreation()
    {
      var oldGroups = app.Groups.GetGroupList();
      var newGroup = new GroupData()
      {
          Name = "tempo"
              
      };

      app.Groups.Add(newGroup);

      var newGroups = app.Groups.GetGroupList();
      oldGroups.Add(newGroup);
      oldGroups.Sort();
      newGroups.Sort();

      // Assert.AreEqual(oldGroups, newGroups);
    }
  }
}