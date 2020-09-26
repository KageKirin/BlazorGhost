
namespace Ghost
{
public class Settings
{
    public string Title {get;set;}
    public string Description {get;set;}
    public string Logo {get;set;}
    public string Icon {get;set;}
    public string CoverImage {get;set;}
    public string Facebook {get;set;}
    public string Twitter {get;set;}
    public string Lang {get;set;}
    public string Timezone {get;set;}
    public string CodeinjectionHead {get;set;}
    public string CodeinjectionFoot {get;set;}
    public NavigationItem[] Navigation {get;set;}
    public NavigationItem[] SecondaryNavigation {get;set;}
    public string MetaTitle {get;set;}
    public string MetaDescription {get;set;}
    public string OgImage {get;set;}
    public string OgTitle {get;set;}
    public string OgDescription {get;set;}
    public string TwitterImage {get;set;}
    public string TwitterTitle {get;set;}
    public string TwitterDescription {get;set;}
    public string MembersSupportAddress {get;set;}
    public string Url {get;set;}
}

public class NavigationItem
{
    public string Label {get;set;}
    public string Url {get;set;}
}
}
