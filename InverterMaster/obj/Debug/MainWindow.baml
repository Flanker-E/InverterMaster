   M S B A M L   `   `   `  ����I  EInverterMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:InverterMasterInverterMaster  5      h dMicrosoft.Toolkit.Wpf.UI.XamlHost, Version=6.1.0.0, Culture=neutral, PublicKeyToken=4aff67a105548ee2�Zclr-namespace:Microsoft.Toolkit.Wpf.UI.XamlHost;assembly=Microsoft.Toolkit.Wpf.UI.XamlHost!Microsoft.Toolkit.Wpf.UI.XamlHost 5      l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization 5	      �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5
      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          InverterMaster.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .localclr-namespace:InverterMaster     5      oxamlHostZclr-namespace:Microsoft.Toolkit.Wpf.UI.XamlHost;assembly=Microsoft.Toolkit.Wpf.UI.XamlHost     5      M	 IModernWpf.Controls, Version=0.9.3.0, Culture=neutral, PublicKeyToken=nullD
 @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullL HModernWpf.MahApps, Version=0.9.3.0, Culture=neutral, PublicKeyToken=null.ui!http://schemas.modernwpf.com/2019 	 
  5      DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit 	 
  5	      �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit 	 
  5
      Blvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf 	 
  5      7System&clr-namespace:System;assembly=mscorlib 	 
  5        � Title$  
MainWindow��5      $	��600��6   $
��1025��6%   0 
 *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  � 	Resources 5       �� Source�� 5   
   $K Epack://application:,,,/ModernWpf;component/DensityStyles/Compact.xaml?�6   %    .��5      ]� .+�5"   
   � -   5        $��menuBar��5"   $   $	��Top=�6    � ColumnDefinitions 5#      �� 5$      �� 5%      $
��Auto �6#   .+�5'      o� $
��Left=�6   $��40��6.   $	��227��6;   $	��Top=�6G   .@�5(      m� $
��File��6   .@�5)      m� $
��_New��6   m� 5*      $��_Open��6   m� 5+      $��_Save��6   m� 5,      $��_Save as...��6   �� 5-      m� 5.      $��_Exit��6   5/      m� 50      $��Connect��6   .@�51      m� $��Logon��6   m� 52      $��Logoff��6   53      m� 54      $
��Help��6   .@�55      m� $��
Error Info��6   m� 56      $��Moter Parameters��6   57      58      �� 59      $��28��5:      $��Right=�5;      $��51��5<      $��Dianracing.png��5=      $��0,0,20,0q�6)   5?      �� 5A   
   -   5        $��	statusBar��5A   -   $��Bottom=�6   ���	#FF007ACC$��2q�6U   $��30��6a   .@�5B      �� $
��Left=�6   .��5C      �� -   5        $��statusInfoTextBlock��5D      
�������Ready5G      5H      �� 5I      $��Right=�6   .��5J      �� -   5        $��timeDateTextBlock��5J      
�������6J   5K      5L      � 5N   
   .+�5O      ]� .+�5P      � $
��Left=�6   $��12q�6-   .+�5Q      5 
 /ModernWpf.Controls.Primitives.ThemeShadowChrome     IsShadowEnabled .    Depth$ 20Q�5S      ._�5T      ��  '  #SystemControlBackgroundAltHighBrush#���   5U      .��5V      ) 
 #ModernWpf.Controls.SimpleStackPanel  $��10q�5W   !      Spacing$ 12Q�5X   !   .+�5Y   "   �� $��SetPints��69   $��18(�6K   .��5Z   &     -   5        $��SetValuesPanel��5[   )   $ 2Q�5\   )   .+�5]   *   �  5^   .   �� 5_   2   $��* �6C   �� 5`   2   $��* �6C   .+�5b   .   �� $��0��67   $��Enable��6G   6Z   �� 5c   .   $��1��67   $��
ErrorReset��6G   6^   5d   +   � 5f   *    5g   .   �� 5h   2   $��* �6C   �� 5i   2   $��* �6C   .+�5k   .   �� $��0��5l   1   1 
 +ModernWpf.Controls.Primitives.ControlHelper   Header$ VelocityLimitP��5m   1   $
