   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D45D0180   D45D0180.D45F1150   =L36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  @dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  -     N� Title$1  +Danh mục bảng giá nâng cao - D45F1150��$	��680��$
��1024�� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/D45D0180;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?��� $1 +/D99D0451;component/Styles/Lemon3Style.xaml?�%    .���  � RowDefinitions �� $��30 ��� �� $��30 �.+�)  #DevExpress.Xpf.Bars.MainMenuControl  -     Name$ MainMenuControl1��$��2��,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -     Name$ tsbAdd��!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm   -   $ tsbEdit��$ Sửa   -   $ 	tsbDelete��$
 Xóa *  $DevExpress.Xpf.Bars.BarItemSeparator    -   $ 
tsbListAll��$ Liệt kê tất cả     -   $ 
tsbSysInfo��$ Thông tin hệ thống � $��1��	 � ColumnDefinitions	 �� -   
 ��Name$

 left��$	��320 ��� $��7 ��� -	   $
 right��$��* �.+�� -
    �Name$ 
GridMaster��$��	0,0,0,-30q� �� �� $��30 �.+�*   $Lemon3.Controls.DevExp.L3GridControl  -     Name$
 tdbg��$��0��)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�   SelectionMode$	 Row=�#   EnableSmartColumnsGeneration . $��Visible=� � ContextMenu �� -   $��ContextMenu1��.@�m� -   $��mnsAdd��$��Thêm��m� -   $��mnsEdit��$��Sửa��m� -   $��	mnsDelete��$
��Xóa���� m� -   $��
mnsListAll��$��Liệt kê tất cả���� m� -   $��
mnsSysInfo��$��Thông tin hệ thống��%	  DevExpress.Xpf.Grid.GridControl 	  View #
  DevExpress.Xpf.Grid.TableView
  -    
 Name$ tdbgView�� 
  AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     ShowFilterPanelMode$ Never=� 
  ShowAutoFilterRow . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     AllowEditing .  
  	AutoWidth .   	  Columns. $  DevExpress.Xpf.Grid.GridColumn  -     Name$ COL_DateFrom��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ DateFrom��$  DevExpress.Xpf.Grid.BaseColumn   Header$   '    HorizontalHeaderContentAlignment$ Center=�   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 50     MinWidth$  50��!   Visible! .    -   $ 
COL_DateTo��$ DateTo��$   $ Center=�$	 110 $	  110��! .    -   $ COL_CreateUserID��$ CreateUserID��$   $ Center=�$	 170 $	  170��! .    -   $ COL_CreateDate��$ 
CreateDate��$   $ Center=�$	 110 ! .    -   $ COL_LastModifyUserID��$ LastModifyUserID��$   $ Center=�$	 110 $	  110��! .    -   $ COL_LastModifyDate��$ LastModifyDate��$   $ Center=�$	 170 ! .    -   $ COL_Mode��$
 Mode��$ Ghi chú $ Center=�$	 170 ! .    -   $ COL_PriceListID��$ PriceListID��$ Mã bảng giá $ Center=�$	 110   -   $ COL_PriceListName��$ PriceListName��$ Diễn giải $ Center=�$	 170   -   $ COL_ValidFrom��$ 	ValidFrom��$ Hiệu lực từ $ Center=�$ 80   -   $ COL_ValidTo��$ ValidTo��$ Hiệu lực đến $ Center=�$ 80   -   $ COL_Disabled��$ Disabled��$	 KSD $ Center=�$ 50 "   EditSettings" 7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings  '   !Lemon3.Controls.DevExp.L3CheckBox  -   #  Name$# chkViewDisable��$��1��$��10,0,0,0q�$
