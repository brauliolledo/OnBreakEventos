   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   I EOnBreakEventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:OnBreakEventos.app.convertersOnBreakEventos.app.converters 5   	   /clr-namespace:OnBreakEventosOnBreakEventos 5	   	   G CPersistencia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW;clr-namespace:Persistencia.lib.entity;assembly=PersistenciaPersistencia.lib.entity 5   	   C&clr-namespace:OnBreakEventos.app.utilsOnBreakEventos.app.utils 5   	   0   *OnBreakEventos.AdministracionContratosView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Cie:http://schemas.microsoft.com/expression/2010/interactivity  5   	   <
converters+clr-namespace:OnBreakEventos.app.converters  5   	   (localclr-namespace:OnBreakEventos  5	   	   Hentity;clr-namespace:Persistencia.lib.entity;assembly=Persistencia  5   	   2utils&clr-namespace:OnBreakEventos.app.utils  5   	     � Title$,  &OnBreak - Administración de contratos��5   	   $��740.81��67   $��887.889��6G    � Icon$ app/Images/Icono.ico��6W   0  *OnBreakEventos.app.utils.EnterKeyTraversal   	IsEnabled .  � DataContext 5      4  .OnBreakEventos.AdministracionContratoViewModel  5   
   62    � 	Resources 5      =  7OnBreakEventos.app.converters.SqlMinDateToNullConverter   SqlMinDateConverter9  3OnBreakEventos.app.converters.IsSqlMinDateConverter  IsSqlMinDateConverter@  :OnBreakEventos.app.converters.ClaseTienePropiedadConverter   ClaseTienePropiedadConverter@  :OnBreakEventos.app.converters.BooleanAVisibilidadConverter   BooleanAVisibilidadConverter��%t   &	        &	      &	 &     &	 9       5   
   6/     5   
   6+     5   
   62     5   
   62   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5      6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 6%   �� *InicializarCacheCommand+5      .��5!      � $��0,-2,0,2q�6   .+�5#   
   �� $*��$app/Images/logo_white_background.jpg��6   $��Right=�6?   $	��Top=�6[   $	��224��6s   $��0,-50,-25,0q�6�   $	��195��6�   	 �� BitmapScalingMode$
	 Fant=�6�   
 J� Clip
 5$      �� 5%       �� Rect$ 10,50 160,200�6%   6<   5'      �� 5(   
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $"��Administración de contratos��6V   $	��Top=�6y   $��24(�6�   $��72��6�   $	��307��6�   �� 5)   
   $
��Left=�6   $��	10,48,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��34��6n   $	��307��6z   $��Italic$�6�   ���	#FF767676�� 6�   $�Ingrese ��6�   �� 6�   $8�2los datos para crear un nuevo contrato, o indique ��6�   �� 6  $'�!el número de un contrato existen��6  �� 65  $�te para modificarlo��69  6W  �� 5+   
   -   5         ��Name$ 
lbl_numero��5+      $��Número��6$   $
��Left=�65   $��
29,110,0,0q�6P   $	��Top=�6d    J� RenderTransformOrigin$ 0.562,1.231&�6|   �� 5,   
   -   5         ��Name$ 
txt_numero��5,      $
��Left=�6&   $��10��6A   $��
96,110,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��97��6�   ��6�   �� *Contrato.NumeroContrato+.��6�    5-        5.      $ 	LostFocus��6"   . 5/      
   6-   �� *BuscarContratoCommand+ 
  CommandParameter 6W   �� *Text+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��51      52      .��53   '   54      �� 55   
   -   5         ��Name$ btn_buscarContrato��55      $
��Left=�6.   $��198,110,0,0q�6I   $��0q�6^   $	��Top=�6j   $��32��6�   $��26��6�   -  'System.Windows.Input.KeyboardNavigation   	IsTabStop .  .��56      �� $��app/Images/DataSearch.png��6   $��20��67   $��21��6C   $
	 Fant=�6N   6w    58        59      $ Click��6"   . 5:      
   6-   �� *AbrirAuxiliarCommand+5;      5=      �� 5?   
   -   5        $ lbl_creacion��5?   &   $��Creación *:��6   $��
24,164,0,0q�6<   $
��Left=�6P   $	��Top=�6k   6�   �� 5A   
   -   5        $ lbl_termino��5A   $   $��
Término: ��6   $��
32,213,0,0q�69   $
��Left=�6M   $	��Top=�6h   6�   �� 5B   
   -   5         ��Name$ cb_estaVigente��5B      $��Vigente��6+    J� IsHitTestVisible .  $
��Left=�6V   $��252,114,0,0q�6q   $	��Top=�6�    d� 	IsChecked 6�   �� *Contrato.Termino+ �� 	Converter# [ +   %MahApps.Metro.Controls.DateTimePicker  5D   
   -   5          Name$ dttp_inicioEvento��5D   "   $��459,153,0,0q�6=   $
��Left=�6R   $	��Top=�6m      SelectedDate 6�   �� *Contrato.InicioEvento+# [  6�     5E   
   -   5        $ dttp_terminoEvento��5E   "   $��717,153,0,0q�6>   $
��Left=�6S   $	��Top=�6n    6�   �� *Contrato.TerminoEvento+# [  6�   �� 5F   
   -	   5        $ lbl_observaciones��5F   )   $��Observaciones:��6   $��377,548,0,0q�6D   $
��Left=�6Y   $	��Top=�6t   $ 0.5,0.5&�6�   5G      �� 5H   
   -
   5        $ lbl_tipoEvento��5H   )   $��Tipo evento *:��6   $��370,193,0,0q�6A   $
