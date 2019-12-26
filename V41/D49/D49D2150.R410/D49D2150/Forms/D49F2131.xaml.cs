using D49D2150;
using DevExpress.Xpf.Grid;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using Lemon3.LoadFN;
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
    /// Interaction logic for D49F2131.xaml
    /// </summary>
    public partial class D49F2131 : L3Window
    {
        
        public D49F2131()
        {
            InitializeComponent();
        }
        public DataTable dtGrid = null;
        public DataTable DTGrid
        {
            set { dtGrid = value; }
        }

        private int iPerD49F2133 = -1;
        private bool _bLoadFormState = false;
        public bool bSAveOk = false;


        #region Truyền biến
        private string _projectID ;
        public string ProjectID
        {
            set { _projectID = value; }
        }
        private string _contractNo ;
        public string ContractNo
        {
            set { _contractNo = value; }
        }
        private string _objectID;
        public string ObjectID
        {
            set { _objectID = value; }
        }
        #endregion

        private EnumFormState _formState = EnumFormState.FormAdd;
        public EnumFormState FormState
        {
            set
            {
                _formState = value;
              
                LoadExt();
                LoadTDBCombo();
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                        EnableAddNew();                       
                        break;
                    case EnumFormState.FormEdit:
                        EnableEdit();
                        LoadEdit();
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
            tdbg.SetDefaultGridControlInput();
            if (!_bLoadFormState) FormState = _formState;
            LoadLanguage();

            LoadTDBDrop();
            LoadTDBGrid("", "LoadGrid");

            
            this.Cursor = Cursors.Arrow;

        }
        private void DefaultAndFormat()
        {
            L3Format.LoadCustomFormat();

            tdbg.InputDate(COL_FromDate,COL_ToDate);
            tdbg.InputDate("MM/yyyy", COL_PeriodID);
            tdbg.InputNumber(L3Format.DxxFormat.D90_ConvertedDecimals, false, false,28,8, COL_OAmount, COL_VATOAmount, COL_TotalOAmount);
            tdbg.InputNumber288(L3Format.DxxFormat.D07_QuantityDecimals, false, false, COL_OQuantity);
            tdbg.InputNumber288(L3Format.DxxFormat.D07_UnitCostDecimals, false, false, COL_UnitPrice);
            tdbg.InputPercent(false, false, 28, 8, COL_VATRate);


            this.SetBackColorObligatory(new Control[] { tdbcProjectID, tdbcContractNo, tdbcObjectID }, null);
            this.SetBackColorObligatory(null, new GridColumn[] {COL_PeriodID, COL_ProductID, COL_OQuantity, COL_UnitPrice, COL_OAmount, COL_VATGroupID, COL_VATOAmount, COL_TotalOAmount });
            tdbg.LockCoumns(true, COL_ServiceTypeName, COL_VATRate);       
            if (_formState == EnumFormState.FormAdd)
            {
                
                this.SetBackColorObligatory(null, new GridColumn[] {COL_UnitID});
            }
            //else
            //{
            //    if((_formState == EnumFormState.FormEdit))
            //    {
            //        tdbg.LockCoumns(true, COL_PeriodID);  
            //    }
            //}

            
        }
        private void EnableAddNew()
        {
            LockMaster(false);           
            btnFilter.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;          
            btnNext.IsEnabled = false;         
        }
        private void EnableEdit()
        {
             LockMaster(true);             
            tdbgView.AllowEditing = true;   
            tdbgView.NewItemRowPosition = NewItemRowPosition.Bottom;
            btnFilter.Visibility = Visibility.Visible;
            btnFilter.IsEnabled = false;
            btnEdit.Visibility = Visibility.Hidden;          
            btnNext.IsEnabled = false;
            chkIsByContract.IsEnabled = true;
            chkIsRoundMonth.IsEnabled = true;
            
            
        }
        private void LoadEdit()
        {
            tdbcProjectID.EditValue =_projectID;
            tdbcContractNo.EditValue = _contractNo;
            tdbcObjectID.EditValue = _objectID;
            dtGrid = L3SQLServer.ReturnDataTable(SQLStoreD49P2131_load("LoadGrid Edit",tdbcProjectID.ReturnValue("ProjectID"),tdbcContractNo.ReturnValue("ContractID"),tdbcObjectID.ReturnValue("ObjectID"),"LoadGrid"));
            L3DataSource.LoadDataSource(tdbg, dtGrid);
        }
        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Cap_nhat_ke_hoach_thu_tien") + " - " + this.GetType().Name;

            grpCon.Text = L3Resource.rL3("Dieu_kien_loc");

            lblProjectName.Content = L3Resource.rL3("Du_an");
            lblContractNo.Content = L3Resource.rL3("So_hop_dong_");
            lblObjectID.Content = L3Resource.rL3("Khach_hang");

            tdbcProjectID.SetCaptionColumn("ProjectID", L3Resource.rL3("Ma"));
            tdbcProjectID.SetCaptionColumn("ProjectName", L3Resource.rL3("Ten"));

            tdbcContractNo.SetCaptionColumn("ContractNo", L3Resource.rL3("Ma"));
            tdbcContractNo.SetCaptionColumn("ContractDesc", L3Resource.rL3("Dien_giai"));

            tdbcObjectID.SetCaptionColumn("ObjectID", L3Resource.rL3("Ma"));
            tdbcObjectID.SetCaptionColumn("ObjectName", L3Resource.rL3("Ten"));

            tdbdProductID.SetCaptionColumn("ProductID", L3Resource.rL3("Ma"));
            tdbdProductID.SetCaptionColumn("ProductName", L3Resource.rL3("Ten"));

            tdbdVATGroupID.SetCaptionColumn("ID", L3Resource.rL3("Ma"));
            tdbdVATGroupID.SetCaptionColumn("Name", L3Resource.rL3("Ten"));

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
            COL_VATRate.Header = L3Resource.rL3("Ty_leU");
            COL_VATOAmount.Header = L3Resource.rL3("Thue");
            COL_TotalOAmount.Header = L3Resource.rL3("TT_sau_thue");
            COL_FromDate.Header = L3Resource.rL3("Tu_ngay");
            COL_ToDate.Header = L3Resource.rL3("Den_ngay");
            COL_Note.Header = L3Resource.rL3("Ghi_chu");
            COL_IsDetailInvoice.Header = L3Resource.rL3("Xuat_hoa_don_chi_tiet");
            COL_Note.Header = L3Resource.rL3("Ghi_chu");
            COL_Attack.Header = L3Resource.rL3("Dinh_kem");
            COL_DetailInvoice.Header = L3Resource.rL3("Chi_tiet_hoa_don");

            chkIsByContract.Content = L3Resource.rL3("Cap_nhat_theo_hop_dong");
            chkIsRoundMonth.Content = L3Resource.rL3("Lam_tron_thang");

            btnFilter.Content = L3Resource.rL3("Loc");
            btnEdit.Content = L3Resource.rL3("Sua");

            btnExportBeforeRevenue.Content = L3Resource.rL3("Trich_truoc_doanh_thu");
            btnPaymentRequest.Content = L3Resource.rL3("De_nghi_thu_tien");
            btnSave.Content = L3Resource.rL3("Luu");
            btnNext.Content = L3Resource.rL3("Nhap_tiep");
            //btnClose.Content = L3Resource.rL3("Dong_");
        }
        private void LoadExt()
        {
            iPerD49F2133 = L3Permissions.ReturnPermission("D49F2133");
        }

        private void LoadTDBCombo()
        {
            //cbo du an
            LoadTDBCProjectID();
            //cbo hop dong
            //LoadTDBCContractNo();
            ////cbo khach hang
            //LoadTDBCObjectID();
  
        }
        private void LoadTDBDrop()
        {
            LoadTDBDProductID();
            LoadTDBDVATGroupID();
            LoadtdbdUnitID();
        }
        private void LoadTDBDProductID()
        {
            L3DataSource.LoadDataSource(tdbdProductID, SQLStoreD49P2131_load("DD Mã dịch vụ", tdbcProjectID.ReturnValue("ProjectID"), tdbcContractNo.ReturnValue("ContractID"), "%", "ProductID"));
        }
        DataTable dtUnit;
        private void LoadtdbdUnitID()
        {
            string sSQL = SQLStoreD49P2131_load("Load DD DVT", L3ConvertType.L3String(tdbcProjectID.ReturnValue("ProjectID")), L3ConvertType.L3String(tdbcContractNo.ReturnValue("ContractID")), "%", "UnitID", chkIsByContract.IsChecked.Value, chkIsRoundMonth.IsChecked.Value);
            sSQL += L3.COMMA + L3SQLClient.SQLString(L3.STRLanguage);
            
             dtUnit = L3SQLServer.ReturnDataTable(sSQL);
            L3DataSource.LoadDataSource(tdbdUnitID, dtUnit);
        }       
        private void LoadTDBDVATGroupID()
        {
            string sSQL = "--load VATGroupID" + Environment.NewLine;
            sSQL += "Exec D05P0002 ";
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA + L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString("9") + L3.COMMA;
            sSQL += L3ConvertType.L3Int(L3.IsUniCode) +L3.COMMA+ L3SQLClient.SQLString(L3.STRLanguage);

            DataTable dt = L3SQLServer.ReturnDataTable(sSQL);

            L3DataSource.LoadDataSource(tdbdVATGroupID, L3DataTable.ReturnTableFilter(dt, "Code = 'VATGroupID' "));
            
        }
        private void LoadTDBCProjectID()
        {
            DataTable dt = L3SQLServer.ReturnDataTable(SQLStoreD49P2131_load("Combo du an", "%", "%", "%", "ProjectID"));
            L3DataSource.LoadDataSource(tdbcProjectID, dt);         
           
        }
        private void LoadTDBCContractNo()
        {   
            string sSQL= SQLStoreD49P2131_load("Combo Hợp đồng",tdbcProjectID.ReturnValue("ProjectID"), "%", "%", "ContractID");
            L3DataSource.LoadDataSource(tdbcContractNo,sSQL);                
        }
        private void LoadTDBCObjectID()
        {
            string sSQL = SQLStoreD49P2131_load("Combo khách hàng", tdbcProjectID.ReturnValue("ProjectID"), tdbcContractNo.ReturnValue("ContractID"), "%", "ObjectID");
            L3DataSource.LoadDataSource(tdbcObjectID, sSQL);           
            
        }
        private void LoadTDBGrid(string sKey = "", string mode="")
        {
            if (_formState == EnumFormState.FormAdd)
            {
                string sSQL = SQLStoreD49P2131_load("Load luoi", tdbcProjectID.ReturnValue("ProjectID"), tdbcContractNo.ReturnValue("ContractID"), tdbcObjectID.ReturnValue("ObjectID"), mode, chkIsByContract.IsChecked.Value, chkIsRoundMonth.IsChecked.Value);
                dtGrid = L3SQLServer.ReturnDataTable(sSQL);
            }
            L3DataSource.LoadDataSource(tdbg, dtGrid);
            ReLoadTDBGrid();
            if (sKey != "")
            {
                int row = tdbg.FindRowByValue(COL_ContractNo, sKey);
                if (row >= 0) tdbg.FocusRowHandle(row);
            }
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
        }
        private string SQLStoreD49P2131_load(string cap, string projectID, string contractID, string objectID, string dataType, bool bIsByContract = false, bool IsRoundMonth = false)
        {
            string sSQL = "--" + cap + Environment.NewLine;
            sSQL += "EXEC  D49P2131 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA + L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA + L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(projectID) + L3.COMMA + L3SQLClient.SQLString(contractID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(objectID) + L3.COMMA + L3SQLClient.SQLString(dataType) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(bIsByContract) + L3.COMMA;
            sSQL += L3SQLClient.SQLNumber(IsRoundMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.MachineName);

            return sSQL;
        }
      
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
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
            //DD ma dịch vu
            L3DataSource.LoadDataSource(tdbdProductID, SQLStoreD49P2131_load("DD Mã dịch vụ", tdbcProjectID.ReturnValue("ProjectID"), tdbcContractNo.ReturnValue("ContractID"), "%", "ProductID"));
            LoadTDBGrid("", "LoadGridAddNew");
            LockMaster(true);
            btnEdit.Visibility = Visibility.Visible;
            btnFilter.Visibility = Visibility.Hidden;
            
        }
        private void LockMaster(Boolean bLock)
        {
            tdbcProjectID.IsEnabled = !bLock;
            tdbcContractNo.IsEnabled = !bLock;
            tdbcObjectID.IsEnabled = !bLock;
            chkIsByContract.IsEnabled = !bLock;
            chkIsRoundMonth.IsEnabled = !bLock;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Du_lieu_tren_luoi_se_bi_xoa_Ban_co_muon_tiep_tuc_khongU")) == System.Windows.Forms.DialogResult.Yes)
            {
                if(dtGrid!=null) dtGrid.Clear();
                btnEdit.Visibility = Visibility.Hidden;
                btnFilter.Visibility = Visibility.Visible;
                LockMaster(false);
               // btnSave.IsEnabled = true;
                tdbgView.AllowEditing = true;
            }
        }
        string sCallFrom = "";
        private void tdbgView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if(e.Column==COL_ProductID)
            {
                tdbg.SetCellValueRowFocused(COL_ProductName, tdbdProductID.ReturnValue("ProductName"));             
                tdbg.SetCellValueRowFocused(COL_ConversionFactor,L3ConvertType.Number(tdbdProductID.ReturnValue("ConversionFactor")));
                tdbg.SetCellValueRowFocused(COL_ServiceTypeName, L3ConvertType.L3String(tdbdProductID.ReturnValue("ServiceTypeName")));
                tdbg.SetCellValueRowFocused(COL_ServiceTypeID, L3ConvertType.L3String(tdbdProductID.ReturnValue("ServiceTypeID")));
                tdbg.SetFocusedRowCellValue(COL_UnitID, tdbdUnitID.ReturnValue("UnitID"));

                // Xử lý chọn giá trị đầu tiên
                DataRow[] rowSelect = dtUnit.Select("ProductID = " + L3SQLClient.SQLString(e.Value));

                if (rowSelect.Length > 0)
                    tdbg.SetFocusedRowCellValue(COL_UnitID, rowSelect[0]["UnitID"]);
                else
                    tdbg.SetFocusedRowCellValue(COL_UnitID, null);
                
            }
            if(e.Column==COL_VATGroupID)
            {
                tdbg.SetCellValueRowFocused(COL_VATRate, tdbdVATGroupID.ReturnValue("RateTax"));
            }
           
            if(e.Column==COL_UnitID)
            {
                tdbg.SetCellValueRowFocused(COL_ConversionFactor,L3ConvertType.L3Int(tdbdUnitID.ReturnValue("ConversionFactor")));
            }
            if (e.Column == COL_VATRate)
            {
                //thue
                Double d = L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) * L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_VATRate));
                tdbg.SetCellValueRowFocused(COL_VATOAmount, d);
                //TT sau the
                d = L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) + L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_VATOAmount));
                tdbg.SetCellValueRowFocused(COL_TotalOAmount, d);
                
            }
           
            if (e.Column == COL_OQuantity)
            {
                if (sCallFrom != "A")
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
                tdbg.SetFocusedRowCellValue(COL_VATOAmount, L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_OAmount)) * L3ConvertType.Number(tdbg.GetFocusedRowCellValue(COL_VATRate)));
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

        }
        private void btnInvoiceDetail_Click(object sender, RoutedEventArgs e)
        {
            D49F2132 f = new D49F2132();
            f.OTransID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_TransID));
            f.ProjectID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProjectID));
            f.ProjectName = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProjectName));
            f.ContractID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ContractID));
            f.ContractNo = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ContractNo));
            f.PeriodID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_PeriodID));
            f.ProductID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProductID));
            f.ProductName = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ProductName));
            f.ObjectID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_ObjectID));
            f.OAmount = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_OAmount));
            f.VATGroupID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_VATGroupID));
            f.VATRate = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_VATRate));
            f.VATOAmount =L3ConvertType.L3String( tdbg.GetFocusedRowCellValue(COL_VATOAmount));
            f.TotalOAmount = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_TotalOAmount));
            f.UnitID = L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_UnitID));
            f.ShowDialog();
            
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            Lemon3.IO.L3CallDLL oCallDLL = new Lemon3.IO.L3CallDLL();
            Lemon3.IO.StructureProperties[] arrPro = null;
            oCallDLL.SetProperties(ref arrPro, "TableName", "D49T2130");
            oCallDLL.SetProperties(ref arrPro, "Permission", "D49T2130");
            oCallDLL.SetProperties(ref arrPro, "DivisionID", L3.DivisionID);
            oCallDLL.SetProperties(ref arrPro, "Key1ID", L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(COL_TransID)));
            oCallDLL.CallFormShowDialog("D91D0340", "D91F4010", arrPro);
        }

        private void btnExportBeforeRevenue_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid == null) return;
            dtGrid.AcceptChanges();
            DataRow[] dr = dtGrid.Select("IsSelected = True");
            if (dr.Length == 0)
            {
                D99D0041.D99C0008.Msg(L3Resource.rL3("Ban_chua_chon_du_lieu_tren_luoi"));
                return;
            }
            string sSQL = "--Trích trước doanh thu" + Environment.NewLine + "begin tran" + Environment.NewLine;
            sSQL += SQLInsertD49T9009_Temp("AccrualRevenue")+Environment.NewLine;
            sSQL += SQLStoreD49P2131_save("Trích trước doanh thu", tdbcProjectID.ReturnValue("ProjectID").ToString(), tdbcContractNo.ReturnValue("ContractID").ToString(), tdbcObjectID.ReturnValue("ObjectID").ToString(),"AccrualRevenue");
            sSQL += Environment.NewLine + "commit tran";
            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    L3Msg.MyMsg(L3Resource.rL3("Trich_truoc_doanh_thu_thanh_cong"));
                }
            }
            catch { };
           
        }

        private void btnPaymentRequest_Click(object sender, RoutedEventArgs e)
        {
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
            sSQL += SQLStoreD49P2131_save("Đề nghị thu tiền", tdbcProjectID.ReturnValue("ProjectID").ToString(), tdbcContractNo.ReturnValue("ContractID").ToString(), tdbcObjectID.ReturnValue("ObjectID").ToString(), "CashRequest");
            sSQL += Environment.NewLine + "commit tran";
            try
            {
                if (!L3SQLServer.CheckStore(sSQL))
                {
                }
                else
                {
                    L3Msg.MyMsg(L3Resource.rL3("De_nghi_thu_tien_thanh_cong"));
                }
            }
            catch { };
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (!btnSave.Focusable) return;
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
            { return; }

            if (AllowSave()==false)
            {
                return;
            }
            int iAddrow = 1;
            if(tdbgView.NewItemRowPosition== NewItemRowPosition.Bottom)
            { iAddrow = 2; }
            string sTransID = "";
            for (int i = 0; i <= tdbg.VisibleRowCount - iAddrow; i++)
            {
                if (tdbg.GetCellValue(i, COL_TransID).ToString().Equals("") == true)
                {
                    sTransID = L3CreateIGE.CreateIGE("D49T2130", "TransID", "49", "PM", L3CreateIGE.KeyString);
                    tdbg.SetCellValue(i, "TransID", sTransID);
                }
                DataRow dr = (tdbg.GetRow(tdbg.GetRowHandleByVisibleIndex(i)) as DataRowView).Row;
                dr["OAmount"] = L3ConvertType.Number(dr["OAmount"], L3Format.DxxFormat.D90_ConvertedDecimals);
                dr["VATOAmount"] = L3ConvertType.Number(dr["VATOAmount"], L3Format.DxxFormat.D90_ConvertedDecimals);
                dr["TotalOAmount"] = L3ConvertType.Number(dr["TotalOAmount"], L3Format.DxxFormat.D90_ConvertedDecimals);

                dr["OQuantity"] = L3ConvertType.Number(dr["OQuantity"], L3Format.DxxFormat.D07_QuantityDecimals);

                dr["UnitPrice"] = L3ConvertType.Number(dr["UnitPrice"], L3Format.DxxFormat.D07_UnitCostDecimals);
            
            }
            L3SQLBulkCopy bulkCopy = new L3SQLBulkCopy();
            string sSQL = "";
            if (_formState==EnumFormState.FormAdd)
            {
                sSQL = SQLStoreD49P2131_save("Lưu dữ liệu", tdbcProjectID.ReturnValue("ProjectID").ToString(), tdbcContractNo.ReturnValue("ContractID").ToString(), tdbcObjectID.ReturnValue("ObjectID").ToString(), "SaveDataAddNew");
            }else
            {
                //sSQL = SQLStoreD49P2131_save("Lưu dữ liệu", tdbg.GetCellValue(0, COL_ProjectID).ToString(), tdbg.GetCellValue(0, COL_ContractID).ToString(), tdbg.GetCellValue(0,COL_ObjectID).ToString(), "SaveDataEdit");
                sSQL = SQLStoreD49P2131_save("Lưu dữ liệu", tdbg.GetCellValue(0, COL_ProjectID).ToString(), tdbg.GetCellValue(0, COL_ContractID).ToString(), tdbg.GetCellValue(0,COL_ObjectID).ToString(), "SaveDataEdit");

            }           
            this.Cursor = Cursors.Wait;
            bulkCopy.AddSQLAfter(sSQL);
            bool bRunSQL = bulkCopy.CheckStoreBulkCopy(dtGrid, "#D49F2131");
            this.Cursor = Cursors.Arrow;
            if(bRunSQL==true)
            {
                bSAveOk = true;
                //Lemon3.Messages.L3Msg.SaveOK();           
                EnableSaveOK(true);
                                    
            }else
            {
                //Lemon3.Messages.L3Msg.SaveNotOK();
                bSAveOk = false;
            }
        }

        private bool AllowSave()
        {
            int iadd = 1;
            if(tdbgView.NewItemRowPosition==NewItemRowPosition.Bottom)
            {
                iadd = 2;
            }
            if (tdbg.VisibleRowCount < iadd)
            {
                L3Msg.MyMsg(L3Resource.rL3("Ban_phai_nhap_du_lieu_tren_luoiU"));
                return false;
            }
            for (int i = 0; i <= tdbg.VisibleRowCount - 2; i++)
            {
                if (tdbg.GetCellValue(i, COL_PeriodID).ToString() == "" )
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_PeriodID.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_PeriodID;
                    return false;
                }
                if (tdbg.GetCellValue(i, COL_ProductID).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_ProductID.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_ProductID;
                    return false;
                }
                if (tdbg.GetCellValue(i, COL_UnitID).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_UnitID.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_UnitID;
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
               
                  if (tdbg.GetCellValue(i, COL_VATGroupID).ToString() == "")
                {
                    D99D0041.D99C0008.MsgNotYetEnter(COL_VATGroupID.Header.ToString());
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_VATGroupID;
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
                  if (L3ConvertType.L3String(tdbg.GetCellValue(i, COL_FromDate)) != "" && L3ConvertType.L3String(tdbg.GetCellValue(i, COL_ToDate)) != "")
                  {
                      if (Convert.ToDateTime(tdbg.GetCellValue(i, COL_FromDate)) > Convert.ToDateTime(tdbg.GetCellValue(i, COL_ToDate)))
                      {
                          D99D0041.D99C0008.MsgNotYetChoose(Lemon3.Resources.L3Resource.rL3("MSG000013"));
                          tdbgView.FocusedRowHandle = i;
                          tdbgView.FocusedColumn = COL_FromDate;
                          return false;
                      }
                  }
                  
            }
            return true;
        }
        private void EnableSaveOK(Boolean bEnable)
        {        
            if(_formState==EnumFormState.FormAdd)
            {
                //tdbgView.AllowEditing = !bEnable;
                COL_IsSelected.Visible = bEnable;
                
                COL_Attack.Visible = bEnable;
                COL_IsSelected.Visible = bEnable;
            }
            COL_DetailInvoice.Visible = bEnable;
            btnExportBeforeRevenue.IsEnabled = bEnable && iPerD49F2133 >= 2;
            btnPaymentRequest.IsEnabled = bEnable && iPerD49F2133 >= 2;
            btnNext.IsEnabled = bEnable;
            btnSave.IsEnabled = !bEnable;   
              
            if(bEnable==true)
            {
                tdbgView.NewItemRowPosition = NewItemRowPosition.None;
            }else
            {
                tdbgView.NewItemRowPosition = NewItemRowPosition.Bottom;             
            }
            btnEdit.IsEnabled = !bEnable;
               
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (D99D0041.D99C0008.MsgAsk(L3Resource.rL3("Ban_co_muon_nhap_tiep")) == System.Windows.Forms.DialogResult.Yes)
            {
                dtGrid.Clear();
                EnableAddNew();
                EnableSaveOK(false);
            }
           
        }

      

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }
        private string SQLInsertD49T9009_Temp(string Key02ID)
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
            string sSQL ="--"+ cap + Environment.NewLine;
            sSQL += "EXEC  D49P2131   ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranMonth) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.TranYear) + L3.COMMA;          
            sSQL += L3SQLClient.SQLString(projectID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(contracID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(objectID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(DataType) + L3.COMMA;
            sSQL += L3ConvertType.L3Int(chkIsByContract.IsChecked) + L3.COMMA;
            sSQL += L3ConvertType.L3Int(chkIsRoundMonth.IsChecked) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA;
            sSQL += L3SQLClient.SQLString(Environment.MachineName);
            return sSQL;
        }

        private void chkIsByContract_Click(object sender, RoutedEventArgs e)
        {
            if (chkIsByContract.IsChecked == false)
            {
                chkIsRoundMonth.IsChecked = false;
                chkIsRoundMonth.IsEnabled = false;
            }
            else
            {
                chkIsRoundMonth.IsEnabled = true;
            }
        }

       

        private void tdbcProjectID_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            LoadTDBCContractNo();
            tdbcObjectID.SelectedItem = null;
        }

        private void tdbcContractNo_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            LoadTDBCObjectID();
            LoadTDBDProductID();
    
        }

        private void PART_GridControlUnitID_Loaded(object sender, RoutedEventArgs e)
        {
            GridControl gc = sender as GridControl;
            gc.FilterString = "ProductID = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_ProductID));
        }

        private void tdbgView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            sCallFrom = "";
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
    }
}
