   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D45D0180   D03D0250.D03F0208   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   AL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  -   $	��680��$
��1024��  N� Title$0  *Báo cáo công nợ phải thu - D03F0208�� N� 
Background
 ����� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/D03D0250;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?��� $1 +/D99D0451;component/Styles/Lemon3Style.xaml?�%    .���  � RowDefinitions �� $	��110 ��� .+��� -    ��Name$
 grpM��$��	10,0,10,0q����� -    ��Name$ 	tblFilter��$��Điều kiện lọc��$
��Bold"�.��� $��0,-10,0,-10q� �� �� ��  � ColumnDefinitions �� $��60 ��� �� $��15 ��� �� $��30 ��� $��85 ��� �� �� $��15 ��� .+�$   Lemon3.Controls.DevExp.L3Label  -   	  Name$	 lblDivisionID��$��
Đơn vị��$
��Left=�$��0,0,0,0q�$��Center=�)   #Lemon3.Controls.DevExp.L3LookUpEdit  -   
  Name$
 tdbcDivisionID��$��1��$��3��$��Stretch=�$��Center=�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit   AutoPopulateColumns .  +  %DevExpress.Xpf.Editors.LookUpEditBase   ImmediatePopup . *  $DevExpress.Xpf.Editors.PopupBaseEdit   
PopupWidth$	 450Q�   DisplayMember$ DivisionName��   ValueMember$ 
DivisionID��   DivisionIDStadard   PopupContentTemplate# �     -   $	 lblObjectTypeID��$��Đối tượng��$��5��$
��Left=�$��10,0,0,0q�$��Center=�  -   $
 tdbcObjectTypeID��$��6��$��Stretch=�$��0,0,5,0q�$��Center=� .   . $	 450Q�$ ObjectTypeName��$ ObjectTypeID��  ObjectTypeIDTemplate# �    -   $
 tdbcObjectIDFrom��$��7��$��Stretch=�$��5,0,0,0q�$��Center=� .   . $	 450Q�$ 
ObjectName��$ ObjectID��  ObjectIDTemplate# �    $��--��$��8��$��Center=�$��Center=�  -	   $
 tdbcObjectIDTo��$��9��$��Stretch=�$��0,0,0,0q�$��Center=� .   . $	 450Q�$ 
ObjectName��$ ObjectID��# �    -
   $
 tdbcPeriodFrom��$��1��$��Stretch=�$��1��$��Center=� .   . $	 450Q�$ Period��$ Period��  PeriodIDStadard# �    $��--��$��2��$��Center=�$��1��$��Center=�  -   $
 tdbcPeriodTo��$��3��$��Stretch=�$��1��$��Center=� .   . $	 450Q�$ Period��$ Period��# �    -   $	 lblAccountID��$��Tài khoản��$��5��$
��Left=�$��10,0,0,0q�$��1��$��Center=�  -   $
 tdbcAccountID��$��6��$��Stretch=�$��1��$��4��$��0,0,0,0q�$��Center=� .   . $	 450Q�$ 	AccountID��$ 	AccountID��  AccountIDTemplate# �  �� $��1��$��2��.+�	� -    	�Name$ 	optPeriod��$
��Kỳ��$
��Left=�$��0,5,0,2q� d� 	IsChecked$
 TrueY�$	��Top=�	� -   $ optDate��$��Ngày��$
��Left=�$��0,5,0,0q�$��Bottom=�'   !Lemon3.Controls.DevExp.L3DateEdit  -     Name$ DateFrom��$��3��$��1��$��Center=�$��Normal"�{�.    -   $ DateTo��$��3��$��3��$��Center=�$��Normal"�{�.  	� -   $ optOriginal��$��Nguyên tệ��$��6��$
��Left=�$��2��$��Center=�	� -   $ optExchange��$��
Quy đổi��$��7��$
��Left=�$��2��$��Center=�+   %Lemon3.Controls.DevExp.L3SimpleButton  -     Name$ 	btnFilter��$��Loc (F5)��$��9��$��2��$��Right=�$��0,0,0,0q�$��Center=�$��90��$��27��&   DevExpress.Xpf.Core.DXTabControl  -   $��
tabControl��$��
10,5,10,10q�$��3��.@�#	  DevExpress.Xpf.Core.DXTabItem	  -   $
��tab1���
  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]] 
  Header$ 1. Tổng hợp��.��� 
