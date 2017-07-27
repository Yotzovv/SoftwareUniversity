public class Box<T>
{
    public T data;

    public Box(T data)
    {
        this.data = data;
    }

    public override string ToString()
    {
        return $"{data.GetType().FullName}: {this.data}";
    }
}
