   M S B A M L   `   `   `  ????B  >CRM.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.Wpf.ViewsCRM.Wpf.Views  5   	   7 clr-namespace:CRM.Wpf.ViewModelsCRM.Wpf.ViewModels  5   	   $    CRM.Wpf.Views.AddCompanyWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CRM.Wpf.Views     5   	   7
viewmodels clr-namespace:CRM.Wpf.ViewModels     5   	     ? Title$!  Новая компания??5	   	    ? SizeToContent$ Height=?5
   	   $	??500??5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$ 
ToolWindow=?5   	    ? DataContext 5      ,   &CRM.Wpf.ViewModels.AddCompanyViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   .+?5!   
   ?? $??Наименование??6   $??0??6)   $??0??69   .??5"      ?? ??6   ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?5#      ?? 5$   
   $!??Дата основания??6   $??1??6+   $??0??6;   .??5%      (  "System.Windows.Controls.DatePicker  $??25??6      SelectedDate 6%   ?? *SelectedDate+$ PropertyChanged=?5&      ?? 5'   
   $'??!Юридический адрес??6   $??0??6.   $??2??6>   $??1??6R   .??5(      ?? ??6   ?? *	Address+$ PropertyChanged=?5)      ?? 5+   
   $??4??6   $??2??6"   	 ?? Orientation$	 
Horizontal=?66   $??Right=?6O   .+?5,      ?? $??Принять??6   ??6'   ?? *AcceptCommand+??6I   ?? 
 ?? RelativeSource
 ??  ?? AncestorType" ?{?6?   ?? *AcceptAllowed+?? 5-      $??Отмена??6   ??6&   ?? *CancelCommand+??6H   ?? 
 ?? " ?5.      50      51      