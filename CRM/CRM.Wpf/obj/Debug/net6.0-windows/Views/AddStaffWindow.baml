   M S B A M L   `   `   `  ????B  >CRM.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.Wpf.ViewsCRM.Wpf.Views  5   	   7 clr-namespace:CRM.Wpf.ViewModelsCRM.Wpf.ViewModels  5   	   "    CRM.Wpf.Views.AddStaffWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CRM.Wpf.Views     5   	   7
viewmodels clr-namespace:CRM.Wpf.ViewModels     5   	     ? Title$#  Новый сотрудник??5	   	   $	??500??5
   	    ? SizeToContent$ Height=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$ 
ToolWindow=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? DataContext 5      *   $CRM.Wpf.ViewModels.AddStaffViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5"   
   ?? $??Фамилия??6   $??0??6$   $??0??61   .??5#      ?? ??6   ?? *	Surname+ ?? UpdateSourceTrigger$ PropertyChanged=?5$      ?? 5%   
   $??Имя??6   $??1??6    $??0??6-   .??5&      ?? ??6   ?? *Name+$ PropertyChanged=?5'      ?? 5(   
   $??Отчество??6   $??2??6%   $??0??62   .??5)      ?? ??6   ?? *
Lastname+$ PropertyChanged=?5*      ?? 5+   
   $??Дата рождения??6   $??0??6*   $??1??67   .??5,      (  "System.Windows.Controls.DatePicker  	   SelectedDate	 6   ?? *	Birthdate+5-      ?? 5.   
   $??Дата найма??6   $??1??6'   $??1??64   .??5/        	 6   ?? *	Hireddate+50      ?? 51   
   $%??Заработная плата??6   $??3??6-   $??0??6:   $??2??6J   .??52      ?? ??6   ?? *Money+$ PropertyChanged=?53      ?? 54   
   $??Должность??6   $??2??6&   $??1??63   .??55      ?? ??6   ?? *Posts+
 ?? SelectedItem
 65   ?? *Post+??56      ?? 57      .R?58      ?? ??6$   ?? *DisplayName+59      5;      5<      ?? 5>   
   $??4??6   $??0??6"   $??2??62    ?? Orientation$ 
Horizontal=?6F   $??Right=?6_   .+?5?      ?? $??Принять??6   ??6'   ?? *AcceptCommand+??6I   ??  ?? RelativeSource ??  ?? AncestorType" ?{?6?   ?? *AcceptAllowed+?? 5@      $??Отмена??6   ??6&   ?? *CancelCommand+??6H   ??  ?? " ?5A      5C      5E      