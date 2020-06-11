namespace RestApi.Model
{
    public class Log
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public Auditor Auditor { get; set; }
    }
}