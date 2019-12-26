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
using System.Collections.Generic;
using System.Linq;

//using Lemon3.IO;
//using Lemon3.Reports;
//using Lemon3.Resources;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

using Lemon3.Messages;
using System.Windows.Controls;
using DevExpress.Xpf.Core.ConditionalFormatting;
using System.Windows.Media;
using Lemon3.Resources;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors;
//using System.Windows.Data;
//using DevExpress.Xpf.Core.Native;
//using System.Collections.ObjectModel;
//using DevExpress.Mvvm;
//using L3CallDLL = Lemon3.IO.L3CallDLL;
//using L3UniCode = Lemon3.UniCode.L3UniCode;

namespace D45D0180
{
    /// <summary>
    /// Interaction logic for D45F1022.xaml
    /// </summary>
    public partial class D45F1022 : L3Page
    {

        private string test = "a string";
        public string Test
        {
            get { return tdbgD.GetFocusedRowCellValue (COLD_Stage).ToString(); }
            set { test = value; }
        }
        public D45F1022()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public override void SetContentForL3Page()
        {

        }
        DataTable _dtGridM = null;
        DataTable _dtGridD = null;
        DataTable _dtBandColumn = null;

        private bool _bAskSave = true;
        private EnumFormState _FormState = EnumFormState.FormView;
        private void L3Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            L3Format.LoadCustomFormat();
            tdbgD.LockCoumns(true, COLD_OrderNo);
            COLD_OrderNo.AllowAutoFilter = false;
            txtPriceListID.CheckIdTextBox();
            tdbgM.InputDate(COLM_ValidTo, COLM_ValidFrom);
            //tdbgD.LockCell("true", new GridColumn[] { COLD_OrderNo, COLD_ProductID, COLD_ProductName });
            LoadLanguage();
            LoadTDBCombo();
            LoadTDBDropDown();
            SetBackColorObligatory();
            LoadTDBGridM();
            tdbgM.Focus();
            LoadEdit(); // fist load
            txtPriceListID.CheckIdTextBox();
            L3Control.SetShortcutPopupMenu(MainMenuControl, tdbgPopupMenu);
            L3Control.SetShortcutPopupMenu(tdbgDPopupMenu);
            SetShortcutPopupMenuOther();
            Lockcontrol(false);
            tdbgM.SetDefaultGridControlInquiry();

            if (!this.IsFocused) tdbgM.Focus();
            this.Cursor = Cursors.Arrow;
        }
        private void SetBackColorObligatory()
        {
            L3Control.SetBackColorObligatory(txtPriceListID, txtPriceListName, dateValidFrom, (tdbcBlockID.Tag.ToString() == "O") ? tdbcBlockID : new Control(), tdbcGroupProductID);
        }
        private void SetShortcutPopupMenuOther()
        {
            mnsExportToExcelDetail.BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
            mnsExportToExcelDetail.Content = L3Resource.ConvertStringHotkeyToWPF(L3Resource.rL3("Xuat__Excel"));
            mnsExportToExcelDetail.KeyGesture = new KeyGesture(Key.X, ModifierKeys.Control);
        }
        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Danh_muc_bang_gia_theo_cong_doan") + " - D45F1022";
            if (this.Parent != null) ((L3Window)this.Parent).Title = L3Resource.rL3("Danh_muc_bang_gia_theo_cong_doan") + " - D45F1022";
            lblPriceListID.Content = L3Resource.rL3("Ma_bang_gia");
            chkDisabled.Content = L3Resource.rL3("Khong_su_dung");
            lblPriceListName.Content = L3Resource.rL3("Dien_giai");
            lblValid.Content = L3Resource.rL3("Hieu_luc");
            lblBlockID.Content = L3Resource.rL3("Khoi");
            lblNote.Content = L3Resource.rL3("Ghi_chu");
            lblGroupProductID.Content = L3Resource.rL3("Nhom_san_pham");
            tab1.Header = L3Resource.rL3("Chi_tiet");

            tdbcBlockID.SetCaptionColumn("BlockID", L3Resource.rL3("Ma")); // Mã
            tdbcBlockID.SetCaptionColumn("BlockName", L3Resource.rL3("Ten")); // Tên
            tdbcGroupProductID.SetCaptionColumn("GroupProductID", L3Resource.rL3("Ma")); // Mã
            tdbcGroupProductID.SetCaptionColumn("GroupProductName", L3Resource.rL3("Ten")); // Tên

            COLM_PriceListID.Header = L3Resource.rL3("Ma_bang_gia");
            COLM_PriceListName.Header = L3Resource.rL3("Dien_giai");
            COLM_ValidFrom.Header = L3Resource.rL3("Hieu_luc_tu");
            COLM_ValidTo.Header = L3Resource.rL3("Hieu_luc_den");
            COLM_Disabled.Header = L3Resource.rL3("KSD");

            COLD_OrderNo.Header = L3Resource.rL3("STT");
            COLD_ProductID.Header = L3Resource.rL3("Ma_san_pham");
            COLD_ProductName.Header = L3Resource.rL3("Ten_san_pham");

