namespace Common.Communication
{
    public class Response
    {
        public bool isSuccessful {  get; set; }
        public string Error { get; set; }
        public object Object { get; set; }
    }
}
