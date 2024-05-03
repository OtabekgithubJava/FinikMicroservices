namespace News.Domain.Entities
{
    public class NewsModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }

        // mashi joyga rasm qoyadigan qowiw kk.
        public string AttachmentFile { get; set;}
        public string PostedDate { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
    }
}
