using DevExpress.Xpf.Grid;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using Lemon3.Messages;
using Lemon3.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace D49D2250
{
    /// <summary>
    /// Interaction logic for D49F2140.xaml
    /// </summary>
    public partial class D49F2140 : L3Page
    {
        public D49F2140()
        {
            InitializeComponent();
            _AttackTextContent = L3Resource.rL3("Dinh_kem");
            this.DataContext = this;
        }

        private string _AttackTextContent;
        public string AttackTextContent
        {
            get { return _AttackTextContent; }

        }

        public override void SetContentForL3Page()
        { }

        private int iPerD49F2140 = -1, iPerD01F2065 = -1, iPerD05F2201 = -1;

        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            DefaultAndFormat();
            LoadLanguage();
            LoadExt();
            EnableMenu();
            LoadTDBCombo();
            tdbg.FooterText(null, new DevExpress.Xpf.Grid.GridColumn[] { COL_OQuantity, COL_UnitPrice, COL_OAmount, COL_VATOAmount, COL_TotalOAmount }, false);
            this.Cursor = Cursors.Arrow;
        }
        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("De_nghi_thu_tienU") + " - " + this.GetType().Name;

            grpCon.Text = L3Resource.rL3("Dieu_kien_loc");

            chkPeriodID.Content = L3Resource.rL3("Ky");
            lblProjectName.Content = L3Resource.rL3("Du_an");
            lblContractNo.Content = L3Resource.rL3("So_hop_dong_");
            lblObjectID.Content = L3Resource.rL3("Khach_hang");

            tdbcProjectID.SetCaptionColumn("ProjectID", L3Resource.rL3("Ma"));
            tdbcProjectID.SetCaptionColumn("ProjectName", L3Resource.rL3("Ten"));

            tdbcContractNo.SetCaptionColumn("ContractNo", L3Resource.rL3("Ma"));
            tdbcContractNo.SetCaptionColumn("ContractID", L3Resource.rL3("Ten"));

            tdbcObjectID.SetCaptionColumn("ObjectID", L3Resource.rL3("Ma"));
            tdbcObjectID.SetCaptionColumn("ObjectName", L3Resource.rL3("Ten"));

            bandAccrualRevenue.Header = L3Resource.rL3("Trich_truoc_doanh_thu");
            bandCashRequest.Header = L3Resource.rL3("De_nghi_thu_tien");
            bandInvoice.Header = L3Resource.rL3("Xuat_hoa_donU");
            bandReipts.Header = L3Resource.rL3("Phieu_thu");

            COL_IsSelected.Header = L3Resource.rL3("Chon");
            COL_PeriodID.Header = L3Resource.rL3("Ky");
            COL_ProjectID.Header = L3Resource.rL3("Du_an");
            COL_ProjectName.Header = L3Resource.rL3("Ten_du_an");
            COL_ContractNo.Header = L3Resource.rL3("So_hop_dong_");
            COL_ObjectID.Header = L3Resource.rL3("Khach_hang");
            COL_ObjectName.Header = L3Resource.rL3("Ten_khach_hang");
            COL_ProductID.Header = L3Resource.rL3("Ma_dich_vuU");
            COL_ProductName.Header = L3Resource.rL3("Ten_dich_vuU");
            COL_ServiceTypeName.Header = L3Resource.rL3("Loai_dich_vuU");
            COL_UnitID.Header = L3Resource.rL3("DVT");

            COL_OQuantity.Header = L3Resource.rL3("So_luongU");
            COL_UnitPrice.Header = L3Resource.rL3("Don_gia");
            COL_OAmount.Header = L3Resource.rL3("Thanh_tien");
            COL_VATGroupID.Header = L3Resource.rL3("Nhom_thueU");
            COL_VATRate.Header = L3Resource.rL3("Thue_suatU");
            COL_VATOAmount.Header = L3Resource.rL3("Thue");
            COL_TotalOAmount.Header = L3Resource.rL3("TT_sau_thue");
            COL_IsDetailInvoice.Header = L3Resource.rL3("Xuat_hoa_don_chi_tiet");
            COL_Note.Header = L3Resource.rL3("Ghi_chu");
            COL_Attack.Header = L3Resource.rL3("Dinh_kem");
            COL_IsAccrualRevenue.Header = L3Resource.rL3("Da_trich_truoc_doanh_thu");
            COL_IsCashRequest.Header = L3Resource.rL3("Da_de_nghi_thu_tien");
            COL_IsInvoice.Header = L3Resource.rL3("Da_xuat_hoa_don");

            COL_AccrualRevenueNo.Header = L3Resource.rL3("So_phieu");
            COL_CashRequestNo.Header = L3Resource.rL3("So_phieu");
            COL_InvoiceNo.Header = L3Resource.rL3("So_phieu");
            COL_AccrualRevenueDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_CashRequestDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_InvoiceDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_ReiptsNo.Header = L3Resource.rL3("So_phieu");
            COL_ReiptsDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_IsReipts.Header = L3Resource.rL3("Da_tao_phieu_thu");

            mnsVoucherDetail.Header = L3Resource.rL3("Chi_tiet_xuat_hoa_donU");
            mnsExportVoucher.Header = L3Resource.rL3("Xuat_hoa_don");
            mnsMakeVoucher.Header = L3Resource.rL3("Tao_phieu_thu");
            btnFilter.Content = L3Resource.rL3("Loc") + " (F5)";
        }
        private void DefaultAndFormat()
        {           
            L3Format.LoadCustomFormat();
            btnFilter.SetImage(ImageType.Filter);
            tdbg.SetDefaultGridControlInquiry();
            tdbg.InputNumber288(L3Format.DxxFormat.D90_ConvertedDecimals, false, false, COL_OAmount, COL_VATOAmount, COL_TotalOAmount);
            tdbg.InputNumber288(L3Format.DxxFormat.D07_QuantityDecimals, false, false, COL_OQuantity);
            tdbg.InputNumber288(L3Format.DxxFormat.D07_UnitCostDecimals, false, false, COL_UnitPrice);
            tdbg.InputPercent(false, false, 28, 8, COL_VATRate);
            tdbg.InputDate(COL_CashRequestDate, COL_InvoiceDate, COL_AccrualRevenueDate, COL_ReiptsDate);
            tdbg.InputDate("MM/yyyy", COL_PeriodID);
            this.SetBackColorObligatory(new Control[] { devdatePeriodFrom, devdatePeriodTo, tdbcProjectID, tdbcContractNo, tdbcObjectID }, null);
            L3Control.SetShortcutPopupMenu(MainMenuControl1, ContextMenu1);
        }

        private void LoadTDBCombo()
        {
            // Kỳ
            //DataTable dtPeriod = L3SQLServer.ReturnDataTable(SQLSelectD01T9999().ToString());
            //L3DataSource.LoadDataSource(tdbcPeriodFrom, dtPeriod.Copy());
            //L3DataSource.LoadDataSource(tdbcPeriodTo, dtPeriod.Copy());

            //tdbcPeriodFrom.EditValue = L3.TranMonth.ToString("00") + "/" + L3.TranYear.ToString();
            //tdbcPeriodTo.EditValue = L3.TranMonth.ToString("00") + "/" + L3.TranYear.ToString();
            devdatePeriodFrom.EditValue = Convert.ToDateTime("01/" + L3.TranMonth + "/" + L3.TranYear);
            devdatePeriodTo.EditValue = Convert.ToDateTime("01/" + L3.TranMonth + "/" + L3.TranYear);

            //string sSQL = "-- Combo Dự án" + Environment.NewLine;
            //sSQL += "EXEC  D49P2130   ";
            //sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA + L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            //sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodFrom.ReturnValue("Period")) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodTo.ReturnValue("Period")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString("%") + L3.COMMA + L3SQLClient.SQLString("%") + L3.COMMA + L3SQLClient.SQLString("%") + L3.COMMA + L3SQLClient.SQLString("ProjectID");

            string sSQL = "-- Combo Dự án" + Environment.NewLine;
            sSQL += "EXEC  D49P2130   ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodFrom.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodTo.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString("%") + L3.COMMA;
            sSQL += L3SQLClient.SQLString("%") + L3.COMMA;
            sSQL += L3SQLClient.SQLString("%") + L3.COMMA;
            sSQL += L3SQLClient.SQLString("ProjectID");
            L3DataSource.LoadDataSource(tdbcProjectID, sSQL);
            tdbcProjectID.SelectedIndex = 0;

            LoadTDBCContractNo();
            LoadTDBCObjectID();

        }
        private void LoadTDBCContractNo()
        {
            string sSQL = "-- Combo hợp đồng" + Environment.NewLine;
            sSQL += "EXEC  D49P2130   ";
            //sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA + L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            //sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodFrom.ReturnValue("Period")) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodTo.ReturnValue("Period")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA + L3SQLClient.SQLString("%") + L3.COMMA + L3SQLClient.SQLString("%") + L3.COMMA + L3SQLClient.SQLString("ContractID");
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodFrom.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodTo.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString("%") + L3.COMMA;
            sSQL += L3SQLClient.SQLString("%") + L3.COMMA;
            sSQL += L3SQLClient.SQLString("ContractID");
            L3DataSource.LoadDataSource(tdbcContractNo, sSQL);
            tdbcContractNo.SelectedIndex = 0;
        }
        private void LoadTDBCObjectID()
        {
            string sSQL = "--Combo khách hàng" + Environment.NewLine;
            sSQL += "EXEC  D49P2130   ";
            //sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA + L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            //sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodFrom.ReturnValue("Period")) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodTo.ReturnValue("Period")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA + L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractID")) + L3.COMMA + L3SQLClient.SQLString("%") + L3.COMMA + L3SQLClient.SQLString("ObjectID");
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodFrom.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodTo.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString("%") + L3.COMMA;
            sSQL += L3SQLClient.SQLString("ObjectID");
            L3DataSource.LoadDataSource(tdbcObjectID, sSQL);
            tdbcObjectID.SelectedIndex = 0;
        }
        private StringBuilder SQLSelectD01T9999()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Combo Ky" + Environment.NewLine);
            sSQL.Append("Select REPLACE(STR(TranMonth, 2), ' ', '0') + '/' + STR(TranYear, 4) AS Period," + Environment.NewLine);
            sSQL.Append("TranMonth, TranYear" + Environment.NewLine);
            sSQL.Append("From D01T9999 WITH(NOLOCK)" + Environment.NewLine);
            sSQL.Append("Where DivisionID = " + L3SQLClient.SQLString(L3.DivisionID) + Environment.NewLine);
            sSQL.Append("Order By TranYear DESC, TranMonth DESC");
            return sSQL;
        }

        DataTable dtGrid;
        private void LoadTDBGrid(bool bFlagAdd = false, string sKey = "")
        {
            if (bFlagAdd)
            {
                tdbg.FilterString = String.Empty;
            }
            string sSQL = "-- Load Grid" + Environment.NewLine;
            sSQL += "EXEC  D49P2130   ";
            //sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA + L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            //sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodFrom.ReturnValue("Period")) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodTo.ReturnValue("Period")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA + L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractID")) + L3.COMMA + L3SQLClient.SQLString(tdbcObjectID.ReturnValue("ObjectID")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString("LoadGrid") + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodFrom.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodTo.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcObjectID.ReturnValue("ObjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString("LoadGrid") + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(this.GetType().Name);
            dtGrid = L3SQLServer.ReturnDataTable(sSQL);
            if (!dtGrid.Columns.Contains("IsSelected"))
            {
                DataColumn dc = new DataColumn("IsSelected", System.Type.GetType("System.Boolean"));
                dc.DefaultValue = false;
                dtGrid.Columns.Add(dc);
            }
            L3DataSource.LoadDataSource(tdbg, dtGrid);
            ReLoadTDBGrid();
            if (sKey != "")
            {
                int row = tdbg.FindRowByValue(COL_ContractNo, sKey);
                if (row >= 0) tdbg.FocusRowHandle(row);
            }
        }

        private void LoadExt()
        {
            iPerD49F2140 = L3Permissions.ReturnPermission("D49F2140");
            iPerD01F2065 = L3Permissions.ReturnPermission("D01F2065");
            iPerD05F2201 = L3Permissions.ReturnPermission("D05F2201");
        }

        private void ReLoadTDBGrid()
        {
            ResetGrid();
        }
        private void ResetGrid()
        {
            EnableMenu();

        }
        private void EnableMenu()   //EnableMenu(bool bEnabled)
        {
            tsbListAll.IsEnabled = tdbg.VisibleRowCount > 0;
            mnsListAll.IsEnabled = tsbListAll.IsEnabled;

            mnsVoucherDetail.IsEnabled = tdbg.VisibleRowCount > 0;
            mnsExportToExcel.IsEnabled = tdbg.VisibleRowCount > 0;

            mnsExportVoucher.IsEnabled = tdbg.VisibleRowCount > 0 && !L3.Closed && iPerD49F2140 >= 2 && iPerD05F2201 >= 2;
            mnsMakeVoucher.IsEnabled = tdbg.VisibleRowCount > 0 && !L3.Closed && iPerD49F2140 >= 2 && iPerD01F2065 >= 2;
        }

        private void chkPeriodID_Click(object sender, RoutedEventArgs e)
        {
            if (chkPeriodID.IsChecked == true)
            {
                this.SetBackColorObligatory(new Control[] { devdatePeriodFrom, devdatePeriodTo }, null);
                devdatePeriodFrom.IsEnabled = true;
                devdatePeriodTo.IsEnabled = true;
                devdatePeriodFrom.EditValue = Convert.ToDateTime("01/" + L3.TranMonth + "/" + L3.TranYear);
                devdatePeriodTo.EditValue = Convert.ToDateTime("01/" + L3.TranMonth + "/" + L3.TranYear);
            }
            else
            {
                devdatePeriodFrom.Background = null;
                devdatePeriodTo.Background = null;
                devdatePeriodFrom.IsEnabled = false;
                devdatePeriodTo.IsEnabled = false;
                devdatePeriodFrom.EditValue = null;
                devdatePeriodTo.EditValue = null;
            }
        }


        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            Lemon3.IO.L3CallDLL oCallDLL = new Lemon3.IO.L3CallDLL();
            Lemon3.IO.StructureProperties[] arrPro = null;
            oCallDLL.SetProperties(ref arrPro, "TableName", "D49T2133");
            oCallDLL.SetProperties(ref arrPro, "Permission", this.GetType().Name);
            oCallDLL.SetProperties(ref arrPro, "DivisionID", L3.DivisionID);
            oCallDLL.SetProperties(ref arrPro, "Key1ID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_TransID)));
            oCallDLL.CallFormShowDialog("D91D0340", "D91F4010", arrPro);

            //btnAttack.Content = L3Resource.rL3("Dinh_kem") + " " + " (" + Lemon3.Data.L3AttachmentAndNotes.ReturnAttachmentNumber("D54T2200", L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_VoucherID))) + ")";
        }


        private void tsbListAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mnsListAll_Click(null, null);
        }

        private void tsbSysInfo_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mnsSysInfo_Click(null, null);
        }

        private void HandleRowFocus(int indexRowFocus)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tdbgView.MoveFocusedRow(indexRowFocus);
                tdbgView.SelectRow(indexRowFocus);
            }), DispatcherPriority.Render);

            tdbg.SelectedItem = indexRowFocus;
            tdbgView.FocusedRowHandle = indexRowFocus;
        }


        private void mnsListAll_Click(object sender, RoutedEventArgs e)
        {
            tdbg.ListAll();
        }

        private void mnsExporttoExcel_Click(object sender, RoutedEventArgs e)
        {
            tdbgView.PrintAutoWidth = false;
            tdbg.ExportToXLS(L3.ApplicationPath + "\\Temp\\xxxxx.xls");
        }

        private void mnsSysInfo_Click(object sender, RoutedEventArgs e)
        {
            L3Window.ShowSysInforForm(tdbg);
        }


        private string SQLStoreD49P2130(string cap, string sContractID, string DataType, string sFormID = "")
        {
            string sSQL = "-- " + cap + Environment.NewLine;
            sSQL += "EXEC  D49P2130   ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3ConvertType.L3Int(chkPeriodID.IsChecked) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString(tdbcPeriodFrom.ReturnValue("Period")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString(tdbcPeriodTo.ReturnValue("Period")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodFrom.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodTo.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(sContractID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcObjectID.ReturnValue("ObjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(DataType) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(sFormID);
            return sSQL;
        }

        private void tdbgView_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            //_AttackTextContent = L3Resource.rL3("Dinh_kem");
            //if (e.NewRow == null)
            //    return;

            //   _AttackTextContent = _AttackTextContentt + " " + " (" + Lemon3.Data.L3AttachmentAndNotes.ReturnAttachmentNumber("D54T2200", L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_VoucherID))) + ")";

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

            if (chkPeriodID.IsChecked == true)
            {
                //if (tdbcPeriodFrom.EditValue == "" || tdbcPeriodFrom.EditValue == null)
                //{
                //    L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_ky_tu"));
                //    tdbcPeriodFrom.Focus();
                //    return;
                //}
                //if (tdbcPeriodTo.EditValue == "" || tdbcPeriodTo.EditValue == null)
                //{
                //    L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_ky_toi"));
                //    tdbcPeriodTo.Focus();
                //    return;
                //}
                //if (L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranYear")) > L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranYear")))
                //{
                //    L3Msg.MyMsg(L3Resource.rL3("Ky_den_phai_lon_hon_ky_tuU"));
                //    tdbcPeriodTo.Focus();
                //    return;
                //}
                //else
                //{
                //    if (L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranYear")) == L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranYear")))
                //    {
                //        if (L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranMonth")) > L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranMonth")))
                //        {
                //            L3Msg.MyMsg(L3Resource.rL3("Ky_den_phai_lon_hon_ky_tuU"));
                //            tdbcPeriodTo.Focus();
                //            return;
                //        }
                //    }
                //}
                if (devdatePeriodFrom.Text == "")
                {
                    L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_ky_tu"));
                    devdatePeriodFrom.Focus();
                    return;
                }
                if (devdatePeriodTo.Text == "")
                {
                    L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_ky_toi"));
                    devdatePeriodTo.Focus();
                    return;
                }
                if (Convert.ToDateTime(devdatePeriodFrom.EditValue) > Convert.ToDateTime(devdatePeriodTo.EditValue))
                {
                    L3Msg.MyMsg(L3Resource.rL3("Ky_den_phai_lon_hon_ky_tuU"));
                    devdatePeriodTo.Focus();
                    return;
                }

            }
            if (tdbcProjectID.EditValue == "" || tdbcProjectID.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblProjectName.Content.ToString());
                tdbcProjectID.Focus();
                return;
            }
            if (tdbcContractNo.EditValue == "" || tdbcContractNo.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblContractNo.Content.ToString());
                tdbcContractNo.Focus();
                return;
            }
            if (tdbcObjectID.EditValue == "" || tdbcObjectID.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblObjectID.Content.ToString());
                tdbcObjectID.Focus();
                return;
            }

            LoadTDBGrid(true);
        }

        private void tdbcProjectID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            LoadTDBCContractNo();
        }

        private void tdbcContractNo_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            LoadTDBCObjectID();
        }

        private void mnsVoucherDetail_Click(object sender, RoutedEventArgs e)
        {
            if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_IsDetailInvoice)) == 0)
            {
                L3Msg.MyMsg(L3Resource.rL3("Ma_hang_khong_xuat_hoa_don_chi_tiet"));
                return;
            }

            Lemon3.IO.L3CallDLL oCallDLL = new Lemon3.IO.L3CallDLL();
            Lemon3.IO.StructureProperties[] arrPro = null;
            oCallDLL.SetProperties(ref arrPro, "OTransID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_TransID)));
            oCallDLL.SetProperties(ref arrPro, "ProjectID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProjectID)));
            oCallDLL.SetProperties(ref arrPro, "ProjectName", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProjectName)));
            oCallDLL.SetProperties(ref arrPro, "ContractID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ContractID)));
            oCallDLL.SetProperties(ref arrPro, "ContractNo", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ContractNo)));
            oCallDLL.SetProperties(ref arrPro, "PeriodID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_PeriodID)));
            oCallDLL.SetProperties(ref arrPro, "ProductID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProductID)));
            oCallDLL.SetProperties(ref arrPro, "ProductName", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProductName)));
            oCallDLL.SetProperties(ref arrPro, "ObjectID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ObjectID)));
            oCallDLL.SetProperties(ref arrPro, "OAmount", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_OAmount)));
            oCallDLL.SetProperties(ref arrPro, "VATGroupID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_VATGroupID)));
            oCallDLL.SetProperties(ref arrPro, "VATRate", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_VATRate)));
            oCallDLL.SetProperties(ref arrPro, "VATOAmount", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_VATOAmount)));
            oCallDLL.SetProperties(ref arrPro, "TotalOAmount", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_TotalOAmount)));
            oCallDLL.SetProperties(ref arrPro, "UnitID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_UnitID)));
            oCallDLL.CallWindowShowDialog("D49D2150", "D49F2132", arrPro);

        }

        private void mnsExportVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid == null) return;
            dtGrid.AcceptChanges();
            DataRow [] dr = dtGrid.Select("IsSelected = True");
            if (dr.Length == 0)
            {
                D99D0041.D99C0008.Msg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            else
            {
                StringBuilder sSQL = new StringBuilder("");
                sSQL.Append(SQLDeleteD49T9009());
                sSQL.Append(SQLInsertD49T9009(dr, "Invoice"));
                if (L3SQLServer.ExecuteSQL(sSQL.ToString()))
                {
                    if (L3SQLServer.CheckStore(SQLStoreD49P2130("Xuat hoa don", tdbcContractNo.ReturnValue("ContractID"), "Invoice", "D49F2140")))
                    {
                        string[] sField = { "FormName", "ModuleID" };
                        string[] sValue = {"D49F2140", "49"};
                        string[] sOutputName = { "Output01" }; //DS tham số đầu ra;
                        string [] sOutput = Lemon3.IO.CallExe.CallDxxMxx40("D05E2240", "D05F2201", sField, sValue, sOutputName);
                        if (L3ConvertType.L3Bool(sOutput[0]))
                        {
                            LoadTDBGrid(true);
                        }
                    }
                }
            }
        }

        private void mnsMakeVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid == null) return;
            dtGrid.AcceptChanges();
            DataRow[] dr = dtGrid.Select("IsSelected = True");
            if (dr.Length == 0)
            {
                D99D0041.D99C0008.Msg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            else
            {
                StringBuilder sSQL = new StringBuilder("");
                sSQL.Append(SQLDeleteD49T9009());
                sSQL.Append(SQLInsertD49T9009(dr, "PaymentVoucher", true));
                if (L3SQLServer.ExecuteSQL(sSQL.ToString()))
                {
                    if (L3SQLServer.CheckStore(SQLStoreD49P2130("Tao phieu thu", tdbcContractNo.ReturnValue("ContractID"), "PaymentVoucher", "D49F2140")))
                    {
                        string[] sField = { "FormName" };
                        string[] sValue = { "D49F2140" };
                        string[] sOutputName = { "SavedOK" }; //DS tham số đầu ra;
                        string[] sOutput = Lemon3.IO.CallExe.CallDxxMxx40("D01E2040", "D01F2080", sField, sValue, sOutputName);
                        if (L3ConvertType.L3Bool(sOutput[0]))
                        {
                            LoadTDBGrid(true);
                        }
                        
                        //Dictionary<string, object> dicParaIn = new Dictionary<string, object>();
                        //dicParaIn.Add("FormID", "D49F2140");
                        //string[] sOutputName = { "bSaved" }; //DS tham số đầu ra;
                        //Dictionary<string, object> dicParaOut = Lemon3.CallDxxMxx40("D01E2040", "D01F2080", dicParaIn, sOutputName);

                        //if (dicParaOut.Count > 0 && L3ConvertType.L3Bool(dicParaOut("bSaved")))
                        //{
                        //    LoadTDBGrid(true);
                        //}
                    }
                        
                }
            }
        }

        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLInsertD49T9009
        // # Created User: Đào Hữu Khánh
        // # Created Date: 13/12/2019 10:35:19
        // #---------------------------------------------------------------------------------------------------
        private StringBuilder SQLInsertD49T9009(DataRow [] dr,string sKey02ID, bool bKey03ID = false)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Insert du lieu bang tam" + Environment.NewLine);
            for (int i = 0; i < dr.Length; i++)
            {
                sSQL.Append("Insert Into D49T9009(");
                sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, Key03ID, " + Environment.NewLine);
                sSQL.Append("Num01, Num02, Num03");
                sSQL.Append(") Values(" + Environment.NewLine);
                sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // UserID, varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA); // HostID, varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString("D49F2140") + L3.COMMA); // FormID, varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(dr[i]["TransID"]) + L3.COMMA); // Key01ID, nvarchar[1000], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(sKey02ID) + L3.COMMA + Environment.NewLine); // Key02ID, nvarchar[1000], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(bKey03ID == true ? dr[i]["CashRequestID"] : "") + L3.COMMA); // Key03ID, nvarchar[1000], NOT NULL
                sSQL.Append(L3SQLClient.SQLNumber(dr[i]["IsAccrualRevenue"]) + L3.COMMA); // Num01, decimal, NOT NULL
                sSQL.Append(L3SQLClient.SQLNumber(dr[i]["IsCashRequest"]) + L3.COMMA); // Num02, decimal, NOT NULL
                sSQL.Append(L3SQLClient.SQLNumber(dr[i]["IsInvoice"])); // Num03, decimal, NOT NULL
                sSQL.Append(")" + Environment.NewLine);
            }
            return sSQL;
        }

        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLDeleteD49T9009
        // # Created User: Đào Hữu Khánh
        // # Created Date: 13/12/2019 10:50:27
        // #---------------------------------------------------------------------------------------------------
        private string SQLDeleteD49T9009()
        {
            string sSQL = "";
            sSQL += ("-- Xoa du lieu bang tam" + Environment.NewLine);
            sSQL += "Delete From D49T9009";
            sSQL += " WHERE UserID = " + L3SQLClient.SQLString(L3.UserID);
            sSQL += " AND HostID = " + L3SQLClient.SQLString(Environment.MachineName);
            sSQL += " AND FormID = 'D49F2140'" + Environment.NewLine;
            return sSQL;
        }

        bool bSelect = true;
        private void tdbgView_ColumnHeaderClick(object sender, DevExpress.Xpf.Grid.ColumnHeaderClickEventArgs e)
        {
            if (e.Column == COL_IsSelected)
            {
                HeaderClick(tdbg, COL_IsSelected, ref bSelect);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void HeaderClick(L3GridControl tdbg, GridColumn col, ref bool bSelect)
        {
            for (int i = 0; i <= tdbg.VisibleRowCount - 1; i++)
            {
                tdbg.SetCellValue(i, col, bSelect);
            }
            bSelect = !bSelect;

        }

        private void L3Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btnFilter_Click(null, null);
            }
        }

    }
}
