   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D45D0180   D45D0180.D45F0030   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   AL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  -     N� Title$   - D45F0030��$	��680��$
��1152��.���  � RowDefinitions �� $��* ��� $��40 �.+�*   $Lemon3.Controls.DevExp.L3GridControl  -     Name$
 tdbg��)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration . $��0��   SelectionMode$	 Row=�%  DevExpress.Xpf.Grid.GridControl   View #  DevExpress.Xpf.Grid.TableView  -     Name$ tdbgView��   AllowPerPixelScrolling . 	 J� 	AllowDrop	 .  &   DevExpress.Xpf.Grid.DataViewBase
   AllowEditing
 .    NewItemRowPosition$
 None=�   	AutoWidth .    ShowAutoFilterRow . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     Columns. $  DevExpress.Xpf.Grid.GridColumn  -     Name$ COL_OrderNo��$  DevExpress.Xpf.Grid.ColumnBase   ReadOnly .    	FieldName$ OrderN��$	  DevExpress.Xpf.Grid.BaseColumn 	  Header)
  #DevExpress.Xpf.Core.ObjectConverter$	 STT
 ' 	   HorizontalHeaderContentAlignment$ Center=� 	  Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 80  	  MinWidth$ 80��   EditSettings 6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!   HorizontalContentAlignment$ Center=�  -   $ COL_Description�� . $ Description��$ Diễn giải
 $ Center=�$	 110 $	 110��  -   $ 	COL_CodeW��$ CodeW��$	 Mã
 $ Center=�$ 80 $ 80��%   AllowConditionalFormattingMenu$
 TrueX�  -   $ COL_Code�� . $
 Code��$  
 $ Center=�$ 80 $ 80�� 	  Visible .    -   $ COL_Name��$
 Name��$ Tên tiếng việt
 $ Center=�$	 110 $	 110��$
 TrueX�  -	   $ 
COL_Name01��$ Name01��$ Tên tiếng anh
 $ Center=�$	 110 $	 110��  -
   $ 	COL_NameT��$ NameT��$ 
Tên tắt
 $ Center=�$	 140 $	 140��  -   $ COL_OrderNum��$ OrderNum��$ TT hiển thị
 $ Center=�$ 80 $ 80��  -   $ COL_Disabled��$ Disabled��$ Sử dụng
 $ Center=�$ 80 $ 80��   SortFieldName$ Disable�� 7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings    -   $ COL_IsVector��$ IsVector��$ Vector ngang
 $ Center=�$ 80 $ 80��$ IsVecto��   � $��1�� � ColumnDefinitions �� �� $
��auto ��� $
��auto �.+�+   %Lemon3.Controls.DevExp.L3SimpleButton  -   $��btnSave��$��1��$
��Lưu��$��27��$��	 0 0 10 0q�$��Right=�&   DevExpress.Xpf.Core.SimpleButton   Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Save_16x16.png 