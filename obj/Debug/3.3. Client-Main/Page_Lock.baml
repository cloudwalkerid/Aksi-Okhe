   M S B A M L   `   `   `  ????E  AAkhi Okhee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Akhi_Okhee._3._3._Client_MainAkhi_Okhee._3._3._Client_Main  5      -    'Akhi_Okhee._3._3._Client_Main.Page_Lock   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Akhi_Okhee._3._3._Client_Main     5      -   5        $??	root_akun??5	   .     N? Title$  	Page_Akun??6    N? 
Background ?#FFECEB.??5      ?  ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6   ???#5D576B$
??Left=?60   ??6K   ?? *ActualWidth+ ?? ElementName$ 	root_akun???? 5   
   -   5        $
??nama??5      $??0??6   $??Dokumen Terkunci??6*   $??12(?6E   $	??429??6T   $??10,0,0,4q?6`   $??Bottom=?6r   $
??Left=?6?   $??26??6?   $
??Bold"?6?   
???????6?   ? 5   
   $??1??6   ??6   ?? *ActualWidth+$ 	root_akun?? ? ColumnDefinitions 5      ?? 5      $	??250 ?6#   ?? 5      $??* ?6#   .+?5      ?? $??0??6   ???#AAA5B6$
??Left=?67   ??6R   ?? *ActualWidth+$ 	root_akun??? 5      -   5        $??barang_content??5   #   $??1??6    5      ?? 5      $??* ?6$   ?? 5      $??60 ?6$   .+?5      ?? -   5        $??listLock??5   ?   $??0??6   $
??Left=?6+   $	??371??6F   $	??Top=?6S   ???#FFECEB ?? View 5      ?? 5      .P?5       ?? $??
Nama Usaha??6]    ?? Width$	 400??6q    ?? DisplayMemberBinding 6-   ??  ?? Path$ 	R109.Data?6q   ?? 5!      $??Pengguna??6b   $	 150??6t    6-   ?? $ Lock_user.Data?6t   5"      5$      ?? 5&      -   5        $
??edit??5&      $??Unlock??6%   $
??Left=?66   $??1??6R   $??Bottom=?6_   $	??120??6z   $??
400,0,0,15q?6?   $??25??6?   6?   5)      5*      5+      5,      