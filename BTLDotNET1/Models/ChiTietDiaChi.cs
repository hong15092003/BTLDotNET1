namespace BTLDotNET1.Models;

public partial class ChiTietDiaChi
{
    public string Id { get; set; }

    public string IdTinhTp { get; set; }

    public string IdHuyenQuan { get; set; }

    public string IdXaPhuong { get; set; }

    public string MoTa { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual HuyenQuan IdHuyenQuanNavigation { get; set; }

    public virtual TinhTp IdTinhTpNavigation { get; set; }

    public virtual XaPhuong IdXaPhuongNavigation { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
