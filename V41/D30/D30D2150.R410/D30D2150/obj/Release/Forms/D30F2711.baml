   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp  D @D30D2150, Version=4.10.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:D30D2150D30D2150    D30D2150.D30F2711   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     EL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  "localclr-namespace:D30D2150  -     � Title$#  Chi tiết phiếu - D30F2711��$	��680��$
��1024��.���  � RowDefinitions �� �� $��37 �.+�'   !Lemon3.Controls.DevExp.L3GroupBox  $��0��$��5,5,5,0q�$��5q����� -    ��Name$ 	textblock��$
��Bold"�
Chi tiết.��*   $Lemon3.Controls.DevExp.L3GridControl  -     Name$
 tdbg��$��0��$��1��)  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration .  � 	Resources *  $DevExpress.Xpf.Grid.GridColumnHeader �� 
TargetType	 �� Property
 �� Value��%-   '        �� "  .��� 	 � ��$
 40��%  DevExpress.Xpf.Grid.GridControl   View #  DevExpress.Xpf.Grid.TableView  -     Name$ tdbgTableView��&   DevExpress.Xpf.Grid.DataViewBase   ShowFilterPanelMode$ Never=�   AllowPerPixelScrolling .    ShowTotalSummary .     AllowEditing .     ShowAutoFilterRow .    Columns. $  DevExpress.Xpf.Grid.GridColumn  -     Name$ COL_InventoryID��$	  DevExpress.Xpf.Grid.ColumnBase 	  	FieldName$ InventoryID��$
  DevExpress.Xpf.Grid.BaseColumn 
  Header)  #DevExpress.Xpf.Core.ObjectConverter$ 	Mã hàng  
  MinWidth$ 80�� 
  Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 80* ' 
   HorizontalHeaderContentAlignment$ Center=�  -   $ COL_InventoryName��$ 
Tên hàng $ InventoryName��$ Center=�$	 140��$
 140*   -   $ 
COL_UnitID��$
 ĐVT $ UnitID��$ Center=�$ 50��$	 50*   -   $ 	COL_Model��$ Model $ Model��$ Center=�$ 50��$	 50*   -	   $ COL_ProDateFrom��$ Ngày bắt đầu $ ProDateFrom��$ Center=�$ 80��$	 80*  
  HeaderTemplate �� .R��� $
��Wrap=� �� TextAlignment$ Center=�����   -
   $ COL_ProDateTo��$ Ngày kết thúc $ 	ProDateTo��$ Center=�$ 80��$	 80*  �� .R��� $
��Wrap=�$ Center=�����   -   $ COL_ProDate��$ Ngày nhập kho $ ProDate��$ Center=�$ 80��$	 80*  �� .R��� $
��Wrap=�$ Center=�����   -   $ COL_Spec01ID��$ Spec01ID $ Spec01ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec02ID��$ Spec02ID $ Spec02ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec03ID��$ Spec03ID $ Spec03ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec04ID��$ Spec04ID $ Spec04ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec05ID��$ Spec05ID $ Spec05ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec06ID��$ Spec06ID $ Spec06ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec07ID��$ Spec07ID $ Spec07ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec08ID��$ Spec08ID $ Spec08ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec09ID��$ Spec09ID $ Spec09ID��$ Center=�$	 110��$
 110*   -   $ COL_Spec10ID��$ Spec10ID $ Spec10ID��$ Center=�$	 110��$
 110*   -   $ COL_SDID��$ 
Kho xuất $
 SDID��$ Center=�$	 110��$
 110*   -   $ COL_SRID��$ 
Kho nhập $
 SRID��$ Center=�$	 110��$
 110*   -   $ COL_OQTY��$ Số lượng $
 OQTY��$ Center=�$	 110��$
 110*   -   $ COL_CQTY��$ Số lượng QĐ $
 CQTY��$ Center=�$	 110��$
 110*   -   $ COL_UseFormula��$ Số lượng QĐ $ 
UseFormula�� 
  Visible .    -   $ COL_ConversionFactor��$ Số lượng QĐ $ ConversionFactor�� .    -   $ COL_Type��$ Số lượng QĐ $
 Type�� .    -   $ COL_VoucherTypeID��$ Số lượng QĐ $ VoucherTypeID�� .    -   $ COL_Formula��$ Số lượng QĐ $ Formula�� .    -   $ COL_SalesOrderID��$ Số lượng QĐ $ SalesOrderID�� .    -    $ COL_TranTypeID��$ Số lượng QĐ $ 
TranTypeID�� .  +   %Lemon3.Controls.DevExp.L3SimpleButton  -!     Name$ btnClose��$��Đóng��$��1��$��Right=�$��0,6,5,6q�$��25��$��Center=�$��80��