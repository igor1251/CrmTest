   M S B A M L   `   `   `  ????B  >CRM.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.Wpf.ViewsCRM.Wpf.Views  5   	   7 clr-namespace:CRM.Wpf.ViewModelsCRM.Wpf.ViewModels  5   	   '    !CRM.Wpf.Views.AddDepartmentWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CRM.Wpf.Views     5   	   7
viewmodels clr-namespace:CRM.Wpf.ViewModels     5   	     ? Title$+  %Новое подразделение??5	   	   $	??400??5
   	    ? SizeToContent$ Height=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$ 
ToolWindow=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? DataContext 5      /   )CRM.Wpf.ViewModels.AddDepartmentViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      .+?5   
   ?? $??Наименование??6   $??0??6)   .??5      ?? ??6   ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?5      ?? 5   
   $??Руководитель??6   $??1??6)   .??5       ?? ??6   ?? *Staffs+ ?? SelectedItem 66   ?? *Master+??5!      ?? 5"      .R?5#      ?? ??6$   ?? *DisplayName+5$      5&      5'      ?? 5)   
   $??2??6   	 ?? Orientation$	 
Horizontal=?6"   $??Right=?6;   .+?5*      ?? $??Принять??6   ??6'   ?? *AcceptCommand+??6I   ?? 
 ?? RelativeSource
 ??  ?? AncestorType" ?{?6?   ?? *AcceptAllowed+?? 5+      $??Отмена??6   ??6&   ?? *CancelCommand+??6H   ?? 
 ?? " ?5,      5.      50      