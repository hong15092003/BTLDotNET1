using BTLDotNET1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTLDotNET1.Models;

public partial class PhuKien
{
    public string Id { get; set; } = null!;

    public string? Ma { get; set; }

    public string? MoTa { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}


class QuanLyPhuKien
{

    ExceptionMessage exm = new ExceptionMessage();

    public ObservableCollection<PhuKien> ListAllAccessory()
    {
        using (var context = new QlsbdtContext())
        {
            var listAllAccessory = context.PhuKiens.ToList();
            return new ObservableCollection<PhuKien>(listAllAccessory);
        }
    }

    public PhuKien? FindAccessoryById(string id)
    {
        using (var context = new QlsbdtContext())
        {
            var findAccessoryById = context.PhuKiens.Where(p => p.Id == id).FirstOrDefault();
            if (findAccessoryById == null) return null;
            return findAccessoryById;
        }
    }

    public ObservableCollection<PhuKien> FindAccessoryByDescriptions(string descriptions)
    {
        using (var context = new QlsbdtContext())
        {
            var findAccessoryByDescriptions = context.PhuKiens.Where(p => p.MoTa.Contains(descriptions)).Select(p => new PhuKien
            {
                Id = p.Id,
                Ma = p.Ma,
                MoTa = p.MoTa,
                CreateDate = p.CreateDate,
                LastModifiedDate = p.LastModifiedDate,
                StatusDeleted = p.StatusDeleted,
            }).ToList();
            if (findAccessoryByDescriptions == null) return null;
            return new ObservableCollection<PhuKien>(findAccessoryByDescriptions);
        }
    }

    public bool AddAccessory(PhuKien phuKien)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                bool checkPhuKien = context.PhuKiens.Any(p => p.Id == phuKien.Id);
                if (checkPhuKien) return UpdateAccessory(phuKien);
                context.PhuKiens.Add(phuKien);
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

    public bool UpdateAccessory(PhuKien phuKien)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.PhuKiens.Update(phuKien);
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

    public bool DeleteAccessory(PhuKien phuKien)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                bool checkAccessory = context.ChiTietSanPhams.Any(p => p.IdPhuKien == phuKien.Id);
                if (checkAccessory)
                {
                    phuKien.StatusDeleted = true;
                    context.PhuKiens.Update(phuKien);
                }
                else
                {
                    context.PhuKiens.Remove(phuKien);
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }
}