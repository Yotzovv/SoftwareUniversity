namespace _01.Stream_Progress.Interfaces
{
    public interface IStreamable
    {
        int Length { get; }
        int BytesSent { get; }
    }
}