������ $��-10,0,-10,-10q�.+�*   $Lemon3.Controls.DevExp.L3GridControl  -     Name$
 tdbg��)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration . $��
10,5,10,10q�$��1��%  DevExpress.Xpf.Grid.GridControl   View #  DevExpress.Xpf.Grid.TableView  -     Name$ tdbgView��   AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary . $  DevExpress.Xpf.Bars.BarManager   DXContextMenu #  DevExpress.Xpf.Bars.PopupMenu  -   $��tdbgPopupMenu��$	��200��   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -    �Name$ mnsShowDetail��!  DevExpress.Xpf.Bars.BarItem    Content)  #DevExpress.Xpf.Core.ObjectConverter$  Hiển thị chi tiết   -   $ mnsExportToExcel��$  Xuất Excel   -   $ mnsPrint��$  In !   Columns.! $  DevExpress.Xpf.Grid.GridColumn  -   "  Name$" COL_ObjectTypeID��$  DevExpress.Xpf.Grid.ColumnBase#   	FieldName$# ObjectTypeID��$  DevExpress.Xpf.Grid.BaseColumn$   Visible$ .    -   $" COL_ObjectID��$# ObjectID��%   Header$% Mã đối tượng '&    HorizontalHeaderContentAlignment$& Center=�'   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	' 110   -   $" COL_ObjectName��$# 
ObjectName��$% Tên đối tượng $& Center=�$	' 230   -    $" COL_ShortName��$# 	ShortName��$% 
Tên tắt $& Center=�$	' 110   -!   $" COL_CurrencyID��$# 
CurrencyID��$% Loại tiền $& Center=�$' 60   -"   $" COL_OpeningDebitAmount��$# OpeningDebitAmount��$% Đầu kỳ nợ $& Center=�$	' 110   -#   $" COL_OpeningCreditAmount��$# OpeningCreditAmount��$% Đầu kỳ có $& Center=�$	' 110   -$   $" COL_DebitAmount��$# DebitAmount��$% Phát sinh nợ $& Center=�$	' 110   -%   $" COL_CreditAmount��$# CreditAmount��$% Phát sinh có $& Center=�$	' 110   -&   $" COL_ClosingDebitAmount��$# ClosingDebitAmount��$% Cuối kỳ nợ $& Center=�$	' 110   -'   $" COL_ClosingCreditAmount��$# ClosingCreditAmount��$% Cuối kỳ có $& Center=�$	' 110 	  -(   $
��tab2��$% 2. Chi tiết theo tài khoản��.��� 
������ $��-10,0,-10,-10q�.+�  -)   $ tdbgD��$
 None=� . $��
10,5,10,10q�$��1��   -*   $ 	tdbgDView�� .  .    -+   $��tdbgDPopupMenu��$	��150��.   -,   $ mnsDExportExcel��$  Xuất Excel   --   $ 	mnsDPrint��$  In .!   -.   $" COLD_Object��$# Object��$ .    -/   $" COLD_AccountID��$# 	AccountID��$% Tài khoản $& Center=�$
' 110*   -0   $" COLD_AccountName��$# AccountName��$% Tên tài khoản $& Center=�$
' 110*   -1   $" COLD_CurrencyID��$# 
CurrencyID��$% Loại tiền $& Center=�$
' 110*   -2   $" COLD_OpeningDebitAmount��$# OpeningDebitAmount��$% Đầu kỳ nợ $& Center=�$
' 110*   -3   $" COLD_OpeningCreditAmount��$# OpeningCreditAmount��$% Đầu kỳ có $& Center=�$
' 110*   -4   $" COLD_DebitAmount��$# DebitAmount��$% Phát sinh nợ $& Center=�$
' 110*   -5   $" COLD_CreditAmount��$# CreditAmount��$% Phát sinh có $& Center=�$
' 110*   -6   $" COLD_ClosingDebitAmount��$# ClosingDebitAmount��$% Cuối kỳ nợ $& Center=�$
' 110*   -7   $" COLD_ClosingCreditAmount��$# ClosingCreditAmount��$% Cuối kỳ có $& Center=�$
' 110* 