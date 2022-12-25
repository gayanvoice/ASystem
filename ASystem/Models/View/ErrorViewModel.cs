namespace ASystem.Models.View
{
    public class ErrorViewModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Url PreviousUrl { get; set; }
        public class Url
        {
            public string Controller { get; set; }
            public string Action { get; set; }
        }
    }
}