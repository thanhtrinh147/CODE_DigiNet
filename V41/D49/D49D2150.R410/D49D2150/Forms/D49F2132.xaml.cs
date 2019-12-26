//using D54D2350.Utils;
using DevExpress.Xpf.Grid;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using Lemon3.LoadFN;
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

namespace D49D2150
{
    /// <summary>
    /// Interaction logic for D49F2132.xaml
    /// </summary>
    public partial class D49F2132 : L3Window
    {
        public D49F2132()
        {
            InitializeComponent();
        }
      

        private int iPerD49F2133 = -1;
        private bool _bLoadFormState = false;
        private DataTable dtGrid;
        private bool _bSavedOK = false;

        #region Truyền biến
        private string _OTransID = "";
        public string OTransID
        {
            set { _OTransID = value; }
        }

        private string _ProjectID = "";
        public string ProjectID
        {
            set { _ProjectID = value; }
        }

        private string _ProjectName = "";
        public string ProjectName
        {
            set { _ProjectName = value; }
        }

        private string _ContractID = "";
        public string ContractID
        {
            set { _ContractID = value; }
        }

        private string _ContractNo = "";
        public string ContractNo
        {
            set { _ContractNo = value; }
        }

        private string _ObjectID = "";
        public string ObjectID
        {
            set { _ObjectID = value; }
        }

        private string _PeriodID = "";
        public string PeriodID
        {
            set { _PeriodID = value; }
        }

        private string _ProductID = "";
        public string ProductID
        {
            set { _ProductID = value; }
        }

        private string _ProductName = "";
        public string ProductName
        {
            set { _ProductName = value; }
        }

        private string _OAmount = "";
        public string OAmount
        {
            set { _OAmount = value; }
        }

        private string _VATGroupID = "";
        public string VATGroupID
        {
            set { _VATGroupID = value; }
        }

        private string _VATRate = "";
        public string VATRate
        {
            set { _VATRate = value; }
        }

        private string _VATOAmount = "";
        public string VATOAmount
        {
            set { _VATOAmount = value; }
        }

        private string _TotalOAmount = "";
        public string TotalOAmount
        {
            set { _TotalOAmount = value; }
        }
        private string _unitID = "";
        public string UnitID
        {
            set { _unitID = value; }
        }
        #endregion

        private EnumFormState _formState = EnumFormState.FormView;
        public EnumFormState FormState
        {
            set
            {
                _formState = value;
                _bLoadFormState = true;
                LoadTDBCombo();
                LoadDataDropdown();
                LoadTDBGrid();
                LoadMaster();
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                        break;
                    case EnumFormState.FormEdit:
                        break;
                    case EnumFormState.FormView:
                        break;
                    default:
                        break;
                }
            }
        }

        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            DefaultAndFormat();
            if (!_bLoadFormState) FormState = _formState;
            LoadExt();
            LoadLanguage();
           
            EnableControl(true);

