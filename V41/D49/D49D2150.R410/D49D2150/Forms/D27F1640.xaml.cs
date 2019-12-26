using D27D1340;
using DevExpress.Xpf.Grid;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using Lemon3.IO;
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

namespace D27D1750
{
    /// <summary>
    /// Interaction logic for D27F1640.xaml
    /// </summary>
    public partial class D27F1640 : L3Window
    {
        public D27F1640()
        {
            InitializeComponent();
        }

        private int iPerD27F1640 = -1;

        private int iPerD27F5663 = -1;
        private DataTable dtGrid1 = null, dtGrid2 = null;
        private bool _bLoadFormState = false;


        private bool _bSaved = false;
        public bool bSaved
        {
            get { return _bSaved; }
        }



        private string _ProjectID = ""; // SADECO_1
        public string ProjectID
        {
            set { _ProjectID = value; }
        }

        private string _PropertyTypeID = "";
        public string PropertyTypeID
        {
            set { _PropertyTypeID = value; }
        }

        private string _CallFormID = ""; // D54F2110
        public string CallFormID
        {
            set { _CallFormID = value; }
        }


        private EnumFormState _formState = EnumFormState.FormView;
        public EnumFormState FormState
        {
            set
            {
                _formState = value;
                _bLoadFormState = true;
                LoadTBDCombo();
                LoadTDBGrid();
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
            txtProjectID.EditValue = _ProjectID;

            if (!_bLoadFormState) FormState = _formState;
            DefaultAndFormat();
            LoadLanguage();
            gridRight.Width = new GridLength(0, GridUnitType.Star);
            this.Cursor = Cursors.Arrow;
        }
        private void DefaultAndFormat()
        {
            tdbg1.SetDefaultGridControlInquiry();
            //tdbg2.SetDefaultGridControlInquiry();
            tdbg1.InputNumber288("N0", false, false, COL1_OfficeQuantity);
            tdbg1.InputDate(COL1_UpdateDate);
            //tdbg2.InputDate(COL2_UpdateDate);

            SetVisibleColumn();

            this.SetBackColorObligatory(new Control[] { tdbcAgencyTypeID, tdbcAgencyID,DateValidFrom}, null);
            L3Control.ReadOnlyControl(true, txtProjectID, txtAgencyName, txtDAGroupName);

            L3Control.SetShortcutPopupMenu(MainMenuControl1, ContextMenu1);

            btnSave.SetImage(ImageType.Save);
            btnNotSave.SetImage(ImageType.NotSave);
        }
        private void LoadExt()
        {
            iPerD27F1640 = L3Permissions.ReturnPermission("D27F1640");
            iPerD27F5663 = L3Permissions.ReturnPermission("D27F5663");

        }
        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Khai_bao_san_giao_dich") + " - " + this.GetType().Name;
            lblProjectID.Content = L3Resource.rL3("Cong_trinh");

            lblAgencyTypeID.Content = L3Resource.rL3("San_giao_dich");
            tdbcAgencyTypeID.SetCaptionColumn("ObjectTypeID", L3Resource.rL3("Ma")); // combobox
            tdbcAgencyTypeID.SetCaptionColumn("ObjectTypeName", L3Resource.rL3("Ten")); // combobox
            tdbcAgencyID.SetCaptionColumn("ObjectID", L3Resource.rL3("Ma")); // combobox
            tdbcAgencyID.SetCaptionColumn("ObjectName", L3Resource.rL3("Ten")); // combobox

            lblDAGroupID.Text = L3Resource.rL3("Nhom_truy_cap_du_lieu");
            tdbcDAGroupID.SetCaptionColumn("DAGroupID", L3Resource.rL3("Ma_nhom")); // combobox
            tdbcDAGroupID.SetCaptionColumn("DAGroupName", L3Resource.rL3("Dien_giai")); // combobox

            grpLeft.Text = L3Resource.rL3("Thong_tin_san_giao_dich");
            grpRight.Text = L3Resource.rL3("Thong_tin_bat_dong_san");
            chkIsDetail.Content = L3Resource.rL3("Hien_thi_chi_tiet");

            COL1_AgencyTypeID.Header = L3Resource.rL3("Loai_san_giao_dich");
            COL1_AgencyID.Header = L3Resource.rL3("Ma_san_giao_dich");
            COL1_AgencyName.Header = L3Resource.rL3("Ten_san_giao_dich");
            COL1_RefInformation.Header = L3Resource.rL3("Ten_tat");
            COL1_ObjectAddress.Header = L3Resource.rL3("Dia_chi");
            COL1_ContactPerson.Header = L3Resource.rL3("Nguoi_lien_he");
            COL1_TelNo.Header = L3Resource.rL3("So_dien_thoai");
            COL1_VATNo.Header = L3Resource.rL3("Ma_so_thue");
            COL1_OfficeQuantity.Header = L3Resource.rL3("So_luong");
            COL1_OfficeID.Header = L3Resource.rL3("Ma_BDS");
            COL1_OfficeNo.Header = L3Resource.rL3("Ma_tham_chieu");
            COL1_PropertyTypeName.Header = L3Resource.rL3("Loai_hinh_san_pham");
            COL1_TUsageTypeName.Header = L3Resource.rL3("Muc_dich_su_dung");
            COL1_PStatusName.Header = L3Resource.rL3("Trang_thai");
            COL1_ApartmentTypeName.Header = L3Resource.rL3("Phan_loai");
            COL1_Notes.Header = L3Resource.rL3("Dien_giai");

            COL2_OfficeID.Header = L3Resource.rL3("Ma_BDS");
            COL2_OfficeNo.Header = L3Resource.rL3("Ma_tham_chieu");
            COL2_PropertyTypeName.Header = L3Resource.rL3("Loai_hinh_san_pham");
            COL2_TUsageTypeName.Header = L3Resource.rL3("Muc_dich_su_dung");
            COL2_PStatusName.Header = L3Resource.rL3("Trang_thai");
            COL2_ApartmentTypeName.Header = L3Resource.rL3("Phan_loai");
            COL2_Notes.Header = L3Resource.rL3("Dien_giai");
            //COL2_DisabledAgency.Header = L3Resource.rL3("Khong_su_dung");
            //COL2_UpdateDate.Header = L3Resource.rL3("Ngay_cap_nhat");

            btnOfficeID.Content = L3Resource.rL3("Chon_ma_bat_dong_san_01");

            lblValidDate.Content = L3Resource.rL3("Ngay_hieu_lucU");
        }



