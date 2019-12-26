using D49D2150;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace D49D2150
{
    /// <summary>
    /// Interaction logic for D49D2130.xaml
    /// </summary>
    public partial class D49F2133 : L3Page
    {
        private string _AttackTextContent;
        public string AttackTextContent
        {
            get { return _AttackTextContent; }
            
        }   
        public override void SetContentForL3Page()
        { }
        public D49F2133()
        {
            InitializeComponent();
         //   this.Title = L3Resource.rL3("Ke_hoach_thu_tien") + " - " + this.GetType().Name;
            _AttackTextContent = L3Resource.rL3("Dinh_kem");
            this.DataContext = this;
        }

        private int iPerD49F2133 = -1;
        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;           
            DefaultAndFormat();
            LoadLanguage();
            LoadExt();
            EnableMenu();
            LoadTDBCombo();
            
            
            this.Cursor = Cursors.Arrow;
        }

        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Ke_hoach_thu_tien") + " - " + this.GetType().Name;

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

            mnsAccrualRevenue.Header = L3Resource.rL3("Trich_truoc_doanh_thu");
            mnsCancelAccrualRevenue.Header = L3Resource.rL3("Huy_trich_truoc_doanh_thu");
            mnsCancelCashRequest.Header = L3Resource.rL3("Huy_de_nghi_thu_tien");
            mnsCashRequest.Header = L3Resource.rL3("De_nghi_thu_tien");

            bandAccrualRevenue.Header = L3Resource.rL3("Trich_truoc_doanh_thu");
            bandCashRequest.Header = L3Resource.rL3("De_nghi_thu_tien");
            bandInvoice.Header = L3Resource.rL3("Xuat_hoa_donU");
            bandReipts.Header = L3Resource.rL3("Phieu_thu");

            COL_IsSelected.Header=L3Resource.rL3("Chon");
            COL_PeriodID.Header=L3Resource.rL3("Ky");
            COL_ProjectID.Header = L3Resource.rL3("Du_an");
            COL_ProjectName.Header=L3Resource.rL3("Ten_du_an");
            COL_ContractNo.Header = L3Resource.rL3("So_hop_dong_");
            COL_ObjectID.Header = L3Resource.rL3("Khach_hang");
            COL_ObjectName.Header = L3Resource.rL3("Ten_khach_hang");
            COL_ProductID.Header = L3Resource.rL3("Ma_dich_vuU");
            COL_ProductName.Header = L3Resource.rL3("Ten_dich_vuU");
            COL_ServiceTypeName.Header = L3Resource.rL3("Loai_dich_vuU");
            COL_UnitID.Header=L3Resource.rL3("DVT");

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
            COL_IsReipts.Header = L3Resource.rL3("Da_tao_phieu_thu");

            COL_AccrualRevenueNo.Header = L3Resource.rL3("So_phieu");
            COL_CashRequestNo.Header = L3Resource.rL3("So_phieu");
            COL_InvoiceNo.Header = L3Resource.rL3("So_phieu");
            COL_AccrualRevenueDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_CashRequestDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_InvoiceDate.Header = L3Resource.rL3("Ngay_phieuU");
            COL_ReiptsNo.Header = L3Resource.rL3("So_phieu");
            COL_ReiptsDate.Header = L3Resource.rL3("Ngay_phieuU");

            btnFilter.Content = L3Resource.rL3("Loc") + " (F5)";
        }
        private void DefaultAndFormat()
        {
            L3Format.LoadCustomFormat();
            btnFilter.SetImage(ImageType.Filter);
            tdbg.SetDefaultGridControlInquiry();
            tdbg.InputDate("MM/yyyy", COL_PeriodID);
            tdbg.InputNumber288(L3Format.DxxFormat.D90_ConvertedDecimals, false, false, COL_OAmount,COL_VATOAmount,COL_TotalOAmount);          
            tdbg.InputNumber288(L3Format.DxxFormat.D07_QuantityDecimals, false, false, COL_OQuantity);
            tdbg.InputNumber288(L3Format.DxxFormat.D07_UnitCostDecimals, false, false, COL_UnitPrice);
            tdbg.InputPercent(false, false, 28, 8, COL_VATRate);
            tdbg.InputDate(COL_CashRequestDate, COL_InvoiceDate, COL_AccrualRevenueDate, COL_ReiptsDate);
            this.SetBackColorObligatory(new Control[] {devdatePeriodFrom, devdatePeriodTo, tdbcProjectID,tdbcContractNo,tdbcObjectID }, null);
            L3Control.SetShortcutPopupMenu(MainMenuControl1, ContextMenu1);          
        }

        private void LoadTDBCombo()
        {
            //// Kỳ
            //DataTable dtPeriod = L3SQLServer.ReturnDataTable(SQLSelectD01T9999().ToString());
            //L3DataSource.LoadDataSource(tdbcPeriodFrom, dtPeriod.Copy());
            //L3DataSource.LoadDataSource(tdbcPeriodTo, dtPeriod.Copy());
            //tdbcPeriodTo.SelectedIndex = 0;
            //tdbcPeriodFrom.SelectedIndex = 0;
            devdatePeriodFrom.EditValue = Convert.ToDateTime("01/" + L3.TranMonth + "/" + L3.TranYear);
            devdatePeriodTo.EditValue = Convert.ToDateTime("01/" + L3.TranMonth + "/" + L3.TranYear);

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
        private void LoadTDBGrid(string sKey = "")
        {

            string sSQL = "-- Load Grid" + Environment.NewLine;
            sSQL += "EXEC  D49P2130   ";
            //sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA + L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            //sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodFrom.ReturnValue("Period")) + L3.COMMA + L3SQLClient.SQLString(tdbcPeriodTo.ReturnValue("Period")) + L3.COMMA;
            //sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA + L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractID")) + L3.COMMA + L3SQLClient.SQLString(tdbcObjectID.ReturnValue("ObjectID")) + L3.COMMA + L3SQLClient.SQLString("LoadGrid");
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkPeriodID.IsChecked)) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodFrom.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Convert.ToDateTime(devdatePeriodTo.EditValue).ToString("MM/yyyy")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcProjectID.ReturnValue("ProjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcObjectID.ReturnValue("ObjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString("LoadGrid");
            dtGrid = L3SQLServer.ReturnDataTable(sSQL);
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
            iPerD49F2133 = L3Permissions.ReturnPermission("D49F2133");
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
            tsbAdd.IsEnabled = iPerD49F2133 >= 2 ;
            tsbEdit.IsEnabled = iPerD49F2133 >= 3 && tdbg.VisibleRowCount > 0;
            tsbDelete.IsEnabled = iPerD49F2133 >= 4 && tdbg.VisibleRowCount > 0;
            tsbListAll.IsEnabled = tdbg.VisibleRowCount > 0;

            mnsAdd.IsEnabled = tsbAdd.IsEnabled;
            mnsEdit.IsEnabled = tsbEdit.IsEnabled;
            mnsDelete.IsEnabled = tsbDelete.IsEnabled;
            mnsListAll.IsEnabled = tsbListAll.IsEnabled;

            mnsVoucherDetail.IsEnabled = tdbg.VisibleRowCount > 0;
            mnsCancelAccrualRevenue.IsEnabled = iPerD49F2133 >= 4 && tdbg.VisibleRowCount > 0;
            mnsCancelCashRequest.IsEnabled = iPerD49F2133 >= 4 && tdbg.VisibleRowCount > 0;
            mnsAccrualRevenue.IsEnabled = iPerD49F2133 >= 4 && tdbg.VisibleRowCount > 0;
            mnsCashRequest.IsEnabled = iPerD49F2133 >= 4 && tdbg.VisibleRowCount > 0;  
       
            mnsExportToExcel.IsEnabled = tdbg.VisibleRowCount > 0;
             
            //tdbg.IsEnabled = !bEnabled;
            //if (!bEnabled)
            //{
            //    L3Control.CheckMenu(this.GetType().Name, MainMenuControl1, ContextMenu1, tdbg.VisibleRowCount, true, false);
            //}
            //else
            //{
            //    L3Control.CheckMenu("-1", MainMenuControl1, ContextMenu1, -1, false, false);
            //}

            // CheckMenuOthers();
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

        private void tsbAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mnsAdd_Click(null,null);
        }

        private void tsbEdit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
            mnsEdit_Click(null,null);
        }

        private void tsbDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mnsDelete_Click(null,null);
        }

        private void tsbListAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mnsListAll_Click(null,null);
        }

        private void tsbSysInfo_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            mnsSysInfo_Click(null,null);
        }

        private void mnsAdd_Click(object sender, RoutedEventArgs e)
        {
            string sSQL = "DELETE D49T9009 WHERE UserID = "+L3SQLClient.SQLString(L3.UserID)+" AND HostID = "+L3SQLClient.SQLString(Environment.MachineName)+" AND FormID = 'D49F2133'" + Environment.NewLine;
            if (L3SQLServer.ExecuteSQL(sSQL))
            {
                D49F2131 f = new D49F2131();
                f.FormState = EnumFormState.FormAdd;
                f.ShowDialog();
                if(f.bSAveOk) LoadTDBGrid();
            }            
        }

        private void mnsEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid == null) return;
            dtGrid.AcceptChanges();
            DataRow[] dr = dtGrid.Select("IsSelected = True");
            if (dr.Length == 0)
            {
                D99D0041.D99C0008.Msg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }

            string sSQL = "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp("CheckEditData") + SQLStoreD49P2130("-- Combo Dự án", "CheckEditData");
            sSQL += Environment.NewLine + "commit tran";

            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                { }
                else
                {
                    
                    D49F2131 F = new D49F2131();                                  
                    F.ProjectID =L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProjectID));
                    F.ContractNo = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ContractID));
                    F.ObjectID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ObjectID));
                    //DataTable dt = L3DataTable.ReturnTableFilter(dtGrid.Copy(), "IsSelected=True");
                    //F.DTGrid = dt;
                    F.FormState = EnumFormState.FormEdit; 
                    F.ShowDialog();
                    LoadTDBGrid();
                }
            }
            catch { };
           
        }
       
        private void mnsDelete_Click(object sender, RoutedEventArgs e)
        {
            tdbg.FocusRowHandle(tdbgView.FocusedRowHandle - 1); 
            tdbg.FocusRowHandle(tdbgView.FocusedRowHandle + 1);
            int iChoose = 0;
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                if (L3ConvertType.L3Bool(tdbg.GetCellValue(i, COL_IsSelected)) == true)
                {
                    iChoose++;
                }
            }
            if (iChoose == 0)
            {
                L3Msg.MyMsg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Ban_co_muon_xoa_du_lieu_tren_luoi") + "?") == System.Windows.Forms.DialogResult.No)
                return;
            string sSQL = "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp("DeleteData") + SQLStoreD49P2130("-- Xóa kế hoạch thu tiền", "DeleteData");
            sSQL += Environment.NewLine + "commit tran";

            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    Lemon3.Messages.L3Msg.DeleteOK();
                    //for (int i = 0; i < tdbg.VisibleRowCount; i++)
                    //{
                    //    DataRow drLoop = (tdbg.GetRow(tdbg.GetRowHandleByVisibleIndex(i)) as DataRowView).Row;
                    //    DataRow drCurrent = (tdbg.CurrentItem as DataRowView).Row;

                    //    if (drLoop == drCurrent)
                    //    {
                    //        // Nếu bên dưới có dòng thì chuyển xuống dòng dưới
                    //        if (i < (tdbg.VisibleRowCount - 1))
                    //        {
                    //            int indexRowFocus = tdbg.GetRowHandleByVisibleIndex(i);
                    //            HandleRowFocus(indexRowFocus);
                    //        }
                    //        else
                    //        {
                    //            int indexRowFocus = tdbg.GetRowHandleByVisibleIndex(0);
                    //            HandleRowFocus(indexRowFocus);
                    //        }
                    //        (tdbg.ItemsSource as DataTable).Rows.Remove(drCurrent);
                    //        break;
                    //    }
                    //}
                     LoadTDBGrid();
                }
            }
            catch
            { };
            
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

        private void mnsVoucherDetail_Click(object sender, RoutedEventArgs e)
        {

            if(tdbg.GetFocusedRowCellValue(COL_IsDetailInvoice).ToString()=="0")
            {
                L3Msg.MyMsg(L3Resource.rL3("Ma_hang_khong_xuat_hoa_don_chi_tiet"));
                return;
            }
            D49F2132 f = new D49F2132();
            f.OTransID = tdbg.GetFocusedRowCellValue(COL_TransID).ToString();
            f.ProjectID = tdbg.GetFocusedRowCellValue(COL_ProjectID).ToString();
            f.ProjectName = tdbg.GetFocusedRowCellValue(COL_ProjectName).ToString();
            f.ContractID = tdbg.GetFocusedRowCellValue(COL_ContractID).ToString();
            f.ContractNo = tdbg.GetFocusedRowCellValue(COL_ContractNo).ToString();
            f.PeriodID = tdbg.GetFocusedRowCellValue(COL_PeriodID).ToString();
            f.ProductID = tdbg.GetFocusedRowCellValue(COL_ProductID).ToString();
            f.ProductName = tdbg.GetFocusedRowCellValue(COL_ProductName).ToString();
            f.ObjectID = tdbg.GetFocusedRowCellValue(COL_ObjectID).ToString();
            f.OAmount = tdbg.GetFocusedRowCellValue(COL_OAmount).ToString();
            f.VATGroupID = tdbg.GetFocusedRowCellValue(COL_VATGroupID).ToString();
            f.VATRate = tdbg.GetFocusedRowCellValue(COL_VATRate).ToString();
            f.VATOAmount = tdbg.GetFocusedRowCellValue(COL_VATOAmount).ToString();
            f.TotalOAmount = tdbg.GetFocusedRowCellValue(COL_TotalOAmount).ToString();
            f.ShowDialog();
        }

        private void mnsCancelAccrualRevenuee_Click(object sender, RoutedEventArgs e)
        {
            tdbg.FocusRowHandle(tdbgView.FocusedRowHandle - 1);
            tdbg.FocusRowHandle(tdbgView.FocusedRowHandle + 1);
            int iChoose = 0;
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                if (L3ConvertType.L3Bool(tdbg.GetCellValue(i, COL_IsSelected)) == true)
                {
                    iChoose++;
                }
            }
            if (iChoose == 0)
            {

                L3Msg.MyMsg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            string sSQL = "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp("CancelAccrualRevenue") + SQLStoreD49P2130("-- Hủy trích trước doanh thu", "CancelAccrualRevenue");
            sSQL += Environment.NewLine + "commit tran";
            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    L3Msg.MyMsg(L3Resource.rL3("Huy_trich_truoc_doanh_thu_thanh_cong"));
                    LoadTDBGrid();
                }
            }catch
            {};
            
        }

        private void mnsCancelCashRequest_Click(object sender, RoutedEventArgs e)
        {
            tdbg.FocusRowHandle(tdbgView.FocusedRowHandle - 1);
            tdbg.FocusRowHandle(tdbgView.FocusedRowHandle + 1);
            int iChoose = 0;
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                if (L3ConvertType.L3Bool(tdbg.GetCellValue(i, COL_IsSelected)) == true)
                {
                    iChoose++;
                }
            }
            if (iChoose == 0)
            {
                L3Msg.MyMsg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            string sSQL = "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp("CancelCashRequest") + SQLStoreD49P2130("--Hủy đề nghị thu tiền", "CancelCashRequest");
            sSQL += Environment.NewLine + "commit tran";
            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    L3Msg.MyMsg(L3Resource.rL3("Huy_de_nghi_thu_tien_thanh_cong"));
                    LoadTDBGrid();
                }
            }
            catch
            { };
        }
        private void mnsCashRequest_Click(object sender, RoutedEventArgs e)
        {
            //tdbg.FocusRowHandle(tdbgView.FocusedRowHandle - 1);
            //tdbg.FocusRowHandle(tdbgView.FocusedRowHandle + 1);
            //int iChoose = 0;
            //for (int i = 0; i < tdbg.VisibleRowCount; i++)
            //{
            //    if (L3ConvertType.L3Bool(tdbg.GetCellValue(i, COL_IsSelected)) == true)
            //    {
            //        iChoose++;
            //    }
            //}
            //if (iChoose == 0)
            //{
            //    L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_du_lieu_tren_luoi"));
            //    return;
            //}
            if (dtGrid == null) return;
            dtGrid.AcceptChanges();
            DataRow[] dr = dtGrid.Select("IsSelected = True");
            if (dr.Length == 0)
            {
                D99D0041.D99C0008.Msg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            string sSQL = "--Đề nghị thu tiền" + Environment.NewLine + "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp("CashRequest") + Environment.NewLine;
            sSQL += SQLStoreD49P2131_save("Đề nghị thu tiền", tdbg.GetFocusedRowCellValue(COL_ProjectID).ToString(), tdbg.GetFocusedRowCellValue(COL_ContractID).ToString(), tdbg.GetFocusedRowCellValue(COL_ObjectID).ToString(), "CashRequest");
            sSQL += Environment.NewLine + "commit tran";
            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    L3Msg.MyMsg(L3Resource.rL3("De_nghi_thu_tien_thanh_cong"));
                    LoadTDBGrid();
                }
            }
            catch { };
        }

        private void mnsAccrualRevenue_Click(object sender, RoutedEventArgs e)
        {
            //tdbg.FocusRowHandle(tdbgView.FocusedRowHandle - 1);
            //tdbg.FocusRowHandle(tdbgView.FocusedRowHandle + 1);
            //int iChoose = 0;
            //for (int i = 0; i < tdbg.VisibleRowCount; i++)
            //{
            //    if (L3ConvertType.L3Bool(tdbg.GetCellValue(i, COL_IsSelected)) == true)
            //    {
            //        iChoose++;
            //    }
            //}
            //if (iChoose == 0)
            //{
            //    L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_du_lieu_tren_luoi"));
            //    return;
            //}
            if (dtGrid == null) return;
            dtGrid.AcceptChanges();
            DataRow[] dr = dtGrid.Select("IsSelected = True");
            if (dr.Length == 0)
            {
                D99D0041.D99C0008.Msg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            string sSQL = "--Trích trước doanh thu" + Environment.NewLine + "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp2131("AccrualRevenue") + Environment.NewLine;
            sSQL += SQLStoreD49P2131_save("Trích trước doanh thu", tdbg.GetFocusedRowCellValue(COL_ProjectID).ToString(), tdbg.GetFocusedRowCellValue(COL_ContractID).ToString(), tdbg.GetFocusedRowCellValue(COL_ObjectID).ToString(), "AccrualRevenue");
            sSQL += Environment.NewLine + "commit tran";
            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    L3Msg.MyMsg(L3Resource.rL3("Trich_truoc_doanh_thu_thanh_cong"));
                    LoadTDBGrid();
                }
            }
            catch { };
           
        }
        private string SQLInsertD49T9009_Temp2131(string Key02ID)
        {
            string sSQL = "-- Insert dữ liệu vào bảng tạm" + Environment.NewLine;
            sSQL += "DELETE D49T9009 WHERE UserID = " + L3SQLClient.SQLString(L3.UserID) + " AND HostID = " + L3SQLClient.SQLString(Environment.MachineName) + " AND FormID = 'D49F2131'" + Environment.NewLine;
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                if (L3ConvertType.L3Bool(tdbg.GetCellValue(i, COL_IsSelected)) == true)
                {
                    sSQL += "INSERT INTO D49T9009 (UserID,HostID,FormID, Key01ID,Key02ID) Values (";
                    sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA + L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA + L3SQLClient.SQLString("D49F2131") + L3.COMMA;
                    sSQL += L3SQLClient.SQLString(tdbg.GetCellValue(i,COL_TransID)) + L3.COMMA + L3SQLClient.SQLString(Key02ID) + ")" + Environment.NewLine;
                }
            }
            return sSQL;
        }
        private string SQLStoreD49P2131_save(string cap, string projectID, string contracID, string objectID, string DataType)
        {
            string sSQL = "--" + cap + Environment.NewLine;
            sSQL += "EXEC  D49P2131   ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(projectID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(contracID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(objectID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(DataType) + L3.COMMA;
            sSQL += L3ConvertType.L3Int(0) + L3.COMMA;
            sSQL += L3ConvertType.L3Int(0) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.MachineName);
            return sSQL;
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

        private string SQLInsertD49T9009_Temp(string Key02ID)
        {
            string sSQL="-- Insert dữ liệu vào bảng tạm" + Environment.NewLine;
            sSQL += "DELETE D49T9009 WHERE UserID = "+L3SQLClient.SQLString(L3.UserID)+" AND HostID = "+L3SQLClient.SQLString(Environment.MachineName)+" AND FormID = 'D49F2133'" + Environment.NewLine;
            for (int i = 0; i < tdbg.VisibleRowCount;i++ )
            {
                if(L3ConvertType.L3Bool(tdbg.GetCellValue(i,COL_IsSelected))==true)
                {
                    sSQL += "INSERT INTO D49T9009 (UserID,HostID,FormID, Key01ID,Key02ID,Num01,Num02,Num03) Values (";
                    sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA + L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA + L3SQLClient.SQLString("D49F2133") + L3.COMMA;
                    sSQL += L3SQLClient.SQLString(tdbg.GetCellValue(i,COL_TransID)) + L3.COMMA + L3SQLClient.SQLString(Key02ID) + L3.COMMA;
                    sSQL += L3ConvertType.L3Int(tdbg.GetCellValue(i, COL_IsAccrualRevenue)) + L3.COMMA + L3ConvertType.L3Int(tdbg.GetCellValue(i, COL_IsCashRequest)) + L3.COMMA + L3ConvertType.L3Int(tdbg.GetCellValue(i, COL_IsInvoice)) + ")" + Environment.NewLine;        
                }        
            }
            return sSQL;  
        }

        private string SQLStoreD49P2130(string cap, string DataType)
        {
            string sSQL = cap + Environment.NewLine;
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
            sSQL += L3SQLClient.SQLString(tdbcContractNo.ReturnValue("ContractNo")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(tdbcObjectID.ReturnValue("ObjectID")) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(DataType) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.UserID) +L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.MachineName);
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
           
            if(chkPeriodID.IsChecked==true)
            {
                //if (tdbcPeriodFrom.EditValue == "" || tdbcPeriodFrom.EditValue==null)
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
                //if(L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranYear"))>L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranYear")))
                //{
                //    L3Msg.MyMsg(L3Resource.rL3("Ky_den_phai_lon_hon_ky_tuU"));
                //    tdbcPeriodTo.Focus();
                //    return;
                //}
                //else
                //{
                //    if(L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranYear"))==L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranYear")))
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
                return ;
            }
            if (tdbcContractNo.EditValue == "" || tdbcContractNo.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblContractNo.Content.ToString());
                tdbcContractNo.Focus();
                return;
            }               
            if (tdbcObjectID.EditValue == "" || tdbcObjectID.EditValue==null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblObjectID.Content.ToString());
                tdbcObjectID.Focus();
                return;
            }

            LoadTDBGrid();
        }
     
        private void tdbcProjectID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            LoadTDBCContractNo();
        }

        private void tdbcContractNo_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            LoadTDBCObjectID();
        }

        private void tdbgView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            dtGrid.AcceptChanges();
        }

        bool bSelect = true;
        private void tdbgView_ColumnHeaderClick(object sender, ColumnHeaderClickEventArgs e)
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

        private void tdbgView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            tdbgView.CommitEditing();
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
