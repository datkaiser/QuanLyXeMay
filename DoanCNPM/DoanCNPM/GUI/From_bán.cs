using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using DoanCNPM.DAL;

namespace DoanCNPM
{
    public partial class From_bán : DevExpress.XtraEditors.XtraForm
    {
        private ListView lv;
        int idPhong = 0;
        public static int mahdd = 0;
        
        public From_bán()
        {
            InitializeComponent();
          
            
        }
        private DataClassesTestDataContext db = new DataClassesTestDataContext();


        private void From_bán_Load(object sender, EventArgs e)
        {
            loadFrombt();
         
        }
        public void loadFrombt()
        {
            var q = db.LOAIPHUTUNGs;
            foreach (var l in q)
            {
                TabPage tp = new TabPage(l.TENPHUTUNG);
                tp.Name = l.MALOAI.ToString();
                tabControl1.Controls.Add(tp);
            }

            var minIDLoaiPhong = db.LOAIPHUTUNGs.Min(x => x.MALOAI);
            load(minIDLoaiPhong, 0);
        }

        public void load(int loaiphong, int tabIndex)
        {
            lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            ImageList im = new ImageList();
            im.ImageSize = new Size(100, 100);
            //im.Images.Add(Properties.Resources.User);
            #region iconhinh

            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\day-ga-thai.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\coga-domino.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\cum-ga-tang-domino-2-day-ga.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\xinhan-spirit-beast-l27.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-chan-gio-zhipat-v2.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dia-kingspeed.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-h2c-tron-1482.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-gu-motogadget-tron.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\che-ket-nuoc-cnc-titan-cho-yamaha-exciter-155.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bao-tay-driven-sbk-chinh-hang.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bao-tay-driven-supermoto.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\op-mat-na-carbon-limited-cho-exciter-155.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\ro-giua-cho-exciter-155.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bo-co-son-carboncho-ex135.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-titan-kieu-dang-suzuki.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\binh-dau-inox-salaya.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\van-voi-inox-salaya.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\cot-banh-truoc-inox-salaya-cho-honda-winner.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gu-inox-salaya-3-canh.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\baga-inox-10-ly-mau-titan-cho-exciter-135.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phuoc-yss-z-sport-chinh-hang-cho-honda-vario.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\loc-gio-luoi-thep-do-danh-cho-honda.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bo-thang-dia-rcb-sau-cho-honda-sh.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bo-noi-bbs-cho-vario-ab.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\sen-phot-rk-428-elo.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\loc-gio-tru-dna-hong-54-chinh-hang.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\loc-gio-tru-dna-hong.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\sen-rk-vang-den-428hsb.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dia-recto-46t-chinh-hang-cho-exciter-155.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhong-mat-troi-15t-cho-honda-winner-sonic.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\mam-rcb-8-cay-chinh-hang-cho-exciter-150-155.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\can-so-2-chieu-cho-exciter-155.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\tham-cao-su-honda-vision.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dia-recto-42t-chinh-hang-cho-honda-sonic.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phuoc-nitron-chinh-hang-viet-nam-cho-raider-satria.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\ong-tieu-inox-honda-winner-x.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\baga-tinh-dien-cho-vespa.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\op-po-inox-300i-zhipat-cho-shvn.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\po-4road-2009-hang-chuan-full-co-pat-cho-shvn-2020.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\cuc-keu-tim-xe-honda.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-michelin-city-grip-2.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-metzeler.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-aspira-sportivo.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-goodride.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-camel-pilot.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-goodride-h993.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-camel-563.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-michelin-city-grip-2-10080.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-camel-pilot1.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-aspira-sportivo1.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-duong-bong-dan-ao-goracing-1459.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-liqui-moly-scooter-race-10w40-100ml.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-motul-scoote-le-10w40-08l.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-maxima-full-syn-10w40.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-repsol-mxr-platium-10w40-1l.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gulf-western-oil-syn-m-4t-premium-scooter-10w40-08l.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-gulf-western-oil-syn-m-4t-premium-10w40-1l.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-gulf-western-oil-syn-m-4t-ester-pao-10w40.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nuoc-lam-mat-goracing-1201.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-xit-lam-sach-dan-nhua-nham-vo-xe-goracing.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\motul-300v-factory-line-10w40-1l.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-xit-ve-sinh-sen-goracing-8572.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-xit-sen-goracing-848.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nuoc-lam-mat-liqui-moly-loai-khong-pha-804.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-wolver-racing-synthetic-10w40-492.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phu-gia-pha-nhot-liqui-moly-mo-s2.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phu-gia-tang-toc-liqui-moly-speed-additive.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dau-suc-dong-co-liqui-moly-engine-flush.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-hop-so-liqui-moly-racing-scooter-gear-oil.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\motul-scooter-gear-plus-38.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gang-tay-bao-ho-dai-ngon-mechanix.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gang-tay-chong-nang-xo-ngon-han-quoc.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\giap-inox-bao-ho-pro-biker-chinh-hang.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\non-bao-hiem-exciter.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaysatria2.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaywave.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaysirius.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaywinnerx.png"));
            im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmayexciter150.png"));

            #endregion
            lv.LargeImageList = im;
            var sd = db.PHUTUNGXEs.Where(x => x.MALOAI == loaiphong );
          
            foreach (var pp in sd)
            {
                int kk = pp.MAPT - 1;
                lv.Items.Add(new ListViewItem { ImageIndex = kk, Text = pp.TENPT, Name = pp.MAPT.ToString() });
            }
            tabControl1.TabPages[tabIndex].Controls.Add(lv);
           
        }
        public void timkiem()
        {
            try
            {
                var w = (from df in db.PHUTUNGXEs
                         where df.TENPT.StartsWith(txttimkiem.Text)
                         select new
                         {
                             maa = df.MALOAI
                         }).First();
                var qq = (from ltv in db.PHUTUNGXEs
                          where ltv.TENPT.StartsWith(txttimkiem.Text)
                         select ltv
                         ).ToList();

                var q = db.LOAIPHUTUNGs.Where(x => x.MALOAI == int.Parse(w.maa.ToString())).First();

                TabPage tp = new TabPage(q.TENPHUTUNG);
                tp.Name = q.MALOAI.ToString();
                tabControl1.Controls.Add(tp);

                lv = new ListView();
                lv.Dock = DockStyle.Fill;
                lv.SelectedIndexChanged += lv_SelectedIndexChanged;
                ImageList im = new ImageList();
                im.ImageSize = new Size(100, 100);

                //#region iconhinh

                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\day-ga-thai.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\coga-domino.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\cum-ga-tang-domino-2-day-ga.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\xinhan-spirit-beast-l27.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-chan-gio-zhipat-v2.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dia-kingspeed.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-h2c-tron-1482.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-gu-motogadget-tron.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\che-ket-nuoc-cnc-titan-cho-yamaha-exciter-155.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bao-tay-driven-sbk-chinh-hang.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bao-tay-driven-supermoto.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\op-mat-na-carbon-limited-cho-exciter-155.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\ro-giua-cho-exciter-155.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bo-co-son-carboncho-ex135.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\kinh-titan-kieu-dang-suzuki.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\binh-dau-inox-salaya.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\van-voi-inox-salaya.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\cot-banh-truoc-inox-salaya-cho-honda-winner.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gu-inox-salaya-3-canh.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\baga-inox-10-ly-mau-titan-cho-exciter-135.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phuoc-yss-z-sport-chinh-hang-cho-honda-vario.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\loc-gio-luoi-thep-do-danh-cho-honda.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bo-thang-dia-rcb-sau-cho-honda-sh.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\bo-noi-bbs-cho-vario-ab.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\sen-phot-rk-428-elo.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\loc-gio-tru-dna-hong-54-chinh-hang.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\loc-gio-tru-dna-hong.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\sen-rk-vang-den-428hsb.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dia-recto-46t-chinh-hang-cho-exciter-155.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhong-mat-troi-15t-cho-honda-winner-sonic.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\mam-rcb-8-cay-chinh-hang-cho-exciter-150-155.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\can-so-2-chieu-cho-exciter-155.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\tham-cao-su-honda-vision.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dia-recto-42t-chinh-hang-cho-honda-sonic.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phuoc-nitron-chinh-hang-viet-nam-cho-raider-satria.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\ong-tieu-inox-honda-winner-x.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\baga-tinh-dien-cho-vespa.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\op-po-inox-300i-zhipat-cho-shvn.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\po-4road-2009-hang-chuan-full-co-pat-cho-shvn-2020.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\cuc-keu-tim-xe-honda.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-michelin-city-grip-2.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-metzeler.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-aspira-sportivo.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-goodride.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-camel-pilot.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-goodride-h993.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-camel-563.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-michelin-city-grip-2-10080.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-camel-pilot1.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\vo-xe-aspira-sportivo1.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-duong-bong-dan-ao-goracing-1459.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-liqui-moly-scooter-race-10w40-100ml.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-motul-scoote-le-10w40-08l.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-maxima-full-syn-10w40.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-repsol-mxr-platium-10w40-1l.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gulf-western-oil-syn-m-4t-premium-scooter-10w40-08l.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-gulf-western-oil-syn-m-4t-premium-10w40-1l.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-gulf-western-oil-syn-m-4t-ester-pao-10w40.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nuoc-lam-mat-goracing-1201.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-xit-lam-sach-dan-nhua-nham-vo-xe-goracing.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\motul-300v-factory-line-10w40-1l.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-xit-ve-sinh-sen-goracing-8572.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\chai-xit-sen-goracing-848.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nuoc-lam-mat-liqui-moly-loai-khong-pha-804.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-wolver-racing-synthetic-10w40-492.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phu-gia-pha-nhot-liqui-moly-mo-s2.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\phu-gia-tang-toc-liqui-moly-speed-additive.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\dau-suc-dong-co-liqui-moly-engine-flush.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\nhot-hop-so-liqui-moly-racing-scooter-gear-oil.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\motul-scooter-gear-plus-38.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gang-tay-bao-ho-dai-ngon-mechanix.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\gang-tay-chong-nang-xo-ngon-han-quoc.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\giap-inox-bao-ho-pro-biker-chinh-hang.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\non-bao-hiem-exciter.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaysatria2.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaywave.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaysirius.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmaywinnerx.png"));
                im.Images.Add(Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\AnhPhuTungXe\octitanlocmayexciter150.png"));

                //#endregion
                lv.LargeImageList = im;
                var sd = db.PHUTUNGXEs.Where(c => c.MAPT == int.Parse(w.maa.ToString()));

                foreach (var pp in qq)
                {
                    int kk = pp.MAPT - 1;
                    lv.Items.Add(new ListViewItem { ImageIndex = kk, Text = pp.TENPT, Name = pp.MAPT.ToString() });
                }
                tp.Controls.Add(lv);
            }
            catch
            {
                
                return;
            }
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {
                
                idPhong = int.Parse(lv.SelectedItems[0].Name);
                label1.Text = idPhong.ToString();
                var df = (from oo in db.PHUTUNGXEs
                         where oo.MAPT == idPhong
                         select new
                         {
                             ten = oo.MOTA,
                             tien = oo.GIABAN
                         }).First();
                txtten.Text = df.ten.ToString();
                txtten.Multiline = true;
                txtten.ScrollBars = ScrollBars.Both;
            
                lbgia.Text = df.tien.ToString();
                int kk = int.Parse(lbgia.Text);
                numericUpDown1.Value = 1;
                numericUpDown1.Enabled = true;
                int kj = (int)numericUpDown1.Value;
                int tt = kk * kj;
                lbthanhtien.Text = tt.ToString();
            }
        }

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idphong = tabControl1.SelectedTab.Name;
            var tabIndex = tabControl1.SelectedIndex;
            numericUpDown1.Enabled = true;
            load(int.Parse(idphong), tabIndex);
            

        }

