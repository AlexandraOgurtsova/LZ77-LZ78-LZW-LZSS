   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.LZ78_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � Title$  LZ78_Window��5   	   $	��450��6   $	��760��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.4* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��0.18* �6   �� 5      $��0.45* �6   .+�5   
   �� -   5         ��Name$ sourceTB��5       �� TextWrapping$
 Wrap=�6$   .��68   Enter message6G   �� 5   
   -   5         ��Name$ outputTB��5   (   $
��Wrap=�6   $��0��6:   $��2��6G   6Y   �� 5   
   $��1��6   $��1��6"   .+�5      �� -   5         ��Name$ startCmprBtn��5      $��15(�6+   .��6T   Start compress6d   �� 5      -   5        $ iterationCmprBtn��5      $��15(�6/   {�.  .��6n   Compression iteration6�   �� 5      -   5        $ 
allCmprBtn��5      $��15(�6)   {�.  .��6b   Compress All6p   �� 5      -   5        $ startDecmprBtn��5      $��15(�6-   {�.  .��6j   Start decompress6|   �� 5      -   5        $ iterationDecmprBtn��5      $��15(�61   {�.  .��6r   Decompression iteration6�   �� 5      -   5        $ allDecmprBtn��5      $��15(�6+   {�.  .��6f   Decompress All6v   �� 5      -	   5        $ t1��5      Compression rate:67   �� 5       -
   5        $ timeC��5       6)   �� 5!      -   5        $ t2��5!      Deecompression rate:6:   �� 5"      -   5        $ timeD��5"      6)   5#      �� 5%   
   $��1��6   $��0��6$   .��5&      �� -   5         ��Name$ compressContainer��5&      $��1��64   $��0��6A   .+�5'      �  � Orientation$ 
Horizontal=�6   .+�5(      �� $	��120��6   	 �� TextAlignment$	 Center=�6*   .��6A   
Dictionary6M   �� 5)      $	��120��6   $	 Center=�6*   .��6A   Remaining Message6T   �� 5*      $��35��6   $	 Center=�6)   .��6@   Prefix6H   �� 5+      $��35��6   $	 Center=�6)   .��6@   Code6F   5,      5-      5.      �� 50   
   $��1��6   $��2��6$   .��51      �� -   5        $ decompressContainer��51      $��1��66   $��2��6C   .+�52      � $ 
Horizontal=�6   .+�53      �� $	��120��6   $	 Center=�6*   .��6A   
Dictionary6M   �� 54      $	��120��6   $	 Center=�6*   .��6A   Remaining Message6T   �� 55      $��35��6   $	 Center=�6)   .��6@   Code6F   56      57      58      5:      5;      