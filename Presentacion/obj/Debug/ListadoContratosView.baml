   M S B A M L   `   `   `  ����I  EOnBreakEventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:OnBreakEventos.app.convertersOnBreakEventos.app.converters  5   	   /clr-namespace:OnBreakEventosOnBreakEventos  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   )    #OnBreakEventos.ListadoContratosView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   B
converters+clr-namespace:OnBreakEventos.app.converters     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Cie:http://schemas.microsoft.com/expression/2010/interactivity  5   	   (localclr-namespace:OnBreakEventos  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	     � Title$!  OnBreak - Listado Contratos��5   	   $��639.407��6-   $��872.211��6>    � Icon$ app/Images/Icono.ico��6N    � 	Resources 5      =   7OnBreakEventos.app.converters.SqlMinDateToNullConverter   SqlMinDateConverter��%   &	          5   
   6/   5       � DataContext 5      .   (OnBreakEventos.ListadoContratosViewModel  5   
   6,   .��5      � $
��Auto��6    � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $��* �6   6)   �� 5      $	��130 �6   6+   .+�5   
   �� $0��*app/Images/logo_transparent_background.png��6    �� BitmapScalingMode$
 Fant=�6E   $��Right=�6l   $	��Top=�6�   $	��224��6�   $��0,-50,-25,0q�6�   $	��195��6�    J� Clip 5      �� 5       �� Rect$ 10,50 160,200�6%   6<   5      �� 5   
   $��0��6   $
��Left=�6!   $��	23,17,0,0q�6<   $
��Wrap=�6O   $��Listado de contratos��6c   $	��Top=�6   $��24(�6�   $	��307��6�   �� 5   
   $��0��6   $
��Left=�6!   $��	23,49,0,0q�6<   $
��Wrap=�6O   $	��Top=�6c   $��34��6{   $	��594��6�   $��Italic$�6�   ���	#FF767676��Vista en detalle de los contratos registrados. Use los controles en la esquina inferior derecha para los filtros. Haga doble clic en un contrato para ver más detalles.6f  &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ dg_contratos��5    Q   $��1��6D   $��Stretch=�6g   $��5,5,0,5q�6�   $��Stretch=�6�   $	��796��6�   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     
IsReadOnly . ��6   ��  �� Path$ ContratosCollection�   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Cliente��6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ Cliente.RazonSocial�6e     5#      $ Número de contrato��6M    6%   �� $ NumeroContrato�6k     5$      $
 Tipo��6O    6%   �� $ Tipo.Descripcion�6_     5%      $ 	Modalidad��6W    6%   �� $ ModalidadServicio.Nombre�6l     5&      $ Fecha de creación��6b    6%   �� $ Creacion� �� StringFormat$ 
dd/MM/yyyy��6     5'      $ Fecha de término��6�    6%   �� $ Termino�$ 
dd/MM/yyyy�� �� 	Converter# [  6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5(      $ Vigente��6[    6)   �� $ EstaVigente� �� Mode$ OneWay=�6n     5)      $ Inicio evento��6l    6%   �� $ InicioEvento�$ dd/MM/yyyy hh:mm��6�     5*      $ Término evento��6m    6%   �� $ TerminoEvento�$ dd/MM/yyyy hh:mm��6�   5,      �� 5-   
   -   5         ��Name$ 
lbl_filtro��5-      $��2��6   $��Filtrar por:��62   $
��Left=�6I   $	��Top=�6d   $��
495,10,0,0q�6|   �� 5.   
   -   5         ��Name$ cmb_tipoFiltro��5.      $��2��6U   $
��Left=�6b   $	��Top=�6~   $	��120��6�   $��
576,10,0,0q�6�    �� SelectedIndex 6+   �� $ 
TipoFiltro�.@�50      �� $��
Sin filtro��6   $
��Left=�60   $	��118��6K   �� 51      $��Número de contrato��6   $
��Left=�68   $	��118��6S   �� 52      $��Rut del cliente��6   $
��Left=�65   $	��118��6P   �� 53      $��Tipo de evento��6   $
��Left=�64   $	��118��6O   �� 54      $��Modalidad Servicio��6   $
��Left=�68   $	��118��6S   55      �� 56   
   -   5         ��Name$ 
txt_filtro��56      $��2��6u   $
��Left=�6�   $��23��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��
724,10,0,0q�6�   ��6&   �� $ Filtro�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 57   
   -   5         ��Name$ btn_refrescarContratos��57      $��2��6   $
��Left=�6>    � ToolTip$ 	Refrescar��6Y   $	��Top=�58      $��42��6   $��44��6)   $��	23,10,0,0q�65   .��59      �� $(��"app/Images/refresh-page-option.png��6   $
 Fant=�6@   $��27��6g   $��27��6s   .  (System.Windows.Interactivity.Interaction   Triggers 5:      /	  )System.Windows.Interactivity.EventTrigger	  5;       	  	EventName$ Click��6"   .
  (System.Windows.Interactivity.TriggerBase 
  Actions. 5<      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6-   �� *RefrescarContratosCommand+5=      5?      �� 5@   
   -   5        $ btn_seleccionar��5@      $��SELECCIONAR��6*   $y�Hidden=�6@   $
��Left=�6T   $��
722,58,0,0q�6o   $��2��6�   $	��Top=�6�   $	��124��6�   $��56��6�    J� RenderTransformOrigin$ 0.577,0.125&�6�   5C      5D      