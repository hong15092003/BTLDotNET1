namespace BTLDotNET1.Helpers
{
    internal class ExceptionMessage
    {
        public ExceptionMessage()
        {

        }
        public void Exception(string message)
        {
            Console.WriteLine(message);
        }

        public void Exception(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
