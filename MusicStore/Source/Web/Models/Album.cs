using System;

namespace MusicStore.Web.Models;

public class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string AlbumArtUrl { get; set; }
}
