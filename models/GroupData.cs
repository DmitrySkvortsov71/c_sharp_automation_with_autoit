using System;

namespace c_sharp_automation_with_autoit
{
  public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
  {
    
    public string Name { get; set; }

    public int CompareTo(GroupData other)
    {
      return ReferenceEquals(other, null) ? 1 : Name.CompareTo(other.Name);
    }

    public bool Equals(GroupData other)
    {
      if (ReferenceEquals(other, null)) return false;
      if (ReferenceEquals(this, other)) return true;

      return Name.Equals(other.Name, StringComparison.Ordinal);
    }
    
    public override string ToString()
    {
      return $"group name: {Name}";
    }
    
  }
  
  
  
}