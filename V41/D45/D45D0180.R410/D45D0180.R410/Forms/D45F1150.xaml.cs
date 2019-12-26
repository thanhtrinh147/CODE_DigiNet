using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.LookUp;
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

namespace D45D0180
{
    /// <summary>
    /// Interaction logic for D45F1150.xaml
    /// </summary>
    public partial class D45F1150 : L3Page
    {
        private L3CreateColumnsForGridControl oL3CreateColumns;
        private bool _bLoadFormState = false;
        private System.Data.DataTable dtGrid =null;
        Lemon3.Data.L3SQLBulkCopy oBulkCopy = new L3SQLBulkCopy();
         DataTable dtOld = new DataTable();
         System.Data.DataTable dtTem;
                   

        private bool _bSaved = false;
        public D45F1150()
        {
            InitializeComponent();
            this.Title = L3Resource.rL3("Danh_muc_bang_gia_nang_cao") + " - D45F1150";
            COLD_OrderNo.Header = L3Resource.rL3("STT");
            COLD_ProductID.Header = L3Resource.rL3("Ma_san_pham");
            COLD_ProductName.Header = L3Resource.rL3("Ten_san_pham");
        }
        public override void SetContentForL3Page()
        {

        }
        private Lemon3.EnumFormState _formState = Lemon3.EnumFormState.FormView;     
        private void L3Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            txtPriceListID.CheckIdTextBox();
            tdbgD.SetColumnOrderNum(COLD_OrderNo);
            tdbg.SetDefaultGridControlInquiry();
            L3Control.SetShortcutPopupMenu(MainMenuControl1, ContextMenu1);
            this.SetBackColorObligatory(new Control[] { txtPriceListID, txtPriceListName, dateValidFrom}, null);
           

            tsbAdd.IsEnabled = L3Permissions.ReturnPermission("D45F1150") >= 2;
            
            mnsAdd.IsEnabled = L3Permissions.ReturnPermission("D45F1150") >= 2;
          
            grpheader.IsEnabled = L3Permissions.ReturnPermission("D45F1150") >= 1;
            split.IsEnabled = L3Permissions.ReturnPermission("D45F1150") >= 1;
            btnConditionList.IsEnabled = L3Permissions.ReturnPermission("D45F1140") >= 2;
            //ResetGrid();
            LoadTDBGrid();
            LoadTDBCombo();
            LoadLanguage();
            LockControl(true);

            tdbgView.ShowGroupPanel = false;
           // COLD_PriceListID.Visible = false;
            //tsbDelete.IsEnabled = true;
            //tsbEdit.IsEnabled = true;
            this.Cursor = Cursors.Arrow;

        }

        private void LockControl(Boolean bLock)
        {
            txtPriceListID.IsReadOnly = bLock;
            txtPriceListName.IsReadOnly=bLock;
            chkDisabled.IsReadOnly=bLock;          
            dateValidTo.IsReadOnly=bLock;
            tdbcBlockID.IsReadOnly=bLock;
            txtNote.IsReadOnly = bLock;
            tdbgDView.AllowEditing = !bLock;
            chkViewDisable.IsEnabled = bLock;
            
            if (_formState == EnumFormState.FormEdit)
            {
                dateValidFrom.IsReadOnly = !_bEdit;
            }
               
            else
            {
                dateValidFrom.IsReadOnly = bLock;
            }
                
        }

        L3LookUpEditSettings ed;
        private void SetDDGridDetail()
        {

            dtTem = L3SQLServer.ReturnDataTable(SQLStoreD45P1151());
            //do nguon cot dong

       
            System.Data.DataTable d1= L3DataTable.ReturnTableFilter(_dtBandColumn, "ControlType = 'DD'" );
            List<string> columnsDD = d1.AsEnumerable().Select(r => r.Field<string>("CaptionID")).ToList();
          //  List<GridColumn> _dynamicColumns = tdbgD.Columns.AsEnumerable().Where(r => r.ParentBand != null && r.ParentBand.VisibleIndex != 0).ToList();
            foreach(GridColumn col in tdbgD.Columns)
            {
                if (columnsDD.Contains(col.FieldName))
                {
                    ed = new L3LookUpEditSettings();
                    ed.AutoComplete = true;                                      
                    ed.ValueMember = "ConditionID";
                    ed.DisplayMember = "Description";
                    DataTable d = L3DataTable.ReturnTableFilter(dtTem, "FieldName='" + col.FieldName + "'");
                    d.Columns.Remove("FieldName");
                    ed.ItemsSource = d;
                    ed.SetCaptionColumn("ConditionID", L3Resource.rL3("Ma"));
                    ed.SetCaptionColumn("Description", L3Resource.rL3("Ten"));
                    ed.AllowNullInput = true;
                    ed.NullText = string.Empty;
                    ed.PopupWidth = 300;
                    
                    
                    ed.PopupContentTemplate = this.FindResource("tdbdTem") as ControlTemplate;
                                      
                    col.EditSettings = ed;
                   
                }
            }

        }

