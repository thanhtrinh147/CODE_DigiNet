   M S B A M L   `   `   `  ����D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp  5   	   D @D30D2150, Version=4.10.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:D30D2150D30D2150 5	   	      D30D2150.D30F2711   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     EL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   "localclr-namespace:D30D2150  5	   	   -   5          � Title$#  Chi tiết phiếu - D30F2711��5   	   $	��680��6+   $
��1024��68   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��37 �6   .+�5   
   '   !Lemon3.Controls.DevExp.L3GroupBox  $��0��6   $��5,5,5,0q�6&   $��5q�67   ��5      �� 5      -   5         ��Name$ 	textblock��5      $
��Bold"�6/   
Chi tiết6K   .��5      *   $Lemon3.Controls.DevExp.L3GridControl  -   5          Name$
 tdbg��5      $��0��6-   $��1��6=   )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6J      AutoGenerateColumns$
 None=�6^   #   EnableSmartColumnsGeneration .  � 	Resources 5      *  $DevExpress.Xpf.Grid.GridColumnHeader �� 
TargetType	 �� Property
 �� Value��%R   '        �� 5      "  6   .�5      �� 	 � ��$
 40��63   5      5      %  DevExpress.Xpf.Grid.GridControl   View 5      #  DevExpress.Xpf.Grid.TableView  5      -   5          Name$ tdbgTableView��5   $   &   DevExpress.Xpf.Grid.DataViewBase   ShowFilterPanelMode$ Never=�6;      AllowPerPixelScrolling .    ShowTotalSummary .     AllowEditing .     ShowAutoFilterRow . 5         Columns. 5!      $  DevExpress.Xpf.Grid.GridColumn  -   5          Name$ COL_InventoryID��5!   !   $	  DevExpress.Xpf.Grid.ColumnBase 	  	FieldName$ InventoryID��6:   $
  DevExpress.Xpf.Grid.BaseColumn 
  Header)  #DevExpress.Xpf.Core.ObjectConverter$ 	Mã hàng 6R    
  MinWidth$ 80��6c    
  Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 80* 6q   ' 
   HorizontalHeaderContentAlignment$ Center=�6}     5"      -   5        $ COL_InventoryName��5"   !   $ 
Tên hàng 6<   $ InventoryName��6N   $ Center=�6h   $	 140��6�   $
 140* 6�     5#      -   5        $ 
COL_UnitID��5#   !   $
 ĐVT 65   $ UnitID��6B   $ Center=�6U   $ 50��6   $	 50* 6�     5$      -   5        $ 	COL_Model��5$   !   $ Model 64   $ Model��6C   $ Center=�6U   $ 50��6   $	 50* 6�     5%      -	   5        $ COL_ProDateFrom��5%   !   $ Ngày bắt đầu 6:   $ ProDateFrom��6P   $ Center=�6h   $ 80��6�   $	 80* 6�    
  HeaderTemplate 5&      �� 5'      .R�5(      �� $
��Wrap=�69    �� TextAlignment$ Center=�6M   ��6(   �� 6M   5)      5+        5,      -
   5        $ COL_ProDateTo��5,   !   $ Ngày kết thúc 68   $ 	ProDateTo��6O   $ Center=�6e   $ 80��6�   $	 80* 6�    5-      �� 5.      .R�5/      �� $
��Wrap=�69   $ Center=�6M   ��6(   �� 6M   50      52        53      -   5        $ COL_ProDate��53   !   $ Ngày nhập kho 66   $ ProDate��6M   $ Center=�6a   $ 80��6�   $	 80* 6�    54      �� 55      .R�56      �� $
��Wrap=�69   $ Center=�6M   ��6(   �� 6M   57      59        5:      -   5        $ COL_Spec01ID��5:   !   $ Spec01ID 67   $ Spec01ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5;      -   5        $ COL_Spec02ID��5;   !   $ Spec02ID 67   $ Spec02ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5<      -   5        $ COL_Spec03ID��5<   !   $ Spec03ID 67   $ Spec03ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5=      -   5        $ COL_Spec04ID��5=   !   $ Spec04ID 67   $ Spec04ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5>      -   5        $ COL_Spec05ID��5>   !   $ Spec05ID 67   $ Spec05ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5?      -   5        $ COL_Spec06ID��5?   !   $ Spec06ID 67   $ Spec06ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5@      -   5        $ COL_Spec07ID��5@   !   $ Spec07ID 67   $ Spec07ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5A      -   5        $ COL_Spec08ID��5A   !   $ Spec08ID 67   $ Spec08ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5B      -   5        $ COL_Spec09ID��5B   !   $ Spec09ID 67   $ Spec09ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5C      -   5        $ COL_Spec10ID��5C   !   $ Spec10ID 67   $ Spec10ID��6I   $ Center=�6^   $	 110��6�   $
 110* 6�     5D      -   5        $ COL_SDID��5D   !   $ 
Kho xuất 63   $
 SDID��6E   $ Center=�6V   $	 110��6�   $
 110* 6�     5E      -   5        $ COL_SRID��5E   !   $ 
Kho nhập 63   $
 SRID��6E   $ Center=�6V   $	 110��6�   $
 110* 6�     5F      -   5        $ COL_OQTY��5F   !   $ Số lượng 63   $
 OQTY��6E   $ Center=�6V   $	 110��6�   $
 110* 6�     5G      -   5        $ COL_CQTY��5G   !   $ Số lượng QĐ 63   $
 CQTY��6H   $ Center=�6Y   $	 110��6�   $
 110* 6�     5H      -   5        $ COL_UseFormula��5H   !   $ Số lượng QĐ 69   $ 
UseFormula��6N    
  Visible .  6e     5I      -   5        $ COL_ConversionFactor��5I   !   $ Số lượng QĐ 6?   $ ConversionFactor��6T    .  6q     5J      -   5        $ COL_Type��5J   !   $ Số lượng QĐ 63   $
 Type��6H    .  6Y     5K      -   5        $ COL_VoucherTypeID��5K   !   $ Số lượng QĐ 6<   $ VoucherTypeID��6Q    .  6k     5L      -   5        $ COL_Formula��5L   !   $ Số lượng QĐ 66   $ Formula��6K    .  6_     5M      -   5        $ COL_SalesOrderID��5M   !   $ Số lượng QĐ 6;   $ SalesOrderID��6P    .  6i     5N      -    5        $ COL_TranTypeID��5N   !   $ Số lượng QĐ 69   $ 
TranTypeID��6N    .  6e   5P      5Q      +   %Lemon3.Controls.DevExp.L3SimpleButton  5R   
   -!   5          Name$ btnClose��5R      $��Đóng��6.   $��1��6=   $��Right=�6J   $��0,6,5,6q�6f   $��25��6w   $��Center=�6�   $��80��6�   6�   5S      5T      