   M S B A M L   `   `   `  ����D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp  5       D45D0180   D45D0180.D45F0030   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      AL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5
      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5      -   5          N� Title$   - D45F0030��5      $	��680��6   $
��1152��6&   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   *   $Lemon3.Controls.DevExp.L3GridControl  -   5          Name$
 tdbg��5      )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6)   #   EnableSmartColumnsGeneration . $��0��6i      SelectionMode$	 Row=�6v   %  DevExpress.Xpf.Grid.GridControl   View 5      #  DevExpress.Xpf.Grid.TableView  5      -   5          Name$ tdbgView��5          AllowPerPixelScrolling . 	 J� 	AllowDrop	 .  &   DevExpress.Xpf.Grid.DataViewBase
   AllowEditing
 .    NewItemRowPosition$
 None=�6v      	AutoWidth .    ShowAutoFilterRow . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  5   �      Columns. 5      $  DevExpress.Xpf.Grid.GridColumn  -   5          Name$ COL_OrderNo��5      $  DevExpress.Xpf.Grid.ColumnBase   ReadOnly .    	FieldName$ OrderN��6C   $	  DevExpress.Xpf.Grid.BaseColumn 	  Header)
  #DevExpress.Xpf.Core.ObjectConverter$	 STT
 6V   ' 	   HorizontalHeaderContentAlignment$ Center=�6c    	  Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 80 6�    	  MinWidth$ 80��6�      EditSettings 5      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!   HorizontalContentAlignment$ Center=�6+   5        5      -   5        $ COL_Description��5       . $ Description��6G   $ Diễn giải
 6_   $ Center=�6r   $	 110 6�   $	 110��6�     5       -   5        $ 	COL_CodeW��5       $ CodeW��62   $	 Mã
 6D   $ Center=�6P   $ 80 6z   $ 80��6�   %   AllowConditionalFormattingMenu$
 TrueX�6�     5!      -   5        $ COL_Code��5!       . $
 Code��6@   $  
 6Q   $ Center=�6[   $ 80 6�   $ 80��6�    	  Visible .  6�     5"      -   5        $ COL_Name��5"      $
 Name��6/   $ Tên tiếng việt
 6@   $ Center=�6X   $	 110 6�   $	 110��6�   $
 TrueX�6�     5#      -	   5        $ 
COL_Name01��5#      $ Name01��61   $ Tên tiếng anh
 6D   $ Center=�6[   $	 110 6�   $	 110��6�     5$      -
   5        $ 	COL_NameT��5$      $ NameT��60   $ 
Tên tắt
 6B   $ Center=�6S   $	 140 6}   $	 140��6�     5%      -   5        $ COL_OrderNum��5%      $ OrderNum��65   $ TT hiển thị
 6J   $ Center=�6_   $ 80 6�   $ 80��6�     5&      -   5        $ COL_Disabled��5&      $ Disabled��65   $ Sử dụng
 6J   $ Center=�6[   $ 80 6�   $ 80��6�      SortFieldName$ Disable��6�    5'      7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings  5(      5*        5+      -   5        $ COL_IsVector��5+      $ IsVector��64   $ Vector ngang
 6I   $ Center=�6_   $ 80 6�   $ 80��6�   $ IsVecto��6�    5,        5-      5/      50      � 51   
   $��1��6    � ColumnDefinitions 52      �� 53      �� 54      $
��auto �6#   �� 55      $
��auto �6#   .+�57      +   %Lemon3.Controls.DevExp.L3SimpleButton  -   5        $��btnSave��57       $��1��6/   $
��Lưu��6?   $��27��6N   $��	 0 0 10 0q�6q   $��Right=�6�   &   DevExpress.Xpf.Core.SimpleButton   Glyph 6�   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Save_16x16.png 5:      5;      5<      