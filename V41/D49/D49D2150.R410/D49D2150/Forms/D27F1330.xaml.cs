using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Reports;
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
using D27D1750.Forms;
using Lemon3.Data;
using System.Windows.Threading;
using DevExpress.Xpf.Grid;

namespace D27D1750
{
    /// <summary>
    /// Interaction logic for D27F1330.xaml
    /// </summary>
    public partial class D27F1330 : L3Page
    {
        private string _TypeID = "";
        private string _VoucherID = "";
        private string _CodeID = "";
        private string _FormID = "D27F1330";
        private string _ModuleID = "27";


        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        private L3CrystalReport crystalReport;
        public string FormID
        {
            set
            {
                _FormID = value;
            }
            get { return _FormID; }
        }
        public string ModuleID
        {
            set
            {
                _ModuleID = value;
            }
            get { return _ModuleID; }
        }
        public string VoucherID
        {
            set
            {
                _VoucherID = value;
            }
            get { return _VoucherID; }
        }

        public D27F1330()
        {
            InitializeComponent();
        }
        public override void SetContentForL3Page()
        {
        }

        //private iPer 
        private DataTable dtGrid = null;
        private bool _bSaved = false;
        private bool _bLoadFormState = false;
        private EnumFormState _formState = EnumFormState.FormView;
        private int iPerD27D1750 = -1;