��Left=�6V   $	��Top=�6q   $��29��6�   �� 5I   
   -   5        $ txt_observaciones��5I      $
��Left=�6-   $��62��6H   $��471,548,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��386��6�   ��6�   �� *Contrato.Observaciones+�� 5J   
   -   5         ��Name$ cmb_tipoEvento��5J      $
��Left=�6+   $��459,193,0,0q�6F   $	��Top=�6[   $	��218��6s   ��6   �� *TiposEvento+ �� SelectedItem 6�   �� *Contrato.Tipo+�� 5K   
   -   5        $ txt_precioBase��5K      $
��Left=�6*   $��23��6E   $��457,274,0,0q�6Q   $
 Wrap=�6f   {�.  $	��Top=�6�   $	��120��6�   ��6�   �� *&$Contrato.ModalidadServicio.ValorBase+�� 5L   
   -   5        $ txt_personalBase��5L      $
��Left=�6,   $��23��6G   $��720,274,0,0q�6S   $
 Wrap=�6h   {�.  $	��Top=�6�   $	��120��6�   ��6�   �� *)'Contrato.ModalidadServicio.PersonalBase+�� 5M   
   -   5        $ lbl_precioBase��5M      $��Precio base:��6(   $
��Left=�6?   $��33��6Z   $��370,274,0,0q�6f   $	��Top=�6{   $��82��6�   �� 5N   
   -   5        $ lbl_personalBase��5N      $��Personal base:��6*   $
��Left=�6C   $��624,274,0,0q�6^   $	��Top=�6s   �� 5Q   
   -   5        $ 	btn_crear��5Q      $
��Left=�6$   $��
29,536,0,0q�5R      $	��Top=�6%   $��68��6=   $��66��6H   .��5S      �� $ ��app/Images/ContractAdd.png��6    � ToolTip$ Nuevo contrato��68   $
	 Fant=�6Q    5T        5U      $ Click��6"   . 5V      
   6-   �� *CrearContratoCommand+5W      5Y      �� 5Z   
   -   5        $ btn_guardarCambios��5Z      $
��Left=�6-   $��789,620,0,0q�5[      $	��Top=�6"   $��68��6:   $��66��6E   .��5\      �� $#��app/Images/ContractUpdate.png��6   $!                     cambios��6;   $
	 Fant=�5]       5_        5`      $ Click��6"   . 5a      
   6-   �� *GuardarContratoCommand+5b      5d      �� 5f   
   -   5        $ btn_terminarContrato��5f      $
��Left=�6/   $��665,620,0,0q�5g      $	��Top=�6"   $��68��6:   $��66��6E   $ Terminar contrato��6R   .��5h      �� $#��app/Images/ContractDelete.png��6   $
	 Fant=�6;    5i        5j      $ Click��6"   . 5k      
   6-   �� *TerminarContratoCommand+5l      5n      (  "System.Windows.Controls.DatePicker  5o   
   -   5          Name$ dtp_creacion��5o      $
��Left=�6+   $��
96,164,0,0q�6F   $	��Top=�6Z   $	��127��6r       SelectedDate  6~   �� *Contrato.Creacion+# [    5p   
   -   5        $ dtp_termino��5p      $
��Left=�6*   $��
96,214,0,0q�6E   $	��Top=�6Y   $	��127��6q   {�.    6}   �� *Contrato.Termino+# [  6�   �� 5q   
   -   5        $ 
lbl_inicio��5q      $��	Inicio *:��6$   $
��Left=�68   $��398,153,0,0q�6S   $	��Top=�6h   �� 5r   
   -   5        $ lbl_terminoEvento��5r      $��Finalización *:��6+   $
��Left=�6E   $��624,152,0,0q�6`   $	��Top=�6u   $��26��6�   $��86��6�   $ 0.917,0.519&�6�   �� 5s   
   $��Asistentes:��6   $
��Left=�6&   $��377,315,0,0q�6A   $	��Top=�6V   �� 5t   
   $��Personal adicional��6   $
��Left=�6-   $��605,315,0,0q�6H   $	��Top=�6]   *   $MahApps.Metro.Controls.NumericUpDown  5u   
   -   5        !  Name$! nup_asistentes��5u   �   "   HasDecimals" .  $��457,315,0,0q�65   $
��Left=�6J   $	��Top=�6e   #   Minimum$# 1Q�6}   $   Value$ 6�   �� *Contrato.Asistentes+6�     5v   
   -   5        $! nup_personalAdicional��5v   �   " .  $��721,315,0,0q�65   $
��Left=�6J   $	��Top=�6e   $# 0Q�6}   $ 6�   �� *Contrato.PersonalAdicional+�� 5w   
   -   5        $ txt_precioTotal��5w      $
��Left=�6+   $��25��6F   $��470,514,0,0q�6R   $
 Wrap=�6g   {�.  $	��Top=�6�   $	��167��6�   ��6�   �� *Contrato.PrecioTotal+% �� StringFormat$% C0���� 5x   
   $��Precio total:��6   $
��Bold"�6(   $
��Left=�6:   $��381,514,0,0q�6U   $	��Top=�6j   �� 5y   
   -   5        $ txt_busquedaClienteRut��5y      $
��Left=�62   $��23��6M   $��
96,266,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��132��6�   ��6�   �� *RutBusquedaCliente+& �� Mode$& TwoWay=�' �� UpdateSourceTrigger$' 	LostFocus=�.��6�   5z      �� 5{   
   $��RUT Cliente *:��6   $
��Left=�6)   $��	8,266,0,0q�6D   $	��Top=�6W   �� 5|   
   -   5        $ btn_buscarCliente��5|      $
��Left=�6,   $��236,266,0,0q�6G   $��0q�6\   $	��Top=�6h   $��32��6�   $��26��6�    .  .��5}      �� $��app/Images/DataSearch.png��6   $��20��67   $��21��6C   $
	 Fant=�6N    5        5�      $ Click��6"   . 5�      
   6-   �� *AbrirAuxiliarClienteCommand+5�      5�      �� 5�   
   -   5        $ txt_nombreCliente��5�      $
��Left=�6-   $��23��6H   $��
96,327,0,0q�6T   $
 Wrap=�6h   {�.  $	��Top=�6�   $	��197��6�   ��6�   �� *Contrato.Cliente.RazonSocial+�� 5�   
   $��Cliente:��6   $
��Left=�6#   $��
37,326,0,0q�6>   $	��Top=�6R   �� 5�   
   $��Modalidad servicio*:��6   $
��Left=�6/   $��327,233,0,0q�6J   $	��Top=�6_   �� 5�   
   -   5        $ cmb_modalidadServicio��5�      $
��Left=�62   $��457,233,0,0q�6M   $	��Top=�6b   $	��218��6z   ��6�   �� *ModalidadesServicio+ 6�   �� *Contrato.ModalidadServicio+�� 5�   
   $��Ambientación:��6   $
��Left=�6(   $��364,356,0,0q�6C   $	��Top=�6X   �� 5�   
   $
��Left=�6   $��459,356,0,0q�6.   $	��Top=�6C   $	��163��6[   ( �� DisplayMemberPath$( Descripcion��5�   =   {�5�      �� *Contrato.Tipo+# [ ) �� ConverterParameter$) Ambientacion����5�      �� *TiposAmbientacion+ 5�      � 5�      * �� FallbackValue$*  ��6"   .&�5�      �� + �� Path$ + Contrato.Tipo.Ambientacion�6   6B   5�      5�      �� 5�   
   $��Música ambiental��6   $
��Left=�5�      $��462,394,0,0q�6.   $	��Top=�6C   {�5�      �� *Contrato.Tipo+# [ $) MusicaAmbiental�� 5�      � 5�      $* False��6"   .&�5�      �� $#+ Contrato.Tipo.MusicaAmbiental�6   6E   5�      5�      �� 5�   
   $��Opción vegetariana��6   $
��Left=�5�      $��462,440,0,0q�6.   $	��Top=�6C   {�5�      �� *Contrato.Tipo+# [ $) Vegetariana�� 5�      � 5�      $* False��6"   .&�5�      �� $+ Contrato.Tipo.Vegetariana�6   6A   5�      5�      �� 5�   
   $��Música cliente��6   $
��Left=�5�      $��462,417,0,0q�6.   $	��Top=�6C   {�5�      �� *Contrato.Tipo+# [ $) MusicaCliente�� 5�      � 5�      $* False��6"   .&�5�      �� $!+ Contrato.Tipo.MusicaCliente�6   6C   5�      5�      �� 5�   
   $��Local:��6   $
��Left=�6!   $��676,354,0,0q�6<   $	��Top=�6Q   �� 5�   
   $��Local OnBreak��6   $
��Left=�5�      $��687,391,0,0q�6.   $	��Top=�6C   {�5�      �� *Contrato.Tipo+# [ $) LocalOnBreak�� 5�      � 5�      $* False��6"   .&�5�      �� $ + Contrato.Tipo.LocalOnBreak�6   6B   5�      5�      �� 5�   
   $��
Otro Local��6   $
��Left=�5�      $��688,423,0,0q�6.   $	��Top=�6C   {�5�      �� *Contrato.Tipo+# [ $) 	OtroLocal�� 5�      � 5�      $* False��6"   .&�5�      �� $+ Contrato.Tipo.OtroLocal�6   6?   5�      5�      �� 5�   
   -   5        $ ValorArriendoTextBox��5�      $
��Left=�5�      $��23��6(   $��682,477,0,0q�64   $
 Wrap=�6I   $	��Top=�6]   $	��120��6u   {�5�      �� *Contrato.Tipo+# [ $) ValorArriendo��.��5�   �   ��5�      � 5�      $*  ��6"   .&�5�      �� $!+ Contrato.Tipo.ValorArriendo�6   6C   5�      .��5�      5�      �� 5�   
   $��Valor arriendo:��6   $
��Left=�6*   $��677,451,0,0q�6E   $	��Top=�6Z   �� 5�   
   
�������$��1q�6)   $
��Left=�6=   $��76��6X   $��
24,622,0,0q�6d   $	��Top=�6x   $	��293��6�   ._�5�      � .+�5�      �� $��Caché de trabajo��6   $��Italic$�63   $��
0,0,190,47q�6F   6\   �� 5�      $��Atrás��6   $��10,32,218,10q�6)    5�        5�      $ Click��6*   . 5�      
   65   �� *MementoAnteriorCommand+5�      5�      �� 5�      $
��Left=�6   $��	118,6,0,0q�67   $
��Wrap=�6J   $	��Top=�6�   $	��163��6�   , �� TextAlignment$, Right=�6�   ��6^   �� *MementoActual.FechaHora+- �� TargetNullValue$- Actual��$% G��6�   �� 5�      $��	Respaldar��6   $
��Left=�6-   $��	86,32,0,0q�6H   $	��Top=�6[   $	��110��6s   $��32��6    5�        5�      $ Click��6*   . 5�      
   65   �� *RespaldarMementoCommand+5�      5�      �� 5�      $��Adelante��6   $
��Left=�6,   $��
204,32,0,0q�6G   $	��Top=�6[   $��77��6s   $��32��6~    5�        5�      $ Click��6*   . 5�      
   65   �� *MementoSiguienteCommand+5�      5�      5�      5�      5�      5�      