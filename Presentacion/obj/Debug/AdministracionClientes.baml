   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   I EOnBreakEventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:OnBreakEventos.app.convertersOnBreakEventos.app.converters 5   	   /clr-namespace:OnBreakEventosOnBreakEventos 5	   	   C&clr-namespace:OnBreakEventos.app.utilsOnBreakEventos.app.utils 5   	   )   #Presentacion.AdministracionClientes   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   B
converters+clr-namespace:OnBreakEventos.app.converters     5   	   .localclr-namespace:OnBreakEventos     5	   	   8utils&clr-namespace:OnBreakEventos.app.utils     5   	     � Title$*  $OnBreak - Administracion de Clientes��5   	   $��656.129��67   $	��897��6H    � Icon$ app/Images/Icono.ico��6T   0  *OnBreakEventos.app.utils.EnterKeyTraversal   	IsEnabled .  � 	Resources 5      =  7OnBreakEventos.app.converters.SqlMinDateToNullConverter   SqlMinDateConverter��%   &	          5   
   6/   5      .��5      � .+�5   
   �� $*��$app/Images/logo_white_background.jpg��6   $��Right=�6?   $	��Top=�6[   $	��224��6s   $��0,-50,-25,0q�6�   $	��195��6�    �� BitmapScalingMode$
 Fant=�6�    J� Clip 5      �� 5       �� Rect$ 10,50 160,200�6%   6<   5      �� 5   
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $!��Administración de clientes��6V   $	��Top=�6x   $��24(�6�   $��72��6�   $	��293��6�   �� 5   
   $
��Left=�6   $��	13,48,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��34��6n   $	��307��6z   $��Italic$�6�   ���	#FF767676�� 6�   $�Ingrese ��6�   �� 6�   $7�1los datos para crear un nuevo cliente, o indique ��6�   �� 6  $"�el RUT de un cliente existen��6
  �� 60  $�te para modificarlo��64  6R  �� 5   
   -   5         ��Name$ lbl_rut��5      $��RUT *��6!   $
��Left=�61   $��
13,107,0,0q�6L   $	��Top=�6`    J� RenderTransformOrigin$ 0.562,1.231&�6x   �� 5   
   -   5        	 ��Name$	 tb_rut��5      $
��Left=�6"   $��10��6=   $��
50,108,0,0q�6I   
 �� TextWrapping$

 Wrap=�6]   $	��Top=�6q   $��97��6�   �� 5   
   -   5         ��Name$ btn_buscarPorRutIngreso��5      $
��Left=�62   $��152,108,0,0q�6M   $��0q�6b   $	��Top=�6n   $��32��6�   $��26��6�   .��5      �� $!��app/Images/ClientSearch.png��6   $��20��69   $��21��6E   $
 Fant=�6P   6y   5      �� 5!   
   -   5        $ btn_buscarPorRutLista��5!      $
��Left=�60   $��201,108,0,0q�6K   $��0q�6`   $	��Top=�6l   $��32��6�   $��26��6�   -  'System.Windows.Input.KeyboardNavigation   	IsTabStop .  .��5"      �� $��app/Images/DataSearch.png��6   $��20��67   $��21��6C   $
 Fant=�6N   6w   5#      �� 5%   
   -   5        $ lbl_razonSocial��5%   *   $��Razón social *:��6   $��
13,155,0,0q�6C   $
��Left=�6W   $	��Top=�6r   6�   �� 5&   
   -   5        $	 tb_razon_social��5&      $
��Left=�6+   $��27��6F   $��
99,153,0,0q�6R   $

 Wrap=�6f   $	��Top=�6{   $	��255��6�   �� 5'   
   -   5        $ lbl_direccion��5'   '   $��Dirección *:��6   $��
26,197,0,0q�6>   $
��Left=�6R   $	��Top=�6m   �� 5(   
   -   5        $	 tb_direccion��5(      $
��Left=�6(   $��27��6C   $��
99,197,0,0q�6O   $

 Wrap=�6c   $	��Top=�6x   $	��255��6�   $ 0.5,0.5&�6�   .��6�   5)      �� 5*   
   -	   5        $ lbl_telefono��5*   &   $��Teléfono *:��6   $��
26,238,0,0q�6<   $
��Left=�6P   $	��Top=�6k   �� 5+   
   -
   5        $	 tb_telefono��5+      $
��Left=�6'   $��27��6B   $��
98,238,0,0q�6N   $

 Wrap=�6b   $	��Top=�6w   $	��119��6�   $ 0.5,0.5&�6�   .��6�   5-      �� 5.   
   -   5        $ lbl_actividad��5.   '   $��Actividad *:��6   $��
26,284,0,0q�6>   $
��Left=�6R   $	��Top=�6m   �� 5/   
   -   5         ��Name$ cmb_actividad��5/      $
��Left=�6*   $��
99,285,0,0q�6E   $	��Top=�6Y   $	��120��6q   �� 50   
   -   5        $ lbl_tipo��50   "   $��Tipo *:��6   $��
50,331,0,0q�64   $
��Left=�6H   $	��Top=�6c   �� 51   
   -   5        $ cmb_tipo��51      $
��Left=�6%   $��
97,332,0,0q�6@   $	��Top=�6T   $	��120��6l   �� 53   
   -   5        $ btn_agregarCliente��53      $
��Left=�6-   $��336,528,0,0q�6H   $��0q�6]   $	��Top=�6i   $��60��6�   $��60��6�   .��54      �� $��app/Images/ClientAdd.png��6   $��50��66   $��50��6B   $
 Fant=�6M   6v   55      �� 57   
   -   5        $ btn_eliminarCliente��57      $
��Left=�6.   $��
32,528,0,0q�6I   $��0q�6]   $	��Top=�6i   $��60��6�   $��60��6�   .��58      �� $!��app/Images/ClientDelete.png��6   $��50��69   $��50��6E   $
 Fant=�6P   6y   59      �� 5;   
   -   5        $ btn_modificarCliente��5;      $
��Left=�6/   $��120,528,0,0q�6J   $��0q�6_   $	��Top=�6k   $��60��6�   $��60��6�   .��5<      �� $!��app/Images/ClientUpdate.png��6   $��50��69   $��50��6E   $
 Fant=�6P   6y   5=      &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dg_contratos��5>         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6W   $	��202��6r   $��416,153,0,0q�6   $	��Top=�6�   $	��463��6�      Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Número de contrato��6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ NumeroContrato�6k     5A      $
 Tipo��6O    6%   �� $ Tipo.Descripcion�6_   4  .System.Windows.Controls.DataGridCheckBoxColumn  5B      $ Vigente��6[    6)   �� $ EstaVigente� �� Mode$ OneWay=�6n     5C      $ Fecha de creación��6b    6%   �� $ Creacion� �� StringFormat$ 
dd/MM/yyyy��6     5D      $ Fecha de término��6�    6%   �� $ Termino�$ 
dd/MM/yyyy�� �� 	Converter# [  6�   5G      �� 5H   
   $
��Left=�6   $��
21,391,0,0q�6/   $
��Wrap=�6C   $��Contacto��6W   $	��Top=�6g   $��14(�6   $
��Bold"�6�   �� 5I   
   -   5        $ lbl_nombreContacto��5I   $   $��	Nombre *:��6   $��
26,427,0,0q�6@   $
��Left=�6T   $	��Top=�6o   �� 5J   
   -   5        $	 txt_nombreContacto��5J      $
��Left=�6.   $��23��6I   $��102,428,0,0q�6U   $

 Wrap=�6j   $	��Top=�6~   $	��218��6�   �� 5L   
   -   5        $ lbl_emailContacto��5L   $   $��	E-mail *:��6   $��
26,471,0,0q�6?   $
��Left=�6S   $	��Top=�6n   �� 5M   
   -   5        $	 txt_emailContacto��5M      $
��Left=�6-   $��23��6H   $��102,472,0,0q�6T   $

 Wrap=�6i   $	��Top=�6}   $	��231��6�   5O      5P      