            this.Cursor = Cursors.Arrow;
        }

        private void LoadLanguage()
        {
            this.Title = Lemon3.Resources.L3Resource.rL3("Chi_tiet_xuat_hoa_don") + " - " + this.GetType().Name;
            grpheader.Text = Lemon3.Resources.L3Resource.rL3("Thong_tin_dich_vu");

            lblProjectID.Content = Lemon3.Resources.L3Resource.rL3("Du_an");
            lblContractNo.Content = Lemon3.Resources.L3Resource.rL3("So_hop_dongU");
            lblPeriodID.Content = Lemon3.Resources.L3Resource.rL3("Ky");
            lblProductID.Content = Lemon3.Resources.L3Resource.rL3("Dich_vuU");
            lblOAmount.Content = Lemon3.Resources.L3Resource.rL3("Thanh_tien");
            lblVATGroupID.Content = Lemon3.Resources.L3Resource.rL3("Nhom_thue");
            lblVATOAmount.Content = Lemon3.Resources.L3Resource.rL3("Tien_thueU");
            lblTotalOAmount.Content = Lemon3.Resources.L3Resource.rL3("TT_sau_thueU");

            

            COL_InventoryID.Header = Lemon3.Resources.L3Resource.rL3("Ma_hangU");
            COL_InventoryName.Header = Lemon3.Resources.L3Resource.rL3("Ten_hangU");
            COL_InventoryUnitID.Header = Lemon3.Resources.L3Resource.rL3("DVT");
            COL_OQuantity.Header = Lemon3.Resources.L3Resource.rL3("So_luong");
            COL_UnitPrice.Header = Lemon3.Resources.L3Resource.rL3("Don_gia");
            COL_OAmount.Header = Lemon3.Resources.L3Resource.rL3("Thanh_tien");
            COL_VATOAmount.Header = Lemon3.Resources.L3Resource.rL3("ThueU");
            COL_TotalOAmount.Header = Lemon3.Resources.L3Resource.rL3("TT_sau_thueU");
            COL_FromDate.Header = Lemon3.Resources.L3Resource.rL3("Tu_ngay");
            COL_ToDate.Header = Lemon3.Resources.L3Resource.rL3("Den_ngay");
            COL_Note.Header = Lemon3.Resources.L3Resource.rL3("Ghi_chu");

            btnSave.Content = Lemon3.Resources.L3Resource.rL3("Luu");
            btnClose.Content = Lemon3.Resources.L3Resource.rL3("DongU1");
        }

        private void LoadExt()
        {
            iPerD49F2133 = L3Permissions.ReturnPermission("D49F2133");
        }

        private void DefaultAndFormat()
        {
            L3Format.LoadCustomFormat();
            tdbg.InputDate(COL_FromDate, COL_ToDate);
            this.SetBackColorObligatory(null, new GridColumn[] { COL_InventoryID,COL_InventoryUnitID, COL_OQuantity,COL_UnitPrice,COL_OAmount });
            
            tdbg.InputNumber288(L3Format.DxxFormat.D07_QuantityDecimals, false, false, COL_OQuantity);
            tdbg.InputNumber288(L3Format.DxxFormat.D90_ConvertedDecimals, false, false,COL_OAmount, COL_VATOAmount, COL_TotalOAmount);
            tdbg.InputNumber288(L3Format.DxxFormat.D07_UnitCostDecimals, false, false, COL_UnitPrice);
            //txtVATRate.InputPercent(true, false, 28, 8);
            tdbg.FooterText(null, new GridColumn[] { COL_OAmount, COL_TotalOAmount }, false);
            tdbg.LockCoumns(true, COL_VATOAmount, COL_TotalOAmount);
            tdbg.LockCell("true", new GridColumn[] { COL_VATOAmount, COL_TotalOAmount });
            btnSave.SetImage(ImageType.Save);
            btnClose.SetImage(ImageType.Close);
        }

        private void EnableControl(bool bEnabled)
        {
            btnClose.IsEnabled = bEnabled;
            btnSave.IsEnabled = bEnabled & iPerD49F2133 >= 2;
        }

        private void LoadMaster()
        {
            // Nhận biến từ màn hình D49F2130 truyền qua
            txtProjectID.EditValue = _ProjectID;
            txtContractNo.EditValue= _ContractNo;
            txtPeriodID.EditValue = Convert.ToDateTime(_PeriodID).ToString("MM/yyyy");
            txtproductID.EditValue = _ProductID;
            txtProductName.EditValue = _ProductName;
            //txtOAmount.EditValue= _OAmount;
            txtOAmount.Text = L3SQLClient.SQLNumber(_OAmount, L3Format.DxxFormat.D90_ConvertedDecimals);
            txtVATGroupID.EditValue= _VATGroupID;
            txtVATRate.EditValue = _VATRate;
            txtVATRate.Text = (L3ConvertType.Number(_VATRate) * 100).ToString() + "%";
            //txtVATOAmount.EditValue = _VATOAmount;
            txtVATOAmount.Text = L3SQLClient.SQLNumber(_VATOAmount, L3Format.DxxFormat.D90_ConvertedDecimals);
            //txtTotalOAmount.EditValue= _TotalOAmount;
            txtTotalOAmount.Text = L3SQLClient.SQLNumber(_TotalOAmount, L3Format.DxxFormat.D90_ConvertedDecimals);
            // Control ẩn
            txtOTransID.EditValue = _OTransID;
            txtContractID.EditValue = _ContractID;
            txtObjectID.EditValue = _ObjectID;

        }

        private void LoadTDBCombo()
        {
            
        }
        DataTable dtInventoryUnitID;
        private void LoadDataDropdown()
        {
            // Dropdown Mã dịch vụ
            DataTable dt=L3SQLServer.ReturnDataTable(SQLStoreD49P2132("Do nguon combo Ma dich vu","", _ProjectID, _ContractID, "InventoryID"));
            L3DataSource.LoadDataSource(tdbdInventoryID,dt );
            //DD DVT
            dtInventoryUnitID = L3SQLServer.ReturnDataTable(SQLStoreD49P2132("Do nguon combo DVT", "", _ProjectID, _ContractID, "UnitID"));
            L3DataSource.LoadDataSource(tdbdInventoryUnitID, dtInventoryUnitID);
        }

        private void LoadTDBGrid(bool bFlagAdd = false, string sKeyID = "")
        {
            //if (bAddMew) tdbg.ListAll();
            if (bFlagAdd)
            {
                tdbg.FilterString = String.Empty;
            }

            dtGrid = L3SQLServer.ReturnDataTable(SQLStoreD49P2132_Grid("Do nguon luoi","",_ProjectID,_ContractID,"LoadGrid",_OTransID));
            L3DataSource.LoadDataSource(tdbg, dtGrid);
            if (!string.IsNullOrEmpty(sKeyID))
            {
                if (!tdbg.IsFocused)//Nếu con trỏ chưa đứng trên lưới thì Focus về lưới
                    tdbg.Focus();

                for (int i = 0; i < tdbg.VisibleRowCount; i++)
                {
                    DataRow drLoop = (tdbg.GetRow(tdbg.GetRowHandleByVisibleIndex(i)) as DataRowView).Row;
                    if (drLoop[COL_TransID.FieldName].ToString() == sKeyID)
                    {
                        HandleRowFocus(i);
                        break;
                    }
                }
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


        string sCallFrom = "";
        private void tdbgView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Row == null) return;

            
            if (e.Column == COL_InventoryID)
            {
                tdbg.SetFocusedRowCellValue(COL_InventoryName, tdbdInventoryID.ReturnValue("InventoryName"));
                // Xử lý chọn giá trị đầu tiên
                DataRow[] rowSelect = dtInventoryUnitID.Select("InventoryID = " + L3SQLClient.SQLString(e.Value));

                if (rowSelect.Length > 0)
                    tdbg.SetFocusedRowCellValue(COL_InventoryUnitID, rowSelect[0]["UnitID"]);
                else
                    tdbg.SetFocusedRowCellValue(COL_InventoryUnitID, null);
            }
            if (e.Column == COL_OQuantity)  
            {
                if(sCallFrom != "A")
                {
                    sCallFrom = "Q";
                    if (L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_UnitPrice)) == 0)
                    {
                        tdbg.SetFocusedRowCellValue(COL_UnitPrice, 0);
                    }
                    tdbg.SetFocusedRowCellValue(COL_OAmount, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OQuantity)) * L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_UnitPrice)));
                }
                    
            }
            if (e.Column == COL_UnitPrice)
            {
                if (sCallFrom != "A")
                {
                    sCallFrom = "U";
                    if (L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OQuantity)) == 0)
                    {
                        tdbg.SetFocusedRowCellValue(COL_OQuantity, 1);
                    }
                    tdbg.SetFocusedRowCellValue(COL_OAmount, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OQuantity)) * L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_UnitPrice)));
                }
            }

            if (e.Column == COL_OAmount)
            {
                tdbg.SetFocusedRowCellValue(COL_VATOAmount, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) * L3ConvertType.Number(txtVATRate.EditValue)/100);
                tdbg.SetFocusedRowCellValue(COL_TotalOAmount, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) + L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_VATOAmount)));


                if (sCallFrom == "Q" || sCallFrom == "U")
                {
                }
                else
                {
                    sCallFrom = "A";
                    if (L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OQuantity)) != 0 && L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_UnitPrice)) != 0)
                    {
                        tdbg.SetFocusedRowCellValue(COL_OQuantity, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) / L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_UnitPrice)));
                    }
                    else
                    {
                        if (L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OQuantity)) == 0)
                        {
                            tdbg.SetFocusedRowCellValue(COL_OQuantity, 1);
                            tdbg.SetFocusedRowCellValue(COL_UnitPrice, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)));
                        }
                        if (L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_UnitPrice)) == 0)
                        {
                            tdbg.SetFocusedRowCellValue(COL_UnitPrice, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) / L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OQuantity)));
                        }
                    }                          
                }
           
            }

            if (e.Column == COL_VATOAmount)
            {
                tdbg.SetFocusedRowCellValue(COL_TotalOAmount, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) + L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_VATOAmount)));
            }
        }
        
        private bool AllowSave()
        {
            int iNewitem = 0;
            if(tdbgView.NewItemRowPosition==NewItemRowPosition.Bottom)
            {
                iNewitem = 1;
            }
            for (int i = 0; i < tdbg.VisibleRowCount-iNewitem; i++)
            {
                if (tdbg.GetCellValue(i, COL_InventoryID).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_InventoryID.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_InventoryID;
                    return false;
                }

                if (tdbg.GetCellValue(i, COL_OQuantity).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_OQuantity.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_OQuantity;
                    return false;
                }

                if (tdbg.GetCellValue(i, COL_UnitPrice).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_UnitPrice.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_UnitPrice;
                    return false;
                }

                if (tdbg.GetCellValue(i, COL_OAmount).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_OAmount.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_OAmount;
                    return false;
                }

                if (tdbg.GetCellValue(i, COL_VATOAmount).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_VATOAmount.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_VATOAmount;
                    return false;
                }

                if (tdbg.GetCellValue(i, COL_TotalOAmount).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_TotalOAmount.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_TotalOAmount;
                    return false;
                }
            }
            return true;
        }
                  
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (!btnSave.IsFocused)
                return;
            int iNewItem = 0;
            if(tdbgView.NewItemRowPosition==NewItemRowPosition.Bottom)
            { iNewItem = 1; }
            if(tdbg.VisibleRowCount<=iNewItem)
            {
                D99D0041.D99C0008.MsgNoDataInGrid();
                return;
            }
            //Hỏi trước khi lưu
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
                return;
            SaveData(sender);
        }      

        private bool SaveData(System.Object sender)
        {
            _bSavedOK = false;
            if (!AllowSave())
                return false;
            int iAddrow = 1;
            if (tdbgView.NewItemRowPosition == NewItemRowPosition.Bottom)
            { iAddrow = 2; }
            for (int i = 0; i <= tdbg.VisibleRowCount - iAddrow; i++)
            {        
                DataRow dr = (tdbg.GetRow(tdbg.GetRowHandleByVisibleIndex(i)) as DataRowView).Row;
                dr["OAmount"] = L3ConvertType.Number(dr["OAmount"], L3Format.DxxFormat.D90_ConvertedDecimals);
                dr["VATOAmount"] = L3ConvertType.Number(dr["VATOAmount"], L3Format.DxxFormat.D90_ConvertedDecimals);
                dr["TotalOAmount"] = L3ConvertType.Number(dr["TotalOAmount"], L3Format.DxxFormat.D90_ConvertedDecimals);

                dr["OQuantity"] = L3ConvertType.Number(dr["OQuantity"], L3Format.DxxFormat.D07_QuantityDecimals);

                dr["UnitPrice"] = L3ConvertType.Number(dr["UnitPrice"], L3Format.DxxFormat.D07_UnitCostDecimals);

            }

            L3SQLBulkCopy bulkCopy = new L3SQLBulkCopy();

            this.Cursor = Cursors.Wait;
            bulkCopy.AddSQLAfter(SQLStoreD49P2132_Save("Store luu","",_ProjectID,_ContractID,"SaveData",_OTransID));
            bool bRunSQL = bulkCopy.CheckStoreBulkCopy(dtGrid, "#D49T2132");
            this.Cursor = Cursors.Arrow;

            if (bRunSQL)
            {
                //Lemon3.Messages.L3Msg.SaveOK();   //(CheckStoreBulkCopy) đã thông báo rồi,nên ở đây không cần thông báo nữa.
                _bSavedOK = true;                
            }
            else
            {
                //Lemon3.Messages.L3Msg.SaveNotOK();   //(CheckStoreBulkCopy) đã thông báo rồi,nên ở đây không cần thông báo nữa.
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region SQL
        private string SQLStoreD49P2132(string sComment,string sTransID, string sProjectID, string sContactID, string sDataType)
        {
            string sSQL = "";
            sSQL += ("-- "+ sComment + Environment.NewLine);
            sSQL += "Exec D49P2132 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA; // TranMonth
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA; // TranYear
            sSQL += L3SQLClient.SQLString(sTransID) + L3.COMMA; // TransID
            sSQL += L3SQLClient.SQLString(sProjectID) + L3.COMMA; // ProjectID
            sSQL += L3SQLClient.SQLString(sContactID) + L3.COMMA; // ContactID
            sSQL += L3SQLClient.SQLString(sDataType) ; // DataType
        
            return sSQL;
        }
        private string SQLStoreD49P2132_Grid(string sComment, string sTransID, string sProjectID, string sContactID, string sDataType, string sOTransID)
        {
            string sSQL = "";
            sSQL += ("-- " + sComment + Environment.NewLine);
            sSQL += "Exec D49P2132 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA; // TranMonth
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA; // TranYear
            sSQL += L3SQLClient.SQLString(sTransID) + L3.COMMA; // TransID
            sSQL += L3SQLClient.SQLString(sProjectID) + L3.COMMA; // ProjectID
            sSQL += L3SQLClient.SQLString(sContactID) + L3.COMMA; // ContactID
            sSQL += L3SQLClient.SQLString(sDataType) + L3.COMMA; // DataType

            sSQL += L3SQLClient.SQLString(sOTransID) + L3.COMMA; // OtransID
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.NewLine);
            return sSQL;
        }     


        private string SQLStoreD49P2132_Save(string sComment, string sTransID, string sProjectID, string sContactID, string sDataType,string sOTransID)
        {
            
            for (int i = 0; i <= tdbg.VisibleRowCount - 1; i++)
            {
                if (L3ConvertType.L3String(tdbg.GetCellValue(i, COL_TransID)).Equals("") == true)
                {
                   
                    sTransID = L3CreateIGE.CreateIGE("D49T2130", "TransID", "49", "DM", L3CreateIGE.KeyString);
                    tdbg.SetCellValue(i,"TransID",sTransID);
                }
                              
            }
            string sSQL = "";

            sSQL += ("-- " + sComment + Environment.NewLine);
            sSQL += "Exec D49P2132 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA; // TranMonth
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA; // TranYear
            sSQL += L3SQLClient.SQLString(sTransID) + L3.COMMA; // TransID
            sSQL += L3SQLClient.SQLString(sProjectID) + L3.COMMA; // ProjectID
            sSQL += L3SQLClient.SQLString(sContactID) + L3.COMMA; // ContactID
            sSQL += L3SQLClient.SQLString(sDataType) + L3.COMMA; // DataType
            sSQL += L3SQLClient.SQLString(sOTransID) + L3.COMMA; // OTransID
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID
            sSQL += L3SQLClient.SQLString(Environment.MachineName); // HostID
            return sSQL;
        }
        #endregion

        private void PART_GridControlUnitID_Loaded(object sender, RoutedEventArgs e)
        {
            GridControl gc = sender as GridControl;
            gc.FilterString = "InventoryID = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_InventoryID));
        }

        private void tdbgView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            sCallFrom = "";
        }

    }
}
