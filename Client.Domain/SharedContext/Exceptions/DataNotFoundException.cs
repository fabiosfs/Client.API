namespace Client.Domain.SharedContext
{
    [Serializable]
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {

        }
    }
}
