public class AlbumsPictures
{
    public AlbumsPictures()
    {
    }

    public AlbumsPictures(int album_Id, int picture_Id)
    {
        AlbumId = album_Id;
        PictureId = picture_Id;
    }

    public int Id { get; set; }

    public int AlbumId { get; set; }

    public Album Album { get; set; }

    public int PictureId { get; set; }

    public Picture Picture { get; set; }
}