��Left=�5n   1   $	��100��5o   1   $�� ��5p   1   �� 5q   .   $��1��5r   1   $ VelocityLimitN��5s   1   $
��Left=�5t   1   $	��100��5u   1   $�� ��5v   1   5w   +   �� 5x   *   $ TargetTorque��5y   -   $
��Left=�5z   -   $	��100��5{   -   $�� ��5|   -   5~   '   5   #   �� 5�   "   $��ActualValues��69   $��18(�6O   .��5�   &   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 ActualValuesGrid��5�   )   
   HeadersVisibility$
 Column=�5�   )      GridLinesVisibility$ Vertical=�5�   )      CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .     
IsReadOnly . $
��Auto��5�   )   $	��241��5�   )   5�   '   5�   #   5�      5�      5�      5�      � 5�      -   5        $$��serialCommunicationConfigPanel��5�      $��Right=�6=   $��12q�6T   $y�Visible=�6`   .+�5�         . $ 20Q�5�      ._�5�      �� $
��Auto=�5�      $
��Auto=�5�      #���   5�      .��5�        $ 24Q�5�   !   $��10q�5�   !   .+�5�   "   �� -   5         ��Name$ ConboBox_Port��5�   %   $ Select Port��5�   %   $
��Left=�5�   %   $	��150��5�   %   $��0,20,0,0q�61   �� 5�   "   -	   5         ��Name$ Button_Connect��5�   %   $��CONNECT��5�   %   $	��150��5�   %   9� 5�   "   $��Print��5�   %   $	��150��5�   %   .��5�   &   �� -
   5        $��recvDataRichTextBox��5�   )   