        private void LoadAdd()
        {
            _formState = EnumFormState.FormAdd;
            _bSaved = false;
            ClearTextALL();
            tdbcAgencyTypeID.Focus();
        }
        private void EnableMenu(bool bEnabled)
        {
            btnSave.IsEnabled = bEnabled;
            btnNotSave.IsEnabled = bEnabled;           
            groupLeft.IsEnabled = !bEnabled;
            btnOfficeID.IsEnabled = bEnabled;
            switch (_formState)
            {
                case EnumFormState.FormView:
                    L3Control.ReadOnlyControl(true, tdbcAgencyTypeID, tdbcAgencyID, tdbcDAGroupID);
                    L3Control.ReadOnlyControl(true, DateValidFrom,DateValidTo);                 
                    break;
                case EnumFormState.FormEdit:
                    L3Control.ReadOnlyControl(true, tdbcAgencyTypeID, tdbcAgencyID);
                    L3Control.ReadOnlyControl(true, DateValidFrom, DateValidTo);
                    L3Control.ReadOnlyControl(false, tdbcDAGroupID);                 
                    if(isUpdateValidDate==true)     //id-125663
                    {
                        L3Control.ReadOnlyControl(false, DateValidFrom, DateValidTo);
                        L3Control.ReadOnlyControl(true, tdbcDAGroupID);
                        btnOfficeID.IsEnabled = false;
                    }
                    break;

                default:
                    L3Control.ReadOnlyControl(false, tdbcAgencyTypeID, tdbcAgencyID, tdbcDAGroupID);
                    L3Control.ReadOnlyControl(false, DateValidFrom, DateValidTo);
                    break;
            }


            if (!bEnabled)
            {
                L3Control.CheckMenu(this.GetType().Name, MainMenuControl1, ContextMenu1, tdbg1.VisibleRowCount, true, false, false, "D27F5663");
            }
            else
            {
                L3Control.CheckMenu("-1", MainMenuControl1, ContextMenu1, -1, false, false);
            }

            CheckMenuOthers();
        }
        private void CheckMenuOthers()
        {
            mnsAdd.IsEnabled = mnsAdd.IsEnabled && iPerD27F1640 >= 2;
            tsbAdd.IsEnabled = tsbAdd.IsEnabled && iPerD27F1640 >= 2;

            mnsEdit.IsEnabled = mnsEdit.IsEnabled && iPerD27F1640 >= 3;
            tsbEdit.IsEnabled = tsbEdit.IsEnabled && iPerD27F1640 >= 3;

            mnsDelete.IsEnabled = mnsDelete.IsEnabled && iPerD27F1640 >= 4;
            tsbDelete.IsEnabled = tsbDelete.IsEnabled && iPerD27F1640 >= 4;

            mnsUpdateValidDate.IsEnabled=mnsUpdateValidDate.IsEnabled & iPerD27F1640 > 2;

            mnsListAll.IsEnabled = mnsListAll.IsEnabled && iPerD27F1640 >= 1;
            tsbListAll.IsEnabled = tsbListAll.IsEnabled && iPerD27F1640 >= 1;

            mnsImportExcel.IsEnabled = mnsImportExcel.IsEnabled && iPerD27F5663 > 2;

            btnOfficeID.IsEnabled = iPerD27F1640 >= 2 && btnOfficeID.IsEnabled;

            btnSave.IsEnabled = btnSave.IsEnabled && iPerD27F1640 >= 2;
            btnNotSave.IsEnabled = btnNotSave.IsEnabled && iPerD27F1640 >= 2;
        }

