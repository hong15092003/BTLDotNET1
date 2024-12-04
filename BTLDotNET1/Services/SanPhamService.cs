using BTLDotNET1.Models;
using Microsoft.EntityFrameworkCore;

namespace BTLDotNET1.Services
{
    public class SanPhamService
    {
        private readonly QLSBDTContext _context;
        private readonly IGenericRepository<ChiTietSanPham> _quanLyChiTietSanPham;

        public SanPhamService(QLSBDTContext context, IGenericRepository<ChiTietSanPham> quanLyChiTietSanPham)
        {
            _context = context;
            _quanLyChiTietSanPham = quanLyChiTietSanPham;
        }

        public async Task AddOrUpdateSanPhamAsync(SanPham sanPham, List<ChiTietSanPham> chiTietSanPhams)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingSanPham = await _context.SanPhams
                    .Include(sp => sp.ChiTietSanPhams)
                    .FirstOrDefaultAsync(sp => sp.Id == sanPham.Id);

                if (existingSanPham != null)
                {
                    // Update existing product
                    existingSanPham.Ma = sanPham.Ma;
                    existingSanPham.Ten = sanPham.Ten;
                    existingSanPham.IdHang = sanPham.IdHang;
                    existingSanPham.LastModifiedDate = sanPham.LastModifiedDate;
                    // Update other properties as needed

                    List<ChiTietSanPham> listProductDetailCurrently = new List<ChiTietSanPham>(existingSanPham.ChiTietSanPhams);
                    foreach (var item in listProductDetailCurrently)
                    {

                        await _quanLyChiTietSanPham.DeleteAsync(item.Id);

                    }
                    foreach (var item in chiTietSanPhams)
                    {
                        await _quanLyChiTietSanPham.AddOrUpdateAsync(item);
                    }
                }
                else
                {
                    // Add new product
                    sanPham.Id = Guid.NewGuid().ToString();
                    sanPham.ChiTietSanPhams = chiTietSanPhams.Select(ctsp =>
                    {
                        ctsp.Id = ctsp.Id;
                        ctsp.IdSanPham = sanPham.Id;
                        return ctsp;
                    }).ToList();

                    _context.SanPhams.Add(sanPham);
                    await _context.SaveChangesAsync();
                }
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }

}