�������$	��300��5�   )   $��0q�5�   )    �� 
IsReadOnly . . �5�   *   /�  /� 
LineHeight$	 1.5��5�   -    /� FontSize$ 14(�5�   -   5�   +   5�   '   5�   #   �� 5�   "   -   5        $ Button_clearRecvDataBox��5�   %   $��CLEAR RECEIVED��5�   %   $
�� 150��5�   %   5�      5�      5�      5�      � 5�      $��Bottom=�6   $��	0,12,0,12q�6/   .+�5�         . $ 20Q�5�      ._�5�      � #���   5�       5�      �� 5�   "   $
��Auto �63   �� 5�   "   $
��Auto �63   �� 5�   "   $
��Auto �63   .+�5�      �� .��5�   "     $ 6Q�5�   %   $��10q�5�   %   $��0��5�   %   .+�5�   &   ��  �� Orientation$ 
Horizontal=�61   .+�5�   *   �� -   5         ��Name$ Slider1��5�   -   $	��100��5�   -    �� TickFrequency$ 10Q�5�   -    � Minimum$ 0Q�5�   -    � Maximum$	 100Q�5�   -    �� TickPlacement$
 Both=�5�   -    � Value 5�   -   ��  �� ElementName$ ProgressValue�� �� Path$ Value� �� Mode$ TwoWay=��� 5�   *   -   5         ��Name$ Control1Output��5�   -   $��30��5�   -     �� TextAlignment$  Center=�5�   -   �� 5�   *   -   5        $ ProgresLabel��5�   -   $��Progress��5�   -   $��Center=�5�   -   $��0,0,10,0q�5�   -   " 	 ModernWpf.Controls.NumberBox  5�   *   -   5        !  Name$! ProgressValue��5�   -   "   Minimum$" 0Q�5�   -   #   Maximum$	# 100Q�5�   -   $   Value$$ 0Q�5�   -   %   SpinButtonPlacementMode$% Inline=�5�   -   4  .System.Windows.Automation.AutomationProperties&   	LabeledBy& 5�   -   �� $ ProgresLabel��5�   -   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� -   5        $ Slider2��5�   -   $	��100��5�   -   $ 10Q�5�   -   $ 0Q�5�   -   $	 100Q�5�   -   $
 Both=�5�   -    5�   -   �� $ ProgressValue2��$ Value�$ TwoWay=��� 5�   *   -   5        $ Control2Output��5�   -   $��30��5�   -   $  Center=�5�   -   �� 5�   *   -   5        $ ProgresLabel2��5�   -   $��Progress��5�   -   $��Center=�5�   -   $��0,0,10,0q�5�   -     5�   *   -   5        $! ProgressValue2��5�   -   $" 0Q�5�   -   $	# 100Q�5   -   $$ 0Q�5  -   $% Inline=�5  -   & 5�   -   �� $ ProgresLabel2��5  -   5  +   �� 5  &   $ 
Horizontal=�61   .+�5  *   �� -   5        $ Slider3��5  -   $	��100��5  -   $ 10Q�5  -   $ 0Q�5	  -   $	 100Q�5
  -   $
 Both=�5  -    5  -   �� $ ProgressValue3��$ Value�$ TwoWay=��� 5  *   -   5        $ Control3Output��5  -   $��30��5  -   $  Center=�5  -   �� 5  *   -   5        $ ProgresLabel3��5  -   $��Progress��5  -   $��Center=�5  -   $��0,0,10,0q�5  -     5  *   -   5        $! ProgressValue3��5  -   $" 0Q�5  -   $	# 100Q�5  -   $$ 0Q�5  -   $% Inline=�5  -   & 5  -   �� $ ProgresLabel3��5  -   5  +   5  '   5       5      $ 12Q�5!  !   $��10q�5"  !   $��1��5#  !   .+�5$  "   �� -   5        $ Button3��5%  !   $
��Test��5&  !   $
��auto��5'  !   �� 5)  "   -   5        $ Button4��5*  !   $��RESET��5+  !   $
��auto��5,  !   5-     � 5.     $��2��5/     $��7q�50      , (SystemControlBackgroundChromeMediumBrush#���  51     .+�52       $��10q�53     $ 12Q�54     .+�55  "   % 	 ModernWpf.Controls.ToggleSwitch  -   5        '  Name$' ProgressToggle��56  %   (   Header$( 
TuningMode��57  %   )   
OffContent$	) OFF��58  %   *   	OnContent$* ON��59  %   +   IsOn+ .  5:  %   �� 5<  "   -   5        $ Button2��5=  %   $��SetTuneValue��5>  %   $
��Auto��5?  %   5A     5B     5C     5D     5E     � 5G     $��0,12,0,0q�6   .+�5H        . $ 10Q�5J     ._�5K     �� .��5L       $ 7Q�6*   #���   66   .+�5N     �� -   5        .��5N  7   Inject/Stop Data5P     �� 5Q     -   5        , ��Name$, testtext��5Q     $��Interval test��6/   #	  LiveCharts.Wpf.CartesianChart	  5T     $	��200��6)   &
   LiveCharts.Wpf.Charts.Base.Chart- 
  DisableAnimations- . . 
  	Hoverable. .  / 
  DataTooltip/ 6a   Z� 0 
  Series0 5V       LiveCharts.Wpf.LineSeries  1   LineSmoothness$	1 0.3Q�5X  !     LiveCharts.Wpf.Series2   StrokeThickness$2 1Q�5Y  !   3   Stroke3 �#F343364   Fill
4 ���� 5   Values5 5V  -   �� *ChartValues+6   PointGeometry6 5W  !   Z� 5[  !   7 
  AxisX7 5b       LiveCharts.Wpf.Axis  8   LabelFormatter8 6'   �� *DateTimeFormatter+9   MaxValue9 5c  #   �� *	AxisMax+:   MinValue: 5d  #   �� *	AxisMin+;   Unit; 5e  #   �� *
AxisUnit+5g     5j     	  5k     $	��200��6)   - . . .  / 6a   Z� 0 5m       $	1 0.3Q�5o     $2 1Q�5p     3 �#F34336
4 ���� 5 5m  -   �� *ChartValues+6 5n     Z� 5r     7 5v       8 6'   �� *DateTimeFormatter+9 5w  !   �� *	AxisMax+: 5x  !   �� *	AxisMin+; 5y  !   �� *
AxisUnit+5{     5}     5     5�     5�     5�     5�     5�     5�     5�     