        private void AddcolumnDridD(string col,string fieldName,string cap,int width)
        {
            
            GridColumn column = new GridColumn();
            column.Name = "COLD_" + col;
            column.FieldName = fieldName;
            column.Header = cap;
            column.HorizontalHeaderContentAlignment = System.Windows.HorizontalAlignment.Center;
            column.Width = new GridColumnWidth(width, GridColumnUnitType.Star);
            column.Width = width;
            column.ReadOnly = false;
            column.Visible = true;
            //tdbgD.Columns.Add(column);
            
            if(column.Name=="COLD_OrderNo")
            {
                tdbgD.SetColumnOrderNum(column);
            }
            tdbgD.Columns.Insert(0, column);
        }
       
       
        private void LoadTDBGrid(bool IsAdd = true, string sKey = "")
        {          
            dtGrid = L3SQLServer.ReturnDataTable(SQLStoreD45P1021());
           L3DataSource.LoadDataSource(tdbg, dtGrid);
           if (chkViewDisable.IsChecked == true)
           {
           }
           else
           {
               L3DataSource.LoadDataSource(tdbg, L3DataTable.ReturnTableFilter(dtGrid, "Disabled = 0"), L3.IsUniCode);
           }        
           if (tdbgView.FocusedRowHandle < 0)
            {
                tdbgView_FocusedRowChanged(null, null);               
            }          
            ReLoadTDBGrid();
            if (sKey != "")
            {
                int row = tdbg.FindRowByValue(COL_PriceListID, sKey);
                if (row >= 0) tdbg.FocusRowHandle(row);
            }
        }
        private void ReLoadTDBGrid()
        {

            if (_formState == EnumFormState.FormAdd)
                return;

            if (tdbg.VisibleRowCount == 0)
            {
                ClearTextALL();
                LoadNullGrid(true);
            }
            else
            {
                _formState = EnumFormState.FormView;
                LoadEdit();
                LoadNullGrid(false);
            }
            //   ResetGrid();
        }
        private void LoadNullGrid(Boolean bNull)
        {
            tsbEdit.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1150") >= 3;
            tsbDelete.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1150") >= 4;           
            mnsDelete.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1150") >= 4;
            mnsEdit.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1150") >= 3;
        }

        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Danh_muc_bang_gia_nang_cao") + " - D45F1150";
            COL_PriceListID.Header = L3Resource.rL3("Ma_bang_giaU");
            COL_PriceListName.Header = L3Resource.rL3("Dien_giai");
            COL_ValidFrom.Header = L3Resource.rL3("Hieu_luc_tu");
            COL_ValidTo.Header = L3Resource.rL3("Hieu_luc_den");
            COL_Disabled.Header = L3Resource.rL3("KSD");

            chkViewDisable.Content = L3Resource.rL3("Hien_thi_danh_muc_khong_su_dungU");

            lblPriceListID.Content = L3Resource.rL3("Ma_bang_giaU");
            lblPriceListName.Content = L3Resource.rL3("Dien_giai");
            lblValid.Content = L3Resource.rL3("Hieu_lucU");
            chkDisabled.Content = L3Resource.rL3("Khong_su_dung");
            lblBlockID.Content = L3Resource.rL3("KhoiU");
            lblNote.Content = L3Resource.rL3("Ghi_chu");

            COLD_OrderNo.Header = L3Resource.rL3("STT");
            COLD_ProductID.Header = L3Resource.rL3("Ma_san_pham");
            COLD_ProductName.Header = L3Resource.rL3("Ten_san_pham");

            btnSave.Content = L3Resource.rL3("Luu");
            btnNext.Content = L3Resource.rL3("Luu_va_nhap_tiepU");
            btnNotSave.Content = L3Resource.rL3("Khong_luu");
            grpheader.Text ="<< "+ L3Resource.rL3("DongU1");
            grpGridheader.Text = L3Resource.rL3("Chi_tiet");

            lblSttProductID.Content = L3Resource.rL3("Ma_san_pham")+":";
            lblsttProductName.Content = L3Resource.rL3("Ten_san_pham") + ":";

            tdbcBlockID.SetCaptionColumn("BlockID", L3Resource.rL3("Ma"));
            tdbcBlockID.SetCaptionColumn("BlockName", L3Resource.rL3("Ten"));

            tdbdProductID.SetCaptionColumn("ProductID", L3Resource.rL3("Ma"));
            tdbdProductID.SetCaptionColumn("ProductName", L3Resource.rL3("Ten"));
            
