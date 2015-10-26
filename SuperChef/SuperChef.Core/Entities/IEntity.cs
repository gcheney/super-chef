
namespace SuperChef.Core.Entities
{
    interface IEntity<T>
    {
        T Id { get; set; }
    }
}
