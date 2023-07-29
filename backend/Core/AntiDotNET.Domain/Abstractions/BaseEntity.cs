namespace AntiDotNET.Domain.Abstractions;

public abstract class BaseEntity<T> : IEntity<T> 
{
    public T Id { get; set; }
}