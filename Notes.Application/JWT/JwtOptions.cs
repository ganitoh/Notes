namespace Notes.Application.JWT
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audiance { get; set; } = string.Empty;
        public int ExpireHourse { get; set; }
    }
}
