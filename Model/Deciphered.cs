namespace RestApi.Model
{
    public class Deciphered
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public string Tag { get; set; }

        public string Data { get; set; }

        public Intermediate Intermediate { get; set; }

        public Auditor Auditor { get; set; }
    }
}