using BTLDotNET1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BTLDotNET1.Utils
{
    public class Provinces : Control
    {
        string IdHuyenQuan;
        string IdTinhTP;
        string IdXaPhuong;

        ComboBox DropTinhTP;
        ComboBox DropHuyenQuan;
        ComboBox DropXaPhuong;

        public Provinces
            (
            ref string IdTinhTP, 
            ref string IdHuyenQuan,
            ref string IdXaPhuong, 
            ref ComboBox DropTinhTP,
            ref ComboBox DropHuyenQuan,
            ref ComboBox DropXaPhuong 
            )
        {
            this.IdTinhTP = IdTinhTP;
            this.IdHuyenQuan = IdHuyenQuan;
            this.IdXaPhuong = IdXaPhuong;
            this.DropTinhTP = DropTinhTP;
            this.DropHuyenQuan = DropHuyenQuan;
            this.DropXaPhuong = DropXaPhuong;
        }


        public void FillData()
        {
        
            using (var context = new QlsbdtContext())
            {
                var ListTinhTP = context.TinhTps.Select(t => t.Ten).ToList();
                DropTinhTP.ItemsSource = ListTinhTP;
            }
            DropTinhTP.SelectionChanged += (sender, e) => DropTinhTP_SelectionChanged();
            DropHuyenQuan.SelectionChanged += (sender, e) => DropHuyenQuan_SelectionChanged();
            DropXaPhuong.SelectionChanged += (sender, e) => DropXaPhuong_SelectionChanged();


        }




        private void DropTinhTP_SelectionChanged()
        {

            var TinhTPChoose = DropTinhTP.SelectedItem.ToString();
            using (var context = new QlsbdtContext())
            {
                var ListTinhTP = context.TinhTps.Select(t => t).ToList();
                IdTinhTP = ListTinhTP.Where(t => t.Ten == TinhTPChoose).Select(t => t.Id).First();
                var ListHuyenQuan = context.HuyenQuans
                    .Where(h => h.IdTinhTp == IdTinhTP)
                    .Select(h => h.Ten)
                    .ToList();
                DropHuyenQuan.ItemsSource = ListHuyenQuan;
                
            }
            
        }

        private void DropHuyenQuan_SelectionChanged()
        {
            if (DropHuyenQuan.SelectedItem != null)
            {
                var HuyenQuanChoose = DropHuyenQuan.SelectedItem.ToString();
                using (var context = new QlsbdtContext())
                {
                    var ListHuyenQuan = context.HuyenQuans.Where(h => h.IdTinhTp == IdTinhTP).Select(h => h).ToList();
                    IdHuyenQuan = ListHuyenQuan.Where(h => h.Ten == HuyenQuanChoose).Select(h => h.Id).First();
                    var ListXaPhuong = context.XaPhuongs
                        .Where(x => x.IdHuyenQuan == IdHuyenQuan)
                        .Select(x => x.Ten)
                        .ToList();

                    DropXaPhuong.ItemsSource = ListXaPhuong;
                    
                }
            }
            
        }


        private void DropXaPhuong_SelectionChanged()
        {
            var XaPhuongChoose = DropXaPhuong.SelectedItem.ToString();
            using (var context = new QlsbdtContext())
            {
                var ListXaPhuong = context.XaPhuongs.Where(x => x.IdHuyenQuan == IdHuyenQuan).Select(x => x).ToList();
                IdXaPhuong = ListXaPhuong.Where(x => x.Ten == XaPhuongChoose).Select(x => x.Id).First();
            }

        }
    }
}
