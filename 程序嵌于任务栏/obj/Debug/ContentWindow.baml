   M S B A M L   `   `   `  ����  程序嵌于任务栏)    #程序嵌于任务栏.ContentWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   -   5        $
��cWnd��5   	     � Title$  ContentWindow��5   	   $	��300��6   $	��500��6,    � AllowsTransparency .  � WindowStyle$
 None=�6R    � ShowInTaskbar .  
������  � 	Resources 5       	  cwstb �� 
TargetName �� TargetProperty W� From	 W� To	 g� Duration��%�   &	        �� 5   
   .��5	      W� $
 cWnd��6   $ Width�5
      $ 0X�5      $	 500X�5      $	 	00:00:0.2D�5      5      5      .��5      �� 
 �� CornerRadius$
 3��6   $��1q�6   ���#1c1c1c$	��295��6H   $	��490��6U   
������� J� Opacity$	 0.5Q�6t    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Color$ 	#FFA39999��6/      ShadowDepth$ 1Q�6A   5      5      