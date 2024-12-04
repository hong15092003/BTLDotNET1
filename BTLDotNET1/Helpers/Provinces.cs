//using BTLDotNET1.Models;
//using System.Windows.Controls;

//namespace BTLDotNET1.Utils
//{
//    public class Provinces(
//        ref string idTinhTp,
//        ref string idHuyenQuan,
//        ref string idXaPhuong,
//        ref ComboBox dropTinhTp,
//        ref ComboBox dropHuyenQuan,
//        ref ComboBox dropXaPhuong)
//        : Control
//    {
//        string IdHuyenQuan = idHuyenQuan;
//        string IdTinhTP = idTinhTp;
//        string IdXaPhuong = idXaPhuong;

//        ComboBox DropTinhTP = dropTinhTp;
//        ComboBox DropHuyenQuan = dropHuyenQuan;
//        ComboBox DropXaPhuong = dropXaPhuong;


//        public void FillData()
//        {

//            using (var context = new QLSBDTContext())
//            {
//                var ListTinhTP = context.TinhTps.Select(t => t.Ten).ToList();
//                DropTinhTP.ItemsSource = ListTinhTP;
//            }
//            DropTinhTP.SelectionChanged += (sender, e) => DropTinhTP_SelectionChanged();
//            DropHuyenQuan.SelectionChanged += (sender, e) => DropHuyenQuan_SelectionChanged();
//            DropXaPhuong.SelectionChanged += (sender, e) => DropXaPhuong_SelectionChanged();


//        }




//        private void DropTinhTP_SelectionChanged()
//        {

//            var TinhTPChoose = DropTinhTP.SelectedItem.ToString();
//            using (var context = new QLSBDTContext())
//            {
//                var ListTinhTP = context.TinhTps.Select(t => t).ToList();
//                IdTinhTP = ListTinhTP.Where(t => t.Ten == TinhTPChoose).Select(t => t.Id).First();
//                var ListHuyenQuan = context.HuyenQuans
//                    .Where(h => h.IdTinhTp == IdTinhTP)
//                    .Select(h => h.Ten)
//                    .ToList();
//                DropHuyenQuan.ItemsSource = ListHuyenQuan;

//            }

//        }

//        private void DropHuyenQuan_SelectionChanged()
//        {
//            if (DropHuyenQuan.SelectedItem != null)
//            {
//                var HuyenQuanChoose = DropHuyenQuan.SelectedItem.ToString();
//                using (var context = new QLSBDTContext())
//                {
//                    var ListHuyenQuan = context.HuyenQuans.Where(h => h.IdTinhTp == IdTinhTP).Select(h => h).ToList();
//                    IdHuyenQuan = ListHuyenQuan.Where(h => h.Ten == HuyenQuanChoose).Select(h => h.Id).First();
//                    var ListXaPhuong = context.XaPhuongs
//                        .Where(x => x.IdHuyenQuan == IdHuyenQuan)
//                        .Select(x => x.Ten)
//                        .ToList();

//                    DropXaPhuong.ItemsSource = ListXaPhuong;

//                }
//            }

//        }


//        private void DropXaPhuong_SelectionChanged()
//        {
//            var XaPhuongChoose = DropXaPhuong.SelectedItem.ToString();
//            using (var context = new QLSBDTContext())
//            {
//                var ListXaPhuong = context.XaPhuongs.Where(x => x.IdHuyenQuan == IdHuyenQuan).Select(x => x).ToList();
//                IdXaPhuong = ListXaPhuong.Where(x => x.Ten == XaPhuongChoose).Select(x => x.Id).First();
//            }

//        }
//    }
//}
