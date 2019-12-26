
using D45D0180.Forms;
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

namespace D45D0180
{
   
    /// <summary>
    /// Interaction logic for D45F1140.xaml
    /// </summary>
    public partial class D45F1140 : L3Page
    {
        private bool _bLoadFormState = false;
        private DataTable dtGrid = null;

        private bool _bSaved = false;
        public bool bSaved
        {
            get { return _bSaved; }
        }
        public D45F1140()
        {
            InitializeComponent();
            this.Title = L3Resource.rL3("Danh_muc_dieu_kien") + " - D45F1140";
        }
        public override void SetContentForL3Page()
        {

        }
        
        private Lemon3.EnumFormState _formState = Lemon3.EnumFormState.FormView;
       
    
        private void L3Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
          

            txtConditionID.CheckIdTextBox();
            tdbg.SetDefaultGridControlInquiry();
            L3Control.SetShortcutPopupMenu(MainMenuControl1, ContextMenu1);
            this.SetBackColorObligatory(new Control[] { txtConditionID,tdbcCode,txtDescription }, null);
            btnSave.SetImage(ImageType.Save);
            btnNotSave.SetImage(ImageType.NotSave);
            btnNext.SetImage(ImageType.Next);
            tdbg.SetColumnOrderNum(COL_OrderNo);

            tsbAdd.IsEnabled =  L3Permissions.ReturnPermission("D45F1140") >= 2;
            //tsbEdit.IsEnabled =   L3Permissions.ReturnPermission("D45F1140") > 3;
            //tsbDelete.IsEnabled = L3Permissions.ReturnPermission("D45F1140") > 4;
            mnsAdd.IsEnabled = L3Permissions.ReturnPermission("D45F1140") >= 2;
            //mnsEdit.IsEnabled = L3Permissions.ReturnPermission("D45F1140") > 3;
            //mnsDelete.IsEnabled = L3Permissions.ReturnPermission("D45F1140") > 4;

