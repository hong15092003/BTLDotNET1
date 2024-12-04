namespace BTLDotNET1.Models;

public partial class XaPhuong
{
    public string Id { get; set; }

    public string IdHuyenQuan { get; set; }

    public string Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietDiaChi> ChiTietDiaChis { get; set; } = new List<ChiTietDiaChi>();

    public virtual HuyenQuan IdHuyenQuanNavigation { get; set; }
}