        private void txtNumberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số !!!!!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void checkKH()
        {
            var q = db.KHACHHANGs.Where(x => x.SDT == txtNumberPhone.Text).ToList();

            if (q.Any())
            {

                lbCheckPhone.ForeColor = Color.Green;
                lbCheckPhone.Text = "Khách hàng đã có !";
                btnKH.Enabled = false;
                loadHD(txtNumberPhone.Text);
                gridControl2.Enabled = true;
                panel2.Enabled = true;
                return;

            }
            if (txtNumberPhone.Text == "")
            {
                lbCheckPhone.Text = "";
                btnKH.Enabled = false;
                gridControl2.Visible = true;
                loadHD("");
              
                return;
            }
            else
            {
                lbCheckPhone.ForeColor = Color.Red;
                lbCheckPhone.Text = "Khách hàng chưa có !";
                btnKH.Enabled = true;
                gridControl2.Visible = true;
                loadHD("");
                return;
            }

        }

        private void txtNumberPhone_TextChanged(object sender, EventArgs e)
        {
            checkKH();
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.Controls.Clear();
                if (txttimkiem.Text == "")
                {
                    loadFrombt();
                    return;
                }
                else
                {
                    timkiem();
                    return;
                }
            }
            catch
            {
                return;
            }
            
        }

