namespace Client.Domain.SharedContext
{
    [Serializable]
    public class UnprocessableEntityException : Exception
    {
        public IEnumerable<string> ValidationErros { get; private set; }

        public UnprocessableEntityException(IEnumerable<string> validationErros, string message) : base(message)
        {
            ValidationErros = validationErros;
        }
    }
}
