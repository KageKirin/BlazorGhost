
namespace Ghost
{
public class Post
{
    public string Id {get;set;}
    public string Uuid {get;set;}
    public string Title {get;set;}
    public string Slug {get;set;}
    public string Html {get;set;}
    public string CommentId {get;set;}
    public string FeatureImage {get;set;}
    public bool Featured {get;set;}
    public string Visibility {get;set;}
    public string CreatedAt {get;set;}
    public string UpdatedAt {get;set;}
    public string PublishedAt {get;set;}
    public string CustomExcerpt {get;set;}
    public string CodeinjectionHead {get;set;}
    public string CodeinjectionFoot {get;set;}
    public string CustomTemplate {get;set;}
    public string CanonicalUrl {get;set;}
    public string Url {get;set;}
    public string Excerpt {get;set;}
    public string ReadingTime {get;set;}
    //public string Page {get;set;}
    public bool Access {get;set;}
    public string OgImage {get;set;}
    public string OgTitle {get;set;}
    public string OgDescription {get;set;}
    public string TwitterImage {get;set;}
    public string TwitterTitle {get;set;}
    public string TwitterDescription {get;set;}
    public string MetaTitle {get;set;}
    public string MetaDescription {get;set;}

    public Tag PrimaryTag {get;set;}
    public Tag[] Tags {get;set;}

    public Author PrimaryAuthor {get;set;}
    public Author[] Authors {get;set;}

}
}
