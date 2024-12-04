using BTLDotNET1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTLDotNET1.Models;

public partial class MauSac
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}


public class QuanLyMauSac
{
    ExceptionMessage exm = new();
    public ObservableCollection<MauSac> ListAllColor()
    {
        using (var context = new QlsbdtContext())
        {
            var listAllColor = context.MauSacs.ToList();
            return new ObservableCollection<MauSac>(listAllColor);
        }
    }
    public MauSac? FindColorById(string Id)
    {
        using (var context = new QlsbdtContext())
        {
            MauSac? findColorById = context.MauSacs.Where(c => c.Id == Id).FirstOrDefault();
            return findColorById;
        }
    }
    public ObservableCollection<MauSac> FindColorByName(string Name)
    {
        using (var context = new QlsbdtContext())
        {
            var findColorByName = context.MauSacs.Where(p => p.Ten == Name).ToList();
            if (findColorByName == null) return null;
            return new ObservableCollection<MauSac>(findColorByName);
        }
    }

    public bool AddColor(MauSac mauSac)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.MauSacs.Add(mauSac);
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

    public bool UpdateColor(MauSac color)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.MauSacs.Update(color);
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

    public bool DeleteColor(MauSac color)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                bool checkColor = context.ChiTietSanPhams.Any(p => p.IdMauSac == color.Id);
                if (checkColor)
                {
                    color.StatusDeleted = true;
                    context.MauSacs.Update(color);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    context.MauSacs.Remove(color);
                    context.SaveChanges();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }
}