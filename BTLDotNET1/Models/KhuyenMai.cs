namespace BTLDotNET1.Models;

public partial class KhuyenMai
{
    public string Id { get; set; }

    public string Ma { get; set; }

    public string TenLoaiKm { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public bool? TrangThai { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<CtspKhuyenMai> CtspKhuyenMais { get; set; } = new List<CtspKhuyenMai>();
}