            chkShowDisabled.Content = L3Resource.rL3("Hien_thi_danh_muc_khong_su_dung");
            //btnExportToExcel.Content = L3Resource.rL3("Xuat_Excel");
            btnSave.Content = L3Resource.rL3("Luu");
            btnNotSave.Content = L3Resource.rL3("Khong_luu");
            mnsExportToExcel.Content = L3Resource.rL3("Xuat_Excel");
            mnsExportToExcelDetail.Content = L3Resource.rL3("Xuat_Excel");
            mnsImportData.Content = L3Resource.rL3("Import_du_lieu");
            btnNext.Content = L3Resource.rL3("Luu_va_nhap_tiep"); //

        }
        private void LoadTDBCombo()
        {
            //cbo khối
            L3DataSource.LoadDataSource(tdbcBlockID, SQLStoreD09P6868());
            tdbcBlockID.Tag = L3SQLServer.ReturnDataTable(SQLStoreD91P0066()).Rows[0]["ValidMode"];

            //cbo nhóm sản phẩm
            string sSQL = "";
            sSQL += " SELECT T1.GroupProductID,T1.GroupProductNameU AS GroupProductName " + Environment.NewLine;
            sSQL += "FROM D45T1070 T1 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "INNER JOIN D45T1071 T2 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "ON T1.GroupProductID = T2.GroupProductID" + Environment.NewLine;
            sSQL += "INNER JOIN D45T1072 T3 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "ON T1.GroupProductID = T3.GroupProductID" + Environment.NewLine;
            sSQL += "WHERE Disabled = 0" + Environment.NewLine;
            sSQL += "GROUP BY T1.GroupProductID, T1.GroupProductNameU";
            L3DataSource.LoadDataSource(tdbcGroupProductID, sSQL);
        }
        private void LoadTDBDropDown()
        {
            LoadtdbdProductID();
        }
        private void LoadtdbdProductID(string GroupProductID = "")
        {
            string sSQL = "";
            sSQL += "SELECT T1.ProductID, T3."+ (L3.IsUniCode == true? "ProductNameU" : "ProductName") + " AS ProductName " + Environment.NewLine; 
            sSQL += "FROM D45T1071 T1 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "INNER JOIN D45T1070 T2 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "ON T1.GroupProductID = T2.GroupProductID" + Environment.NewLine;
            sSQL += "INNER JOIN D45T1000 T3 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "ON T1.ProductID = T3.ProductID" + Environment.NewLine;
            sSQL += "WHERE T2.Disabled = 0 AND T1.GroupProductID = " + L3SQLClient.SQLString(GroupProductID);
            L3DataSource.LoadDataSource(tdbdProductID, sSQL);
        }
        private void LoadTDBGridM(bool FlagAdd = false, string sKey = "")
        {

            _dtGridM = L3SQLServer.ReturnDataTable(SQLStoreD45P1021());
            L3DataSource.LoadDataSource(tdbgM, _dtGridM, L3.IsUniCode);
            ReLoadTDBGridM();
            if (sKey != "")
            {
                DataTable dt1 = _dtGridM.DefaultView.ToTable();
                DataRow[] dr = dt1.Select(COLM_PriceListID.FieldName + " = " + L3SQLClient.SQLString(sKey), dt1.DefaultView.Sort);
                if (dr.Length > 0)
                {
                    HandleRowFocus(tdbgM, tdbgMView, tdbgM.GetRowHandleByListIndex(dt1.Rows.IndexOf(dr[0])));
                }
            }
        }
        private void ReLoadTDBGridM(bool bLoadEdit = true)
        {
            string strFind = "";
            if (!chkShowDisabled.IsChecked ?? false)
            {
                if (strFind != "")
                    strFind += " And ";
                strFind += "Disabled = 0";
            }
            _dtGridM.DefaultView.RowFilter = strFind;
            ResetGrid();
            if (_FormState == EnumFormState.FormAdd)
                return;

            if (tdbgM.VisibleRowCount == 0)
            {
                ClearText();
                if (_dtGridD != null)
                    _dtGridD.Clear();
                if (tdbgD.Bands.Count > 1)
                {
                    for (int b = 1; b < tdbgD.Bands.Count; b++)
                    {
                        tdbgD.Bands.RemoveAt(b);
                    }
                }
                tdbgD.ItemsSource = null;
            }
            else
            {
                _FormState = EnumFormState.FormView;
            }
        }
        private void ClearText()
        {

            txtPriceListID.EditValue = "";
            txtPriceListName.EditValue = "";
            chkDisabled.IsChecked = false;
            dateValidFrom.EditValue = "";
            dateValidTo.EditValue = "";
            tdbcBlockID.EditValue = "";
            tdbcGroupProductID.Text = "";
            txtNote.EditValue = "";

            txtPriceListID.Focus();
            if (_dtGridD != null)
                _dtGridD.Clear();
            if (tdbgD.Bands.Count > 1)
            {
                for (int b = 1; b < tdbgD.Bands.Count; b++)
                {
                    tdbgD.Bands.RemoveAt(b);
                }
            }
            tdbgD.ItemsSource = null;
        }
        private void ResetGrid()
        {
            EnableMenu(false);
            tdbgM.FooterText(new[] { COLM_PriceListID }, new GridColumn[] { }, true);
        }
        private void EnableMenu(bool bEnabled)
        {
            if (_dtGridM == null)
                return;
            btnSave.IsEnabled = bEnabled;
            btnNext.IsEnabled = bEnabled;
            btnNotSave.IsEnabled = bEnabled;
            chkShowDisabled.IsEnabled = !bEnabled;
            tdbgM.IsEnabled = !bEnabled;
            if (_FormState == EnumFormState.FormAdd)
            {
                btnNext.Visibility = Visibility.Visible;
                btnNext.Width = 140;
                chkDisabled.IsEnabled = false;
            }
            else
            {
                btnNext.Visibility = Visibility.Hidden;
                btnNext.Width = 0;
                chkDisabled.IsEnabled = true;
            }
            if (btnNext.Visibility == Visibility.Visible & btnNext.IsEnabled)
            { }
            else
            { }
            if (bEnabled)
                L3Control.CheckMenu("-1", MainMenuControl, tdbgPopupMenu, tdbgM.ReturnVisibleRowCount, true, false);
            else
                L3Control.CheckMenu("D45F1022", MainMenuControl, tdbgPopupMenu, tdbgM.ReturnVisibleRowCount, true, false);
        }
        private void HandleRowFocus(L3GridControl tdbg, GridViewBase tdbgView, int indexRowFocus)
        {
            tdbgMView.FocusedRowHandle = indexRowFocus;
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tdbgMView.FocusedRowHandle = indexRowFocus;
                tdbgView.MoveFocusedRow(indexRowFocus);
                tdbg.FocusRowHandle(indexRowFocus);
            }), DispatcherPriority.Render);
        }
        private void LoadEdit()
        {
            if (tdbgM.VisibleRowCount <= 0)
                return;
            if (tdbgMView.FocusedRowHandle < 0)
                tdbgMView.FocusedRowHandle = 0;
            this.Cursor = Cursors.Wait;
            string sSQL = "-- Do nguon cho master" + Environment.NewLine;
            sSQL += "SELECT PriceListID, PriceListNameU as PriceListName, NoteU as Note, Disabled, ValidFrom, ValidTo, BlockID, GroupProductID " + Environment.NewLine;
            sSQL += "FROM      D45T1020 WITH(NOLOCK)" + Environment.NewLine;
            sSQL += "WHERE PriceListID = " + L3SQLClient.SQLString(tdbgM.GetFocusedRowCellValue(COLM_PriceListID));
            DataTable _dtM = L3SQLServer.ReturnDataTable(sSQL);
            if (_dtM == null || _dtM.Rows.Count < 1)
                return;
            txtPriceListID.Text = _dtM.Rows[0].Field<string>("PriceListID");
            chkDisabled.IsChecked = L3ConvertType.L3Bool(_dtM.Rows[0]["Disabled"].ToString());
            txtPriceListName.Text = _dtM.Rows[0]["PriceListName"].ToString();
            dateValidFrom.EditValue = _dtM.Rows[0]["ValidFrom"];
            dateValidTo.EditValue = _dtM.Rows[0]["ValidTo"];
            tdbcBlockID.EditValue = _dtM.Rows[0]["BlockID"].ToString();
            tdbcGroupProductID.Tag = _dtM.Rows[0]["GroupProductID"].ToString();
            tdbcGroupProductID.EditValue = _dtM.Rows[0]["GroupProductID"].ToString();
            txtNote.Text = _dtM.Rows[0]["Note"].ToString();
            Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtPriceListID);
            LoadtdbdProductID(tdbcGroupProductID.EditValue.ToString());
            LoadTDBGridD();

            this.Cursor = Cursors.Arrow;
        }
        private void SetReturnFormView()
        {
            _FormState = EnumFormState.FormView;
           // Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(false, txtPriceListID, dateValidFrom, dateValidTo, tdbcBlockID, tdbcGroupProductID, tdbgD);
            dateValidTo.Background = Brushes.White;
            SetBackColorObligatory();
            EnableMenu(false);
            if (tdbgM.VisibleRowCount == 0)
                Lemon3.Controls.DevExp.L3Control.ClearText(grpMaster);
            Lockcontrol(false);
        }
        private void Lockcontrol(bool bLocked)
        {
            tdbgDView.AllowEditing = bLocked;
            txtPriceListName.IsReadOnly = !bLocked;
            dateValidFrom.IsReadOnly = !bLocked;
            dateValidTo.IsReadOnly = !bLocked;
            tdbcBlockID.IsReadOnly = !bLocked;
            if (_FormState == EnumFormState.FormEdit)
                tdbcGroupProductID.IsReadOnly = !_bEdit;
            else
                tdbcGroupProductID.IsReadOnly = !bLocked;
            txtNote.IsReadOnly = !bLocked;
            chkDisabled.IsReadOnly = !bLocked;
            txtPriceListID.IsReadOnly = (_FormState != EnumFormState.FormAdd);
        }
        private bool SaveData(System.Object sender)
        {
            if (!AllowSave())
                return false;
            this.Cursor = Cursors.Wait;
            StringBuilder sSQL = new StringBuilder();
            bool bRunSQL = false;
            Lemon3.Data.L3SQLBulkCopy oBulkCopy = new L3SQLBulkCopy();
            switch (_FormState)
            {
                case EnumFormState.FormAdd:
                    {
                        string sSQLCheck = "--- Kiem tra trung ma bang gia" + Environment.NewLine +
                                       "SELECT 	Top 1 1 " + Environment.NewLine +
                                       "FROM D45T1020 WITH(NOLOCK)" + Environment.NewLine +
                                       "WHERE PriceListID = " + L3SQLClient.SQLString(txtPriceListID.Text);
                        if (L3ConvertType.L3Bool(L3SQLServer.ReturnScalar(sSQLCheck)))
                        {
                            D99D0041.D99C0008.MsgDuplicatePKey();
                            break;
                        }

                        oBulkCopy.AddSQLBeforce(SQLInsertD45T1020().ToString());
                        oBulkCopy.AddSQLAfter(SQLStoreD45P1022("Save"));
                        bRunSQL = oBulkCopy.SaveBulkCopy(_dtGridD, "#D45P1022_" + L3.UserID);
                        break;
                    }
                case EnumFormState.FormEdit:
                    {
                        oBulkCopy.AddSQLBeforce(SQLUpdateD45T1020().ToString());
                        oBulkCopy.AddSQLAfter(SQLStoreD45P1022("Save"));
                        bRunSQL = oBulkCopy.SaveBulkCopy(_dtGridD, "#D45P1022_" + L3.UserID);
                        break;
                    }
            }
            this.Cursor = Cursors.Arrow;
            if (bRunSQL)
            {
                L3Msg.SaveOK();
                switch (_FormState)
                {
                    case EnumFormState.FormAdd:
                        {
                            LoadTDBGridM(true, txtPriceListID.Text);
                            _FormState = EnumFormState.FormView;
                            LoadTDBGridD();
                            break;
                        }

                    case EnumFormState.FormEdit:
                        {
                            LoadTDBGridM(sKey: txtPriceListID.Text);
                            L3AuditLog.RunAuditLog("45", "PriceLists", "02", txtPriceListID.Text, txtPriceListName.Text, dateValidFrom.EditValue.ToString(), DateTime.Now.ToShortDateString(), "");
                            LoadEdit();
                            break;
                        }
                }
                Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtPriceListID);
                SetReturnFormView();
            }
            else
            {
                L3Msg.SaveNotOK();
                return false;
            }
            return true;
        }
        private bool AllowSave()
        {
            if (txtPriceListID.Text.Trim() == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblPriceListID.Content.ToString());
                txtPriceListID.Focus();
                return false;
            }
            if (txtPriceListName.Text.Trim() == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblPriceListName.Content.ToString());
                txtPriceListName.Focus();
                return false;
            }
            if (dateValidFrom.EditValue.ToString() == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter("Hiệu lực từ");
                dateValidFrom.Focus();
                return false;
            }
            if (dateValidFrom.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetChoose(Lemon3.Resources.L3Resource.rL3("Ngay"));
                dateValidFrom.Focus();
                return false;
            }
            if (dateValidTo.Text != "" && Convert.ToDateTime((dateValidFrom.EditValue)) > Convert.ToDateTime((dateValidTo.EditValue)))
            {
                D99D0041.D99C0008.MsgNotYetChoose(Lemon3.Resources.L3Resource.rL3("MSG000013"));
                dateValidFrom.Focus();
                return false;
            }

            if (tdbcBlockID.Text == "" && tdbcBlockID.Tag != null && tdbcBlockID.Tag.ToString() != "C")
            {
                if (tdbcBlockID.Tag.ToString() == "O")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(lblBlockID.Content.ToString());
                    tdbcBlockID.Focus();
                    return false;
                }
                if (tdbcBlockID.Tag.ToString() == "W")
                {
                    if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Ban_chua_nhap") + new string(' ', 1) + lblBlockID.Content + new string(' ', 1) + L3Resource.rL3("Ban_co_muon_nhap_khong")) == System.Windows.Forms.DialogResult.Yes)
                    {
                        tdbcBlockID.Focus();
                        return false;
                    }
                }
            }
            if (tdbcGroupProductID.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblGroupProductID.Content.ToString());
                tdbcGroupProductID.Focus();
                return false;
            }

            for (int i = 0; i < tdbgD.VisibleRowCount - 1; i++)
            {
                if (tdbgD.GetCellValue(i, COLD_ProductID).ToString().Trim() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COLD_ProductID.Header.ToString());
                    tdbgD.Focus();
                    tdbgD.CurrentColumn = COLD_ProductID;
                    tdbgD.FocusRowHandle(i);
                    return false;
                }
            }
            return true;
        }

        #region "load cot dong - do nguon luoi"

        private L3CreateColumnsForGridControl oL3CreateColumns;
        private int _originRowCount = 0;
        private void LoadTDBGridD()
        {
            if (tdbgD.Bands.Count > 1)
            {
                for (int b = 1; b < tdbgD.Bands.Count; b++)
                {
                    tdbgD.Bands.RemoveAt(b);
                }
            }
            tdbgD.ItemsSource = null;
            DataSet ds = L3SQLServer.ReturnDataSet(SQLStoreD45P1022("Load"));
            _dtBandColumn = ds.Tables[0];
            _dtGridD = ds.Tables[1];
            if (!_dtGridD.Columns.Contains(COLD_OrderNo.FieldName))
                _dtGridD.Columns.Add(COLD_OrderNo.FieldName, typeof(System.String));
            if (oL3CreateColumns == null) oL3CreateColumns = new L3CreateColumnsForGridControl();
            oL3CreateColumns.CreateColumns(tdbgD, _dtBandColumn);
            foreach (GridControlBand band in tdbgD.Bands)
            {
                if (band.Header.ToString() == "") band.OverlayHeaderByChildren = true;
                else
                {
                    BandHeaderBold(band);
                }
            }
            if (_FormState != EnumFormState.FormAdd)
            {
                if (!_dtGridD.Columns.Contains("Stage"))
                { _dtGridD.Columns.Add("Stage", Type.GetType("System.String")); }
                foreach (DataRow dr in _dtGridD.Rows)
                    dr["Stage"] = "1";
            }

            //var test = new ObservableCollection<Test>();
            //foreach (DataRow row in _dtGridD.Rows)
            //{
            //    var obj = new Test()
            //    {
            //        OrderNo = (string)(row["OrderNo"] == System.DBNull.Value ? "": row["OrderNo"]),
            //        ProductName = (string)row["ProductName"],
            //        PriceListID = (string)row["PriceListID"],
            //        ProductID = (string)row["ProductID"]
            //    };
            //    test.Add(obj);
            //}
            //Binding bin = new Binding("_dtGridD")
            //{
            //    Source = test
            //};
            //tdbgD.SetBinding(BaseEdit.EditValueProperty, bin);

            L3DataSource.LoadDataSource(tdbgD, _dtGridD);
            _originRowCount = _dtGridD.Rows.Count;

            //if (!FunctionF12.IsHasBandName(tdbgD.Bands))
            //{
            //    btnF12.IsEnabled = false;
            //}
            //else
            //{
            //    FunctionF12.RestoreLayoutFromXml(this.GetType().Name, tdbg);
            //}
            // Set column visible
            List<string> columnsEnable = _dtBandColumn.AsEnumerable().Select(r => r.Field<string>("CaptionID")).ToList();
            List<GridColumn> _dynamicColumns = tdbgD.Columns.AsEnumerable().Where(r => r.ParentBand != null && r.ParentBand.VisibleIndex != 0).ToList();

            foreach (GridColumn col in _dynamicColumns)
            {
                if (!columnsEnable.Contains(col.FieldName)) col.Visible = false;
                else
                {
                    ColumnHeaderBold(col);
                }
            }
            // Set style
            SetStyle();
            SetHideBandColumnHide();
            ResetGridD();
        }
     
        private void ResetGridD()
        {
            tdbgD.FooterText(new[] { COLD_PriceListID }, new GridColumn[] { }, true);
            D45X0002.UpdateTDBGOrderNum(tdbgD, tdbgD.Columns.IndexOf(COLD_OrderNo), bUseFilterBar: true);
            //UpdateTDBGOrderNum(tdbg, tdbg.Columns.IndexOf(COL_OrderNum), bUseFilterBar: true);
        }
        private void BandHeaderBold(GridControlBand band)
        {
            DataTemplate dataTemplate = new DataTemplate();
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            textBlockFactory.SetValue(TextBlock.TextProperty, band.Header);
            textBlockFactory.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            textBlockFactory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);

            dataTemplate.VisualTree = textBlockFactory;
            band.HeaderTemplate = dataTemplate;
        }
        private void ColumnHeaderBold(GridColumn col)
        {
            DataTemplate dataTemplate = new DataTemplate();
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            textBlockFactory.SetValue(TextBlock.TextProperty, col.Header);
            textBlockFactory.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            textBlockFactory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);

            dataTemplate.VisualTree = textBlockFactory;
            col.HeaderTemplate = dataTemplate;
        }

        private const string _ColumnStyle = "StyleExcel";
        List<FormatConditionBase> _FormatConditionCollection = null;
        private void SetStyle()
        {
            var OrderNoFormatCondition = new FormatCondition()
            {
                Expression = "Contains([Style], 'B')",
                //FieldName = null,
                Format = new Format()
                {
                    FontWeight = FontWeights.Bold
                },
                IsEnabled = true,
                Fixed = true
            };
            tdbgDView.FormatConditions.Add(OrderNoFormatCondition);

            if (_FormatConditionCollection == null)
            {
                _FormatConditionCollection = tdbgDView.FormatConditions.ToList();
            }

            if (tdbgDView.FormatConditions.Count != _FormatConditionCollection.Count)
            {
                tdbgDView.FormatConditions.Clear();
                foreach (var formarCon in _FormatConditionCollection)
                {
                    tdbgDView.FormatConditions.Add(formarCon);
                }
            }

            if (_dtGridD.Columns.Contains(_ColumnStyle))
            {
                var allStyle = _dtGridD.AsEnumerable()
                     .Where(w => w[_ColumnStyle] is string)
                     .GroupBy(gb => gb[_ColumnStyle])
                     .Select(s => s.Key).ToList();
                allStyle.RemoveAll(rm => L3ConvertType.L3String(rm) == "");

                if (allStyle.Count == 0) return;
                Style styleRowControl = new Style();
                styleRowControl.TargetType = typeof(RowControl);

                foreach (var cellStyleValue in allStyle)
                {
                    string sCellStyleValue = cellStyleValue.ToString();
                    string[] saStyleSplit = sCellStyleValue.Split(';');

                    foreach (string sStyle in saStyleSplit)
                    {
                        //bool bIsHasFormatColumn = false;
                        //if (sStyle.Replace(" ", "").IndexOf('(') > 0)
                        //    bIsHasFormatColumn = true;
                        //if (bIsHasFormatColumn)
                        //    lsColStyle.Add(sStyle);
                        //else
                        FormatRow(tdbgD, tdbgDView, sStyle, sCellStyleValue, styleRowControl); // Đổ style row trước
                    }
                }

            }

        }
        private void SetHideBandColumnHide()
        {
            try
            {
                List<string> _lsColumnsHide = tdbgD.Columns.Where(w => !w.Visible).Select(s => s.FieldName).ToList();
                foreach (string fieldName in _lsColumnsHide) // Ẩn column
                {
                    GridColumn column = tdbgD.Columns.GetColumnByFieldName(fieldName);
                    if (column != null)
                    {
                        if (column.ParentBand != null)
                        {
                            GridControlBand parentBand = column.ParentBand as GridControlBand;
                            if (parentBand.Columns.Count == 1)
                            {
                                SetBandHide(parentBand); // Ẩn band
                            }
                        }

                    }
                }
            }
            catch { }
        }
        private void FormatRow(L3GridControl tdbg, TableView tableView, string sStyle, string sCellStyleValue, Style styleRowControl)
        {
            string sCell = sStyle.Replace(" ", "").Replace("(", "").Replace(")", "");
            string[] sCellSplit = sCell.Split(',');


            if (sCellSplit[0].Contains("B"))
            {
                var formatCondition = new FormatCondition()
                {
                    Expression = String.Format("{0} = '{1}'", _ColumnStyle, sCellStyleValue),
                    Format = new Format() { FontWeight = FontWeights.Bold },
                    IsEnabled = true,
                    Fixed = true,
                };
                tdbgDView.FormatConditions.Add(formatCondition);

            }

            if (sCellSplit.Length >= 2)
            {
                if (sCellSplit[1] != "") // màu chữ
                {
                    var formatCondition = new FormatCondition()
                    {
                        Expression = String.Format("{0} = '{1}'", _ColumnStyle, sCellStyleValue),
                        Format = new Format() { Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(sCellSplit[1]) },
                        IsEnabled = true,
                        Fixed = true,
                    };
                    tdbgDView.FormatConditions.Add(formatCondition);
                }
            }
        }
        private void SetBandHide(GridControlBand band)
        {
            band.Visible = false;
            if (band.ParentBand != null)
            {
                GridControlBand parentBand = band.ParentBand as GridControlBand;
                if (parentBand.Bands.Count == 1)
                {
                    SetBandHide(parentBand);
                }
            }

        }

        #endregion

        #region"SQL"
        private string SQLStoreD09P6868()
        {
            string sSQL = "-- Do nguon khoi" + Environment.NewLine;
            sSQL += "Exec D09P6868 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("D45F1022") + L3.COMMA; // FormID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("Block") + L3.COMMA; // TypeID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber("") + L3.COMMA; // IsMSS, tinyint, NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(L3.IsUniCode); // CodeTable, tinyint, NOT NULL
            return sSQL;
        }
        private string SQLStoreD91P0066()
        {
            string sSQL = "--Kiem tra bat buoc nhap combo khoi" + Environment.NewLine;
            sSQL += "Exec D91P0066 ";
            sSQL += L3SQLClient.SQLString("45") + L3.COMMA; // ModuleID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(L3.IsUniCode) + L3.COMMA; // CodeTable, tinyint, NOT NULL
            sSQL += L3SQLClient.SQLString("D45F1020") + L3.COMMA; // FormID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(1); // CheckMode, tinyint, NOT NULL
            return sSQL;
        }
        private string SQLStoreD45P1021()
        {
            string sSQL = "--Do nguon cho luoi bang gia" + Environment.NewLine;
            sSQL += "Exec D45P1021 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("D45F1022") + L3.COMMA; // FormID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(L3.IsUniCode); // CodeTable, tinyint, NOT NULL
            return sSQL;
        }
        private string SQLStoreD45P1022(string TransTypeID)
        {
            string sSQL = (TransTypeID == "Save" ? "--Thuc thi luu du lieu" : "--Do nguon cho luoi chi tiet") + Environment.NewLine;
            sSQL += "Exec D45P1022 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA; // HostID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(L3.IsUniCode) + L3.COMMA; // CodeTable, tinyint, NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(TransTypeID) + L3.COMMA; // TransTypeID, varchar[20], NOT NULL --- Load: do du lieu len luoi, Save: Luu du lieu
            sSQL += L3SQLClient.SQLString(tdbgM.IsKeyboardFocusWithin || btnNotSave.IsFocused || btnSave.IsFocused || (TransTypeID == "Save" && _FormState == EnumFormState.FormEdit) ? "E" : "A") + L3.COMMA; // Type, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(tdbcGroupProductID.EditValue) + L3.COMMA; // GrouProductID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(txtPriceListID.Text); // PriceListID, varchar[20], NOT NULL
            return sSQL;
        }

        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLInsertD45T1020
        // # Created User: 
        // # Created Date: 23/07/2019 04:09:56
        // #---------------------------------------------------------------------------------------------------
        private StringBuilder SQLInsertD45T1020()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Luu vao bang gia" + Environment.NewLine);
            sSQL.Append("Insert Into D45T1020(");
            sSQL.Append("PriceListID, PriceListNameU, DateFrom, DateTo, ValidFrom, ValidTo,  NoteU, " + Environment.NewLine);
            sSQL.Append("Disabled, CreateUserID, CreateDate, LastModifyUserID, " + Environment.NewLine);
            sSQL.Append("LastModifyDate, BlockID, GroupProductID");
            sSQL.Append(") Values(" + Environment.NewLine);
            sSQL.Append(L3SQLClient.SQLString(txtPriceListID.Text) + L3.COMMA); // PriceListID [KEY], varchar[20], NOT NULL
            sSQL.Append("N" + L3SQLClient.SQLString(txtPriceListName.Text) + L3.COMMA); // PriceListNameU, nvarchar[500], NOT NULL
            sSQL.Append(L3SQLClient.SQLDateSave(DateTime.Now.Date.ToShortDateString()) + L3.COMMA); // DateFrom, datetime, NULL
            sSQL.Append(L3SQLClient.SQLDateSave(DateTime.Now.Date.ToShortDateString()) + L3.COMMA); // DateTo, datetime, NULL
            sSQL.Append(L3SQLClient.SQLDateSave(dateValidFrom.EditValue) + L3.COMMA); // ValidFrom, datetime, NULL
            sSQL.Append(L3SQLClient.SQLDateSave(dateValidTo.EditValue) + L3.COMMA); // ValidTo, datetime, NULL
            sSQL.Append("N" + L3SQLClient.SQLString(txtNote.Text) + L3.COMMA + Environment.NewLine); // NoteU, nvarchar[1000], NOT NULL
            sSQL.Append(L3SQLClient.SQLNumber(chkDisabled.IsChecked ?? false) + L3.COMMA); // Disabled, tinyint, NOT NULL
            sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" + L3.COMMA); // CreateDate, datetime, NULL
            sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA + Environment.NewLine); // LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" + L3.COMMA); // LastModifyDate, datetime, NULL
            sSQL.Append(L3SQLClient.SQLString(tdbcBlockID.EditValue) + L3.COMMA); // BlockID, varchar[50], NOT NULL
            sSQL.Append(L3SQLClient.SQLString(tdbcGroupProductID.EditValue)); // GroupProductID, varchar[50], NULL
            sSQL.Append(")");

            return sSQL;
        }
        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLUpdateD45T1020
        // # Created User: 
        // # Created Date: 24/07/2019 01:53:29
        // #---------------------------------------------------------------------------------------------------
        private StringBuilder SQLUpdateD45T1020()
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("-- Luu cap nhat vao bang gia: " + Environment.NewLine);
            sSQL.Append("Update D45T1020 Set " + Environment.NewLine);
            sSQL.Append("PriceListNameU = " + "N" + L3SQLClient.SQLString(txtPriceListName.Text) + L3.COMMA); // varchar[500], NOT NULL
            sSQL.Append("DateFrom = " + L3SQLClient.SQLDateSave(DateTime.Now.Date.ToShortDateString()) + L3.COMMA); // datetime, NULL
            sSQL.Append("DateTo = " + L3SQLClient.SQLDateSave(DateTime.Now.Date.ToShortDateString()) + L3.COMMA); // datetime, NULL
            sSQL.Append("NoteU = " + "N" + L3SQLClient.SQLString(txtNote.Text) + L3.COMMA); // varchar[1000], NOT NULL
            sSQL.Append("Disabled = " + L3SQLClient.SQLNumber(chkDisabled.IsChecked ?? false) + L3.COMMA); // tinyint, NOT NULL
            sSQL.Append("LastModifyUserID = " + L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // varchar[20], NOT NULL
            sSQL.Append("LastModifyDate = GetDate()" + L3.COMMA); // datetime, NULL
            sSQL.Append("ValidFrom = " + L3SQLClient.SQLDateSave(dateValidFrom.EditValue) + L3.COMMA); // datetime, NULL
            sSQL.Append("ValidTo = " + L3SQLClient.SQLDateSave(dateValidTo.EditValue) + L3.COMMA); // datetime, NULL
            sSQL.Append("BlockID = " + L3SQLClient.SQLString(tdbcBlockID.EditValue) + L3.COMMA); // varchar[50], NOT NULL
            sSQL.Append("GroupProductID = " + L3SQLClient.SQLString(tdbcGroupProductID.EditValue)); // varchar[50], NULL
            sSQL.Append(" Where ");
            sSQL.Append("PriceListID = " + L3SQLClient.SQLString(txtPriceListID.Text));

            return sSQL;
        }
        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLStoreD91P9106
        // # Created User: 
        // # Created Date: 24/07/2019 02:16:06
        // #---------------------------------------------------------------------------------------------------
        private string SQLStoreD91P9106()
        {
            string sSQL = "";
            sSQL += ("-- Audit Log Edit" + Environment.NewLine);
            sSQL += "Exec D91P9106 ";
            sSQL += L3SQLClient.SQLDateSave("") + L3.COMMA; // AuditDate, datetime, NOT NULL
            sSQL += L3SQLClient.SQLString("PriceLists") + L3.COMMA; // AuditCode, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("45") + L3.COMMA; // ModuleID, varchar[2], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("02") + L3.COMMA; // EventID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(txtPriceListID.Text) + L3.COMMA; // Desc1, nvarchar[500], NOT NULL
            sSQL += "N" + L3SQLClient.SQLString(txtPriceListName.Text) + L3.COMMA; // Desc2, nvarchar[500], NOT NULL
            sSQL += L3SQLClient.SQLString(dateValidFrom.EditValue) + L3.COMMA; // Desc3, nvarchar[500], NOT NULL
            sSQL += L3SQLClient.SQLString("GetDate()") + L3.COMMA; // Desc4, nvarchar[500], NOT NULL
            sSQL += "N" + L3SQLClient.SQLString("") + L3.COMMA; // Desc5, nvarchar[500], NOT NULL
            sSQL += L3SQLClient.SQLNumber(0) + L3.COMMA; // IsAuditDetail, tinyint, NOT NULL
            sSQL += L3SQLClient.SQLString(""); // AuditItemID, varchar[50], NOT NULL
            return sSQL;
        }

        #endregion

        #region"Event"

        private void mnsAdd_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            EnableMenu(true);
            LoadAdd();
        }
        private void LoadAdd()
        {
            _FormState = EnumFormState.FormAdd;
            Lemon3.Controls.DevExp.L3Control.ClearTextALL(grpMaster);
            chkDisabled.IsChecked = false;
            txtPriceListID.IsReadOnly = false;
            Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(false, txtPriceListID, dateValidFrom, dateValidTo, tdbcBlockID, tdbcGroupProductID, tdbgD);
            ClearText();
            Lockcontrol(true);
        }

        private bool _bEdit = false;
        private void mnsEdit_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (tdbgMView.FocusedRowHandle < 0)
                return;
            try
            {
                if (!D45X0002.CheckMyStore(D45X0002.SQLStoreD45P5555(2, "D45F1022", tdbgM.GetFocusedRowCellValue(COLM_PriceListID).ToString()), ref _bEdit))
                {
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            _FormState = EnumFormState.FormEdit;
            Lockcontrol(true);
            EnableMenu(true);
            Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtPriceListID);
            txtPriceListID.Focus();

        }
        private void mnsDelete_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (tdbgMView.FocusedRowHandle < 0)
                return;
            if (D99D0041.D99C0008.MsgAskDelete() == System.Windows.Forms.DialogResult.No)
                return;
            this.Cursor = Cursors.Wait;
            if (!L3SQLServer.CheckStore(D45X0002.SQLStoreD45P5555(1, "D45F1022", txtPriceListID.Text)))
            {
                this.Cursor = Cursors.Arrow;
                return;
            }
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("DELETE D45T1021 WHERE PriceListID = " + L3SQLClient.SQLString(txtPriceListID.Text));
            sSQL.Append("DELETE D45T1020 WHERE PriceListID = " + L3SQLClient.SQLString(txtPriceListID.Text));
            sSQL.Append("DELETE D45T1024 WHERE PriceListID = " + L3SQLClient.SQLString(txtPriceListID.Text));

            bool bRunSQL = L3SQLServer.ExecuteSQL(sSQL.ToString());
            if (bRunSQL)
            {
                L3AuditLog.RunAuditLog("45", "PriceLists", "03", txtPriceListID.Text, txtPriceListName.Text, dateValidFrom.EditValue.ToString(), DateTime.Now.ToShortDateString(), "");
                Lemon3.Messages.L3Msg.DeleteOK();
                D45X0002.DeleteGridEvent(tdbgM, tdbgMView, _dtGridM, COLM_PriceListID.FieldName, L3ConvertType.L3Bool(chkShowDisabled.IsChecked ?? false));
                if (tdbgM.VisibleRowCount == 0)
                {
                    ResetGrid();
                    //tsbAdd_Click(null, null);
                    ClearText();
                }
                else
                {
                    ReLoadTDBGridM();
                    tdbgM.Focus();
                    tdbgM_RowColChange(null, null);
                }
            }
            else
                Lemon3.Messages.L3Msg.DeleteNotOK();
            this.Cursor = Cursors.Arrow;
        }
        private void tsbSysInfo_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            L3Window.ShowSysInforForm(tdbgM);
        }
        private void tdbgM_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.Key == Key.Enter)
                    tdbgM_DoubleClick(null, null);
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    if (e.Key == Key.C && tdbgMView.FocusedRowHandle >= 0 && tdbgM.GetFocusedValue() != null)
                    {
                        try
                        {
                            System.Windows.Clipboard.SetDataObject(tdbgM.GetFocusedValue().ToString());
                        }
                        catch (Exception ex)
                        {
                            L3Msg.MyMsg(ex.Message.ToString());
                        }
                    }
                }
            }
        }
        private void tsbImportData_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            if (D99D0241.D99X0020.CallShowDialogD80F2090("D45", "D45F5604", "D45F1022"))
            {
                LoadTDBGridM(true);
                tdbgM.Focus();
                LoadEdit();
            }
            this.Cursor = Cursors.Arrow;

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (btnSave.IsFocused == false)
                return;
            tdbgD.FilterString = "";
            if (_bAskSave)
            {
                if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
                    return;
            }
            else
                _bAskSave = true;
            SaveData(sender);
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
            if (_FormState == EnumFormState.FormAdd && txtPriceListID.Text == "")
            {
                if (tdbgM.VisibleRowCount > 0)
                {
                    _FormState = EnumFormState.FormView;
                    LoadEdit();
                }
                goto One;
            }
            if (L3Msg.AskMsgBeforeRowChange())
            {
                _bAskSave = false;
                if (!SaveData(sender))
                    return;
            }
            else
            {
                LoadEdit();
                Lockcontrol(false);
            }

            One:
            SetReturnFormView();

        }
        private void tdbgM_RowColChange(object sender, SelectedItemChangedEventArgs e)
        {
            if (!tdbgM.IsKeyboardFocusWithin)
            {
                return;
            }
            if (tdbgMView.FocusedRowHandle < 0 && !(tdbgM.VisibleRowCount > 0))
                return;
            LoadEdit();
            Lockcontrol(false);
        }
        private void tdbgM_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tdbgM.VisibleRowCount <= 0 || tdbgMView.FocusedRowHandle < 0)
                return;
            this.Cursor = Cursors.Wait;
            if (tsbEdit.IsEnabled)
                mnsEdit_Click(sender, null);
            this.Cursor = Cursors.Arrow;
        }
        private void chkShowDisabled_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (_dtGridM == null && _dtGridM.Rows.Count <= 0)
                return;
            this.Cursor = Cursors.Wait;
            ReLoadTDBGridM();
            if (tdbgM.VisibleRowCount == 0) tdbgMView.FocusedRowHandle = 0;
            tdbgMView.Focus();
            tdbgM_RowColChange(null, null);
            this.Cursor = Cursors.Arrow;
        }
        private void mnsExportToExcelDetail_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            try
            {
                DataTable dtCaption = Lemon3.Documents.Excel.L3ExportExcel.CreateTableForExcelOnly(tdbgD);
                Lemon3.IO.L3CallDLL oCallDLL = new Lemon3.IO.L3CallDLL();

                Lemon3.IO.StructureProperties[] arrPro = null;
                oCallDLL.SetProperties(ref arrPro, "UseUnicode", L3.IsUniCode);
                oCallDLL.SetProperties(ref arrPro, "FormID", "D45F1022");
                oCallDLL.SetProperties(ref arrPro, "dtLoadGrid", dtCaption);
                oCallDLL.SetProperties(ref arrPro, "dtExportTable", _dtGridD);
                oCallDLL.CallFormShowDialog("D99D0341", "D99F2222", arrPro);
            }
            catch (Exception ex)
            {
                D99D0041.D99C0008.MsgL3("Có lỗi trong quá trình xuất Excel: " + ex.Message);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void mnsExportToExcelMaster_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            try
            {
                DataTable dtCaption = Lemon3.Documents.Excel.L3ExportExcel.CreateTableForExcelOnly(tdbgM);
                Lemon3.IO.L3CallDLL oCallDLL = new Lemon3.IO.L3CallDLL();

                Lemon3.IO.StructureProperties[] arrPro = null;
                oCallDLL.SetProperties(ref arrPro, "UseUnicode", L3.IsUniCode);
                oCallDLL.SetProperties(ref arrPro, "FormID", "D45F1022");
                oCallDLL.SetProperties(ref arrPro, "dtLoadGrid", dtCaption);
                //oCallDLL.SetProperties(ref arrPro, "GroupColumns", gsGroupColumns);
                oCallDLL.SetProperties(ref arrPro, "dtExportTable", _dtGridM);
                //oCallDLL.SetProperties(ref arrPro, "dtMaster", dtCaption);
                oCallDLL.CallFormShowDialog("D99D0341", "D99F2222", arrPro);
            }
            catch (Exception ex)
            {
                D99D0041.D99C0008.MsgL3("Có lỗi trong quá trình xuất Excel: " + ex.Message);
            }
            this.Cursor = Cursors.Arrow;
        }
        private void tdbcGroupProductID_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (tdbcGroupProductID.IsKeyboardFocusWithin == false)
                return;
            if (tdbcGroupProductID.EditValue == null)
                return;
            if (tdbgM.IsKeyboardFocusWithin)
                return;
            if (_FormState == EnumFormState.FormAdd && tdbcGroupProductID.EditValue.ToString() == "")
            {
                return;
            }
            this.Cursor = Cursors.Wait;
            LoadtdbdProductID(tdbcGroupProductID.EditValue.ToString());
            LoadTDBGridD();
            this.Cursor = Cursors.Arrow;
        }
        #endregion
        private void tdbgD_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    if (e.Key == Key.C && tdbgDView.FocusedRowHandle >= 0 && tdbgD.GetFocusedValue() != null)
                    {
                        try
                        {
                            System.Windows.Clipboard.SetDataObject(tdbgD.GetFocusedValue().ToString());
                        }
                        catch (Exception ex)
                        {
                            string mess = ex.Message.ToString();
                        }
                    }
                }
            }
        }
        private void L3Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (tdbgDView.IsKeyboardFocusWithin && e.Key == Key.Delete && _FormState == EnumFormState.FormEdit && tdbgDView.FocusedRowHandle < _originRowCount)
            {
                e.Handled = true;
                tdbgDView.CancelRowEdit();
                return;
            }
        }
        private void tdbgD_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (_FormState == EnumFormState.FormEdit && !_bEdit)
            {
                //if (e.Column == COLD_ProductID)
                //{
                    e.Cancel = (tdbgDView.FocusedRowHandle <= _originRowCount - 1) && tdbgDView.FocusedRowHandle >= 0;
                //}
                //else
                //{
                //    e.Cancel = !((e.Column as GridColumn).AllowEditing == DevExpress.Utils.DefaultBoolean.Default || (e.Column as GridColumn).AllowEditing == DevExpress.Utils.DefaultBoolean.True ? true : false);
                //}
            }
        }
        private void TdbgDView_RowUpdated(object sender, RowEventArgs e)
        {
            ResetGridD();
        }
        private void TdbgDView_ValidateCell(object sender, GridCellValidationEventArgs e)
        {
            TableView view = sender as TableView;
            TextEdit edit = view.ActiveEditor  as TextEdit;
            if (edit.Text == "") return;
            switch (e.Column.FieldName)
            {
                case "ProductID":
                  int duplicate = _dtGridD.AsEnumerable().Where(w => w["ProductID"].ToString() == edit.Text).Count();
                    if (duplicate > 0)
                    {
                        D99D0041.D99C0008.MsgDuplicatePKey();
                        tdbgD.SetFocusedRowCellValue(COLD_ProductName, "");
                        e.IsValid  = false;
                    }
                    else
                        tdbgD.SetFocusedRowCellValue(COLD_ProductName, tdbdProductID.ReturnValue("ProductName"));
                    break;
                default:
                    break;
            }
        }
        private void tdbgDView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "ProductID":
                    tdbgD.SetFocusedRowCellValue(COLD_ProductName, tdbdProductID.ReturnValue("ProductName"));
                    break;
                default:
                    break;
            }
        }
    }
}