            //ResetGrid();
            LoadTDBGrid();
            LoadTDBCombo();
            LoadLanguage();
            LockControl(true);

            
            tdbgView.ShowGroupPanel = false;
            this.Cursor = Cursors.Arrow;
            
        }
        private void LockControl(Boolean bLock)
        {
            txtConditionID.IsReadOnly = bLock;
            txtDescription.IsReadOnly = bLock;
            txtNotes.IsReadOnly = bLock;
            chkDisabled.IsReadOnly = bLock;
            tdbcCode.IsReadOnly = bLock;
           
        }
        private void ResetGrid()
        {
            EnableMenu(false);
        }

        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Danh_muc_dieu_kien") + " - D45F1140";
            COL_OrderNo.Header = L3Resource.rL3("STT");
            COL_CODE.Header = L3Resource.rL3("Ma_loai_dieu_kienU");
            COL_Name.Header = L3Resource.rL3("Ten_loai_dieu_kien");
            COL_NameT.Header = L3Resource.rL3("Ten_tat");
            COL_ConditionID.Header = L3Resource.rL3("Ma_dieu_kienU");
            COL_Description.Header = L3Resource.rL3("Dien_giai");
            COL_Notes.Header = L3Resource.rL3("Ghi_chu");
            COL_Disabled.Header = L3Resource.rL3("KSDU");
            lblConditionID.Content = L3Resource.rL3("Ma_dieu_kien");
            lblDescription.Content = L3Resource.rL3("Dien_giai");
            chkDisabled.Content = L3Resource.rL3("Khong_su_dungU");
            lblCode.Content = L3Resource.rL3("Ma_loai_dieu_kienU");
            lblNotes.Content = L3Resource.rL3("Ghi_chu");
            btnSave.Content = L3Resource.rL3("Luu");
            btnNext.Content = L3Resource.rL3("Luu___Nhap_tiep");
            btnNotSave.Content = L3Resource.rL3("Khong_luu");
            chkViewDisable.Content = L3Resource.rL3("Hien_thi_du_lieu_KSD");
            tdbcCode.SetCaptionColumn("CodeW", L3Resource.rL3("Ten"));
            tdbcCode.SetCaptionColumn("Name", L3Resource.rL3("Ten_loai_dieu_kien"));
            grpheader.Text = L3Resource.rL3("Chi_tiet");
        }

        private void LoadTDBCombo()
        {
            string sSQL = "-- Do nguon cho combo" + Environment.NewLine;

            sSQL += "SELECT 	CODE, CodeW, CASE WHEN "+L3SQLClient.SQLString(L3.STRLanguage) +"= '84' THEN Name ELSE Name01 END AS Name" + Environment.NewLine;
            sSQL += "FROM 		D45T0030 WITH(NOLOCK) " + Environment.NewLine;
            sSQL += "WHERE 		Disabled = 1" + Environment.NewLine;
            sSQL += "ORDER BY	OrderNum " + Environment.NewLine;
            System.Data.DataTable dt = L3SQLServer.ReturnDataTable(sSQL);

            L3DataSource.LoadDataSource(tdbcCode,dt);
        }

        private void LoadTDBGrid(bool IsAdd = true, string sKey = "")
        {
            if (IsAdd) tdbg.ListAll();
            tdbg.SetColumnOrderNum(COL_OrderNo);
            dtGrid = null;
            dtGrid = L3SQLServer.ReturnDataTable(SQLStoreD45P1140());
            L3DataSource.LoadDataSource(tdbg, dtGrid);
            if(chkViewDisable.IsChecked==true)
            {                
            }
            else
            {
                L3DataSource.LoadDataSource(tdbg, L3DataTable.ReturnTableFilter(dtGrid, "Disabled = 0"), L3.IsUniCode);
            }
           
            //L3DataSource.LoadDataSource(tdbg, dtGrid);
            
            ReLoadTDBGrid();
            if (sKey != "")
            {
                int row = tdbg.FindRowByValue(COL_ConditionID, sKey);
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
        private  void LoadNullGrid(Boolean bNull)
        {
            tsbEdit.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1140") >= 3;
            tsbDelete.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1140") >= 4;             
            mnsDelete.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1140") >= 4;
            mnsEdit.IsEnabled = !bNull && L3Permissions.ReturnPermission("D45F1140") >= 3;          
        }
        private string SQLStoreD45P1140()
        {
            string sSQL = "--- Do nguon cho luoi truy van dieu kien" +Environment.NewLine;

            sSQL += "EXEC D45P1140"+ Environment.NewLine;
           
            sSQL += L3SQLClient.SQLString(L3.DivisionID) +","+ Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.UserID) + "," + Environment.NewLine;
            sSQL += L3SQLClient.SQLString("D45F1140") + "," + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + "," + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.IsUniCode)  + Environment.NewLine;
           

            return sSQL;
        }

        private void LoadEdit()
        {
            if (tdbg.VisibleRowCount <1)
            {
                return;
            }             
            txtConditionID.Text = tdbg.GetFocusedRowCellValue(COL_ConditionID).ToString();
            tdbcCode.EditValue = tdbg.GetFocusedRowCellValue(COL_CODE).ToString();
            txtDescription.EditValue = tdbg.GetFocusedRowCellValue(COL_Description).ToString();
            txtNotes.EditValue = tdbg.GetFocusedRowCellValue(COL_Notes).ToString();
            chkDisabled.IsChecked = tdbg.GetFocusedRowCellValue(COL_Disabled).ToString() == "1";

            btnSave.IsEnabled = false;
            btnNext.IsEnabled = false;
            btnNotSave.IsEnabled = false;
        }
        
        private void EnableMenu(bool bEnable)
        {
            btnSave.IsEnabled = bEnable;
            btnNext.IsEnabled = bEnable;
            btnNotSave.IsEnabled = bEnable;
            tdbg.IsEnabled = !bEnable;
            //GroupDetail.IsEnabled = bEnable;
            chkViewDisable.IsEnabled = !bEnable;

            tsbAdd.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1140") >= 2 ;
            tsbEdit.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1140") >= 3;
            tsbDelete.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1140") >= 4;
            mnsAdd.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1140") >= 2;
            mnsEdit.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1140") >= 3;
            mnsDelete.IsEnabled = !bEnable && L3Permissions.ReturnPermission("D45F1140") >= 4;
            
            //if (!bEnable)
            //{
            //    L3Control.CheckMenu(this.GetType().Name, MainMenuControl1, ContextMenu1, tdbg.VisibleRowCount, true, false);
            //}
            //else
            //{
            //    L3Control.CheckMenu("-1", MainMenuControl1, ContextMenu1, -1, false, false);
            //}

        }
        
        private void LoadAdd()
        {
  
            _formState = Lemon3.EnumFormState.FormAdd;
            _bSaved = false;
            ClearTextALL();
            txtConditionID.Focus();

            LockControl(false);
            tdbg.IsEnabled = false;

        }

        private void ClearTextALL()
        {
         	txtConditionID.Text="";
            txtNotes.Text="";
            txtDescription.Text="";
            chkDisabled.IsChecked=false;
            tdbcCode.EditValue="";
        }
        private void tsbAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            LoadAdd();
            EnableMenu(true);

        }
        private void tsbEdit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            _formState = EnumFormState.FormEdit;
            
            EnableMenu(true);
            btnNext.IsEnabled = false;
            LockControl(false);
            txtConditionID.IsReadOnly = true;
            tdbcCode.IsReadOnly = true;
        }

        private void tsbDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (!L3SQLServer.CheckStore(SQLStoreD45P5555("-- Kiem tra truoc khi xóa", 1)))
            {
                return;
            }
            if (D99D0041.D99C0008.MsgAskDelete() == System.Windows.Forms.DialogResult.No)
                return;
            bool bRunSQL = L3SQLServer.ExecuteSQLNoTransaction(SQLDeleteD45T0031());
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
            sSQL += L3SQLClient.SQLString("D45F1140") + ",";
            sSQL += L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_ConditionID).ToString()) + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") ;          

            return sSQL;
        }

           private string SQLStoreD45P5555_Save(string cap, int mode)
           {
               string sSQL = cap + Environment.NewLine;
               sSQL += "EXEC D45P5555" + Environment.NewLine;
               sSQL += L3SQLClient.SQLString(L3.DivisionID) + ",";
               sSQL += L3SQLClient.SQLString(L3.TranMonth) + ",";
               sSQL += L3SQLClient.SQLString(L3.TranYear) + ",";
               sSQL += L3SQLClient.SQLString("84") + ",";
               sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
               sSQL += L3SQLClient.SQLString(Environment.MachineName) + ",";
               sSQL += L3SQLClient.SQLNumber(mode) + ",";
               sSQL += L3SQLClient.SQLString("D45F1140") + ",";
               sSQL += L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_ConditionID).ToString()) + ",";
               sSQL += L3SQLClient.SQLString("") + ",";
               sSQL += L3SQLClient.SQLString("") + ",";
               sSQL += L3SQLClient.SQLString("") + ",";
               sSQL += L3SQLClient.SQLString("") + ",";
               sSQL += L3SQLClient.SQLNumber(chkDisabled.IsChecked);

               return sSQL;
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
            tsbAdd_ItemClick(null, null);
        }

        private void mnsEdit_Click(object sender, RoutedEventArgs e)
        {
            tsbEdit_ItemClick(null,null);
        }

        private void mnsDelete_Click(object sender, RoutedEventArgs e)
        {
            tsbDelete_ItemClick(null, null);
        }

        private void mnsListAll_Click(object sender, RoutedEventArgs e)
        {
            tsbListAll_ItemClick(null, null);
        }
        private void mnsSysInfo_Click(object sender, RoutedEventArgs e)
        {
            tsbSysInfo_ItemClick(null,null);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (!btnSave.Focusable) return;
            if(_formState== EnumFormState.FormEdit)
            {
                if (!L3SQLServer.CheckStore(SQLStoreD45P5555_Save("-- Kiem tra truoc khi Lưu Edit", 0)))
                {
                    return;
                }
            } 
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
            {

                SetReturnFormView();
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
                return;
            }
            isNext = true;
            if (SaveData(sender) == false)
            { return; }
            ClearTextALL();
            btnSave.IsEnabled = true;
            btnNext.IsEnabled = true;
            btnNotSave.IsEnabled = true;
        }

        private void btnNotSave_Click(object sender, RoutedEventArgs e)
        {
            if (_formState == EnumFormState.FormAdd && txtConditionID.Text == "")
            {
                if (tdbg.VisibleRowCount > 0)
                {
                    LoadEdit();
                }
                goto one;
            }
            if (Lemon3.Messages.L3Msg.AskMsgBeforeRowChange())
            {
                if (_formState == EnumFormState.FormEdit)
                {
                    if (!L3SQLServer.CheckStore(SQLStoreD45P5555_Save("-- Kiem tra truoc khi Lưu Edit", 0)))
                    {
                        return;
                    }
                } 
                if (SaveData(sender) == false)
                { return; }
            }
            else
            {
               
                LoadEdit();
            }
        one:
            SetReturnFormView();
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
                    sSQL.Append(SQLInsertD45T0031());
                    break;
                case EnumFormState.FormEdit:
                    sSQL.Append(SQLUpdateD45T0031());
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
                        LoadTDBGrid(true, txtConditionID.Text);
                        break;
                    case EnumFormState.FormEdit:
                        LoadTDBGrid(false, txtConditionID.Text);
                        break;
                }
                if(isNext==true)
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
            
            if (txtConditionID.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblConditionID.Content.ToString());
                txtConditionID.Focus();
                return false;
            }
            if(_formState==EnumFormState.FormAdd)
            {
                if (CheckSave() == false)
                {
                    return false;
                }
            }               
            if (tdbcCode.Text == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(lblCode.Content.ToString());
                    tdbcCode.Focus();
                    return false;
                }
            
            if (txtDescription.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetEnter(lblDescription.Content.ToString());
                txtDescription.Focus();
                return false;
            }
            
            
            return true;

        }
        private void SetReturnFormView()
        {
            _formState = EnumFormState.FormView;
            EnableMenu(false);
            btnNext.IsEnabled = false;
            LockControl(true);
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
        private Boolean CheckSave()
        {

            string sSQl=" ---Kiem tra du lieu truoc khi luu"+Environment.NewLine;

            sSQl+=" SELECT 		TOP 1 CASE WHEN ConditionID ="+ L3SQLClient.SQLString(txtConditionID.EditValue)+Environment.NewLine;
            sSQl+="THEN 1 ELSE 0 END AS Status"+Environment.NewLine;
            sSQl+="FROM 		D45T0031 WITH(NOLOCK)"+Environment.NewLine;
            sSQl += "ORDER BY Status DESC" + Environment.NewLine;
            System.Data.DataTable dt = L3SQLServer.ReturnDataTable(sSQl);
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
        private string SQLInsertD45T0031()
        {
            string sSQL = "--Luu bang dieu kien" + Environment.NewLine;
            sSQL += "INSERT INTO	D45T0031" + Environment.NewLine;
            sSQL += "(ConditionID, Description, Notes, CODE, CodeW, CreateUserID, CreateDate, LastModifyUserID, LastModifyDate, Disabled)" + Environment.NewLine;
            sSQL += "VALUES " + Environment.NewLine;
            sSQL += "(";   
            sSQL += L3SQLClient.SQLString(txtConditionID.EditValue)+",";
            sSQL += "N" +L3SQLClient.SQLString(txtDescription.EditValue) + ",";
            sSQL += "N"+L3SQLClient.SQLString(txtNotes.EditValue) + ",";
            sSQL += L3SQLClient.SQLString(tdbcCode.ReturnValue("CODE")) + ",";
            sSQL += L3SQLClient.SQLString(tdbcCode.ReturnValue("CodeW")) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLDateSave(DateTime.Now) + ",";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLDateSave(DateTime.Now) + ",";
            if (chkDisabled.IsChecked == true)
            {
                sSQL += 1;
            }
            else
            {
                sSQL += 0;
            }
            sSQL += ")" +Environment.NewLine;
            return sSQL;
        }
        private string SQLUpdateD45T0031()
        {
            
            string sSQL = "---Cap nhat du lieu Master " + Environment.NewLine;
            sSQL += "UPDATE      	D45T0031" + Environment.NewLine;
            sSQL += "SET" + Environment.NewLine;
            sSQL += "Description =N" + L3SQLClient.SQLString(txtDescription.Text) + "," + Environment.NewLine;
            sSQL += "Notes =N" + L3SQLClient.SQLString(txtNotes.EditValue) + "," + Environment.NewLine;
            sSQL += "LastModifyUserID  =" + L3SQLClient.SQLString(L3.UserID) + "," + Environment.NewLine;
            sSQL += "LastModifyDate  =" + L3SQLClient.SQLDateSave(DateTime.Now) + "," + Environment.NewLine;
            if(chkDisabled.IsChecked==true)
            {
                sSQL += "Disabled=1" + Environment.NewLine;
            }
            else
            {
                sSQL += "Disabled=0" + Environment.NewLine;
            }        
            sSQL += "WHERE  ";
            sSQL += "ConditionID = " + L3SQLClient.SQLString(txtConditionID.EditValue) + Environment.NewLine;

            return sSQL;
        }
        private string SQLStoreD45P5555()
        {
            string sSQL = "-- Kiem tra truoc khi xoa" + Environment.NewLine;
            sSQL +="EXEC D45P5555" + Environment.NewLine;
            sSQL +=L3SQLClient.SQLString(L3.DivisionID)+",";
            sSQL +=L3SQLClient.SQLString(L3.TranMonth )+",";
            sSQL +=L3SQLClient.SQLString(L3.TranYear )+",";
            sSQL +=L3SQLClient.SQLString(L3.STRLanguage )+",";
            sSQL +=L3SQLClient.SQLString(L3.UserID )+",";
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + ",";
            sSQL += L3SQLClient.SQLNumber(1) + ",";
            sSQL += L3SQLClient.SQLString("D45F1140") + ",";
            sSQL += L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_ConditionID)) + ",";
            sSQL += L3SQLClient.SQLString("") + ",";
            sSQL += L3SQLClient.SQLString("") + ",";  
            sSQL +=L3SQLClient.SQLString("")+",";
            sSQL +=L3SQLClient.SQLString("")+",";

            return sSQL;
        }
        private string SQLDeleteD45T0031()
        {
            string sSQL = "--Xoa du lieu bang dieu kien" + Environment.NewLine;
            sSQL += "DELETE " + Environment.NewLine;
            sSQL += "FROM 		D45T0031" + Environment.NewLine;
            sSQL += "WHERE 		ConditionID =" + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_ConditionID));

            return sSQL;
        }

        private void tdbgView_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
           
            if (tdbgView.FocusedRowHandle < 0)
            { return; };
            LoadEdit();
        }

        private void chkViewDisable_Click(object sender, RoutedEventArgs e)
        {
            LoadTDBGrid();
         
        }

        //private void txtConditionID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    int i = 0;



        //    bool result = int.TryParse(e.Text.ToString(), out i);



        //    if (!result && (e.Text[0] < 'a' || e.Text[0] > 'z') && (e.Text[0] < 'A' || e.Text[0] > 'Z'))
        //    {

        //        e.Handled = true;

        //    }
        //    if(e.Text[0]==' ')
        //    {
        //        e.Handled = true;
        //    }
        //}

      
       
    }
}
