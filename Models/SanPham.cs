using BTLDotNET1.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BTLDotNET1.Models;

public partial class SanPham
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public string IdHang { get; set; } = null!;

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual Hang IdHangNavigation { get; set; } = null!;
}


public class QuanLySanPham
{
    ExceptionMessage exm = new();


    public ObservableCollection<SanPham> ListAllProduct()
    {
        using (var context = new QlsbdtContext())
        {
            var listAllProduct = context.SanPhams.ToList();
            return new ObservableCollection<SanPham>(listAllProduct);
        }
    }

    public ObservableCollection<SanPham> FindProductsByCode(string Code)
    {
        using (var context = new QlsbdtContext())
        {
            var findProductByCode = context.SanPhams.Where(p => p.Ma.Contains(Code));
            return new ObservableCollection<SanPham>(findProductByCode);
        }
    }

    public SanPham? FindProductByCode(string Code)
    {
        using (var context = new QlsbdtContext())
        {
            var findProductByCode = context.SanPhams.Where(p => p.Ma == Code).FirstOrDefault();
            if (findProductByCode == null) return null;
            return findProductByCode;
        }
    }

    public ObservableCollection<SanPham> FindProductsByName(string Name)
    {
        using (var context = new QlsbdtContext())
        {
            var findProductByName = context.SanPhams.Where(p => p.Ten.Contains(Name));
            return new ObservableCollection<SanPham>(findProductByName);
        }
    }

    public ObservableCollection<SanPham> FindProductsByBrand(string brand)
    {
        using (var context = new QlsbdtContext())
        {
            var findProductByHang = context.SanPhams.Where(p => p.IdHang == brand);
            return new ObservableCollection<SanPham>(findProductByHang);
        }
    }

    public bool AddProduct(SanPham product)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.SanPhams.Add(product);
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

    public bool UpdateProduct(SanPham product)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {
                context.SanPhams.Update(product);
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

    public bool DeleteProduct(SanPham product)
    {
        try
        {
            using (var context = new QlsbdtContext())
            {

                QuanLyChiTietSanPham quanLyChiTietSanPham = new QuanLyChiTietSanPham();

                ObservableCollection<ChiTietSanPham> productDetailOfProduct = quanLyChiTietSanPham.FindProductDetailByIdProduct(product.Id);

                foreach (ChiTietSanPham item in productDetailOfProduct)
                {
                    bool isDelete = quanLyChiTietSanPham.DeleteProductDetail(item);
                }

                productDetailOfProduct = quanLyChiTietSanPham.FindProductDetailByIdProduct(product.Id);

                if (productDetailOfProduct.Count == 0)
                {
                    context.SanPhams.Remove(product);
                    context.SaveChanges();

                }
                else
                {
                    product.StatusDeleted = true;
                    context.SanPhams.Update(product);
                    context.SaveChanges();
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