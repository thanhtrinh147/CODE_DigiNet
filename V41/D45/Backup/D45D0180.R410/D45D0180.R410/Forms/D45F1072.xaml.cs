using DevExpress.Xpf.Grid;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using System;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

//using Lemon3.IO;
//using Lemon3.Reports;
//using Lemon3.Resources;
using System.Collections.Generic;
using System.Linq;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

using Cursors = System.Windows.Input.Cursors;
using L3Resource = Lemon3.Resources.L3Resource;
using L3Msg = Lemon3.Messages.L3Msg;
using L3CallDLL = Lemon3.IO.L3CallDLL;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors;
//using System.Windows.Controls;
//using L3UniCode = Lemon3.UniCode.L3UniCode;

namespace D45D0180
{
    /// <summary>
    /// Interaction logic for D45F1072.xaml
    /// </summary>
    public partial class D45F1072 : L3Page
    {
        public D45F1072()
        {
            InitializeComponent();
        }
        public override void SetContentForL3Page()
        {

        }
        DataTable _dtGrid = null;
        DataTable _dtGrid1 = null;
        DataTable _dtGrid2 = null;

        private EnumFormState _FormState = EnumFormState.FormView;
        private bool _bAskSave = true; // Kiểm tra xem có thông báo hỏi khi nhấn nút Lưu không
        public EnumFormState FormState
        {
            set
            {
                _FormState = value;
                switch (_FormState)
                {
                    case EnumFormState.FormAdd:
                        {
                            break;
                        }

                    case EnumFormState.FormEdit:
                        {
                            //LoadEdit();
                            break;
                        }

                    case EnumFormState.FormView:
                        {
                            break;
                        }
                }
            }
        }
        private void L3Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            L3Format.LoadCustomFormat();
            SetBackColorObligatory();
            LoadLanguage();
            LoadTDBDropDown();
            LoadTDBGrid();
            txtGroupProductID.CheckIdTextBox();
            L3Control.SetShortcutPopupMenu(MainMenuControl, tdbgPopupMenu, tdbg1PopupMenu, tdbg2PopupMenu);
            SetShortcutPopupMenuOther();
            tdbg.SetDefaultGridControlInquiry();
            if (!this.IsFocused) tdbg.Focus();
            this.Cursor = Cursors.Arrow;
        }
        private void SetBackColorObligatory()
        {
            L3Control.SetBackColorObligatory(txtGroupProductID, txtGroupProductName);
        }
        private void SetShortcutPopupMenuOther()
        {
            //mnsExportToExcel1.BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
            //mnsExportToExcel1.Content = L3Resource.ConvertStringHotkeyToWPF(L3Resource.rL3("Xuat__Excel"));
            //mnsExportToExcel1.KeyGesture = new KeyGesture(Key.X, ModifierKeys.Control);

            mnsImportData1.BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
            mnsImportData1.Content = L3Resource.ConvertStringHotkeyToWPF(L3Resource.rL3("Import__du_lieu"));
            mnsImportData1.KeyGesture = new KeyGesture(Key.M, ModifierKeys.Control);
            mnsImportData1.IsEnabled = (L3Permissions.ReturnPermission("D80F2090") >= 2);

            //mnsExportToExcel2.BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
            //mnsExportToExcel2.Content = L3Resource.ConvertStringHotkeyToWPF(L3Resource.rL3("Xuat__Excel"));
            //mnsExportToExcel2.KeyGesture = new KeyGesture(Key.X, ModifierKeys.Control);

            mnsImportData2.BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
            mnsImportData2.Content = L3Resource.ConvertStringHotkeyToWPF(L3Resource.rL3("Import__du_lieu"));
            mnsImportData2.KeyGesture = new KeyGesture(Key.M, ModifierKeys.Control);
            mnsImportData2.IsEnabled = (L3Permissions.ReturnPermission("D80F2090") >= 2);
        }
        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Danh_muc_nhom_san_pham") + " - D45F1072";
            if (this.Parent != null) ((L3Window)this.Parent).Title = L3Resource.rL3("Danh_muc_nhom_san_pham") + " - D45F1072";
            tblFilter.Text = L3Resource.rL3("Chi_tiet");
            lblGroupProductID.Content = L3Resource.rL3("Ma_nhom_san_pham");
            chkDisable.Content = L3Resource.rL3("Khong_su_dung");
            lblGroupProductName.Content = L3Resource.rL3("Ten_nhom_san_pham");
            lblGroupProductDesc.Content = L3Resource.rL3("Ghi_chu");

            COL_GroupProductID.Header = L3Resource.rL3("Ma");
            COL_GroupProductName.Header = L3Resource.rL3("Ten");
            COL_GroupProductDesc.Header = L3Resource.rL3("Ghi_chu");
            COL_Disabled.Header = L3Resource.rL3("KSD");

            tab1.Header = "1." + L3Resource.rL3("San_pham");
            tab2.Header = "2." + L3Resource.rL3("Cong_doan");

            COL1_ProductID.Header = L3Resource.rL3("Ma_san_pham");
            COL1_ProductName.Header = L3Resource.rL3("Ten_san_pham");
            COL1_ShortName.Header = L3Resource.rL3("Ten_tat");
            COL1_Note.Header = L3Resource.rL3("Ghi_chu");

