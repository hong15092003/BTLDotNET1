namespace BTLDotNET1.Models;

public partial class SanPham
{
    public string Id { get; set; }

    public string Ma { get; set; }

    public string Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public string IdHang { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual Hang IdHangNavigation { get; set; }
}
