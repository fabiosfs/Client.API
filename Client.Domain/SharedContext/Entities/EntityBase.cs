using prmToolkit.NotificationPattern;

namespace Client.Domain.SharedContext
{
    public abstract class EntityBase : Notifiable
    {
        public Guid Id { get; protected set; }

        public EntityBase() => Id = Guid.NewGuid();

        public void ChangeId(Guid id) => Id = id;

        public abstract void Validation();
    }
}
