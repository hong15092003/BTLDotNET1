namespace BTLDotNET1.Models;

public partial class Hang
{
    public string Id { get; set; }

    public string Ma { get; set; }

    public string Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
