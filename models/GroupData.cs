using System;

namespace c_sharp_automation_with_autoit
{
  public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
  {
    
    public string Name { get; set; }
    public int CompareTo(GroupData other) => this.Name.CompareTo(other.Name);
    public bool Equals(GroupData other) => this.Name.Equals(other.Name);
  }
  
  
  
  
}