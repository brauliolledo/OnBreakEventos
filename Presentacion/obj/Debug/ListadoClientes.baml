   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   I EOnBreakEventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:OnBreakEventosOnBreakEventos 5   	   $   OnBreakEventos.ListadoClientes   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:OnBreakEventos     5   	     � Title$   OnBreak - Listado Clientes��5	   	   $��639.407��6,   $��872.211��6=    � Icon$ app/Images/Icono.ico��6M   .��5
      � $
��Auto��6    � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $��* �6   6)   �� 5      $	��130 �6   6+   .+�5   
   �� $0��*app/Images/logo_transparent_background.png��6    �� BitmapScalingMode$
 Fant=�6E   $��Right=�6l   $	��Top=�6�   $	��224��6�   $��0,-50,-25,0q�6�   $	��195��6�    J� Clip 5      �� 5       �� Rect$ 10,50 160,200�6%   6<   5      �� 5   
   $��0��6   $
��Left=�6!   $��	23,17,0,0q�6<   $
��Wrap=�6O   $��Listado de clientes��6c   $	��Top=�6~   $��24(�6�   $	��307��6�   �� 5   
   $��0��6   $
��Left=�6!   $��	23,49,0,0q�6<   $
��Wrap=�6O   $	��Top=�6c   $��34��6{   $	��594��6�   $��Italic$�6�   ���	#FF767676��Vista en detalle de los contratos registrados. Use los controles en la esquina inferior derecha para los filtros. Haga doble clic en un contrato para ver más detalles.6f  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_clientes��5       $��1��6   $��Stretch=�65   $��5,5,0,5q�6S   $��Stretch=�6d   $	��796��6�      AutoGenerateColumns .     CanUserAddRows .  	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 RUT��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$	 Rut�6Q     5      $ Razón Social��6J    6%   �� $ RazonSocial�6b     5      $ 
Dirección��6H    6%   �� $ 	Direccion�6]     5      $ 	Actividad��6H    6%   �� $ 	Actividad�6]     5      $
 Tipo��6C    6%   �� $
 Tipo�6S   5       �� 5!   
   -   5         ��Name$ 
lbl_filtro��5!      $��2��6   $��Filtrar por:��62   $
��Left=�6I   $	��Top=�6d   $��
495,10,0,0q�6|   �� 5"   
   -   5         ��Name$ cmb_tipoFiltro��5"       �� SelectedIndex$ 0��6+   $��2��6=   $
��Left=�6J   $	��Top=�6f   $	��120��6~   $��
576,10,0,0q�6�   .@�5$      �� $��
Sin filtro��6   $
��Left=�60   $	��118��6K   �� 5%      $	��RUT��6   $
��Left=�6)   $	��118��6D   �� 5&      $��Razón Social��6   $
��Left=�62   $	��118��6M   �� 5'      $��	Actividad��6   $
��Left=�6/   $	��118��6J   �� 5(      $
��Tipo��6   $
��Left=�6*   $	��118��6E   5)      �� 5*   
   -   5         ��Name$ 
txt_filtro��5*      $��2��6K   $
��Left=�6Y   $��23��6t    �� TextWrapping$
 Wrap=�6�   $��
��6�   $	��Top=�6�   $	��120��6�   $��
724,10,0,0q�6�   �� 5+   
   -   5         ��Name$ btn_refrescarContratos��5+      $��2��6   $
��Left=�6>    � ToolTip$ 	Refrescar��6Y   $	��Top=�5,      $��42��6   $��44��6)   $��	23,10,0,0q�6Z   .��5-      �� $(��"app/Images/refresh-page-option.png��6   $
 Fant=�6@   $��27��6g   $��27��6s   5/      �� 50   
   -   5        $ btn_seleccionar��50      $��SELECCIONAR��6H   $y�Hidden=�6^   $
��Left=�6r   $��
722,58,0,0q�6�   $��2��6�   $	��Top=�6�   $	��124��6�   $��56��6�    J� RenderTransformOrigin$ 0.577,0.125&�6�   53      54      