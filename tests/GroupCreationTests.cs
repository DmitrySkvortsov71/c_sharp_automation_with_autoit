using NUnit.Framework;

namespace c_sharp_automation_with_autoit
{
  public class GroupCreationTests : TestBase
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
    public void TestGroupCreation(GroupData newGroup)
    {
      var oldGroups = app.Groups.GetGroupList();

      app.Groups.Add(newGroup);

      var newGroups = app.Groups.GetGroupList();
      oldGroups.Add(newGroup);
      oldGroups.Sort();
      newGroups.Sort();
      
      Assert.AreEqual(oldGroups, newGroups);
    }
  }
}