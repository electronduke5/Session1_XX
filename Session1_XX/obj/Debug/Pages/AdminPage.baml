   M S B A M L   `   `   `  ????F  BSession1_XX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Session1_XX.PagesSession1_XX.Pages  5      !    Session1_XX.Pages.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Session1_XX.Pages     5        N? Title$  	AdminPage??5	       N? 
Background
 ?????.??5      ?? $	??Top=?6   .+?5   
   o? .@?5      m? -   5        $??Add User??5      5      m? 5      -   5        $
??Exit??5      5      5      ]? 5   
   .+?5      ??  ?? Orientation$ 
Horizontal=?5      $	??Top=?5      $??0 0 0 10q?5      .+?5      ?? $??10q?6   	Office:61   ?? 5      -   5        $??	cbOffices??5      $	??100??5      $??10q?5      5      ?? 5       -   5        $??10q?5"      .??6!   Clear filter5$      5%      &   System.Windows.Controls.DataGrid  5&      -   5        $??dgUsers??5'         CanUserAddRows .    CanUserDeleteRows .    
IsReadOnly . $??10q?5+      $??Stretch=?5-      $??Stretch=?5.      $	??Top=?5/      $??Stretch=?50      $??Stretch=?51         AutoGenerateColumns .     Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??56      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 57      ?? *	FirstName+  59      $ 	Last name??5:      	 5;      ?? *
LastName+  5=      $
 Name??5>      	 5?      ?? *	FirstName+  5A      $	 Age??5B      	 5C      ?? *Age+  5E      $ 	User Role??5F      	 5G      ?? *	RoleTitle+  5I      $ Email Address??5J      	 5K      ?? *Email+  5M      $ Office??5N      	 5O      ?? *OfficeTitle+
   RowStyle
 5Q      ?? 5R       ?? 
TargetType)  #System.Windows.Controls.DataGridRow"  6    ?? Triggers 5S      ?? 5T       ?? Binding 5U   !   ?? *Active+ ?? Value	 false6<   .a?5V   "   ??  ?? Property ? ?? ?? Value
 ?  ??6?   ?? 5W   "    ? ??
 ?????6?   5X      5Z      5\      ?? 5]      $??Bottom=?5^      $ 
Horizontal=?5_      .+?5a      ?? -   5        $??btnChangeRole??5c      $??75??5b      $??10q?5e      $??
ChangeRole??5f      ?? 5i      -   5        $??btnToggleActive??5j      $	??125??5k      $??50 10 10 10q?5l      $??Enable/Disable Login??5n      5o      5p      5q      5r      