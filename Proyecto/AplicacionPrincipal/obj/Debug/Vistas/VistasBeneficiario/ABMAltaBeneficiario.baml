   M S B A M L   `   `   `  ����N  JAplicacionPrincipal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:AplicacionPrincipal.Vistas.VistasBeneficiario-AplicacionPrincipal.Vistas.VistasBeneficiario  5   	   G    AAplicacionPrincipal.Vistas.VistasBeneficiario.ABMAltaBeneficiario   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Mlocal;clr-namespace:AplicacionPrincipal.Vistas.VistasBeneficiario     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  ABMAltaBeneficiario��5	   	   $	��700��6%   $	��410��62   .��5
      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#012e67._�5      �� -   5         ��Name$ 	lblTitulo��5      $��Alta Beneficiario��6'   $��60��6C   $��Center=�6O   $	��380��6j   $��Center=�6v   $��Center=�6�   $��Center=�6�   $��30(�6�   $
��Bold"�6�   
�������6�   5      �� 5   
   -   5         ��Name$ 	txtNombre��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre��6%    %  !MaterialDesignFloatingHintTextBox#��[  6M   $��88,10,84,515q�6�   $��1��6�   �� 5   
   -   5        $ txtApellido��5      $ Apellido��6'   #��[  6Q   $��88,79,84,446q�6�   $��1��6�   �� 5   
   -   5        $ txtDNI��5      $	 DNI��6"   #��[  6G   $��88,148,84,379q�6�   $��1��6�   �� 5   
   -   5         ��Name$ cbxNvlEscolar��5      $ Nivel de Escolaridad��6*    & "MaterialDesignFloatingHintComboBox#��[ 6`   $��88,385,84,156q�6�   $��48��6�   $��1��6�   .@�5      �� $��Primario��6   �� 5      $��
Secundario��6   �� 5      $��Universitario��6   5      �� 5   
   -   5         ��Name$ 
btnAceptar��5      $��ACEPTAR��6%    $  MaterialDesignRaisedAccentButton#��[ 67    � ToolTip$5 /Resource name: MaterialDesignRaisedAccentButton��6q   $��88,510,200,43q�6�   $��1��6�   $
��Auto��6�   �� 5   
   -   5        $��btnCancelar��5      $��CANCELAR��6$     MaterialDesignFlatButton#��[ 67   $ MaterialDesignFlatButton��6i   $��204,510,84,43q�6�   $��1��6�   $
��Auto��6�   �� 5   
   -   5        $ txtCuil��5      $
 Cuil��6#   #��[  6I   $��88,215,84,312q�6�   $��1��6�   �� 5   
   -	   5        $ txtMail��5      $
 Mail��6#   #��[  6I   $��88,282,84,245q�6�   $��1��6�   '  !MaterialDesignThemes.Wpf.PackIcon  5   
   -
   5          Name$ 	iconCheck��5   "   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]	   Kind$	 CheckBoxOutline=�5      $��28��5       $��29��5!      $��Center=�6   $��Bottom=�69   $��323,0,50,245q�6T   $��1��6j   
���  ��6w   5"      5#      