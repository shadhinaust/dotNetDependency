namespace RestApi.Model
{
    public class Intermediate
    {
        public long Id { get; set; }

        public long MessageId { get; set; }

        public string Tag { get; set; }

        public string Data { get; set; }

        public Source Source { get; set; }

        public Decoded Deciphered { get; set; }

        public Auditor Auditor { get; set; }
    }
}