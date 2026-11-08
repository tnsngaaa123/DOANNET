namespace PhongKham.Core;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class PageInfoAttribute : Attribute
{
    public string Key
    {
        get;
    }
    public string Title
    {
        get;
    }
    public string Group
    {
        get;
    }
    public int Order
    {
        get;
    }
    public string[] Roles
    {
        get;
    }
    public bool ShowInMenu { get; set; } = true;

    public PageInfoAttribute(string key, string title, string group, int order, params string[] roles)
    {
        Key = key;
        Title = title;
        Group = group;
        Order = order;
        Roles = roles;
    }
}