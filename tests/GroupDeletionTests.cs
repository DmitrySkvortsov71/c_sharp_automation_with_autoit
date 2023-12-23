using NUnit.Framework;

namespace c_sharp_automation_with_autoit
{
  
  public class GroupDeletionTests : TestBase
  {
    public static object[] NewGroupData =
    {
        new object[]
        {
            new GroupData() { Name = GenerateRandomNumber(1000, 10000) },
        },
    };
    
    [Test]
    [TestCaseSource(nameof(NewGroupData))]
    public void GroupDeletionTest(GroupData newGroup)
    {
      var oldGroups = app.Groups.GetGroupList();
      
      if (oldGroups.Count <= 1) // we couldn't delete the only group
      {
        app.Groups.Add(newGroup);
        oldGroups = app.Groups.GetGroupList();
      }
      
      app.Groups.Remove(1);
      
      var newGroups = app.Groups.GetGroupList();
      oldGroups.RemoveAt(1);
      oldGroups.Sort();
      newGroups.Sort();
      
      Assert.AreEqual(oldGroups, newGroups);

    }
  }
}