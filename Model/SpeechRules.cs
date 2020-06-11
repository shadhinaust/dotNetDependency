namespace RestApi.Model
{
    public class SpeechRules
    {
        public long Id { get; set; }

        public string Rule { get; set; }

        public string MessageFormat { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public Auditor Auditor { get; set; }
    }
}