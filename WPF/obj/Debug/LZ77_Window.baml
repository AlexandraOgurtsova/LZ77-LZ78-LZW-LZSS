   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.LZ77_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � Title$  LZ77_Window��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.4* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��0.18* �6   �� 5      $��0.45* �6   .+�5   
   �� -   5         ��Name$ bufferSizeTB��5      $��1��6(    �� TextWrapping$
 Wrap=�68   .��6L   $"Enter buffer size: (10 by default)6p   �� 5   
   -   5        $ sourceTB��5      $
 Wrap=�6$   .��68   Enter message6G   �� 5   
   -   5         ��Name$ outputTB��5      $��0��6&   $��2��63   $
��Wrap=�6C   6Y   �� 5   
   $��1��6   $��1��6"   .+�5      �� -   5         ��Name$ startCmprBtn��5      $��15(�6+   $��Right=�6T   $	��126��6p   .��6|   Start compress6�   �� 5      -   5        $ iterationCmprBtn��5      $��15(�6/   {�.  .��6n   Compression iteration6�   �� 5      -   5        $ 
allCmprBtn��5      $��15(�6)   {�.  .��6b   Compress All6p   �� 5      -   5        $ startDecmprBtn��5      $��15(�6-   {�.  .��6j   Start decompress6|   �� 5      -   5        $ iterationDecmprBtn��5      $��15(�61   {�.  .��6r   Decompression iteration6�   �� 5       -	   5        $ allDecmprBtn��5       $��15(�6+   {�.  .��6f   Decompress All6v   �� 5!      -
   5        $ t1��5!      Compression rate:67   �� 5"      -   5        $ timeC��5"      6)   �� 5#      -   5        $ t2��5#      Deecompression rate:6:   �� 5$      -   5        $ timeD��5$      6)   5%      �� 5'   
   $��1��6   $��0��6$   .��5(      �� -   5         ��Name$ compressContainer��5(      $��1��64   $��0��6A   .+�5)      �  � Orientation$ 
Horizontal=�6   .+�5*      �� $	��130��6   	 �� TextAlignment$	 Center=�6*   .��6A   Buffer6I   �� 5,      $��60��6   $	 Center=�6)   .��6@   Code6F   5-      5.      5/      �� 51   
   $��1��6   $��2��6$   .��52      �� -   5        $ decompressContainer��52      $��1��66   $��2��6C   .+�53      � $ 
Horizontal=�6   .+�54      �� $	��120��6   $	 Center=�6*   .��6A   Code6G   �� 55      $	��120��6   $	 Center=�6*   .��6A   Answer6I   56      57      58      59      5:      