        public EnumFormState FormState
        {
            set
            {
                _formState = value;
                _bLoadFormState = true;
                //iPerF2040 = L3Permissions.ReturnPermission(this.GetType().Name);
                LoadTBDCombo();
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                        LoadAdd();
                        break;
                    case EnumFormState.FormEdit:
                        LoadEdit();
                        break;
                    case EnumFormState.FormView:
                        LoadEdit();
                        break;
                    default:
                        break;
                }
            }
        }

        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            LoadExt();
            if (!_bLoadFormState) FormState = _formState;
            LoadLanguage();
            tdbg.SetDefaultGridControlInquiry();
            L3Control.SetShortcutPopupMenu(MainMenuControl1, ContextMenu1);
            this.SetBackColorObligatory(new Control[] { tdbcInforEmailID }, null);          
            btnSave.SetImage(ImageType.Save);
            btnNotSave.SetImage(ImageType.NotSave);
            L3SimpleButton.SetImage(btnNotSave, null, btnNotSave);         
            ResetGrid();
            LoadTDBGrid();
            this.Cursor = Cursors.Arrow;
            
        }
        private void LoadExt()
        {
            iPerD27D1750 = L3Permissions.ReturnPermission("D27F1330");
        }

        private void LoadLanguage()
        {
            this.Title = Lemon3.Resources.L3Resource.rL3("Thong_tin_gui_mailU") + " - D27F1330";
            COL_InforEmailID.Header = Lemon3.Resources.L3Resource.rL3("Loai_nghiep_vu");
            COL_Subject.Header = Lemon3.Resources.L3Resource.rL3("Tieu_deU");
            COL_OrderNo.Header = Lemon3.Resources.L3Resource.rL3("STTU");
            GroupDetail.Header = Lemon3.Resources.L3Resource.rL3("Chi_tiet");

            lblInforEmailID.Content   = Lemon3.Resources.L3Resource.rL3("Loai_nghiep_vu");
            lblReportID.Content  = Lemon3.Resources.L3Resource.rL3("Mau_file_dinh_kemU");
            lblSubject.Content    = Lemon3.Resources.L3Resource.rL3("Tieu_deU");
            lblContent.Content = Lemon3.Resources.L3Resource.rL3("Noi_dung");

            btnChoose.Content  =Lemon3.Resources.L3Resource.rL3("Chon_tham_so");
            btnSave.Content   =Lemon3.Resources.L3Resource.rL3("LuuU");
            btnNotSave.Content = Lemon3.Resources.L3Resource.rL3("Khong_luuU");
        }

        private void LoadAdd()
        {
            _formState = EnumFormState.FormAdd;
            _bSaved = false;
            tdbcInforEmailID.IsReadOnly = false;
       
            tdbcInforEmailID.EditValue = "";
            tdbcReportID.EditValue = "";
            txtContent.EditValue = "";
            txtReportName.EditValue = "";
            txtSubject.EditValue = "";

            tdbcInforEmailID.Focus();
        }
        private void LoadEdit()
        {
            if (tdbg.VisibleRowCount < 1) return;
            if (tdbgView.FocusedRowHandle == L3GridControl.AutoFilterRowHandle) return;
            tdbcInforEmailID.EditValue = tdbg.GetFocusedRowCellValue(COL_InforEmailID);
            tdbcReportID.EditValue = tdbg.GetFocusedRowCellValue(COL_ReportID);
            txtContent.EditValue = tdbg.GetFocusedRowCellValue(COL_Content);           
            txtSubject.EditValue = tdbg.GetFocusedRowCellValue(COL_Subject);
            tdbcInforEmailID.IsReadOnly = true;
            //L3Control.ReadOnlyControl(true, new DependencyObject[] { txtVoucherNo });
        }

        private void LoadtdbcReportID()
        {
            if (tdbcInforEmailID.ReturnValue("IsSelectFile")=="0")
            {
                tdbcReportID.IsEnabled = false;
                tdbcReportID.EditValue = null;
                txtReportName.EditValue = "";
                tdbcReportID.Background=Brushes.White;
            }
            if (tdbcInforEmailID.ReturnValue("IsSelectFile") == "1")
            {
                this.SetBackColorObligatory(new Control[] { tdbcReportID }, null);  
                tdbcReportID.IsEnabled = true;
                L3DataSource.LoadDataSource(tdbcReportID, SqlStoreD89P9105());
            }
            
        }
        private string SqlStoreD89P9105()
        {
            string sSQL = "--Combo Mau file dinh kem" + Environment.NewLine;
            sSQL += "Exec D89P9105 '" + tdbcInforEmailID.ReturnValue("ReportTypeID") + "','" + tdbcInforEmailID.ReturnValue("ModuleID") + "','84','" + L3.UserID + "',1";
            return sSQL;
        }
        private void LoadTBDCombo()
        {
            String sSQL = "-- Combo Loai nghiep vu"+Environment.NewLine;
            sSQL += "SELECT	ID AS InforEmailID, Name84U AS InforEmailName, CONVERT(TINYINT,Num01) AS IsSelectFile, Str01 AS ReportTypeID, Str02 AS ModuleID ";
            sSQL += "FROM	D27N5555 ('" + _FormID + "','InforEmail','" + _ModuleID + "', '', '', '')	ORDER BY	OrderNo";

       
            L3DataSource.LoadDataSource(tdbcInforEmailID, sSQL);
          
        }
        private string SQLSelect()
        {
            String sSQL = "--Danh sach thong tin gui mail"+Environment.NewLine;
            sSQL += "SELECT T1.InforEmailID, T2.Name84U AS InforEmailName,T1.Subject, T1.Content, T1.ReportID ";
            sSQL += "FROM		D27T1330 T1 WITH (NOLOCK) ";
            sSQL += "INNER JOIN 	D27N5555 ";
            sSQL += "('" + _FormID + "', 'InforEmail','" + _ModuleID + "', '', '', '') T2";
            sSQL += " ON	T1.InforEmailID = T2.ID";	//AND T1.ModuleID = T2.Str02";

            return sSQL;
        }
        private string SqlStoreD27P5555()
        {
            string _mode = "";
            if(_formState==EnumFormState.FormAdd)
            {
                _mode = "A";
            }
            if (_formState == EnumFormState.FormEdit)
            {
                _mode = "E";
            }
            string sSQL = "--Kiem tra truoc khi luu"+Environment.NewLine;
            sSQL += "EXEC D27P5555 '"+ L3.DivisionID+"','"+L3.TranMonth+"','"+L3.TranYear+"','"+L3.STRLanguage+"','";    
            sSQL += L3.UserID + "','" + Environment.MachineName+"','"+_mode+"','"+_FormID+"','"+_CodeID+"','"+_ModuleID+"',";
            sSQL += L3SQLClient.SQLString(tdbcInforEmailID.ReturnValue("InforEmailID")) + "," + L3SQLClient.SQLString(tdbcReportID.ReturnValue("ReportID"));
            return sSQL;
        }
        private string SQLDeleteD27T1330()
        {
            string sSQL = "DELETE FROM D27T1330 WHERE InforEmailID ="+ L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_InforEmailID)) +" AND ModuleID = "+L3SQLClient.SQLString(_ModuleID);
            return sSQL;
        }
        private string SQLInsertD27T1330()
        {
            string sSQL ="--Luu thiet lap thong tin gui mail"+Environment.NewLine  + "BEGIN TRAN  ";
            sSQL += "DELETE FROM D27T1330 WHERE InforEmailID ="+ L3SQLClient.SQLString(tdbcInforEmailID.ReturnValue("InforEmailID")) +" AND ModuleID = "+L3SQLClient.SQLString(_ModuleID)+Environment.NewLine;
            sSQL +="  INSERT INTO D27T1330 (InforEmailID, ModuleID, ReportID, Subject, Content)"+Environment.NewLine;
            sSQL +="VALUES ('"+tdbcInforEmailID.ReturnValue("InforEmailID")+"','"+ _ModuleID +"','"+ tdbcReportID.ReturnValue("ReportID")+"',N'";
            sSQL += txtSubject.Text +"',N'"+ txtContent.Text+"')";
            sSQL += "  COMMIT TRAN";
            return sSQL;
        }
        private string SQLEditD27T1330()
        {
            string sSQL = "--Luu thiet lap thong tin gui mail" + Environment.NewLine + "BEGIN TRAN  ";
            sSQL += "DELETE FROM D27T1330 WHERE InforEmailID =" + L3SQLClient.SQLString(tdbcInforEmailID.ReturnValue("InforEmailID")) + " AND ModuleID = " + L3SQLClient.SQLString(_ModuleID) + Environment.NewLine;
            sSQL += "  INSERT INTO D27T1330 (InforEmailID, ModuleID, ReportID, Subject, Content)" + Environment.NewLine;
            sSQL += "VALUES ('" + tdbcInforEmailID.ReturnValue("InforEmailID") + "','" + _ModuleID + "','" + tdbcReportID.ReturnValue("ReportID") + "',N'";
            sSQL += txtSubject.Text + "',N'" + txtContent.Text + "')";
            sSQL += "  COMMIT TRAN";
            return sSQL;
        }

        private void LoadTDBGrid(bool IsAdd = true, string sKey = "")
        {
            if (IsAdd) tdbg.ListAll();
            tdbg.SetColumnOrderNum(COL_OrderNo);
            dtGrid = null;
            dtGrid = L3SQLServer.ReturnDataTable(SQLSelect());
            L3DataSource.LoadDataSource(tdbg, dtGrid);
            ReLoadTDBGrid();
            if (sKey != "")
            {
                int row = tdbg.FindRowByValue(COL_InforEmailID, sKey);
                if (row >= 0) tdbg.FocusRowHandle(row);
            }
        }
        private void ReLoadTDBGrid()
        {

            if (_formState == EnumFormState.FormAdd)
                return;

            if (tdbg.VisibleRowCount == 0)
            {
                L3Control.ClearTextALL(GridD);
            }
            else
            {
                _formState = EnumFormState.FormView;
                LoadEdit();
            }
            ResetGrid();
        }
        private void ResetGrid()
        {
            EnableMenu(false);
        }
        private void EnableMenu(bool bEnabled)
        {
            btnSave.IsEnabled = bEnabled;
            btnNotSave.IsEnabled = bEnabled;
            btnChoose.IsEnabled = bEnabled && iPerD27D1750>1;
            tdbg.IsEnabled = !bEnabled;                                
            if (!bEnabled)
            {
                L3Control.CheckMenu(this.GetType().Name, MainMenuControl1, ContextMenu1, tdbg.VisibleRowCount, true, false);
            }
            else
            {
                L3Control.CheckMenu("-1", MainMenuControl1, ContextMenu1, -1, false, false);
            }

           // CheckMenuOthers();
        }
        private void InsertText(L3TextEdit txt, string _CodeID)
        {
            var selectionIndex = txt.SelectionStart;
                txt.Text = txt.Text.Insert(selectionIndex, _CodeID);
                txt.SelectionStart = selectionIndex + _CodeID.Length;
        }
        private L3TextEdit lastControl = null;
        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if(tdbcInforEmailID.Text=="")
            {
                Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_loai_nghiep_vu"));
            } else
            {             
                D27D1330DSTS frm = new D27D1330DSTS();
                frm.InforEmailID = tdbcInforEmailID.ReturnValue("InforEmailID");
                frm.FormID = _FormID;
                frm.ModuleID = _ModuleID;
                frm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                frm.ShowDialog();
                _CodeID = frm.CodeID;
              if (  lastControl == null || lastControl.Name == txtContent.Name)
               {
                    InsertText(txtContent, _CodeID);
              }
                   else
                   {
                  InsertText(txtSubject, _CodeID);
                   }
               }
               
            }

      

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (!btnSave.Focusable) return;
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No) return;
            SaveData(sender);
        }
        private bool SaveData(System.Object sender)
        {
            _bSaved = false;
            if (!AllowSave())
                return false;
            this.Cursor = Cursors.Wait;
            StringBuilder sSQL = new StringBuilder();

            switch (_formState)
            {
                case EnumFormState.FormAdd:
                    sSQL.Append(SQLInsertD27T1330());
                    break;
                case EnumFormState.FormEdit:
                    sSQL.Append(SQLEditD27T1330());
                    break;
            }

            bool bRunSQL = false;
            bRunSQL = L3SQLServer.ExecuteSQL(sSQL.ToString());
            this.Cursor = Cursors.Arrow;
            if (bRunSQL)
            {
                Lemon3.Messages.L3Msg.SaveOK();
                tdbcInforEmailID.IsReadOnly = true;
                _bSaved = true;
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                        LoadTDBGrid(true, tdbcInforEmailID.ReturnValue("InforEmailID"));
                        break;
                    case EnumFormState.FormEdit:
                        LoadTDBGrid(false, tdbcInforEmailID.ReturnValue("InforEmailID"));
                        break;
                }
                //L3Control.ReadOnlyControl(true, new DependencyObject[] { txtVoucherNo });
                SetReturnFormView();
            }
            else
            {
                Lemon3.Messages.L3Msg.SaveNotOK();
                return false;
            }
            return true;
        }
        private void SetReturnFormView()
        {
            _formState = EnumFormState.FormView;
            EnableMenu(false);
            tdbcInforEmailID.IsReadOnly = true;
            if (tdbg.VisibleRowCount == 0)
            {
                L3Control.ClearTextALL(GridD);
            }
            else
            {
                LoadEdit();
                tdbg.Focus();
            }
        }
        private bool AllowSave()
        {
            if (tdbcInforEmailID.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblInforEmailID.Content.ToString());
                tdbcInforEmailID.Focus();
                return false;
            }
            if (tdbcReportID.IsEnabled == true)
            {
                if (tdbcReportID.Text == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(lblReportID.Content.ToString());
                    tdbcReportID.Focus();
                    return false;
                }
            }
            if (!L3SQLServer.CheckStore(SqlStoreD27P5555()))
            {                              
                return false;
            }
            return true;
         
        }

        private void tsbEdit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            _formState = EnumFormState.FormEdit;
            tdbcInforEmailID.IsReadOnly = true;
            EnableMenu(true);            
            if(tdbcReportID.IsEnabled==false)
            {
                txtSubject.Focus();
            }else
            {
                tdbcReportID.Focus();
            }
            
        }

        private void tsbAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            LoadAdd();
            EnableMenu(true);
        }

        private void tsbDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
            bool bRunSQL = L3SQLServer.ExecuteSQLNoTransaction(SQLDeleteD27T1330());
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

        private void tsbFind_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
           
        }

        private void tsbListAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
           // L3Window.ShowSysInforForm(tdbg);
            tdbg.ListAll();
        }

        private void mnsAdd_Click(object sender, RoutedEventArgs e)
        {
            tsbAdd_ItemClick(null, null);
        }

        private void mnsEdit_Click(object sender, RoutedEventArgs e)
        {
            tsbEdit_ItemClick(null, null);
        }

        private void mnsDelete_Click(object sender, RoutedEventArgs e)
        {
            tsbDelete_ItemClick(null, null);
        }

     

        private void mnsListAll_Click(object sender, RoutedEventArgs e)
        {
            tsbListAll_ItemClick(null,null);
        }

        private void btnNotSave_Click(object sender, RoutedEventArgs e)
        {
            if (_formState == EnumFormState.FormAdd && tdbcInforEmailID.Text == "")
            {
                if (tdbg.VisibleRowCount > 0)
                {
                    LoadEdit();
                }
                goto one;
            }
            if (Lemon3.Messages.L3Msg.AskMsgBeforeRowChange())
            {
                if (!SaveData(sender))
                    return;
            }
            else
            {
                tdbcInforEmailID.IsReadOnly = true;
                LoadEdit();
            }
        one:
            SetReturnFormView();
        }

        private void tdbg_FilterChanged(object sender, RoutedEventArgs e)
        {
            tdbg.FocusRowHandle(tdbg.GetRowHandleByVisibleIndex(0));

            try
            {
                if ((dtGrid == null))
                    return;
                ReLoadTDBGrid();

            }
            catch (Exception ex)
            {

            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                tdbgView.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                tdbgView.FocusedColumn = tdbg.CurrentColumn as GridColumn;
                tdbgView.ShowEditor();
            }), DispatcherPriority.Render);

        }

        private void tdbg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!tdbg.CheckDoubleClickInRow(e)) return;
            this.Cursor = Cursors.Wait;
            if (tsbEdit.IsEnabled)
            {
                tsbEdit_ItemClick(sender, null);
            }
            this.Cursor = Cursors.Arrow;
        }

        private void tdbgView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            LoadEdit();
            //CheckMenuOthers();
        }

       

        private void tdbcInforEmailID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (tdbcInforEmailID.EditValue == "")
            {
                tdbcReportID.IsEnabled = false;
                tdbcReportID.Background = null;
                txtReportName.EditValue = "";
            }
                LoadtdbcReportID();
            
        }

        private void tdbcReportID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (tdbcReportID.EditValue == "" || tdbcReportID.EditValue == null)
            {
                txtReportName.Text = "";
            }
            else
            {                
                txtReportName.EditValue = tdbcReportID.ReturnValue("ReportName");
            }
        }

        private void txtSubject_GotFocus(object sender, RoutedEventArgs e)
        {
            lastControl = (L3TextEdit)sender;
        }
               
    } 
}
