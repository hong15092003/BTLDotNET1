namespace BTLDotNET1.Models;

public partial class BaoHanh
{
    public string Id { get; set; }

    public int ThoiGianBaoHanh { get; set; }

    public DateOnly NgayBatDau { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public string IdImei { get; set; }

    public virtual Imei IdImeiNavigation { get; set; }
}
