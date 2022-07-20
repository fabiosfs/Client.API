using prmToolkit.NotificationPattern;

namespace Client.Domain.SharedContext
{
    public class EntityBase : Notifiable
    {
        public Guid Id { get; protected set; }

        public EntityBase() => Id = new Guid();
    }
}
