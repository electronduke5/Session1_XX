   M S B A M L   `   `   `  ????F  BSession1_XX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Session1_XX.PagesSession1_XX.Pages  5      !    Session1_XX.Pages.UsersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Session1_XX.Pages     5        N? Title$  	UsersPage??5	       N? 
Background
 ?????.??5      ?? $	??Top=?6   .+?5   
   o? .@?5      m? -   5        $??btnExit??5      $
??Exit??5      5      5      ]? 5   
   .+?5      ??  ?? Orientation$ Vertical=?5      $	??Top=?5      $??0 0 0 10q?5      .+?5      ?  ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      ?? 5       .+?5"      ?? $ 
Horizontal=?5#      .+?5$      ?? $??16(?6$   $??
10 10 5 10q?62   Hi6J   ?? 5%      -   5        $??
tbFullName??5%   E   $??16(?6$   $??	0 10 0 10q?62   ??6W   ?? *	FirstName+?? 5&      $??16(?6$   $??
0 10 10 10q?62   , Welcome to AMONIC Airlines:6e   5'      ?? 5)      $??1??5*      $??1??5+      $ 
Horizontal=?5,      .+?5-      ?? $??
10 10 5 10q?6$   Time spent on system:6O   ?? 5.      -   5        $??tbTimer??5.   7   $??	0 10 0 10q?6$   $??00:00:00??6F   5/      ?? 51      $??1??52      $??2??53      $ 
Horizontal=?54      .+?55      ?? $??
10 10 5 10q?6$   Number of craches:6L   ?? 56      $??	0 10 0 10q?6$   $??0??67   57      58      5:      &   System.Windows.Controls.DataGrid  5;      -   5        $??dgActivities??5<         CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $??10q?5@      $??Stretch=?5C      $??Stretch=?5D      $	??Top=?5E      $??Stretch=?5F      $??Stretch=?5G         AutoGenerateColumns .  	   Columns	 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Date??5L      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M      ?? *	LoginTime+ ?? StringFormat$ 
MM/dd/yyyy??  5O      $
 
Login time??5P       5Q      ?? *	LoginTime+$ HH:mm??  5S      $
 Logout Time??5T       5U      ?? *
LogoutTime+$ HH:mm??  5W      $
 Time spent on system??5X       5Y      ?? *	SpentTime+  5[      $!
 Unsuccessfull logout reason??5\       5]      ?? *LogoutReason+   RowStyle 5`      ?? 5a       ?? 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .?5b      ??  ?? Property ? ?? ?? Value
 ?  ??67   ?? 5c       ? ??
 ?????67    ?? Triggers 5d      ?? 5e       ?? Binding 5f   !   ?? *LogoutReason+ ?? Value 6B   Z? .a?5g   "   ??  ? ??
 ?????6?   ?? 5h   "    ? ??
 ?   ?6?   5i      5k      5m      5n      5o      5p      