        public bool checkgiamgia()
        {
            var k = from x in db.GIAMGIAs
                      where x.MAGIAMGIA == txtgiamgia.Text.ToUpper() && x.NGAYBATDAU <= DateTime.Now && x.NGAYKETTHUC >= DateTime.Now
                      select x;
            if (k.Any())
            {
                lbtb.ForeColor = Color.Green;
                lbtb.Text = "Mã giảm giá tồn tại !!!";
                 dd = k.Select(x => Convert.ToDouble(x.SOTIENGIAM)).First();
                return true;
            }
            else
            {
                lbtb.ForeColor = Color.Red;
                lbtb.Text = "Mã giảm giá khồng còn !";
                return false;
            }

        }

        double dd = 0;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
                if (txtgiamgia.Text == "" || checkgiamgia() == false)
                {
                    int a = (int)numericUpDown1.Value;
                    int b = int.Parse(lbgia.Text);
                    int kq = a * b;
                    lbthanhtien.Text = kq.ToString();
                }
                if (checkgiamgia() == true)
                {
                    int a = (int)numericUpDown1.Value;
                    int b = int.Parse(lbgia.Text);
                    double c = double.Parse(dd.ToString());
                    double kq = (a * b) - c;
                    lbthanhtien.Text = kq.ToString();
                }
            
           
        }

        public void loadhoadon(int mahd,string sdt)
        {
            var hds = from hd in db.CTHDs
                      join pt in db.PHUTUNGXEs on hd.MAPT equals pt.MAPT
                      join kh in db.HOADONs on hd.MAHD equals kh.MAHD
                      where hd.MAHD == mahd && kh.SDT == sdt && pt.MAPT == hd.MAPT
                      select new
                      {
                          mhd = hd.MAHD,
                          ten = pt.TENPT,
                          soluong = hd.SOLUONG,
                          don = hd.DONGIA,
                          giam = hd.GIAMGIA,
                          thanhtien = hd.THANHTIEN
                      };
            gridControl1.DataSource = hds;
        }

        public void loadHD(string sdts)
        {
            var t = from j in db.HOADONs
                     where j.SDT == sdts
                     select j;
            gridControl2.DataSource = t;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            maql = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ten").ToString();
      
           
        }

        private void gridControl2_Click_1(object sender, EventArgs e)
        {
           mahdd = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHD").ToString().Trim());

        }

        private void txtgiamgia_EditValueChanged(object sender, EventArgs e)
        {
            checkgiamgia();
        }
        string maql = "";
        private void quaylai_Click(object sender, EventArgs e)
        {
            gridControl2.Visible = true;
            loadHD(txtNumberPhone.Text);
            quaylai.Enabled = false;
            quayxuong.Visible = true;
            maql = "";
 

        }



        private void btndathang_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lấy mã hóa đơn đã có rồi không !", "Thông báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            if (r == DialogResult.OK)
            {
                themHDroi();
            }
            if (r == DialogResult.No)
            {
                themHD();
               
            }

        }


        public void themHD()
        {
            string txtSDT = txtNumberPhone.Text;
            if (codexuly.kiemtraSDTKH(txtSDT))
            {
                HOADON hd = new HOADON();
                
                hd.SDT = txtSDT;
                hd.MANV = Form1.nvdn.MANV;
                hd.NGAYBAN = DateTime.Now;
                hd.TONGTIEN = int.Parse(lbthanhtien.Text);
                hd.Tinhtrang = true;
                db.HOADONs.InsertOnSubmit(hd);
                db.SubmitChanges();
                var jj = (from ll in db.HOADONs
                          orderby ll.MAHD descending
                          select new
                          {
                              so = ll.MAHD
                          }).First();
                CTHD ct = new CTHD();
                ct.MAHD = int.Parse(jj.so.ToString());
                ct.MAPT = int.Parse(label1.Text);
                ct.SOLUONG = (int)numericUpDown1.Value;
                ct.DONGIA = int.Parse(lbgia.Text);
                if (checkgiamgia() == true)
                {
                    ct.GIAMGIA = double.Parse(dd.ToString());
                }
                else
                {
                    ct.GIAMGIA = 0;
                }
                ct.THANHTIEN = int.Parse(lbthanhtien.Text);
                db.CTHDs.InsertOnSubmit(ct);
                db.SubmitChanges();
                loadHD(txtNumberPhone.Text);
            }
            else {

                MessageBox.Show("Số Điện thoại khách hàng chưa có trong hệ thống. Vui lòng thêm mới", "Thông báo");
            }
            
        }

        public void themHDroi()
        {
            CTHD ct = new CTHD();
            ct.MAHD = mahdd;
            ct.MAPT = int.Parse(label1.Text);
            ct.SOLUONG = (int)numericUpDown1.Value;
            ct.DONGIA = int.Parse(lbgia.Text);
            if (checkgiamgia() == true)
            {
                ct.GIAMGIA = double.Parse(dd.ToString());
            }
            else
            {
                ct.GIAMGIA = 0;
            }
            ct.THANHTIEN = int.Parse(lbthanhtien.Text);
            db.CTHDs.InsertOnSubmit(ct);
            db.SubmitChanges();
            loadHD(txtNumberPhone.Text);
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            loadhoadon(mahdd, txtNumberPhone.Text);
            quaylai.Enabled = true;
            gridControl2.Visible = false;
            quayxuong.Visible = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }
        int maaa = 0;
        

        private void btnxoa_Click(object sender, EventArgs e)
        {
            #region xoa
            if (maql != "")
            {
                DialogResult r = MessageBox.Show("Bạn có muốn xóa đơn hàng này không !", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (r == DialogResult.Yes)
                {

                var dff = (from kk in db.PHUTUNGXEs
                          where kk.TENPT == maql
                          select new 
                          {
                              ma = kk.MAPT
                          }).First();
                

                mahdd = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHD").ToString().Trim());

                CTHD knews = db.CTHDs.Where(x => x.MAHD == mahdd && x.MAPT == int.Parse(dff.ma.ToString())).Single();
                db.CTHDs.DeleteOnSubmit(knews);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!", "Thông Báo");
                loadhoadon(mahdd, txtNumberPhone.Text);
                loadHD(txtNumberPhone.Text);
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!", "Thông Báo");
                    return;
                }
            }
            else if (maql == "")
            {
                 var baohanhs = db.BAOHANHs.Where(x => x.MAHD == mahdd).Count();
               
                DialogResult r = MessageBox.Show("Bạn có muốn xóa đơn hàng này không !", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (r == DialogResult.Yes)
                {

                    mahdd = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MAHD").ToString().Trim());

                    
                    var kk = db.CTHDs.Where(x => x.MAHD == mahdd).Count();


                    if (int.Parse(kk.ToString()) == 0)
                    {
                        if (int.Parse(baohanhs.ToString()) > 0)
                        {
                            MessageBox.Show("KHông thể xóa vì sản phẩm đã nhận bảo hành", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            HOADON knew = db.HOADONs.Where(x => x.MAHD == mahdd).First();
                            db.HOADONs.DeleteOnSubmit(knew);
                            db.SubmitChanges();
                            loadhoadon(mahdd, txtNumberPhone.Text);
                            loadHD(txtNumberPhone.Text);
                            MessageBox.Show("Xóa thành công!", "Thông Báo");
                        }
                    }
                    else if (int.Parse(kk.ToString()) > 0)
                    {
                       
                        if (int.Parse(baohanhs.ToString()) > 0)
                        {
                            MessageBox.Show("KHông thể xóa vì sản phẩm đã nhận bảo hành", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            for (int i = 1; i <= kk; i++)
                            {

                                var nhoc = (from l in db.CTHDs
                                            where l.MAHD == mahdd
                                            orderby l.MAHD descending
                                            select new
                                            {
                                                ma = l.MAPT
                                            }).First();

                                CTHD knews = db.CTHDs.Where(x => x.MAHD == mahdd && x.MAPT == int.Parse(nhoc.ma.ToString())).FirstOrDefault();
                                db.CTHDs.DeleteOnSubmit(knews);
                                db.SubmitChanges();

                            }
                            HOADON knew = db.HOADONs.Where(x => x.MAHD == mahdd).First();
                            db.HOADONs.DeleteOnSubmit(knew);
                            db.Refresh(RefreshMode.OverwriteCurrentValues, knew);
                            db.SubmitChanges();
                            loadhoadon(mahdd, txtNumberPhone.Text);
                            loadHD(txtNumberPhone.Text);
                            MessageBox.Show("Xóa thành công!", "Thông Báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Thông Báo");
                        return;
                    }
                }
            }
            #endregion


        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnKH_Click(object sender, EventArgs e)
        {
            
            
            txtNumberPhone.Text = From_Khachhang.makh;
            From_Khachhang fr = new From_Khachhang();
            fr.Show();
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DanhSachYT fr = new DanhSachYT();
            fr.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_BH fr = new Form_BH();
            fr.ShowDialog();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
  
            Menu fr = new Menu();
            fr.ShowDialog();
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private class OrderPlaced
        {
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
        }
    }
}