        private void LoadEdit()
        {
            if (tdbg1.VisibleRowCount < 1) return;
            if (tdbg1View.FocusedRowHandle == L3GridControl.AutoFilterRowHandle) return;
            //tdbg1View_FocusedRowChanged(null, null);
        }




        private void LoadTDBGrid(bool IsAdd = true, string sKeyObjectTypeID = "", string sKeyObjectID = "")
        {
            if (IsAdd) tdbg1.ListAll();
            dtGrid1 = L3SQLServer.ReturnDataTable(SQLStoreD27P1640LeftGrid());
            L3DataSource.LoadDataSource(tdbg1, dtGrid1);
            ReLoadTDBGrid();
            if (!string.IsNullOrEmpty(sKeyObjectTypeID) && !string.IsNullOrEmpty(sKeyObjectID))
            {
                if (!tdbg1.IsFocused)//Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
                    tdbg1.Focus();

                for (int i = 0; i < tdbg1.VisibleRowCount; i++)
                {
                    DataRow drLoop = (tdbg1.GetRow(tdbg1.GetRowHandleByVisibleIndex(i)) as DataRowView).Row;
                    if (drLoop[COL1_AgencyTypeID.FieldName].ToString() == sKeyObjectTypeID &&
                        drLoop[COL1_AgencyID.FieldName].ToString() == sKeyObjectID)
                    {
                        HandleRowFocus(i);
                        break;
                    }
                }
            }
        }
        private void ReLoadTDBGrid()
        {
            if (_formState == EnumFormState.FormAdd)
                return;

            if (tdbg1.VisibleRowCount == 0)
            {
                ClearTextALL();
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
        private void HandleRowFocus(int indexRowFocus)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tdbg1View.MoveFocusedRow(indexRowFocus);
                tdbg1View.SelectRow(indexRowFocus);
            }), DispatcherPriority.Render);

