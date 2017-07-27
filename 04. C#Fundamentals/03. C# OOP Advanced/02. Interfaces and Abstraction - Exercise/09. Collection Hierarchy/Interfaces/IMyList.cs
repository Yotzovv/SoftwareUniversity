namespace _09.Collection_Hierarchy.Interfaces
{
    public interface IMyList<T> : IAddRemoveCollection<T>
    {
        int User { get; }
    }
}
