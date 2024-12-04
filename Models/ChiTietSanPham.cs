using BTLDotNET1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTLDotNET1.Models;

public partial class ChiTietSanPham
{
    public string Id { get; set; } = null!;

    public string IdSanPham { get; set; } = null!;

    public string IdMauSac { get; set; } = null!;

    public string IdCtspKhuyenMai { get; set; } = null!;

    public string IdPhuKien { get; set; } = null!;

    public double? BoNhoTrong { get; set; }

    public double? Ram { get; set; }

    public string? MoTa { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public decimal? Gia { get; set; }

    public int? SoLuong { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual CtspKhuyenMai IdCtspKhuyenMaiNavigation { get; set; } = null!;

    public virtual MauSac IdMauSacNavigation { get; set; } = null!;

    public virtual PhuKien IdPhuKienNavigation { get; set; } = null!;

    public virtual SanPham IdSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<Imei> Imeis { get; set; } = new List<Imei>();
}


class QuanLyChiTietSanPham
{
    ExceptionMessage exm = new ExceptionMessage();
    public ObservableCollection<ChiTietSanPham> ListAllProductDetail()
    {

        using (var context = new QlsbdtContext())
        {
            var listProductDetail = context.ChiTietSanPhams.ToList();
            return new ObservableCollection<ChiTietSanPham>(listProductDetail);
        }
    }

    public ObservableCollection<ChiTietSanPham> FindProductDetailByIdProduct(string id)
    {
        using (var context = new QlsbdtContext())
        {
            var listProductDetail = context.ChiTietSanPhams.Where(p => p.IdSanPham == id).ToList();
            return new ObservableCollection<ChiTietSanPham>(listProductDetail);
        }
    }

    public ObservableCollection<ChiTietSanPham> FindProductDetailByProductColor(string colorName)
    {
        using (var context = new QlsbdtContext())
        {
            var listProductDetail = context.MauSacs
                .Where(c => c.Ten.Contains(colorName))
                .Join(context.ChiTietSanPhams, c => c.Id, p => p.IdMauSac, (c, p) => p)
                .ToList();
            return new ObservableCollection<ChiTietSanPham>(listProductDetail);
        }
    }

    public ObservableCollection<ChiTietSanPham> FindProductDetailByPromotion(string promotionId)
    {
        using (var context = new QlsbdtContext())
        {
            var listProductDetail = context.CtspKhuyenMais
                .Where(c => c.IdKhuyenMai.Contains(promotionId))
                .Join(context.ChiTietSanPhams, c => c.Id, p => p.IdCtspKhuyenMai, (c, p) => p)
                .ToList();
            return new ObservableCollection<ChiTietSanPham>(listProductDetail);
        }
    }

    public bool AddProductDetail(ChiTietSanPham productDetail)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                ChiTietSanPham? chiTietSanPham = context.ChiTietSanPhams.Find(productDetail.Id);
                if (chiTietSanPham != null)
                {
                    productDetail.CreateDate = chiTietSanPham.CreateDate;
                    UpdateProductDetail(productDetail);
                    context.SaveChanges();
                }
                else
                {
                    context.ChiTietSanPhams.Add(productDetail);
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

    public bool AddManyProductDetail(List<ChiTietSanPham> listChiTietSanPham)
    {
        try
        {
            foreach (var item in listChiTietSanPham)
            {
                AddProductDetail(item);
            }
            return true;
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }

    public bool AddManyProductDetail(ObservableCollection<ChiTietSanPham> listChiTietSanPham)
    {
        try
        {
            foreach (var item in listChiTietSanPham)
            {
                AddProductDetail(item);
            }
            return true;
        }
        catch (Exception ex)
        {
            exm.Exception(ex);
            return false;
        }
    }

    public bool UpdateProductDetail(ChiTietSanPham productDetail)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.ChiTietSanPhams.Update(productDetail);
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
    public bool DeleteProductDetail(ChiTietSanPham productDetail)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                var checkProductDetail = context.HoaDonChiTiets.Any(p => p.IdSanPham == productDetail.Id);
                if (checkProductDetail)
                {
                    productDetail.StatusDeleted = true;
                    context.ChiTietSanPhams.Update(productDetail);
                    context.SaveChanges();
                }
                else
                {
                    context.ChiTietSanPhams.Remove(productDetail);
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

    public bool DeleteManyProductDetail(List<ChiTietSanPham> listProductDetail)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                foreach (var item in listProductDetail)
                {
                    DeleteProductDetail(item);
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
    public bool DeleteManyProductDetail(ObservableCollection<ChiTietSanPham> listProductDetail)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                foreach (var item in listProductDetail)
                {
                    DeleteProductDetail(item);
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