            tdbg1.SelectedItem = indexRowFocus;
            tdbg1View.FocusedRowHandle = indexRowFocus;
        }


        private void LoadTDBGrid2(string sAgencyTypeID, string sAgencyID)
        {
            dtGrid2 = L3SQLServer.ReturnDataTable(SQLStoreD27P1640RightGrid(sAgencyTypeID, sAgencyID));
            L3DataSource.LoadDataSource(tdbg2, dtGrid2);
        }

        DataTable dtAgencyID;
        private void LoadTBDCombo()
        {
            L3DataSource.LoadDataSource(tdbcAgencyTypeID, Lemon3.LoadGeneral.L3ObjectIDBase.ReturnTableObjectTypeID(EnumUnionAll.None, ""));
            dtAgencyID = Lemon3.LoadGeneral.L3ObjectIDBase.ReturnTableObjectID(EnumUnionAll.None);
            L3DataSource.LoadDataSource(tdbcAgencyID, dtAgencyID);
            L3DataSource.LoadDataSource(tdbcDAGroupID, SQLDAGroupID());
        }






        private void chkIsDetail_Click(object sender, RoutedEventArgs e)
        {
            LoadTDBGrid(false, L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_AgencyTypeID)), L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_AgencyID)));
            SetVisibleColumn();
        }
        private void SetVisibleColumn()
        {
            COL1_OfficeID.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
            COL1_OfficeNo.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
            COL1_PropertyTypeName.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
            COL1_TUsageTypeName.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
            COL1_PStatusName.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
            COL1_ApartmentTypeName.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
            COL1_Notes.Visible = L3ConvertType.L3Bool(chkIsDetail.IsChecked);
        }

        private void tdbcAgencyTypeID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                tdbcAgencyID.EditValue = null;
            }
            L3DataSource.LoadDataSource(tdbcAgencyID, Lemon3.Functions.L3DataTable.ReturnTableFilter(dtAgencyID, "ObjectTypeID = " + L3SQLClient.SQLString(tdbcAgencyTypeID.ReturnValue("ObjectTypeID")), true));
        }


        private void tdbcAgencyID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            txtAgencyName.EditValue = tdbcAgencyID.ReturnValue("ObjectName");
            //LoadTDBGrid2(L3ConvertType.L3String(tdbcAgencyTypeID.EditValue), L3ConvertType.L3String(tdbcAgencyID.EditValue));
        }
        private void tdbcAgencyID_PopupClosed(object sender, DevExpress.Xpf.Editors.ClosePopupEventArgs e)
        {
            if(DateValidFrom.EditValue!=null)
            {
                if (!L3SQLServer.CheckStore(SQLStoreD27P1640CheckOrSave("Kiem tra san giao dich da ton tai trong du an", "CheckAddnew")))
                {
                    btnOfficeID.IsEnabled = false;                    
                    return;
                }
                else
                {
                    btnOfficeID.IsEnabled = true;
                }
            }
           
            // Khi grid2 có dữ liệu
            if (dtGrid2 != null && dtGrid2.Rows.Count > 0)
            {
                // Xuất thông báo dạng Yes/No: “Bạn có muốn xóa dữ liệu trên lưới?”
                if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Ban_co_muon_xoa_du_lieu_tren_luoi") + "?") == System.Windows.Forms.DialogResult.Yes)
                {
                    dtGrid2.Clear();
                }
            }
        }

        private void tdbcDAGroupID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            txtDAGroupName.EditValue = tdbcDAGroupID.ReturnValue("DAGroupName");
        }

        private void split_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridRight.Width == new GridLength(0, GridUnitType.Star))
            {
                gridLeft.Width = new GridLength(1, GridUnitType.Star);
                gridRight.Width = new GridLength(1, GridUnitType.Star);
            }
            else
            {
                gridRight.Width = new GridLength(0, GridUnitType.Star);
            }
        }


        private void tdbg1View_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            //Reset và load lại group phải (master và grid2 thông tin bất động sản)
            ClearRightMaster();
            LoadTDBGrid2(L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_AgencyTypeID)), L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_AgencyID)));
            if (dtGrid2.Rows.Count > 0)
            {
                tdbcAgencyTypeID.EditValue = dtGrid2.Rows[0]["AgencyTypeID"];
                tdbcAgencyID.EditValue = dtGrid2.Rows[0]["AgencyID"];
                tdbcDAGroupID.EditValue = dtGrid2.Rows[0]["DAGroupID"];
                //txtAgencyName.EditValue = dtGrid2.Rows[0]["AgencyName"];
                DateValidFrom.EditValue = tdbg1.GetFocusedRowCellValue(COL1_DateValidFrom);
                DateValidTo.EditValue = tdbg1.GetFocusedRowCellValue(COL1_DateValidTo);
            }
        }

        private void ClearRightMaster()
        {
            tdbcAgencyTypeID.EditValue = null;
            tdbcAgencyID.EditValue = null;
            txtAgencyName.EditValue = null;
            tdbcDAGroupID.EditValue = null;
            txtDAGroupName.EditValue = null;
            DateValidFrom.EditValue = null;
            DateValidTo.EditValue = null;
        }
        private void ClearTextALL()
        {
            ClearRightMaster();
            if (dtGrid2 != null)
                dtGrid2.Clear();
        }





        private void tdbg2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (L3ConvertType.L3Int(tdbg2.GetFocusedRowCellValue(COL2_IsLock)) == 1)
                {
                    Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Ma_bat_dong_san_nay_da_su_dung") + ". " + L3Resource.rL3("Ban_khong_duoc_phep_xoa") + ".");
                    return;
                }
                tdbg2.DeleteRowFocusEvent();
            }
        }

        private void tdbg2View_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //if (e.Column == COL2_DisabledAgency)
            //{
            //    tdbg2.SetFocusedRowCellValue(COL2_UpdateDate, DateTime.Now);
            //}
        }

        private void tdbg2View_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.Row != null)
            {
                //if (e.Column != COL2_DisabledAgency && e.Column != COL2_UpdateDate)
                //{
                    e.Cancel = true;
                //}
                //else
                //{
                //    if (_formState != EnumFormState.FormAdd && _formState != EnumFormState.FormEdit)
                //    {
                //        e.Cancel = true;
                //    }
                //}
            }
        }




        #region Menu
        private void tsbAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            LoadAdd();
            EnableMenu(true);

            gridLeft.Width = new GridLength(1, GridUnitType.Star);
            gridRight.Width = new GridLength(1, GridUnitType.Star);
        }

        private void tsbEdit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (!L3SQLServer.CheckStore(SQLStoreD27P1640CheckOrSave("Kiem tra truoc khi sua san giao dich", "CheckEdit"))) return;
            _formState = EnumFormState.FormEdit;
            EnableMenu(true);

            gridLeft.Width = new GridLength(1, GridUnitType.Star);
            gridRight.Width = new GridLength(1, GridUnitType.Star);
        }

        private void tsbDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("San_giao_dich_se_bi_xoa") + ". " + L3Resource.rL3("Ban_co_muon_tiep_tuc_01") + "?") == System.Windows.Forms.DialogResult.No)
                return;
            bool bRunSQL = L3SQLServer.CheckStore(SQLStoreD27P1640Delete());
            if (bRunSQL)
            {
                Lemon3.Messages.L3Msg.DeleteOK();
                LoadTDBGrid();
            }
        }

        private void tsbSearch_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void tsbListAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            tdbg1.ListAll();
            tdbg2.ListAll();
        }

        private void tsbSysInfo_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            L3Window.ShowSysInforForm(tdbg1);
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

        private void mnsSearch_Click(object sender, RoutedEventArgs e)
        {
            tsbSearch_ItemClick(null, null);
        }

        private void mnsListAll_Click(object sender, RoutedEventArgs e)
        {
            tsbListAll_ItemClick(null, null);
        }

        private void mnsSysInfo_Click(object sender, RoutedEventArgs e)
        {
            tsbSysInfo_ItemClick(null, null);
        }

        private void mnsImportExcel_Click(object sender, RoutedEventArgs e)
        {
            L3CallDLL callDLL = new L3CallDLL();
            callDLL.CallShowDialogD80F2090("D27", "D27F5663", "D27F1640");
        }

        private void mnsExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                DataTable dtMaster = new DataTable();
                AddDataRowTable(ref dtMaster, "Loại sàn giao dịch", "ObjectTypeID", L3ConvertType.L3String(tdbcAgencyTypeID.EditValue), i++);
                AddDataRowTable(ref dtMaster, "Mã sàn giao dịch", "ObjectID", L3ConvertType.L3String(tdbcAgencyID.EditValue), i++);
                AddDataRowTable(ref dtMaster, "Tên sàn giao dịch", "ObjectName", L3ConvertType.L3String(txtAgencyName.EditValue), i++);
                AddDataRowTable(ref dtMaster, "Mã nhóm truy cập dữ liệu", "DAGroupID", L3ConvertType.L3String(tdbcDAGroupID.EditValue), i++);
                AddDataRowTable(ref dtMaster, "Tên nhóm truy cập dữ liệu", "DAGroupName", L3ConvertType.L3String(txtDAGroupName.EditValue), i++);

                DataTable dtCaption = Lemon3.Documents.Excel.L3ExportExcel.CreateTableForExcelOnly(tdbg1);

                L3CallDLL oCallDLL = new L3CallDLL();
                Lemon3.IO.StructureProperties[] arrPro = null;
                oCallDLL.SetProperties(ref arrPro, "UseUnicode", L3.IsUniCode);
                oCallDLL.SetProperties(ref arrPro, "FormID", this.GetType().Name);
                oCallDLL.SetProperties(ref arrPro, "dtLoadGrid", dtCaption);
                oCallDLL.SetProperties(ref arrPro, "dtExportTable", tdbg1.ReturnDataTableFilter);
                oCallDLL.SetProperties(ref arrPro, "dtMaster", dtMaster);
                oCallDLL.CallFormShowDialog("D99D0341", "D99F2222", arrPro);
            }
            catch (Exception ex)
            {
                D99D0041.D99C0008.MsgL3("Có lỗi trong quá trình xuất Excel: " + ex.Message);
            }
        }
        private void AddDataRowTable(ref DataTable dtM, string text, string sField, string value, int tabIndex)
        {
            if (dtM == null || dtM.Columns.Count == 0)
                dtM = InitTable();
            DataRow dr = dtM.NewRow();
            dr["Description"] = text;
            dr["FieldExcel"] = "<#" + sField + "#>";
            dr["Value"] = value;
            dr["TabIndex"] = tabIndex;
            dtM.Rows.Add(dr);
        }
        private DataTable InitTable()
        {
            DataTable dtM = new DataTable();
            dtM.Columns.Add("Description");
            dtM.Columns.Add("FieldExcel");
            dtM.Columns.Add("Value");
            dtM.Columns.Add("TabIndex", Type.GetType("System.Int64"));
            return dtM;
        }
        #endregion Menu


        #region Button Click

        private void btnOfficeID_Click(object sender, RoutedEventArgs e)
        {
            //Lemon3.IO.L3CallDLL oCallDLL = new Lemon3.IO.L3CallDLL();
            //Lemon3.IO.StructureProperties[] arrPro = null;
            //oCallDLL.SetProperties(ref arrPro, "ProjectID", L3ConvertType.L3String(txtProjectID.EditValue));
            //oCallDLL.SetProperties(ref arrPro, "PropertyTypeID", _PropertyTypeID);
            //oCallDLL.SetProperties(ref arrPro, "CallFormID", this.GetType().Name);
            //object frm = oCallDLL.CallFormShowDialog("D27D1340", "D27F1203", arrPro);

            D27F1203 frm = new D27F1203();
            frm.ProjectID = L3ConvertType.L3String(txtProjectID.EditValue);
            frm.PropertyTypeID = _PropertyTypeID;
            frm.CallFormID = this.GetType().Name;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.ShowDialog();

            if (!frm.bIsClickButtonChoose) return;

            // Sau khi đóng form D27F1203
            if (dtGrid2 != null && dtGrid2.Rows.Count > 0)
            {
                DataTable dtNewReturn = L3SQLServer.ReturnDataTable(SQLStoreD27P1640CheckOrSave("Load thong tin ma bat dong san duoc chon", "ChooseOfficeID"));

                if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Da_ton_tai_du_lieu_tren_luoi") + ". " + L3Resource.rL3("Ban_co_muon_xoa_khong_01") + "?") == System.Windows.Forms.DialogResult.Yes)
                {
                    // Xóa dòng ko lock dtGrid2
                    var rows = dtGrid2.Select("IsLock = 0");
                    foreach (var row in rows)
                        dtGrid2.Rows.Remove(row);
                    // dtGrid2 thêm dữ liệu mới
                    foreach (DataRow dr in dtNewReturn.Rows)
                    {
                        dtGrid2.Rows.Add(dr.ItemArray);
                    }
                }
                else
                {
                    // Xóa dòng trùng mã BĐS (OfficeID) trên dtGrid2 so với dtNewReturn
                    List<DataRow> lsRowDelete = new List<DataRow>();
                    foreach (DataRow row in dtGrid2.Rows)
                    {
                        if (dtNewReturn.Select("OfficeID = " + L3SQLClient.SQLString(row["OfficeID"])).Length > 0)
                            lsRowDelete.Add(row);
                    }
                    foreach (var row in lsRowDelete)
                        dtGrid2.Rows.Remove(row);
                    // dtGrid2 thêm dữ liệu mới
                    foreach (DataRow dr in dtNewReturn.Rows)
                    {
                        dtGrid2.Rows.Add(dr.ItemArray);
                    }
                }
            }
            else
            {
                dtGrid2 = L3SQLServer.ReturnDataTable(SQLStoreD27P1640CheckOrSave("Load thong tin ma bat dong san duoc chon", "ChooseOfficeID"));
                L3DataSource.LoadDataSource(tdbg2, dtGrid2);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (!btnSave.Focusable) return;
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
            {
                isUpdateValidDate = false;
                return;
            }            
            SaveData(sender);
        }
        private bool SaveData(System.Object sender)
        {
            _bSaved = false;
            if (!AllowSave())
                return false;
            isUpdateValidDate = false;
            this.Cursor = Cursors.Wait;
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append(SQLInsertD27T9009s());
            bool bRunSQL = L3SQLServer.ExecuteSQL(sSQL.ToString());
            if (!bRunSQL) return false;


            switch (_formState)
            {
                case EnumFormState.FormAdd:
                    if (!L3SQLServer.CheckStore(SQLStoreD27P1640CheckOrSave("Luu moi cap nhat san giao dich", "Save"))) return false;
                    break;
                case EnumFormState.FormEdit:
                    if (!L3SQLServer.CheckStore(SQLStoreD27P1640CheckOrSave("Luu edit cap nhat san giao dich", "Edit"))) return false;
                    break;
            }


            this.Cursor = Cursors.Arrow;
            if (bRunSQL)
            {
                Lemon3.Messages.L3Msg.SaveOK();
                _bSaved = true;
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                    case EnumFormState.FormEdit:
                        LoadTDBGrid(false, L3ConvertType.L3String(tdbcAgencyTypeID.EditValue), L3ConvertType.L3String(tdbcAgencyID.EditValue));
                        break;
                }
                L3Control.ReadOnlyControl(true, new DependencyObject[] { tdbcAgencyTypeID, tdbcAgencyID, tdbcDAGroupID });
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
            if (tdbcAgencyTypeID.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblAgencyTypeID.Content.ToString());
                tdbcAgencyTypeID.Focus();
                return false;
            }
           
            if (tdbcAgencyID.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblAgencyTypeID.Content.ToString());
                tdbcAgencyID.Focus();
                return false;
            }

            // Thực thi store kiểm tra, xuất message trả ra từ store theo chuẩn
            if (!L3SQLServer.CheckStore(SQLStoreD27P1640CheckOrSave("Kiem tra truoc khi luu", "CheckSave")))
            {
                return false;
            }


            // -	Kiểm tra dữ liệu trên lưới thông tin bất động sản: Không có dữ liêu, xuất thông báo chặn: “Bạn phải chọn mã bất động sản”
            if (dtGrid2 == null || dtGrid2.Rows.Count == 0)
            {
                Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Ban_phai_chon_ma_bat_dong_san") + ".");
                btnOfficeID.Focus();
                return false;
            }
            if (DateValidFrom.EditValue == null)
            {
                D99D0041.D99C0008.MsgNotYetChoose(lblValidDate.Content.ToString());
                DateValidFrom.Focus();
                return false;
            }
            if (DateValidFrom.EditValue!=null && DateValidTo.EditValue!=null)
            {
                if(_formState==EnumFormState.FormAdd || isUpdateValidDate==true)
                {
                    if (((DateTime)DateValidFrom.EditValue).CompareTo((DateTime)DateValidTo.EditValue) == 1)
                    {
                        Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Ngay_toi_phai_lon_hon_ngay_tu") + ".");
                        DateValidTo.Focus();
                        return false;
                    }
                    
                }           
            }
            return true;
        }


        private void btnNotSave_Click(object sender, RoutedEventArgs e)
        {
            if (_formState == EnumFormState.FormAdd)
            {
                if (tdbg1.VisibleRowCount > 0)
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
                LoadEdit();
            }
        one:
            LoadTDBGrid(false, L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_AgencyTypeID)), L3ConvertType.L3String(tdbg1.GetFocusedRowCellValue(COL1_AgencyID)));
            SetReturnFormView();
        }
        private void SetReturnFormView()
        {
            isUpdateValidDate = false;
            _formState = EnumFormState.FormView;
            EnableMenu(false);
            if (tdbg1.VisibleRowCount == 0)
            {
                ClearTextALL();
            }
            else
            {
                LoadEdit();
                tdbg1.Focus();
            }
        }

        #endregion Button Click



        #region SQL
        private string SQLStoreD27P1640LeftGrid()
        {
            string sSQL = "";
            sSQL += ("-- Thong tin san giao dich" + Environment.NewLine);
            sSQL += "Exec D27P1640 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[2], NOT NULL
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA; // HostID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3ConvertType.L3Bool(chkIsDetail.IsChecked) ? "DetailLeftGrid" : "LeftGrid") + L3.COMMA; // DataType, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(_ProjectID) + L3.COMMA; // ProjectID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // PropertyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // AgencyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(""); // AgencyID, varchar[50], NOT NULL
            return sSQL;
        }

        private string SQLStoreD27P1640RightGrid(string sAgencyTypeID, string sAgencyID)
        {
            string sSQL = "";
            sSQL += ("-- Thong tin bat dong san" + Environment.NewLine);
            sSQL += "Exec D27P1640 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[2], NOT NULL
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA; // HostID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("RightGrid") + L3.COMMA; // DataType, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(txtProjectID.EditValue) + L3.COMMA; // ProjectID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // PropertyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(sAgencyTypeID) + L3.COMMA; // AgencyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(sAgencyID)+ L3.COMMA; // AgencyID, varchar[50], NOT NULL
             sSQL += L3SQLClient.SQLDateSave(tdbg1.GetFocusedRowCellValue(COL1_DateValidFrom)) + L3.COMMA;
             sSQL += L3SQLClient.SQLDateSave(tdbg1.GetFocusedRowCellValue(COL1_DateValidTo));
            return sSQL;
        }

        private string SQLStoreD27P1640CheckOrSave(string sMessage, string sDataType)
        {
            string sSQL = "";
            sSQL += ("-- " + sMessage + Environment.NewLine);
            sSQL += "Exec D27P1640 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[2], NOT NULL
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA; // HostID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(sDataType) + L3.COMMA; // DataType, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(txtProjectID.EditValue) + L3.COMMA; // ProjectID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // PropertyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(tdbcAgencyTypeID.EditValue) + L3.COMMA; // AgencyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(tdbcAgencyID.EditValue) + L3.COMMA; // AgencyID, varchar[50], NOT NULL
            if(_formState==EnumFormState.FormAdd)
            {
                sSQL += L3SQLClient.SQLDateSave(DateValidFrom.EditValue) + L3.COMMA;
                sSQL += L3SQLClient.SQLDateSave(DateValidTo.EditValue); 
            }
            else
            {
                sSQL += L3SQLClient.SQLDateSave(tdbg1.GetFocusedRowCellValue(COL1_DateValidFrom)) + L3.COMMA;
                sSQL += L3SQLClient.SQLDateSave(tdbg1.GetFocusedRowCellValue(COL1_DateValidTo));
            }
            return sSQL;
        }

        private string SQLStoreD27P1640Delete()
        {
            string sSQL = "";
            sSQL += ("-- Xoa thong tin san giao dich" + Environment.NewLine);
            sSQL += "Exec D27P1640 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[2], NOT NULL
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA; // HostID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("Delete") + L3.COMMA; // DataType, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(txtProjectID.EditValue) + L3.COMMA; // PropertyID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // PropertyTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(tdbg1.GetFocusedRowCellValue(COL1_AgencyTypeID)) + L3.COMMA; // ObjectTypeID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLString(tdbg1.GetFocusedRowCellValue(COL1_AgencyID)) + L3.COMMA; // ObjectID, varchar[50], NOT NULL
            sSQL += L3SQLClient.SQLDateSave(tdbg1.GetFocusedRowCellValue(COL1_DateValidFrom)) + L3.COMMA;
            sSQL += L3SQLClient.SQLDateSave(tdbg1.GetFocusedRowCellValue(COL1_DateValidTo));
            return sSQL;
        }

        private StringBuilder SQLInsertD27T9009s()
        {
            StringBuilder sRet = new StringBuilder();
            StringBuilder sSQL = new StringBuilder();
            for (int i = 0; i <= dtGrid2.Rows.Count - 1; i++)
            {
                DataRow dr = dtGrid2.Rows[i];
                if (sSQL.ToString() == "" & sRet.ToString() == "")
                    sSQL.Append("-- Quet du lieu tren luoi Insert bang tam" + Environment.NewLine);
                sSQL.Append("-- Insert bang tam" + Environment.NewLine);
                sSQL.Append("Insert Into D27T9009(");
                sSQL.Append("UserID, HostID, FormID, Key01ID, Key02ID, " + Environment.NewLine);
                sSQL.Append("Key03ID, Key04ID, Key05ID, Key06ID, Key07ID, Date01,Date02");
                sSQL.Append(") Values(" + Environment.NewLine);
                sSQL.Append(L3SQLClient.SQLString(L3.UserID) + L3.COMMA); // UserID, varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA); // HostID, varchar[50], NOT NULL
                sSQL.Append(L3SQLClient.SQLString(this.GetType().Name) + L3.COMMA); // FormID, varchar[50], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString(txtProjectID.EditValue) + L3.COMMA); // Key01ID, nvarchar[1000], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString(tdbcAgencyTypeID.EditValue) + L3.COMMA + Environment.NewLine); // Key02ID, nvarchar[1000], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString(tdbcAgencyID.EditValue) + L3.COMMA); // Key03ID, nvarchar[1000], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString(dr[COL2_PropertyTypeID.FieldName]) + L3.COMMA); // Key04ID, nvarchar[1000], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString(dr[COL2_OfficeID.FieldName]) + L3.COMMA); // Key05ID, nvarchar[1000], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString("SaveAgency") + L3.COMMA); // Key06ID, nvarchar[1000], NOT NULL
                sSQL.Append("N" + L3SQLClient.SQLString(tdbcDAGroupID.EditValue) + L3.COMMA); // Key07ID, nvarchar[1000], NOT NULL  
                //id-125663
                sSQL.Append(L3SQLClient.SQLDateSave(DateValidFrom.EditValue) + L3.COMMA); // Date01, DateValidFrom, Not NULL
                sSQL.Append(L3SQLClient.SQLDateSave(DateValidTo.EditValue));

                sSQL.Append(")");
                sRet.Append(sSQL.ToString() + Environment.NewLine);
                sSQL.Remove(0, sSQL.Length);
            }
            return sRet;
        }

        private string SQLDAGroupID()
        {
            string sSQL = "";
            sSQL += ("-- Do nguon combo nhom truy cap du lieu" + Environment.NewLine);
            sSQL += "SELECT DAGroupID, DAGroupNameU as DAGroupName ";
            sSQL += "FROM LEMONSYS.dbo.D00T0080 ";
            sSQL += "WHERE Disabled = 0 And (DAGroupID IN (Select DAGroupID From lemonsys.dbo.D00V0080 Where UserID = " + L3SQLClient.SQLString(L3.UserID) + " ) ";
            sSQL += "OR 'LEMONADMIN' = " + L3SQLClient.SQLString(L3.UserID) + ") ";
            sSQL += "ORDER BY DAGroupID";
            return sSQL;
        }
        #endregion SQL

        //id-125663
        private Boolean isUpdateValidDate = false;
        private void mnsUpdateValidDate_Click(object sender, RoutedEventArgs e)
        {
            isUpdateValidDate=true;
            tsbEdit_ItemClick(null, null);
        }

        private void DateValidFrom_PopupClosed(object sender, DevExpress.Xpf.Editors.ClosePopupEventArgs e)
        {
            if(DateValidFrom.IsReadOnly==true)
            {
                return;
            }
            if (DateValidFrom.EditValue != null)
            {
                if (!L3SQLServer.CheckStore(SQLStoreD27P1640CheckOrSave("Kiem tra san giao dich da ton tai trong du an", "CheckAddnew")))
                {
                    btnOfficeID.IsEnabled = false;
                    return;
                }
                else
                {
                    btnOfficeID.IsEnabled = true;
                }
            }

            // Khi grid2 có dữ liệu
            if (dtGrid2 != null && dtGrid2.Rows.Count > 0)
            {
                // Xuất thông báo dạng Yes/No: “Bạn có muốn xóa dữ liệu trên lưới?”
                if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Ban_co_muon_xoa_du_lieu_tren_luoi") + "?") == System.Windows.Forms.DialogResult.Yes)
                {
                    dtGrid2.Clear();
                }
            }
        }

    }
}
