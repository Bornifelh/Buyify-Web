namespace Buyify_Web
{
    public class Article
    {
        public int Id { get; set; }
        public string? IdMagasin { get; set; }
        public string? CategoryID { get; set; }
        public string? Nom { get; set; }
        public string? Details { get; set; }
        public decimal? Prix { get; set; }
        public decimal? PrixSold { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public string? Img4 { get; set; }
        public object AccueillModel { get; internal set; }
    }
}
