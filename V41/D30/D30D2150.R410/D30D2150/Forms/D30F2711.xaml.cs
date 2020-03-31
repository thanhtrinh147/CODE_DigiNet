using DevExpress.Xpf.Grid;
using Lemon3.Controls.DevExp;
using System;
using System.Collections;
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

namespace D30D2150
{
    /// <summary>
    /// Interaction logic for D30F2711.xaml
    /// </summary>
    public partial class D30F2711 : L3Window
    {
        public D30F2711()
        {
            InitializeComponent();
        }

        private byte bNumber = 0;
        public byte Number
        {
            set
            {
                bNumber = value;
            }
        }

        private DataTable _dtGrid = null;
        public DataTable Grid 
        {
            set
            {
              _dtGrid = value ;
            }
        }

        private string sHeader = "Chi tiết";
        public string Header 
        {
            set
            {
               sHeader = value ;
            }
        }

        private ArrayList arrColVisible = null;
        public ArrayList ColVisible
        {
            set
            {
                arrColVisible = value;
            }
        }

        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Lemon3.L3Format.LoadCustomFormat();
            LoadLanguage();
            SetHeaderGroup();
          
            DataTable dtSpec = null;
            Lemon3.LoadFN.L3SpecificationID COL_Spec = new Lemon3.LoadFN.L3SpecificationID();
            COL_Spec.LoadSpecificationCaption(tdbg, COL_Spec01ID, false, ref dtSpec);

            tdbg_LoadColumns();
            tdbg_NumberFormat();
            tdbg_SetFooter();
            LoadTDBGGrid();
            this.Cursor = Cursors.Arrow;
        }

        private void tdbg_LoadColumns()
        {
            VisibleCol();
            switch (bNumber)
            {
                case 1:
                    COL_ProDateFrom.Header = Lemon3.Resources.L3Resource.rL3("Ngay_bat_dau");
                    COL_ProDateTo.Header = Lemon3.Resources.L3Resource.rL3("Ngay_ket_thuc");
                    COL_ProDate.Header = Lemon3.Resources.L3Resource.rL3("Ngay_nhap_kho");
                    COL_CQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_OQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_SDID.Visible = false;
                    COL_SRID.Visible = false;
                    break;
                case 2:
                    COL_ProDateFrom.Header = Lemon3.Resources.L3Resource.rL3("Ngay_san_xuat");
                    COL_ProDateTo.Header = Lemon3.Resources.L3Resource.rL3("Ngay_hoan_thanh");
                    COL_ProDate.Header = Lemon3.Resources.L3Resource.rL3("Ngay_giao_hang");
                    COL_CQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_OQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_SDID.Visible = false;
                    COL_SRID.Visible = false;
                    break;
                case 3:
                    COL_ProDateFrom.Header = Lemon3.Resources.L3Resource.rL3("Ngay_san_xuat");
                    COL_CQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_OQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_SDID.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_SRID.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_ProDateTo.Visible = false;
                    COL_ProDate.Visible = false;
                    break;
                case 4:
                    COL_ProDate.Header = Lemon3.Resources.L3Resource.rL3("Ngay_nhan_hang_du_kien_");                 
                    COL_CQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_OQTY.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_SRID.Fixed = DevExpress.Xpf.Grid.FixedStyle.Right;
                    COL_SDID.Visible = false;
                    COL_ProDateFrom.Visible = false;
                    COL_ProDateTo.Visible = false;
                    break;
                case 5:
                case 6:
                    COL_ProDateTo.Visible = false;
                    COL_ProDate.Visible = false;
                    break;
            }
        }

        private void VisibleCol()
        {
            if (arrColVisible != null)
            {
                for (int i = 0; i < arrColVisible.Count; i++)
                {
                    tdbg.Columns.GetColumnByFieldName(arrColVisible[i].ToString()).Visible = false;
                }
            }
        }

        private void SetHeaderGroup()
        {
            textblock.Text = sHeader;
        }

        private void LoadTDBGGrid()
        {
            if (_dtGrid != null)
            {
                L3DataSource.LoadDataSource(tdbg, _dtGrid);
            }
        }

        private void tdbg_NumberFormat()
        {
            tdbg.InputNumber288(Lemon3.L3Format.DxxFormat.D07_QuantityDecimals, false, true, COL_OQTY);
            tdbg.InputNumber288(Lemon3.L3Format.DxxFormat.D07_QuantityDecimals, false, true, COL_CQTY);
        }

        private void tdbg_SetFooter()
        {
            tdbg.FooterText(new[] { COL_InventoryName }, new GridColumn[] { }, true);
            tdbg.FooterTextSum(COL_OQTY);
            tdbg.FooterTextSum(COL_CQTY);
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void tdbg_LoadSpecificationCaption()
        //{
        //    if (arrSpecificationCaption != null)
        //    {
        //        for (int i = 1; i <= arrSpecificationCaption.Count; i++)
        //        {
        //            string sColName = i < 10 ? "Spec0" + i + "ID" : "Spec" + i + "ID";
        //            tdbg.Columns.GetColumnByFieldName(sColName).Header = arrSpecificationCaption[i];
        //        }
        //    }
        //}

        private void LoadLanguage()
        {
            this.Title = Lemon3.Resources.L3Resource.rL3("Chi_tiet_phieu") + " - D30F2711";

            COL_InventoryID.Header = Lemon3.Resources.L3Resource.rL3("Ma_hang");
            COL_InventoryName.Header = Lemon3.Resources.L3Resource.rL3("Ten_hang_");
            COL_UnitID.Header = Lemon3.Resources.L3Resource.rL3("DVT");
            COL_OQTY.Header = Lemon3.Resources.L3Resource.rL3("So_luong");
            COL_CQTY.Header = Lemon3.Resources.L3Resource.rL3("So_luong_QD");
            COL_ProDateFrom.Header = Lemon3.Resources.L3Resource.rL3("Ngay_san_xuat");
            COL_SDID.Header = Lemon3.Resources.L3Resource.rL3("Kho_nhap");
            COL_SRID.Header = Lemon3.Resources.L3Resource.rL3("Kho_xuat");

            btnClose.Content = Lemon3.Resources.L3Resource.rL3("DongU1");
        }

        private void tdbg_FilterChanged(object sender, RoutedEventArgs e)
        {
            HandleRowFocus(tdbg.GetRowHandleByVisibleIndex(0));
            try
            {
                if ((_dtGrid == null))
                    return;
            }
            catch (Exception ex)
            {

            }
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tdbgTableView.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                tdbgTableView.FocusedColumn = tdbg.CurrentColumn as GridColumn;
                tdbgTableView.ShowEditor();
            }), DispatcherPriority.Render);
        }

        private void HandleRowFocus(int indexRowFocus)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tdbgTableView.MoveFocusedRow(indexRowFocus);
                //tdbgTableView.SelectRow(indexRowFocus);
                tdbg.FocusRowHandle(indexRowFocus);
            }), DispatcherPriority.Render);

            tdbg.SelectedItem = indexRowFocus;
            tdbgTableView.FocusedRowHandle = indexRowFocus;
        }
    }
}
