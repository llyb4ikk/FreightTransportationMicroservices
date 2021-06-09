namespace IDserv.Infrastruct
{
    public class OperationDetails
    {
        public OperationDetails(bool succedeed, string message, string prop, int userId)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
            UserId = userId;
        }
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
        public int UserId { get; set; }
    }
}