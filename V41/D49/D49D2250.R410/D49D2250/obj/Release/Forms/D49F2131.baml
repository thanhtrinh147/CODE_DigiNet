   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D49D2150   D49D2150.D49F2131   =L36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  d	 `DevExpress.Xpf.Docking.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking 	 -     � Title$5  /D49D2131 - Cập nhật Kế hoạch thu tiền��$	��680��$
��1024�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/D49D2150;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?��� $1 +/D99D0451;component/Styles/Lemon3Style.xaml?�%    .���  � RowDefinitions �� $��70 ��� �� $��30 �.+�'   !Lemon3.Controls.DevExp.L3GroupBox  $��0��$��5,0,5,0q�$��Stretch=�$��Stretch=����� -    ��Name$ grpCon��$
��Bold"�Điều kiện lọc.���  � ColumnDefinitions �� $
��auto ��� �� $
��auto ��� �� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $
��auto �.+�$   Lemon3.Controls.DevExp.L3Label  -   	  Name$	 lblProjectName��$��Dự án��$��Center=�$��Center=�$��0��$��	10,0,10,0q�)   #Lemon3.Controls.DevExp.L3LookUpEdit  -   
  Name$
 tdbcProjectID��$��1��$��Stretch=�$��Center=�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit   AutoPopulateColumns .  +  %DevExpress.Xpf.Editors.LookUpEditBase   AutoComplete .    ImmediatePopup . *  $DevExpress.Xpf.Editors.PopupBaseEdit   
PopupWidth$	 350Q�   DisplayMember$ ProjectName��   ValueMember$ 	ProjectID��   ProjectIDTemplate   PopupContentTemplate# �   )  #DevExpress.Xpf.Editors.TextEditBase"   VerticalScrollBarVisibility$ Disabled=�  -   $	 lblContractNo��$��Số hợp đồng��$��Center=�$��Center=�$��2��$��	10,0,10,0q�  -   $
 tdbcContractNo��$��3��$��Stretch=�$��Center=� .   .  . $	 350Q�$ 
ContractNo��$ 
ContractID��  ContractIDTemplate# �    -   $	 lblObjectID��$��Khách hàng��$��Center=�$��Center=�$��4��$��	10,0,10,0q�  -   $
 tdbcObjectID��$��5��$��Stretch=�$��Center=� .   .  . $	 350Q�$ 
ObjectName��$ ObjectID��  ObjectIDTemplate# �  +   %Lemon3.Controls.DevExp.L3SimpleButton  -	     Name$ 	btnFilter��$��Lọc��$��10��$��Stretch=�$��Center=�$��27��$
��auto��$��5,0,5,0q�  -
   $ btnEdit��$��Sửa��$��10��$��Stretch=�$��Center=�$��27��$
��auto��$��5,0,5,0q�$y�Hidden=�'	   !Lemon3.Controls.DevExp.L3CheckBox	  -    	 Name$ chkIsByContract��$%��Cập nhật theo hợp đồng��$
��Left=�$��Center=�$��6��$��	10,0,10,0q� d� 	IsChecked$
 TrueY�	  -   $ chkIsRoundMonth��$��Làm tròn tháng��$
��Left=�$��Center=�$��7��$��	10,0,10,0q�$
 TrueY�*
   $Lemon3.Controls.DevExp.L3GridControl
  -    
 Name$
 tdbg��$��1��$��5,5,5,5q�)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration . $��Visible=�%  DevExpress.Xpf.Grid.GridControl   View #  DevExpress.Xpf.Grid.TableView  -     Name$ tdbgView��   AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     ShowFilterPanelMode$ Never=�   ShowAutoFilterRow .     NewItemRowPosition$ Bottom=�    AllowEditing  . !   	AutoWidth! .  &   DevExpress.Xpf.Grid.GridViewBase"   ShowGroupPanel" .  #   Columns.# $  DevExpress.Xpf.Grid.GridColumn  -   $  Name$$ COL_TransID��$  DevExpress.Xpf.Grid.ColumnBase%   	FieldName$% TransID��$  DevExpress.Xpf.Grid.BaseColumn&   Header)  #DevExpress.Xpf.Core.ObjectConverter$&   ''    HorizontalHeaderContentAlignment$' Center=�(   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$( 50 )   Visible) .    -   $$ COL_TranMonth��$% 	TranMonth��$&   $' Center=�$	( 170 ) .    -   $$ COL_TranYear��$% TranYear��$&   $' Center=�$( 10 ) .    -   $$ COL_CreateUserID��$% CreateUserID��$&   $' Center=�$	( 170 ) .    -   $$ COL_CreateDate��$% 
CreateDate��$&   $' Center=�$( 10 ) .    -   $$ COL_LastModifyUserID��$% LastModifyUserID��$&   $' Center=�$	( 170 ) .    -   $$ COL_LastModifyDate��$% LastModifyDate��$&   $' Center=�$( 50 ) .    -   $$ COL_ContractID��$% 
ContractID��$&   $' Center=�$	( 170 ) .    -   $$ COL_ServiceTypeID��$% ServiceTypeID��$&   $' Center=�$( 10 ) .    -   $$ COL_CurrencyID��$% 
CurrencyID��$&   $' Center=�$	( 170 ) .    -   $$ COL_ExchageRate��$% ExchageRate��$&   $' Center=�$( 10 ) .    -   $$ COL_ConversionFactor��$% ConversionFactor��$&   $' Center=�$	( 170 ) .    -   $$ COL_IsSelected��$% 
IsSelected��$& Chọn $' Center=�$( 50 ) . *   EditSettings* 7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings    -   $$ COL_PeriodID��$% PeriodID��$
& Kỳ $' Center=�$( 80   -   $$ COL_ProjectID��$% 	ProjectID��$& Dự án $' Center=�$	( 110 ) .    -   $$ COL_ProjectName��$% ProjectName��$& Tên dự án $' Center=�$	( 140 ) .    -   $$ COL_ContractNo��$% 
ContractNo��$& Số hợp đồng $' Center=�$	( 110 ) .    -    $$ COL_ObjectID��$% ObjectID��$& Khách hàng $' Center=�$	( 110 ) .    -!   $$ COL_ObjectName��$% 
ObjectName��$& Tên khách hàng $' Center=�$	( 140 ) .    -"   $$ COL_ProductID��$% 	ProductID��$& Mã dịch vụ $' Center=�$	( 110 * 1   +Lemon3.Controls.DevExp.L3LookUpEditSettings  -#   +  Name$+ tdbdProductID��6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!,   HorizontalContentAlignment$
, Left=�<  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase-   AutoComplete- . 3  -DevExpress.Xpf.Grid.LookUp.LookUpEditSettings.   AutoPopulateColumns. .  /   ImmediatePopup/ . ;  5DevExpress.Xpf.Editors.Settings.PopupBaseEditSettings0   
PopupWidth$	0 320Q�1   DisplayMember$1 	ProductID��2   ValueMember$2 	ProductID��  ProductIDTemplate3   PopupContentTemplate#3 �    -$   $$ COL_ProductName��$% ProductName��$& Tên dịch vụ $' Center=�$	( 140 4   ReadOnly4 .   -%   $$ COL_ServiceTypeName��$% ServiceTypeName��$& Loại dịch vụ $' Center=�$	( 110   -&   $$ 
COL_UnitID��$% UnitID��$
& ĐVT $' Center=�$	( 110 *   -'   $+ 
tdbdUnitID��$
, Left=�- . . .  / . $	0 320Q�$1 UnitID��$2 UnitID��  UnitIDTemplate#3 �    -(   $$ COL_OQuantity��$% 	OQuantity��$& Số lượng $' Center=�$	( 110   -)   $$ COL_UnitPrice��$% 	UnitPrice��$& 
Đơn giá $' Center=�$	( 110   -*   $$ COL_OAmount��$% OAmount��$& Thành tiền $' Center=�$	( 110   -+   $$ COL_VATGroupID��$% 
VATGroupID��$& Nhóm thuế $' Center=�$	( 110 *   -,   $+ tdbdVATGroupID��$
, Left=�- . . .  / . $	0 320Q�$1 ID��$2 ID��  VATGroupIDTemplate#3 �    --   $$ COL_VATRate��$% VATRate��$& 	Tỷ lệ $' Center=�$	( 110   -.   $$ COL_VATOAmount��$% 
VATOAmount��$& Thuế $' Center=�$	( 110   -/   $$ COL_TotalOAmount��$% TotalOAmount��$& TT sau thuế $' Center=�$	( 110   -0   $$ COL_FromDate��$% FromDate��$& 
Từ ngày $' Center=�$	( 110   -1   $$ 
COL_ToDate��$% ToDate��$& Đến ngày $' Center=�$	( 110   -2   $$ COL_Note��$
% Note��$& Ghi chú $' Center=�$	( 170   -3   $$ COL_IsDetailInvoice��$% IsDetailInvoice��$"& Xuất hóa đơn chi tiết $' Center=�$	( 140 *     -4   $$ COL_DetailInvoice��$%  ��$& Chi tiết hóa đơn $' Center=�$	( 110 ) .  5   CellTemplate5 �� .R�'  !DevExpress.Xpf.Editors.ButtonEdit  6   ShowText6 .  7   AllowDefaultButton$7 FalseX�%  DevExpress.Xpf.Editors.BaseEdit8   
ShowBorder8 .  9   Buttons.9 '  !DevExpress.Xpf.Editors.ButtonInfo  :  Name$: btnInvoiceDetail��-5   ;   Content$; 
Chi tiết < � ToolTip$< 
Chi tiết��= �� 	IsEnabled= �� > �� Path$!> RowData.Row.IsDetailInvoice�  -6   $$ 
COL_Attack��?   AllowAutoFilter? .  $& Đính kèm $( 80 $' Center=�) .  5 �� .R�  6 .  $7 FalseX�8 .  .9   $: 	btnAttack��-7   $; Đính kèm $< Đính kèm��� $��2��$��5,0,5,5q�.+��  �� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�  -8   $��btnExportBeforeRevenue��$��1��$��Trích trước doanh thu��$��Right=�$��Center=�$��0,0,10,0q�$
��auto��$��27��{�.    -9   $��btnPaymentRequest��$��2��$��Đề nghị thanh toán��$��Right=�$��Center=�$��0,0,10,0q�$
��auto��$��27��{�.    -:   $��btnSave��$��3��$
��Lưu��$��Right=�$��Center=�$��0,0,10,0q�$��80��$��27��  -;   $��btnNext��$��4��$��Nhập tiếp��$��Right=�$��Center=�$��0,0,0,0q�$
��auto��$��27��