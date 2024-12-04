using BTLDotNET1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTLDotNET1.Models;

public partial class Hang
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}

class QuanLyHang
{
    ExceptionMessage exm = new ExceptionMessage();

    public ObservableCollection<Hang> ListAllBrand()
    {
        using (var context = new QlsbdtContext())
        {
            var listAllBrand = context.Hangs.ToList();
            return new ObservableCollection<Hang>(listAllBrand);
        }
    }
    public Hang? FindBrandById(string id)
    {
        using (var context = new QlsbdtContext())
        {
            var findBrandByCode = context.Hangs.Where(b => b.Id == id).FirstOrDefault();
            if (findBrandByCode == null) return null;
            return findBrandByCode;
        }
    }
    public Hang? FindBrandByMa(string ma)
    {
        using (var context = new QlsbdtContext())
        {
            var findBrandByCode = context.Hangs.Where(b => b.Ma == ma).FirstOrDefault();
            if (findBrandByCode == null) return null;
            return findBrandByCode;
        }
    }

    public ObservableCollection<Hang>? FindBrandByName(string name)
    {
        using (var context = new QlsbdtContext())
        {
            var listAllBrand = context.Hangs.Where(b => b.Ten.Contains(name)).ToList();
            if (listAllBrand == null) return null;
            return new ObservableCollection<Hang>(listAllBrand);
        }
    }

    public bool AddBrand(Hang hang)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                Hang? kiemTraHang = FindBrandById(hang.Id);
                if (kiemTraHang == null)
                {
                    context.Hangs.Add(hang);
                    context.SaveChanges();

                }
                else
                {
                    UpdateBrand(hang);
                }
                return true;
            }
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }

    public bool UpdateBrand(Hang brand)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.Hangs.Update(brand);
                context.SaveChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }

    public bool DeleteBrand(Hang brand)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                bool checkBrand = context.SanPhams.Any(p => p.IdHang == brand.Id);
                if (checkBrand)
                {
                    brand.StatusDeleted = true;
                    context.Hangs.Update(brand);
                }
                else
                {
                    context.Hangs.Remove(brand);
                    context.SaveChanges();
                }
                return true;
            }
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }
}