namespace BTLDotNET1.Models;

public partial class HuyenQuan
{
    public string Id { get; set; }

    public string IdTinhTp { get; set; }

    public string Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietDiaChi> ChiTietDiaChis { get; set; } = new List<ChiTietDiaChi>();

    public virtual TinhTp IdTinhTpNavigation { get; set; }

    public virtual ICollection<XaPhuong> XaPhuongs { get; set; } = new List<XaPhuong>();
}