��Left=�$��Center=�$��Normal"�$0��*Hiển thị danh mục không sử dụng���� -    $ ��Name$$ split��$��1��$��Stretch=�$��Stretch=�$��0,3,0,0q�� $��	0,0,0,-30q�$��2�� �� $	��200 ��� �� $��30 �.+�'   !Lemon3.Controls.DevExp.L3GroupBox  -!   %  Name$% GroupDetail��$��Stretch=�$��Stretch=�$��5,0,5,0q����� -"   & ��Name$& 	grpheader��$
��Bold"�Đóng/Mở.��� -#   $ 	grpMaster��$��0q� �� �� �� �� 	 �� $��90 ��� �� $��20 ��� �� $��20 ��� $��50 ��� �� $��20 ��� $	��110 ��� .+�$   Lemon3.Controls.DevExp.L3Label  -$   '  Name$' lblPriceListID��$��Mã bảng giá��$
��Left=�$��0,0,0,0q�$��Center=�'   !Lemon3.Controls.DevExp.L3TextEdit  -%   (  Name$( txtPriceListID��$��1��$��3��$��Stretch=�$��0,0,0,0q�$��Center=�(   "Lemon3.Controls.DevExp.L3CheckEdit  -&   )  Name$) chkDisabled��$��5��$��2��$��0,0,0,0q�$
��Left=�$��Center=�$��Normal"�&   DevExpress.Xpf.Editors.CheckEdit*   Content$* Không sử dụng   -'   $' lblPriceListName��$��1��$��Diễn giải��$
��Left=�$��0,0,0,0q�$��Center=�  -(   $( txtPriceListName��$��1��$��1��$��9��$��Stretch=�$��0,0,0,0q�$��Center=�  -)   $' lblValid��$��2��$��Hiệu lực��$
��Left=�$��0,0,0,0q�$��Center=�'   !Lemon3.Controls.DevExp.L3DateEdit  -*   +  Name$+ dateValidFrom��%  DevExpress.Xpf.Editors.TextEdit,   Mask$, 
dd/MM/yyyy��$��2��$��1��$��Center=�$��Normal"�  -+   $' verticalLine��$��2��$��2��$��-��$��Center=�$��0,0,0,0q�$��Center=�  -,   $+ dateValidTo��$, 
dd/MM/yyyy��$��2��$��3��$��Center=�$��Normal"�  --   $' 
lblBlockID��$��2��$��5��$��Khối��$
��Left=�$��0,0,0,0q�$��Center=�)   #Lemon3.Controls.DevExp.L3LookUpEdit  -.   -  Name$- tdbcBlockID��$��2��$��6��$��Center=�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit.   AutoPopulateColumns. .  +  %DevExpress.Xpf.Editors.LookUpEditBase/   AutoComplete/ . *  $DevExpress.Xpf.Editors.PopupBaseEdit0   
PopupWidth$	0 250Q�1   ImmediatePopup1 . 2   DisplayMember$2 BlockID��3   ValueMember$3 BlockID��   tdbcBlockID4   PopupContentTemplate#4 �   5   IsPopupAutoWidth5 .    -/   $' lblNote��$��3��$��Ghi chú��$
��Left=�$��0,0,0,0q�$��Center=�  -0   $( txtNote��$��3��$��1��$��9��$��Stretch=�$��0,0,0,0q�$��Center=�  -1   $% GroupGridDetail��$��1��$��Stretch=�$��Stretch=�$��5,0,5,0q����� -2   $& grpGridheader��$
��Bold"�
Chi tiết.��� $��
10,0,-10,0q� �� �� $��20 �.+�  -3   $ tdbgD��$��0��$
 None=�$	 Row=� . $��Visible=�$��
0,-10,0,10q� 
  -4   $ 	tdbgDView�� .  .  .  $ Never=� .  .  6 J� 	AllowDrop6 .  7 
  NewItemRowPosition$7 Bottom=� .  8   AllowColumnMoving8 .  9 
  AllowBandMoving9 .  : 	  Bands: )  #DevExpress.Xpf.Grid.GridControlBand  -5   ;  Name$; leftFIxInfoBand��$ Thông tin phiếu "  DevExpress.Xpf.Grid.BandBase<   OverlayHeaderByChildren< . =   AllowResizing]	 YDevExpress.Data.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  	 /DevExpress.Utils.Design.DefaultBooleanConverter$
= True  >   
FixedWidth> .  ?   HeaderStyle? �� @ �� 
TargetType+!  %DevExpress.Xpf.Grid.BandHeaderControl"@ ! .��� A �� PropertyA � ��B �� Value$B Center=�C   Columns.C   -6   $ COLD_OrderNo��$  ��$	 STT $ Center=�$ 50 $  50��D   ReadOnlyD . E   AllowEditing$E False    -7   $ COLD_PriceListID��$ PricelistID��$ Mã bảng giá $ Center=�$	 110 $	  110��! .    -8   $ COLD_ProductID��$ 	ProductID��$ Mã sản phẩm $ Center=�$	 170 $	  170��D .  " 1"   +Lemon3.Controls.DevExp.L3LookUpEditSettings"  -9   F �Name$F tdbdProductID��<#  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBaseG #  AutoCompleteG . H #  ImmediatePopupH . 3$  -DevExpress.Xpf.Grid.LookUp.LookUpEditSettingsI $  AutoPopulateColumnsI .  ;%  5DevExpress.Xpf.Editors.Settings.PopupBaseEditSettingsJ %  
PopupWidth$	J 400Q�K #  DisplayMember$K 	ProductID��L #  ValueMember$L 	ProductID��  tdbdProductIDM %  PopupContentTemplate#M �    -:   $ COLD_ProductName��$ ProductNameU��$ Tên sản phẩm $ Center=�$	 170 $	  170��D . $E False  � $��1��	 �� $
��auto ��� �� $
��auto ��� .+�  -;   $' lblSttProductID��$��0��$��Mã sản phẩm:��$
��Left=�$��	20,0,10,0q�$��Center=�$
��Bold"�  -<   $' SttProductID��$��1��$�� ��$
��Left=�$��0,0,0,0q�$��Center=�  -=   $' lblsttProductName��$��2��$��Tên sản phẩm:��$
��Left=�$��	10,0,10,0q�$��Center=�$
��Bold"�  ->   $' SttProductName��$��3��$�� ��$
��Left=�$��0,0,0,0q�$��Center=�� $��2��.+�+&   %Lemon3.Controls.DevExp.L3SimpleButton&  -?   $��btnConditionList��$��1��$��Danh mục điều kiện��$
��Left=�$��Center=�$��0,0,0,0q�$	��130��$��27��{�.  � $��2��	 �� �� $
��auto ��� $
��auto ��� $
��auto �.+�&  -@   $��btnSave��$��1��$
��Lưu��$��Right=�$��Center=�$��0,0,10,0q�$��80��$��27��{�.  &'   DevExpress.Xpf.Core.SimpleButtonN '  GlyphN *(  $DevExpress.Xpf.Core.DXImageExtension(  O (  Image1)  +DevExpress.Xpf.Core.Native.DXImageConverter$O Save_16x16.png) &  -A   $��btnNext��$��2��$��Nhập tiếp��$��Right=�$��Center=�$��0,0,10,0q�$	��140��$��27��{�.  N (  $O SaveAndNew_16x16.png) &  -B   $��
btnNotSave��$��3��$��Không lưu��$��Right=�$��Center=�$��0,0,5,0q�$	��110��$��27��{�.  N (  $O SaveAndClose_16x16.png) 