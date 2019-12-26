using Lemon3.Controls.DevExp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace D27D1750.Forms
{
    /// <summary>
    /// Interaction logic for D27D1330_DSTS.xaml
    /// </summary>
    public partial class D27D1330DSTS : L3Window
    {
        private string _ModuleID = "";
        private string _InforEmailID = "";
        private string _CodeID = "";
        private string _FormID = "";

        public string FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }
        public string ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }

        public string InforEmailID
        {
            get { return _InforEmailID; }
            set { _InforEmailID = value; }
        }

        public string CodeID
        {
            get { return _CodeID; }
        }

        public D27D1330DSTS()
        {
            InitializeComponent();
        }
        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            LoadLanguage();
            tdbg.SetDefaultGridControlInquiry();
            tdbgView.ShowGroupPanel = false;
            LoadTDBGrid();
            this.Cursor = Cursors.Arrow;
        }

        private void LoadLanguage()
        {
            
            this.Title = Lemon3.Resources.L3Resource.rL3("Danh_sach_tham_soU");
            
            COL_OrderNo.Header = Lemon3.Resources.L3Resource.rL3("STTU");
            COL_CodeID.Header = Lemon3.Resources.L3Resource.rL3("Ma");
            COL_CodeName.Header = Lemon3.Resources.L3Resource.rL3("Dien_giai");
            btnChoose.Content = Lemon3.Resources.L3Resource.rL3("Chon");
            btnClose.Content = Lemon3.Resources.L3Resource.rL3("DongU1");
        }
        private void LoadTDBGrid()
        {
            string sSQL = "--Danh sach tham so" + Environment.NewLine;
            sSQL += "SELECT 	OrderNo, ID AS CodeID, Name84U AS CodeName, Str01 AS FieldName ";
            sSQL += "FROM	D27N5555 ('"+_FormID+"','"+ _InforEmailID+"', 'ListCodeMail' , '"+_ModuleID+"','','' )";
            sSQL += "ORDER BY OrderNo	";
        
            L3DataSource.LoadDataSource(tdbg, sSQL);
        }

        private void tdbg_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _CodeID = tdbg.GetFocusedRowCellValue(COL_CodeID).ToString();
            this.Close();
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            _CodeID = tdbg.GetFocusedRowCellValue(COL_CodeID).ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