            btnConditionList.Content = L3Resource.rL3("Danh_muc_dieu_kien");
        }

        private void LoadTDBCombo()
        {
            System.Data.DataTable dt;

            string sSQL = "-- Do nguon kiem tra su dung khoi va dinh dang ngay"+Environment.NewLine;
            sSQL += "SELECT 	IsUseBlock,FormatDateType FROM 	D09T0000 WITH(NOLOCK)";
            dt = L3SQLServer.ReturnDataTable(sSQL);
            tdbcBlockID.IsEnabled = dt.Rows[0][0].ToString() == "1";


            dt = L3SQLServer.ReturnDataTable(SQLStoreD91P0066());

            if(dt.Rows[0]["ValidMode"].ToString()=="O")
            {
                this.SetBackColorObligatory(new Control[] { tdbcBlockID}, null);
            }
            if (dt.Rows[0]["ValidMode"].ToString() == "W")
            {
               //canhb bao
            }

            dt = L3SQLServer.ReturnDataTable(SQLStoreD09P6868());
            L3DataSource.LoadDataSource(tdbcBlockID, dt);

            sSQL = "--tdbd Combo sản phẩm"+Environment.NewLine;
            sSQL += "SELECT ProductID, ProductNameU As ProductName FROM D45T1000  WITH(NOLOCK) WHERE Disabled = 0 Order By ProductID";
            dt = L3SQLServer.ReturnDataTable(sSQL);
            L3DataSource.LoadDataSource(tdbdProductID, sSQL);
        }
     

        private string SQLStoreD91P0066()
        {
            string sSQL = "";
            sSQL = "--- Kiem tra bat buoc nhap combo khoi" + Environment.NewLine;
            sSQL += "EXEC D91P0066 " + Environment.NewLine;
            sSQL += L3SQLClient.SQLString("45") + ",";
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + ",";
            sSQL += L3SQLClient.SQLString(L3.IsUniCode) + ",";
            sSQL += L3SQLClient.SQLString("D45F1020") + ",";
            sSQL += L3SQLClient.SQLNumber(1);

            return sSQL;
        }
        private string SQLStoreD09P6868()
        {
            string sSQL = "";
            sSQL = "-- Do nguon khoi " + Environment.NewLine;
            sSQL += "EXEC D09P6868  " + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString("D45F1150") + ",";
            sSQL += L3SQLClient.SQLString("Block") + ",";
            sSQL += L3SQLClient.SQLNumber(0) + ",";
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + ",";
            sSQL += L3SQLClient.SQLString(L3.IsUniCode);

            return sSQL;
        }
        private string SQLStoreD45P1151()
        {
            string sSQL = "";
            sSQL = "-- Đổ nguồn combo cot dong " + Environment.NewLine;
            sSQL += " EXEC D45P1151   " + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString("D45F1150") + ",";
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + ",";
            sSQL += L3SQLClient.SQLString("DD");

            return sSQL;
        }
        private string SQLStoreD45P1021()
        {
            string sSQL = "";
            sSQL = "-- Do nguon cho luoi bang gia " + Environment.NewLine;
            sSQL += " EXEC D45P1021    " + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString("D45F1150") + ",";
            sSQL += L3SQLClient.SQLString(L3.STRLanguage);
           
            return sSQL;
        }
        private string SQLStoreD45P1150()
        {
            string sSQL = "";
            sSQL = "-- Do nguon cho luoi chi tiết " + Environment.NewLine;
            sSQL += " EXEC D45P1150  " + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + ",";
            sSQL += L3SQLClient.SQLString("1") + ",";
            sSQL += L3SQLClient.SQLString("84") + ",";
            sSQL += L3SQLClient.SQLString("Load") + ",";
            if(_formState==EnumFormState.FormAdd)
            {
                sSQL += L3SQLClient.SQLString("A") + ",";

            }else
            {
                sSQL += L3SQLClient.SQLString("E") + ",";
            }
            sSQL += L3SQLClient.SQLString(txtPriceListID.Text) ;

            return sSQL;
        }

        private void GridSplitter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (left.Width == new GridLength(0, GridUnitType.Star))
            {
                left.Width = new GridLength(300);
                grpheader.Text = "<< "+L3Resource.rL3("DongU1");
            }
            else
            {
                left.Width = new GridLength(0, GridUnitType.Star);
                grpheader.Text = L3Resource.rL3("MoU")+" >>";
            }
        }
        private void tdbgView_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            if (tdbgView.FocusedRowHandle < 0)
            {
                tdbgView.FocusedRowHandle = 0;
            }
            LoadEdit();           
            LoadTDBGDetail();

        }

        private void LoadEdit()
        {
            if (tdbg.VisibleRowCount < 1)
            { return; };
            LoadMaster(tdbg.GetFocusedRowCellValue(COL_PriceListID).ToString());

        }

        private void LoadMaster(string priceListID)
        {
            string sSQL = ""; 
            sSQL += "-- Do nguon cho master"+Environment.NewLine;
            sSQL += "SELECT 	PriceListID, PriceListNameU as PriceListName, NoteU as Note, Disabled, ValidFrom, ValidTo, BlockID"+Environment.NewLine;
            sSQL += "FROM 	  D45T1020  WITH(NOLOCK) WHERE 	  PriceListID=" + L3SQLClient.SQLString(priceListID);

            System.Data.DataTable dt = L3SQLServer.ReturnDataTable(sSQL);

            txtPriceListID.EditValue = dt.Rows[0]["PriceListID"].ToString();
            txtPriceListName.EditValue = dt.Rows[0]["PriceListName"].ToString();
            chkDisabled.IsChecked = dt.Rows[0]["Disabled"].ToString() == "1";
            dateValidFrom.EditValue = dt.Rows[0]["ValidFrom"];
            dateValidTo.EditValue = dt.Rows[0]["ValidTo"];
            tdbcBlockID.EditValue = dt.Rows[0]["BlockID"].ToString();
            txtNote.EditValue = dt.Rows[0]["Note"].ToString();
        }
        DataTable dtGridD=null;
        DataTable _dtBandColumn = null;
        private int _originRowCount = 0;
        private void LoadTDBGDetail()
        {
            if (tdbgD.Bands.Count > 1)
            {
                for (int b = tdbgD.Bands.Count-1; b > 0; b--)
                {
                    tdbgD.Bands.RemoveAt(b);
                }
            }
          
            DataSet ds = L3SQLServer.ReturnDataSet(SQLStoreD45P1150("Load","E"));
            if (ds == null)
            {
                return;
            }
            _dtBandColumn = ds.Tables[0];

            if (ds.Tables.Count > 1) 
            {
                dtGridD = ds.Tables[1];
                dtCoppy = ds.Tables[1].Copy();
            }
            if (oL3CreateColumns == null) oL3CreateColumns = new L3CreateColumnsForGridControl();
   
           
            oL3CreateColumns.CreateColumns(tdbgD, _dtBandColumn);
            SetDDGridDetail();

            foreach (GridControlBand band in tdbgD.Bands)
            {
                if (band.Header.ToString() == "") band.OverlayHeaderByChildren = true;
                else
                {
                    BandHeaderBold(band);
                }
            }
           
            L3DataSource.LoadDataSource(tdbgD, dtGridD);           
            _originRowCount = dtGridD.Rows.Count;
            // Set column visible
            List<string> columnsEnable = _dtBandColumn.AsEnumerable().Select(r => r.Field<string>("CaptionID")).ToList();
            foreach (GridColumn col in tdbgD.Columns)
            {
                if (!columnsEnable.Contains(col.FieldName) && col.FieldName != "PricelistID")
                {
                    col.Visible = true;
                    ColumnHeaderBold(col);
                }
                else
                {
                    ColumnHeaderBold(col);
                }
            }
           
        
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
        private void tsbAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            LoadAdd();
            EnableMenu(true);
        }

        private void EnableMenu(bool bEnable)
        {
            tdbg.IsEnabled = !bEnable;

            btnSave.IsEnabled = bEnable;
            btnNext.IsEnabled = bEnable;
            btnNotSave.IsEnabled = bEnable;
            btnConditionList.IsEnabled = !bEnable;


            tsbAdd.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1150") >= 2;
            tsbEdit.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1150") >= 3;
            tsbDelete.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1150") >= 4;
            mnsAdd.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1150") >= 2;
            mnsEdit.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1150") >= 3;
            mnsDelete.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1150") >= 4;
        }
        private void LoadAdd()
        {

            _formState = Lemon3.EnumFormState.FormAdd;
            _bSaved = false;
            ClearTextALL();
            txtPriceListID.Focus();
            LockControl(false);
            dateValidFrom.EditValue = DateTime.Now;
            if (dtGridD != null)
            {
                dtGridD.Clear();
            }
            
            
        }

        private void ClearTextALL()
        {
            txtPriceListID.Text = "";
            txtPriceListName.Text = "";
            chkDisabled.IsChecked = false;
            dateValidFrom.EditValue = "";
            dateValidTo.EditValue = "";
            tdbcBlockID.EditValue = "";
            txtNote.Text = "";
            if(dtGridD!=null)
            {
                dtGridD.Clear();
            }
            
           
                  
        }
        private bool _bEdit = false;
        private void tsbEdit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (tdbgView.FocusedRowHandle < 0)
                return;
            try
            {
                if (!D45X0002.CheckMyStore(D45X0002.SQLStoreD45P5555(2, "D45F1150", tdbg.GetFocusedRowCellValue(COL_PriceListID).ToString()), ref _bEdit))
                {
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            _formState = EnumFormState.FormEdit;
            LockControl(false);
            EnableMenu(true);
            btnNext.IsEnabled = false;
            Lemon3.Controls.DevExp.L3Control.ReadOnlyControl(true, txtPriceListID);
            txtPriceListID.Focus();
           
        }
        private void tsbDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (!L3SQLServer.CheckStore(SQLStoreD45P5555("-- Kiem tra truoc khi xóa",1)))
            {
                return;
            }
            if (D99D0041.D99C0008.MsgAskDelete() == System.Windows.Forms.DialogResult.No)
                return;

            string sSQL = DeletePriceList();
            sSQL += SQlStoreD91P9106("-- Audit Log Delete", "03");
            bool bRunSQL = L3SQLServer.ExecuteSQL(sSQL);
            if (bRunSQL)
            {
                Lemon3.Messages.L3Msg.DeleteOK();
                //LoadTDBGrid();
                //Xử lý refreah lưới

                for (int i = 0; i < tdbg.VisibleRowCount; i++)
                {
                    DataRow drLoop = (tdbg.GetRow(tdbg.GetRowHandleByVisibleIndex(i)) as DataRowView).Row;
                    DataRow drCurrent = (tdbg.CurrentItem as DataRowView).Row;

                    if (drLoop == drCurrent)
                    {
                        // Nếu bên dưới có dòng thì chuyển xuống dòng dưới
                        if (i < (tdbg.VisibleRowCount - 1))
                        {
                            int indexRowFocus = tdbg.GetRowHandleByVisibleIndex(i);
                            HandleRowFocus(indexRowFocus);
                        }
                        else
                        {
                            int indexRowFocus = tdbg.GetRowHandleByVisibleIndex(0);
                            HandleRowFocus(indexRowFocus);
                        }
                        (tdbg.ItemsSource as DataTable).Rows.Remove(drCurrent);
                        break;
                    }
                }
            }
            else
            {
                Lemon3.Messages.L3Msg.DeleteNotOK();
            }
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

        private void tsbListAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            tdbg.ListAll();
        }

        private void tsbSysInfo_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            L3Window.ShowSysInforForm(tdbg);
        }

        private void mnsAdd_Click(object sender, RoutedEventArgs e)
        {
            tsbAdd_ItemClick(null,null);
        }

        private void mnsEdit_Click(object sender, RoutedEventArgs e)
        {
            tsbEdit_ItemClick(null,null);
        }

        private void mnsDelete_Click(object sender, RoutedEventArgs e)
        {
            tsbDelete_ItemClick(null,null);
        }

        private void mnsListAll_Click(object sender, RoutedEventArgs e)
        {
            tsbListAll_ItemClick(null,null);
        }

        private void mnsSysInfo_Click(object sender, RoutedEventArgs e)
        {
            tsbSysInfo_ItemClick(null,null);
        }

        

        private void chkViewDisable_Click(object sender, RoutedEventArgs e)
        {
            LoadTDBGrid();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (!btnSave.Focusable) return;
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
            {

                SetReturnFormView();
                LoadTDBGDetail();
            }else
            {
                SaveData(sender);
            }
            
        }
        Boolean isNext;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           
            btnNext.Focus();
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
            {
               
                SetReturnFormView();
                LoadTDBGDetail();
            }
            else 
            {
                isNext = true;
                if (SaveData(sender) == false)
                { return; }
                ClearTextALL();
                btnSave.IsEnabled = true;
                btnNext.IsEnabled = true;
                btnNotSave.IsEnabled = true;
            }
            
        }

        private void btnNotSave_Click(object sender, RoutedEventArgs e)
        {
            if (_formState == EnumFormState.FormAdd && txtPriceListID.Text == "")
            {
                if (tdbg.VisibleRowCount > 0)
                {
                    LoadEdit();
                }
                goto one;
            }
            if (Lemon3.Messages.L3Msg.AskMsgBeforeRowChange())
            {
                if (SaveData(sender) == false)
                { return; }
            }
            else
            {

                LoadEdit();
                LoadTDBGDetail();
            }
        one:
            SetReturnFormView();
        }
        private bool SaveData(System.Object sender)
        {

            _bSaved = false;
            if (!AllowSave())
                return false;          
            StringBuilder sSQL = new StringBuilder();
            //DataSet ds=null;

            switch (_formState)
            {
                case EnumFormState.FormAdd:
                    sSQL.Append(SQLInsertD45T1020()+Environment.NewLine);
                    oBulkCopy.AddSQLAfter(SQLStoreD45P1150("save", "A"));        //SQLStoreD45P1150("save", "A")
                     Boolean bRunA = oBulkCopy.CheckStoreBulkCopy(dtGridD, "#D45P1150_"+L3.UserID);
                     if (bRunA==false)
                     {
                         //L3Msg.MyMsg(L3Resource.rL3("Ban_da_nhap_trung_du_lieu_tren_luoi"));                       
                         return false;
                     }                  
                    sSQL.Append(SQlStoreD91P9106("-- Audit Log AddNew", "01") + Environment.NewLine);
                    break;
                case EnumFormState.FormEdit:
                    sSQL.Append(SQLUpdateD45T1020()+Environment.NewLine);
                    oBulkCopy.AddSQLAfter(SQLStoreD45P1150("Save", "E"));
                    Boolean bRunE = oBulkCopy.CheckStoreBulkCopy(dtGridD, "#D45P1150_" + L3.UserID);
                    if (bRunE == false)
                     {
                         //L3Msg.MyMsg(L3Resource.rL3("Ban_da_nhap_trung_du_lieu_tren_luoi"));                       
                         return false;
                     }     
                    sSQL.Append(SQlStoreD91P9106("-- Audit Log Edit","02"));
                    break;
            }

            bool bRunSQL = false;
            bRunSQL = L3SQLServer.ExecuteSQL(sSQL.ToString());
            this.Cursor = Cursors.Arrow;
            if (bRunSQL)
            {
                Lemon3.Messages.L3Msg.SaveOK();

                _bSaved = true;
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                        LoadTDBGrid(true, txtPriceListID.Text);
                        break;
                    case EnumFormState.FormEdit:
                        LoadTDBGrid(false, txtPriceListID.Text);
                        break;
                }
                if (isNext == true)
                {
                    isNext = false;
                    return true;
                }
                SetReturnFormView();
            }
            else
            {
                Lemon3.Messages.L3Msg.SaveNotOK();
                return false;
            }
            return true;
        }
        private bool AllowSave()
        {
            
            if (txtPriceListID.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblPriceListID.Content.ToString());
                txtPriceListID.Focus();
                return false;
            }
            if (_formState == EnumFormState.FormAdd)
            {
                if (CheckPriceListID() == false)
                {
                    return false;
                }
            }
            
            if (txtPriceListName.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblPriceListName.Content.ToString());
                txtPriceListName.Focus();
                return false;
            }

            if (dateValidFrom.EditValue.ToString() == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(L3Resource.rL3("Ban_phai_nhap_Ngay_hieu_luc_tu"));
                dateValidFrom.Focus();
                return false;
            }
          

            return true;

        }
        private void SetReturnFormView()
        {
            _formState = EnumFormState.FormView;
            EnableMenu(false);
            btnNext.IsEnabled = false;
            if (tdbg.VisibleRowCount == 0)
            {
                L3Control.ClearTextALL(tdbgD);
            }
            else
            {
                LoadEdit();
                tdbg.Focus();
            }
            LockControl(true);
        }
        private void grpheader_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GridSplitter_PreviewMouseDown(null,null);
        }

        private void tdbgDView_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            if (tdbgDView.FocusedRowHandle < 0||  tdbgD.VisibleRowCount < 2)
            {
                SttProductID.Content = "";
                SttProductName.Content = "";
                return;

            }else
            {
                SttProductID.Content = L3ConvertType.L3String(tdbgD.GetFocusedRowCellValue(COLD_ProductID));
                SttProductName.Content = L3ConvertType.L3String(tdbgD.GetFocusedRowCellValue(COLD_ProductName)); 
            }      
        }
        private string SQLStoreD45P5555(string cap, int mode)
        {
            string sSQL = cap + Environment.NewLine;
            sSQL += "EXEC D45P5555" + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + "," ;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + ",";
            sSQL += L3SQLClient.SQLString(L3.TranYear) + ",";
            sSQL += L3SQLClient.SQLString("84") + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + ",";
            sSQL += L3SQLClient.SQLNumber(mode) + ",";
            sSQL += L3SQLClient.SQLString("D45F1150") + ",";
            sSQL += L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_PriceListID).ToString()) + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLNumber(0) ;

            return sSQL;
        }
       private Boolean CheckPriceListID()
        {
            string sSQL = "--- Kiem tra trung ma bang gia"+ Environment.NewLine;
            sSQL += "SELECT TOP 1 CASE WHEN PriceListID =  "+L3SQLClient.SQLString(txtPriceListID.Text) + Environment.NewLine;
            sSQL += "THEN 1 ELSE 0 END AS STATUS FROM D45T1020 ORDER BY STATUS DESC";

            DataTable dt = L3SQLServer.ReturnDataTable(sSQL);
            if (dt.Rows.Count < 1)
            {
                return true;
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    L3Msg.MyMsg(L3Resource.rL3("Ma_da_bi_trung"));
                    return false;
                }
            }

            return true;
        }
        private string  SQLInsertD45T1020()
       {
            string sSQL = "---Lưu vào bảng giá" + Environment.NewLine;
            sSQL += "INSERT INTO D45T1020 "+Environment.NewLine;
            sSQL += "(PriceListID, PriceListNameU, DateFrom, DateTo, ValidFrom, ValidTo, NoteU, Disabled, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate,BlockID,IsCondition) "+Environment.NewLine;
            sSQL += "VALUES "+Environment.NewLine;
            sSQL+=  "(" ;
            sSQL += L3SQLClient.SQLString(txtPriceListID.Text) + ",";
            sSQL += "N"+L3SQLClient.SQLString(txtPriceListName.Text) + ",";
            sSQL += "GetDate()" + ",";
            sSQL += "GetDate()" + ",";
            sSQL += L3SQLClient.SQLDateSave(dateValidFrom.EditValue) + ",";
            sSQL += L3SQLClient.SQLDateSave(dateValidTo.EditValue) + ",";
            sSQL += "N" + L3SQLClient.SQLString(txtNote.Text) + ",";
            sSQL += L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkDisabled.IsChecked))+ ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += "GetDate()" + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += "GetDate()" + ",";
            sSQL += L3SQLClient.SQLString(tdbcBlockID.ReturnValue("BlockID")) + ",";
            sSQL += L3SQLClient.SQLNumber(1);
            sSQL += ")";

            return sSQL;
       }

        private string SQLStoreD45P1150(string tran,string type)
        {

            string sSQL = "---lưu dữ liệu" + Environment.NewLine;
            sSQL += "EXEC D45P1150 " +Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString(Environment.NewLine) + ",";
            sSQL += L3SQLClient.SQLString("1") + ",";
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + ",";
            sSQL += L3SQLClient.SQLString(tran) + ",";
            sSQL += L3SQLClient.SQLString(type) + ",";
            sSQL += L3SQLClient.SQLString(txtPriceListID.Text) ;
            return sSQL;
        }

        private string SQlStoreD91P9106(string cap, string events)
        {
            string sSQL = "--"+cap + Environment.NewLine;
             sSQL +="EXEC D91P9106" +Environment.NewLine;
             sSQL += "Null" + ",";
             sSQL += L3SQLClient.SQLString("PriceLists") + ",";
             sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
             sSQL += L3SQLClient.SQLString("45") + ",";
             sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
             sSQL += L3SQLClient.SQLString(events) + ",";
             sSQL += "N"+ L3SQLClient.SQLString(txtPriceListID.Text) + ",";
             sSQL += "N" + L3SQLClient.SQLString(txtPriceListName.Text) + ",";
             sSQL += "N" + L3SQLClient.SQLDateSave(dateValidFrom.EditValue) + ",";
             sSQL += "GetDate" + ",";
             sSQL += "N" + L3SQLClient.SQLString("") + ",";
             sSQL += L3SQLClient.SQLNumber(0) + ",";
             sSQL += L3SQLClient.SQLString("") ;
             return sSQL;
        }
        private string SQLUpdateD45T1020()
        {
            string sSQL = "--Lưu cập nhật vào bảng giá: " + Environment.NewLine;
            sSQL += "UPDATE D45T1020" +Environment.NewLine;
            sSQL += "SET"  + Environment.NewLine;
            sSQL += "PriceListName =" + L3SQLClient.SQLString(txtPriceListName.Text) + "," + Environment.NewLine;
            sSQL += "PriceListNameU = " + "N" + L3SQLClient.SQLString(txtPriceListName.Text) + "," + Environment.NewLine;
            sSQL += "Note =" + L3SQLClient.SQLString(txtNote.Text) + "," + Environment.NewLine;
            sSQL += "NoteU = " + "N" + L3SQLClient.SQLString(txtNote.Text) + "," + Environment.NewLine;
            sSQL += "Disabled =" + L3SQLClient.SQLNumber(L3ConvertType.L3Int(chkDisabled.IsChecked)) + "," + Environment.NewLine;
            sSQL += "LastModifyUserID = " + L3SQLClient.SQLString(L3.UserID) + "," + Environment.NewLine;
            sSQL += "LastModifyDate =" + "GetDate()" + "," + Environment.NewLine;
            sSQL += "BlockID =" + L3SQLClient.SQLString(tdbcBlockID.ReturnValue("BlockID")) + "," + Environment.NewLine;
            sSQL += "ValidFrom =" + L3SQLClient.SQLDateSave(dateValidFrom.EditValue) + "," + Environment.NewLine;
            sSQL += "ValidTo =" + L3SQLClient.SQLDateSave(dateValidTo.EditValue) + Environment.NewLine; 
            sSQL += "WHERE  PriceListID = " + L3SQLClient.SQLString(txtPriceListID.Text);

            return sSQL;
        }
        private string DeletePriceList()
        {
            string sSQL = "-- Xoa du lieu cua bang gia" + Environment.NewLine;
            sSQL += "DELETE D45T1021 WHERE PriceListID =" + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_PriceListID)) + Environment.NewLine;
            sSQL += "DELETE D45T1020 WHERE PriceListID =" + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_PriceListID)) + Environment.NewLine;
            sSQL += "DELETE D45T1024 WHERE PriceListID =" + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_PriceListID)) + Environment.NewLine;

            return sSQL;
        }

        private void tdbgDView_ValidateCell(object sender, GridCellValidationEventArgs e)
        {
            //TableView view = sender as TableView;
            //TextEdit edit = view.ActiveEditor as TextEdit;
            //if (edit.Text == "") return;
            switch (e.Column.FieldName)
            {
                case "ProductID":
            //        int duplicate = dtGridD.AsEnumerable().Where(w => w["ProductID"].ToString() == edit.Text).Count();
            //        if (duplicate > 0)
            //        {
            //            D99D0041.D99C0008.MsgDuplicatePKey();
            //            tdbgD.SetFocusedRowCellValue(COLD_ProductName, "");
            //            e.IsValid = false;
            //        }
            //        else
                        tdbgD.SetFocusedRowCellValue(COLD_ProductName, tdbdProductID.ReturnValue("ProductName"));
                    break;
                default:
                    break;
            }
        }

        private void btnConditionList_Click_1(object sender, RoutedEventArgs e)
        {
            D45F1140 f = new D45F1140();
            L3Window.CallWindowDialogFromPage(f);
            LoadTDBGDetail();
        }

        private void tdbgDView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (_formState == EnumFormState.FormEdit && !_bEdit)
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
        DataTable dtCoppy = null;
        private void tdbgDView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (_formState == EnumFormState.FormEdit && !_bEdit)
            {

                if (e.Key == Key.Delete)
                {
                    if (tdbgDView.FocusedRowHandle <= _originRowCount - 1 && tdbgDView.FocusedRowHandle>=0)
                    {
                        return;
                    }
                    else
                    {
                        if(tdbgDView.FocusedRowHandle<0)
                        {
                            tdbgDView.DeleteRow(_originRowCount);
                            tdbgDView.FocusedRowHandle = _originRowCount - 1;
                            
                        }
                        else
                        {
                            int index = tdbgDView.FocusedRowHandle;
                            tdbgDView.DeleteRow(tdbgDView.FocusedRowHandle);
                            tdbgDView.FocusedRowHandle = index - 1;
                        }            
                    }
                }

            }
            else
            {
                if (e.Key == Key.Delete)
                {
                    int index = tdbgDView.FocusedRowHandle;
                    tdbgDView.DeleteRow(tdbgDView.FocusedRowHandle);
                    tdbgDView.FocusedRowHandle = index - 1;
                }
            }
            //if (tdbgDView.AllowEditing == false)
            //{
            //    return;
            //}
            //dtCoppy.Clear();
            //bool bIsKeyCtrlDown = false;
            //bool bIsKey1Down = false;
            //bool bIsKey2Down = false;
            //if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) bIsKeyCtrlDown = true;
            //// Key combination
            //if (Keyboard.IsKeyDown(Key.C)) bIsKey1Down = true;
            //if (Keyboard.IsKeyDown(Key.V)) bIsKey2Down = true;
            //// Handler
            //if (bIsKeyCtrlDown)
            //{
            //    if (bIsKey1Down)
            //    {
            //            foreach (DataRowView item in tdbg.SelectedItems)
            //            {
            //                DataRow dr = (DataRow)item.Row;
            //                DataRow dr1 = null;
                           
            //                dtCoppy.Rows.Add(dr1);
            //            }
            //        L3Msg.MyMsg("Copped!");
            //    }
            //    else if (bIsKey2Down)
            //    {
            //        foreach (DataRow dr in dtCoppy.Rows)
            //        {
            //            dtGridD.Rows.Add(dr);
            //        }
            //        L3Msg.MyMsg("Pasted!");
            //    }
            //}
        }

        private void tdbgD_KeyDown(object sender, KeyEventArgs e)
        {
            if (_formState == EnumFormState.FormEdit && !_bEdit)
            {

                if (e.Key == Key.Delete)
                {
                    if (tdbgDView.FocusedRowHandle <= _originRowCount - 1)
                    {
                        return;
                    }
                }

            }
        }

      
    }
}