            COL2_StageID.Header = L3Resource.rL3("Ma_cong_doan");
            COL2_StageName.Header = L3Resource.rL3("Dien_giai");
            COL2_Note.Header = L3Resource.rL3("Ghi_chu");

            tdbdProductID.SetCaptionColumn("ProductID", L3Resource.rL3("Ma")); // Mã
            tdbdProductID.SetCaptionColumn("ProductName", L3Resource.rL3("Ten")); // Tên
            tdbdStageID.SetCaptionColumn("StageID", L3Resource.rL3("Ma")); // Mã
            tdbdStageID.SetCaptionColumn("StageName", L3Resource.rL3("Ten")); // Tên

            btnSave.Content = L3Resource.rL3("Luu");
            btnNext.Content = L3Resource.ConvertStringHotkeyToWPF(L3Resource.rL3("Luu_va_nhap_tiep")); //Nhập &tiếp
            btnNotSave.Content = L3Resource.rL3("Khong_luu");
            chkShowDisabled.Content = L3Resource.rL3("Hien_thi_danh_muc_khong_su_dung");
            mnsExportToExcel.Content = L3Resource.rL3("Xuat_Excel");
            mnsImportData1.Content = L3Resource.rL3("Import_du_lieu");
            mnsImportData2.Content = L3Resource.rL3("Import_du_lieu");
        }
        private void LoadTDBDropDown()
        {
            //tdbdProductID
            string sSQL = "SELECT D45.ProductID, D45." + (L3.IsUniCode == true ? "ProductNameU" : "ProductName") + " As ProductName, D45." + (L3.IsUniCode == true ? "ShortNameU" : "ShortName") + " As ShortName, D45." + (L3.IsUniCode == true ? "NoteU" : "Note") + " As Note" + Environment.NewLine;
            sSQL += "FROM D45T1000 D45 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += " WHERE D45.Disabled = 0" + Environment.NewLine;
            sSQL += "Order by D45.ProductID" + Environment.NewLine;
            L3DataSource.LoadDataSource(tdbdProductID, sSQL);

            //tdbdStageID 
            sSQL = "SELECT		D45.StageID,D45." + (L3.IsUniCode == true ? "StageNameU" : "StageName") + " As StageName, D45." + (L3.IsUniCode == true ? "NoteU" : "Note") + " As Note" + Environment.NewLine;
            sSQL += "FROM	D45T1010 D45" + Environment.NewLine;
            sSQL += "WHERE D45.Disabled = 0 " + Environment.NewLine;
            L3DataSource.LoadDataSource(tdbdStageID, sSQL);

        }
        private void LoadTDBGrid(bool FlagAdd = false, string sKey = "")
        {
            string sSQL = "SELECT " + (L3.IsUniCode == true ? "GroupProductNameU" : "GroupProductName") + " As GroupProductName," + Environment.NewLine;
            sSQL += (L3.IsUniCode == true ? "GroupProductDescU" : "GroupProductDesc") + " As GroupProductDesc" + " , D45.*" + Environment.NewLine;
            sSQL += "FROM D45T1070 D45 WITH (NOLOCK) ORDER BY D45.GroupProductID";
            _dtGrid = L3SQLServer.ReturnDataTable(sSQL);
            L3DataSource.LoadDataSource(tdbg, _dtGrid, L3.IsUniCode);
            ReLoadTDBGrid();
            if (sKey != "")
            {
                DataTable dt1 = _dtGrid.DefaultView.ToTable();
                DataRow[] dr = dt1.Select(COL_GroupProductID.FieldName + " = " + L3SQLClient.SQLString(sKey), dt1.DefaultView.Sort);
                if (dr.Length > 0)
                {
                    HandleRowFocus(tdbg, tdbgView, tdbg.GetRowHandleByListIndex(dt1.Rows.IndexOf(dr[0])));
                }
                if (!tdbgView.IsFocused)
                    tdbgView.Focus();
            }
        }
        private void ReLoadTDBGrid(bool bLoadEdit = true)
        {
            string strFind = "";
            if (!chkShowDisabled.IsChecked ?? false)
            {
                if (strFind != "")
                    strFind += " And ";
                strFind += "Disabled = 0";
            }
            _dtGrid.DefaultView.RowFilter = strFind;
            ResetGrid();
            if (_FormState == EnumFormState.FormAdd)
                return;

            if (tdbg.VisibleRowCount == 0)
            {
                Lemon3.Controls.DevExp.L3Control.ClearTextALL(grpDetail);
                if (_dtGrid1 != null)
                {
                    _dtGrid1.Clear();
                    tdbg1.RefreshData();
                }
                if (_dtGrid2 != null)
                {
                    _dtGrid2.Clear();
                    tdbg2.RefreshData();
                }
            }
            else
            {
                _FormState = EnumFormState.FormView;
                tdbg1View.AllowEditing = false;
                tdbg2View.AllowEditing = false;
                if (bLoadEdit)
                    LoadEdit();
            }
        }
        private void ResetGrid()
        {
            EnableMenu(false);
            //FooterTotalGrid(tdbg, COL_ConsoDSType);
            tdbg.FooterText(new[] { COL_GroupProductID }, new GridColumn[] { }, true);
        }
        private void EnableMenu(bool bEnabled)
        {
            if (_dtGrid == null)
                return;
            btnSave.IsEnabled = bEnabled;
            btnNext.IsEnabled = bEnabled;
            btnNotSave.IsEnabled = bEnabled;
            chkShowDisabled.IsEnabled = !bEnabled;
            tdbg.IsEnabled = !bEnabled;
            if (_FormState == EnumFormState.FormAdd)
            {
                btnNext.Visibility = Visibility.Visible;
                btnNext.Width = 140;
                chkDisable.IsEnabled = false;
            }
            else
            {
                btnNext.Visibility = Visibility.Hidden;
                btnNext.Width = 0;
                chkDisable.IsEnabled = true;
            }
            if (btnNext.Visibility == Visibility.Visible & btnNext.IsEnabled)
            { }
            else
            { }
            if (bEnabled)
                L3Control.CheckMenu("-1", MainMenuControl, tdbgPopupMenu, tdbg.ReturnVisibleRowCount, true, false);
            else
                L3Control.CheckMenu("D45F1070", MainMenuControl, tdbgPopupMenu, tdbg.ReturnVisibleRowCount, true, false);
        }
        private void LockControlDetail(bool bLock)
        {
            //grpDetail. = !bLock;
            tdbg1View.AllowEditing = !bLock;
            tdbg2View.AllowEditing = !bLock;
        }
        private void HandleRowFocus(L3GridControl tdbg,GridViewBase tdbgView,int indexRowFocus)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tdbgView.MoveFocusedRow(indexRowFocus);
                tdbg.FocusRowHandle(indexRowFocus);
            }), DispatcherPriority.Render);
        }
        private void LoadEdit()
        {
            if (_dtGrid == null)
                return; // Chưa đổ nguồn cho lưới
            if (_dtGrid.Rows.Count == 0)
                return; // Chưa đổ nguồn cho lưới
            if (tdbgView.FocusedRowHandle < 0)
                tdbgView.FocusedRowHandle = 0;

            COL_GroupProductID.Tag = (tdbgView.FocusedRowHandle >= 0 ? tdbg.GetFocusedRowCellValue(COL_GroupProductID).ToString() : "");
            //// Gán dữ liệu
            txtGroupProductID.Text = tdbgView.FocusedRowHandle >= 0 ? tdbg.GetFocusedRowCellValue(COL_GroupProductID).ToString() : "";
            txtGroupProductName.Text = tdbgView.FocusedRowHandle >= 0 ? tdbg.GetFocusedRowCellValue(COL_GroupProductName).ToString() : "";
            txtGroupProductDesc.Text = tdbgView.FocusedRowHandle >= 0 ? tdbg.GetFocusedRowCellValue(COL_GroupProductDesc).ToString() : "";
            chkDisable.IsChecked = L3ConvertType.L3Bool(tdbgView.FocusedRowHandle >= 0 ? tdbg.GetFocusedRowCellValue(COL_Disabled).ToString() : "");
            Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtGroupProductID);
            LoadTDBGrid1(L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_GroupProductID)));
            LoadTDBGrid2( L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_GroupProductID)));
        }
        private void mnsAdd_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
           EnableMenu(true);
            LoadAdd();
        }
        private void LoadAdd()
        {
            _FormState = EnumFormState.FormAdd;
            tdbg1View.AllowEditing = true;
            tdbg2View.AllowEditing = true;
            COL_GroupProductID.Tag = "";
            // ********************
            //_bSavedOK = false;
            Lemon3.Controls.DevExp.L3Control.ClearTextALL(grpDetail);
            chkDisable.IsChecked = false;
            txtGroupProductID.IsReadOnly = false;
            txtGroupProductID.Focus();

            if (_dtGrid1 == null) LoadTDBGrid1();
            if (_dtGrid1.Rows.Count > 0) _dtGrid1.Clear();
            if (_dtGrid2 == null) LoadTDBGrid2();
            if (_dtGrid2.Rows.Count > 0)  _dtGrid2.Clear();
        }
        private bool _bEdit = false;
        private void mnsEdit_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (tdbgView.FocusedRowHandle < 0)
                return;
            try
            {
                if (!D45X0002.CheckMyStore(D45X0002.SQLStoreD45P5555(2, "D45F1072", tdbg.GetFocusedRowCellValue(COL_GroupProductID).ToString()),ref _bEdit))
                {
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            _FormState = EnumFormState.FormEdit;
            tdbg1View.AllowEditing = true;
            tdbg2View.AllowEditing = true;
            EnableMenu(true);
            Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtGroupProductID);
            txtGroupProductID.Focus();
        }
        private void mnsDelete_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (tdbgView.FocusedRowHandle < 0)
                return;
            if (D99D0041.D99C0008.MsgAskDelete() == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
            
            if (!L3SQLServer.CheckStore(D45X0002.SQLStoreD45P5555(1, "D45F1072", tdbg.GetFocusedRowCellValue(COL_GroupProductID).ToString())))
            {
                this.Cursor = Cursors.Arrow;
                return;
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append(SQLDeleteD45T1072());
            bool bRunSQL = L3SQLServer.ExecuteSQL(sSQL.ToString());
            if (bRunSQL)
            {
                Lemon3.Messages.L3Msg.DeleteOK();
                DeleteGridEvent(COL_GroupProductID.FieldName);
                if (_dtGrid.Rows.Count == 0)
                {
                    ResetGrid();
                    mnsAdd_Click(null, null);
                }
                else
                    ReLoadTDBGrid();
            }
            else
                Lemon3.Messages.L3Msg.DeleteNotOK();
        }
        public void DeleteGridEvent(string sFieldID = "")
        {
            int iRow = 0;
            sFieldID = "GroupProductID";
            {
                DataRow[] dr = _dtGrid.Select(sFieldID + " = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(sFieldID).ToString()));
                var loopTo = dr.Length - 1;
                iRow = _dtGrid.Rows.IndexOf(dr[0]);
                for (int i = 0; i <= loopTo; i++)
                    _dtGrid.Rows.Remove(dr[i]);
            }

            tdbg.RefreshData(); // sửa lỗi FetchRowStyle ID 89865 ngày 09/12/2016
            _dtGrid.AcceptChanges();
            if (_dtGrid.Rows.Count > 0)
                tdbgView.FocusedRowHandle = (iRow >= tdbg.VisibleRowCount) ? tdbg.GetRowHandleByListIndex(iRow - 1) : tdbg.GetRowHandleByListIndex(iRow);
        }
        private void tsbSysInfo_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            L3Window.ShowSysInforForm(tdbg);
        }
        private void tdbg_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tdbg.VisibleRowCount <= 0 || tdbgView.FocusedRowHandle < 0)
                return;
            this.Cursor = Cursors.Wait;
            if (tsbEdit.IsEnabled)
                mnsEdit_Click(sender, null);
            this.Cursor = Cursors.Arrow;
        }
        private void tdbg_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                    tdbg_DoubleClick(null, null);
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    if (e.Key == Key.C && tdbgView.FocusedRowHandle >= 0 && tdbg.GetFocusedValue() != null)
                    {
                        try
                        {
                            System.Windows.Clipboard.SetDataObject(tdbg.GetFocusedValue().ToString());
                        }
                        catch (Exception ex)
                        {
                            string mess = ex.Message.ToString();
                        }
                    }
                }
            }
        }
        private void tdbgView_FocusedRowHandleChanged(object sender, FocusedRowHandleChangedEventArgs e)
        {

        }
        private void chkDisable_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (btnSave.IsFocused == false)
                return;
            // Hỏi trước khi lưu
            tdbg1.FilterString = "";
            tdbg2.FilterString = "";
            if (_bAskSave)
            {
                if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
                    // SetReturnFormView()
                    return;
            }
            else
                _bAskSave = true;
            SaveData(sender);
            //LoadEdit();
        }
        private bool SaveData(System.Object sender)
        {
            if (!AllowSave())
                return false;
            this.Cursor = Cursors.Wait;
            StringBuilder sSQL = new StringBuilder();
            switch (_FormState)
            {
                case EnumFormState.FormAdd:
                    {
                        sSQL.Append(SQLInsertD45T1070());
                        sSQL.Append(SQLInsertD45T1071());
                        sSQL.Append(SQLInsertD45T1072());
                        break;
                    }

                case EnumFormState.FormEdit:
                    {
                        sSQL.Append(SQLUpdateD45T1070());
                        sSQL.Append(SQLInsertD45T1071());
                        sSQL.Append(SQLInsertD45T1072());
                        break;
                    }
            }

            bool bRunSQL = L3SQLServer.ExecuteSQL(sSQL.ToString());
            this.Cursor = Cursors.Arrow;

            if (bRunSQL)
            {
                L3Msg.SaveOK();
                switch (_FormState)
                {
                    case EnumFormState.FormAdd:
                        {
                            LoadTDBGrid(true, txtGroupProductID.Text);
                            break;
                        }

                    case EnumFormState.FormEdit:
                        {
                            LoadTDBGrid(sKey: txtGroupProductID.Text);
                            break;
                        }
                }
                Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtGroupProductID);
                SetReturnFormView();
            }
            else
            {
                L3Msg.SaveNotOK();
                return false;
            }
            return true;
        }
        private void SetReturnFormView()
        {
            _FormState = EnumFormState.FormView;
            tdbg1View.AllowEditing = false;
            tdbg2View.AllowEditing = false;
            EnableMenu(false);
            if (tdbg.VisibleRowCount == 0)
                Lemon3.Controls.DevExp.L3Control.ClearText(grpDetail);
            else
            {
                LoadEdit();
                //LockControlDetail(true);
                tdbg.Focus();
            }
        }
        private bool AllowSave()
        {
            if (txtGroupProductID.Text.Trim() == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblGroupProductID.Content.ToString());
                txtGroupProductID.Focus();
                return false;
            }

            if (_FormState == EnumFormState.FormAdd)
            {
                if (L3SQLServer.IsExistKey("D45T1070", "GroupProductID", txtGroupProductName.Text))
                {
                    D99D0041.D99C0008.MsgDuplicatePKey();
                    txtGroupProductName.Focus();
                    return false;
                }
            }
            _dtGrid1.AcceptChanges();
            if (_dtGrid1.Rows.Count > 0)
            {
                IEnumerable<DataRow> _duplicatePKey = _dtGrid1.AsEnumerable().GroupBy(g => g.Field<string>("ProductID")).LastOrDefault(f =>  f.Count() > 1);
                if (_duplicatePKey != null)
                {
                    D99D0041.D99C0008.MsgDuplicatePKey();
                    tab1.Focus();
                    tab1.IsSelected = true;
                    tdbg1View.Focus();
                    tdbg1.CurrentColumn = COL1_ProductID;
                    HandleRowFocus(tdbg1, tdbg1View, _dtGrid1.Rows.IndexOf(_duplicatePKey.ToArray<DataRow>().Last()));
                    tdbg1View.ShowEditor();
                    return false;
                }
            }
            _dtGrid2.AcceptChanges();
            if (_dtGrid2.Rows.Count > 0)
            {
                IEnumerable<DataRow> _duplicatePKey = _dtGrid2.AsEnumerable().GroupBy(g => g.Field<string>("StageID")).LastOrDefault(f => f.Count() > 1);
                if (_duplicatePKey != null)
                {
                    D99D0041.D99C0008.MsgDuplicatePKey();
                    tab2.Focus();
                    tab2.IsSelected = true;
                    tdbg2View.Focus();
                    tdbg2.CurrentColumn = COL2_StageID;
                    HandleRowFocus(tdbg2, tdbg2View, _dtGrid2.Rows.IndexOf(_duplicatePKey.ToArray<DataRow>().Last()));
                    tdbg2View.ShowEditor();
                    return false;
                }
            }
            for (int i = 0; i < tdbg1.VisibleRowCount - 1; i++)
            {
                if (tdbg1.GetCellValue(i, COL1_ProductID).ToString().Trim() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL1_ProductID.Header.ToString());
                    tdbg1.Focus();
                    tdbg1.CurrentColumn = COL1_ProductID;
                    tdbg1.FocusRowHandle(i);
                    return false;
                }
            }
            for (int i = 0; i < tdbg2.VisibleRowCount - 1; i++)
            {
                if (tdbg2.GetCellValue(i, COL2_StageID).ToString().Trim() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL2_StageID.Header.ToString());
                    tdbg2.Focus();
                    tdbg2.CurrentColumn = COL2_StageID;
                    tdbg2.FocusRowHandle(i);
                    return false;
                }
            }
            return true;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Hỏi trước khi lưu
            if (_bAskSave)
            {
                if (L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
                {
                    SetReturnFormView();
                    return;
                }
            }
            else
                _bAskSave = true;
            if (SaveData(sender))
                mnsAdd_Click(null, null);
        }
        private void btnNotSave_Click(object sender, RoutedEventArgs e)
        {
            if (_FormState == EnumFormState.FormAdd && txtGroupProductID.Text == "")
            {
                if (tdbg.VisibleRowCount > 0)
                    LoadEdit();
                goto One;
            }
            if (L3Msg.AskMsgBeforeRowChange())
            {
                _bAskSave = false;
                if (!SaveData(sender))
                    return;
            }
            else
                LoadEdit();
        One:
            SetReturnFormView();
        }
        private void chkShowDisabled_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (_dtGrid == null && _dtGrid.Rows.Count <= 0)
                return;
            ReLoadTDBGrid();
        }
        private void tdbg_RowColChange(object sender, SelectedItemChangedEventArgs e)
        {
            if (tdbgView.FocusedRowHandle < 0)
                return;
            if (tdbg.VisibleRowCount <= 1)
                return;
            if ((COL_GroupProductID.Tag == null || (tdbg.GetFocusedRowCellValue(COL_GroupProductID) != null && tdbg.GetFocusedRowCellValue(COL_GroupProductID).ToString() != COL_GroupProductID.Tag.ToString())) && btnNext.Visibility == Visibility.Hidden)
            {
                tdbg1.FilterString = "";
                tdbg2.FilterString = "";
                LoadEdit();
            }
        }

        #region "tdbg1"
        private int _originRowCount1 = 0;
        private void LoadTDBGrid1(string sGroupProductID = "")
        {
            string sSQL = "SELECT	D2.ProductID,D1.ProductName" + (L3.IsUniCode ? "U" : "") + " As ProductName, D1.ShortName" + (L3.IsUniCode ? "U" : "") + " As ShortName, D1.Note" + (L3.IsUniCode ? "U" : "") + " As Note" + Environment.NewLine;
            sSQL += "FROM D45T1071 D2 INNER JOIN 	D45T1000 D1 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "ON D1.ProductID = D2.ProductID And D2. GroupProductID = " + L3SQLClient.SQLString(sGroupProductID) + " And D1.Disabled = 0" + Environment.NewLine;
            sSQL += "Order By D2.ProductID";
            _dtGrid1 = L3SQLServer.ReturnDataTable(sSQL);
            if(_FormState != EnumFormState.FormAdd)
            {
                if (!_dtGrid1.Columns.Contains("State")) _dtGrid1.Columns.Add("State", Type.GetType("System.String"));
                _dtGrid1.AsEnumerable().ToList().ForEach(f => f["State"] = "1");
            }
            L3DataSource.LoadDataSource(tdbg1, _dtGrid1, L3.IsUniCode);
            _originRowCount1 = _dtGrid1.Rows.Count;
            tdbg1.FooterText(new[] { COL1_ProductID }, new GridColumn[] { }, true);
        }
        private void tdbg1View_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "ProductID":
                    tdbg1.SetFocusedRowCellValue(COL1_ProductName, tdbdProductID.ReturnValue("ProductName"));
                    tdbg1.SetFocusedRowCellValue(COL1_ShortName, tdbdProductID.ReturnValue("ShortName"));
                    tdbg1.SetFocusedRowCellValue(COL1_Note, tdbdProductID.ReturnValue("Note"));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region "tdbg2"
        private int _originRowCount2 = 0;
        private void LoadTDBGrid2(string sGroupProductID = "")
        {
            string sSQL = "SELECT D2.StageID, D1.StageName" + (L3.IsUniCode ? "U" : "") + " As StageName, D1.Note" + (L3.IsUniCode ? "U" : "") + " As Note" + Environment.NewLine;
            sSQL += "FROM D45T1072 D2  INNER JOIN D45T1010 D1 WITH (NOLOCK)" + Environment.NewLine;
            sSQL += "ON D1.StageID = D2.StageID " + Environment.NewLine;
            sSQL += "WHERE D2. GroupProductID = " + L3SQLClient.SQLString(sGroupProductID) + Environment.NewLine;
            sSQL += "Order by D2.StageID" + Environment.NewLine;
            _dtGrid2 = L3SQLServer.ReturnDataTable(sSQL);
            if (_FormState != EnumFormState.FormAdd)
            {
                if (!_dtGrid2.Columns.Contains("State")) _dtGrid2.Columns.Add("State", Type.GetType("System.String"));
                _dtGrid2.AsEnumerable().ToList().ForEach(f => f["State"] = "1");
            }
            L3DataSource.LoadDataSource(tdbg2, _dtGrid2, L3.IsUniCode);
            _originRowCount2 = _dtGrid2.Rows.Count;
            tdbg2.FooterText(new[] { COL2_StageID }, new GridColumn[] { }, true);
        }
        private void tdbg2View_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "StageID":
                    tdbg2.SetFocusedRowCellValue(COL2_StageName, tdbdStageID.ReturnValue("StageName"));
                    tdbg2.SetFocusedRowCellValue(COL2_Note, tdbdStageID.ReturnValue("Note"));
                    break;
                default:
                    break;
            }
        }
        #endregion

        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLInsertD93T0120
        // # Created User: 
        // # Created Date: 21/06/2019 04:39:51
        // #---------------------------------------------------------------------------------------------------
        private StringBuilder SQLInsertD45T1070()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Luu nhom san pham: " + Environment.NewLine);
            sSQL.Append("Insert Into D45T1070 (");
            sSQL.Append("GroupProductID, GroupProductNameU, GroupProductDescU, ");
            sSQL.Append("Disabled, CreateUserID, LastModifyUserID, CreateDate, LastModifyDate");
            sSQL.Append(") Values(" + Environment.NewLine);
            sSQL.Append(L3SQLClient.SQLString(txtGroupProductID.Text) + L3.COMMA); // GroupProductID [KEY], varchar[50], NOT NULL
            sSQL.Append("N" + L3SQLClient.SQLString(txtGroupProductName.Text) + L3.COMMA); // GroupProductNameU, varchar[20], NOT NULL
            sSQL.Append("N" + L3SQLClient.SQLString(txtGroupProductDesc.Text) + L3.COMMA); // GroupProductDescU, nvarchar[1000], NOT NULL
            sSQL.Append(L3SQLClient.SQLNumber(chkDisable.IsChecked ?? false) + L3.COMMA); // Disabled, tinyint, NOT NULL
            sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // CreateUserID, varchar[50], NOT NULL
            sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // LastModifyUserID, varchar[50], NOT NULL
            sSQL.Append("GetDate()" + L3.COMMA); // CreateDate, datetime, NOT NULL
            sSQL.Append("GetDate()"); // LastModifyDate, datetime, NOT NULL
            sSQL.Append(")" + Environment.NewLine);
            return sSQL;
        }
        private StringBuilder SQLInsertD45T1071()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Luu san pham " + Environment.NewLine);
            sSQL.Append("DELETE FROM D45T1071 ");
            sSQL.Append("WHERE GroupProductID = " + L3SQLClient.SQLString(txtGroupProductID.Text) + Environment.NewLine);
            for (int i = 0; i < tdbg1.VisibleRowCount - 1; i++)
            {
                sSQL.Append("INSERT INTO D45T1071(");
                sSQL.Append("GroupProductID, ProductID");
                sSQL.Append(") Values(");
                sSQL.Append(L3SQLClient.SQLString(txtGroupProductID.Text) + L3.COMMA); // GroupProductID [KEY], varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(tdbg1.GetCellValue(i, COL1_ProductID))); // GroupProductID [KEY], varchar[50], NOT NULL
                sSQL.Append(") " + Environment.NewLine);
            }
            return sSQL;
        }
        private StringBuilder SQLInsertD45T1072()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Luu san pham " + Environment.NewLine);
            sSQL.Append("DELETE FROM D45T1072 ");
            sSQL.Append("WHERE GroupProductID = " + L3SQLClient.SQLString(txtGroupProductID.Text) + Environment.NewLine);
            for (int i = 0; i < tdbg2.VisibleRowCount - 1; i++)
            {
                sSQL.Append("INSERT INTO D45T1072(");
                sSQL.Append("GroupProductID, StageID, CreateUserID, CreateDate");
                sSQL.Append(") Values(");
                sSQL.Append(L3SQLClient.SQLString(txtGroupProductID.Text) + L3.COMMA); // GroupProductID [KEY], varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(tdbg2.GetCellValue(i, COL2_StageID)) + L3.COMMA); // StageID [KEY], varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // CreateUserID , varchar[50], NOT NULL
                sSQL.Append("GetDate()"); // CreateDate, datetime, NOT NULL
                sSQL.Append(") " + Environment.NewLine);
            }
            return sSQL;
        }
        private string SQLDeleteD45T1072()
        {
            string sSQL = "";
            sSQL += ("-- Xoa du lieu " + Environment.NewLine);
            sSQL += "Delete From D45T1072 ";
            sSQL += "Where GroupProductID = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_GroupProductID)) + Environment.NewLine;

            sSQL += "Delete From D45T1071 ";
            sSQL += "Where GroupProductID = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_GroupProductID)) + Environment.NewLine;

            sSQL += "Delete From D45T1070 ";
            sSQL += "Where GroupProductID = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_GroupProductID)) + Environment.NewLine;

            return sSQL;
        }
        private StringBuilder SQLUpdateD45T1070()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("--	Cap nhat nhom san pham: " + Environment.NewLine);
            sSQL.Append("Update D45T1070 Set ");
            sSQL.Append("GroupProductNameU = " + "N" + L3SQLClient.SQLString(txtGroupProductName.Text) + L3.COMMA); //GroupProductNameU varchar[20], NOT NULL
            sSQL.Append("GroupProductDescU = " + "N" + L3SQLClient.SQLString(txtGroupProductDesc.Text) + L3.COMMA); //GroupProductDescU varchar[20], NOT NULL
            sSQL.Append("Disabled = " + L3SQLClient.SQLNumber(chkDisable.IsChecked ?? false) + L3.COMMA); //Disabled tinyint, NOT NULL
            sSQL.Append("LastModifyUserID = " + L3SQLClient.SQLString(L3.UserID) + L3.COMMA); //LastModifyUserID varchar[50], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()"); //LastModifyDate, datetime, NOT NULL
            sSQL.Append(" Where GroupProductID = " + L3SQLClient.SQLString(txtGroupProductID.Text));
            return sSQL;
        }
        private void mnsExportExcel_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            try
            {
                DataTable dtCaption = Lemon3.Documents.Excel.L3ExportExcel.CreateTableForExcelOnly(tdbg);
                L3CallDLL oCallDLL = new L3CallDLL();

                Lemon3.IO.StructureProperties[] arrPro = null;
                oCallDLL.SetProperties(ref arrPro, "UseUnicode", L3.IsUniCode);
                oCallDLL.SetProperties(ref arrPro, "FormID", this.GetType().Name);
                oCallDLL.SetProperties(ref arrPro, "dtLoadGrid", dtCaption);
                oCallDLL.SetProperties(ref arrPro, "dtExportTable", _dtGrid);
                oCallDLL.CallFormShowDialog("D99D0341", "D99F2222", arrPro);
            }
            catch (Exception ex)
            {
                D99D0041.D99C0008.MsgL3("Có lỗi trong quá trình xuất Excel: " + ex.Message);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void mnsExportToExcel1_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            try
            {
                DataTable dtCaption = Lemon3.Documents.Excel.L3ExportExcel.CreateTableForExcelOnly(tdbg1);
                L3CallDLL oCallDLL = new L3CallDLL();

                Lemon3.IO.StructureProperties[] arrPro = null;
                oCallDLL.SetProperties(ref arrPro, "UseUnicode", L3.IsUniCode);
                oCallDLL.SetProperties(ref arrPro, "FormID", this.GetType().Name);
                oCallDLL.SetProperties(ref arrPro, "dtLoadGrid", dtCaption);
                oCallDLL.SetProperties(ref arrPro, "dtExportTable", _dtGrid1);
                oCallDLL.CallFormShowDialog("D99D0341", "D99F2222", arrPro);
            }
            catch (Exception ex)
            {
                D99D0041.D99C0008.MsgL3("Có lỗi trong quá trình xuất Excel: " + ex.Message);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void mnsImportData1_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            if (D99D0241.D99X0020.CallShowDialogD80F2090("D45", "D45F5604", "D45F1070"))
            {
                string sSQL = "SELECT " + (L3.IsUniCode == true ? "GroupProductNameU" : "GroupProductName") + " As GroupProductName , " + (L3.IsUniCode == true ? "GroupProductDescU" : "GroupProductDesc") + " As GroupProductDesc , D45.* " + Environment.NewLine;
                sSQL += "FROM D45T1070 D45 WITH (NOLOCK) ORDER BY D45.GroupProductID ";
                _dtGrid = L3SQLServer.ReturnDataTable(sSQL);
                L3DataSource.LoadDataSource(tdbg, _dtGrid, L3.IsUniCode);
                ReLoadTDBGrid();
                if (!tdbgView.IsFocused)
                    tdbgView.Focus();
            }
            this.Cursor = Cursors.Arrow;
        }
        private void mnsExportToExcel2_Click(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            try
            {
                DataTable dtCaption = Lemon3.Documents.Excel.L3ExportExcel.CreateTableForExcelOnly(tdbg2);
                L3CallDLL oCallDLL = new L3CallDLL();

                Lemon3.IO.StructureProperties[] arrPro = null;
                oCallDLL.SetProperties(ref arrPro, "UseUnicode", L3.IsUniCode);
                oCallDLL.SetProperties(ref arrPro, "FormID", this.GetType().Name);
                oCallDLL.SetProperties(ref arrPro, "dtLoadGrid", dtCaption);
                oCallDLL.SetProperties(ref arrPro, "dtExportTable", _dtGrid2);
                oCallDLL.CallFormShowDialog("D99D0341", "D99F2222", arrPro);
            }
            catch (Exception ex)
            {
                D99D0041.D99C0008.MsgL3("Có lỗi trong quá trình xuất Excel: " + ex.Message);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void tsbImportData2_Click(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            if (D99D0241.D99X0020.CallShowDialogD80F2090("D45", "D45F5604", "D45F1070"))
            {
                string sSQL = "SELECT " + (L3.IsUniCode == true ? "GroupProductNameU" : "GroupProductName") + " As GroupProductName , " + (L3.IsUniCode == true ? "GroupProductDescU" : "GroupProductDesc") + " As GroupProductDesc , D45.* " + Environment.NewLine;
                sSQL += "FROM D45T1070 D45 WITH (NOLOCK) ORDER BY D45.GroupProductID ";
                _dtGrid = L3SQLServer.ReturnDataTable(sSQL);
                L3DataSource.LoadDataSource(tdbg, _dtGrid, L3.IsUniCode);
                ReLoadTDBGrid();
                if (!tdbgView.IsFocused)
                    tdbgView.Focus();
            }
            this.Cursor = Cursors.Arrow;
        }
        private void tdbg1View_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (_FormState == EnumFormState.FormEdit && !_bEdit)
            {
                if (e.Column == COL1_ProductID)
                {
                    e.Cancel = (tdbg1View.FocusedRowHandle <= _originRowCount1 - 1) && tdbg1View.FocusedRowHandle >= 0;
                }
                else
                {
                    e.Cancel = !((e.Column as GridColumn).AllowEditing == DevExpress.Utils.DefaultBoolean.Default || (e.Column as GridColumn).AllowEditing == DevExpress.Utils.DefaultBoolean.True ? true : false);

                }
            }
        }
        private void tdbg1View_ValidateCell(object sender, GridCellValidationEventArgs e)
        {
            TableView view = sender as TableView;
            TextEdit edit = view.ActiveEditor as TextEdit;
            if (edit.Text == "") return;
            switch (e.Column.FieldName)
            {
                case "ProductID":
                    int duplicate = _dtGrid1.AsEnumerable().Where(w => w["ProductID"].ToString() == edit.Text).Count();
                    if (duplicate > 0)
                    {
                        D99D0041.D99C0008.MsgDuplicatePKey();
                        tdbg1.SetFocusedRowCellValue(COL1_ProductName, "");
                        e.IsValid = false;
                    }
                    else
                        tdbg1.SetFocusedRowCellValue(COL1_ProductName, tdbdProductID.ReturnValue("ProductName"));
                    break;
                default:
                    break;
            }
        }
        private void L3Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (tdbg1View.IsKeyboardFocusWithin && e.Key == Key.Delete && _FormState == EnumFormState.FormEdit && tdbg1View.FocusedRowHandle < _originRowCount1)
            {
                e.Handled = true;
                tdbg1View.CancelRowEdit();
                return;
            }
            if (tdbg2View.IsKeyboardFocusWithin && e.Key == Key.Delete && _FormState == EnumFormState.FormEdit && tdbg2View.FocusedRowHandle < _originRowCount2)
            {
                e.Handled = true;
                tdbg2View.CancelRowEdit();
                return;
            }
        }
        private void tdbg2View_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (_FormState == EnumFormState.FormEdit && !_bEdit)
            {
                if (e.Column == COL2_StageID)
                {
                    e.Cancel = (tdbg2View.FocusedRowHandle <= _originRowCount2 - 1) && tdbg2View.FocusedRowHandle >= 0;
                }
                else
                {
                    e.Cancel = !((e.Column as GridColumn).AllowEditing == DevExpress.Utils.DefaultBoolean.Default || (e.Column as GridColumn).AllowEditing == DevExpress.Utils.DefaultBoolean.True ? true : false);
                }
            }
        }
        private void tdbg2View_ValidateCell(object sender, GridCellValidationEventArgs e)
        {
            TableView view = sender as TableView;
            TextEdit edit = view.ActiveEditor as TextEdit;
            if (edit.Text == "") return;
            switch (e.Column.FieldName)
            {
                case "StageID":
                    int duplicate = _dtGrid2.AsEnumerable().Where(w => w["StageID"].ToString() == edit.Text).Count();
                    if (duplicate > 0)
                    {
                        D99D0041.D99C0008.MsgDuplicatePKey();
                        tdbg2.SetFocusedRowCellValue(COL2_StageID, "");
                        e.IsValid = false;
                    }
                    else
                        tdbg2.SetFocusedRowCellValue(COL2_StageID, tdbdProductID.ReturnValue("StageID"));
                    break;
                default:
                    break;
            }
        }
    }
}
