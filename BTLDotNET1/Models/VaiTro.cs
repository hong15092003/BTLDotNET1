namespace BTLDotNET1.Models;

public partial class VaiTro
{
    public string Id { get; set; }

    public string Ten { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
