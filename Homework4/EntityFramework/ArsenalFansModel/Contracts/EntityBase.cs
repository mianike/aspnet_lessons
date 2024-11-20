using ArsenalFansModel.Contracts.Interfaces;

namespace ArsenalFansModel.Contracts
{
    public abstract class EntityBase<T> : IEntity
    {
        public T Id { get; set; }
    }
}
