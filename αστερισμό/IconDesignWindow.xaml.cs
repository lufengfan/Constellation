using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace αστερισμό
{
    /// <summary>
    /// IconDesignWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IconDesignWindow : Window
    {
        public IconDesignWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PNG (*.png)|*.png",
                FileName= "αστερισμό.png"
            };
            if (sfd.ShowDialog() == true)
            {
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    this.SaveVisualImage(this.canvas, fs);
                }

                if (File.Exists(sfd.FileName))
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        private void SaveVisualImage(FrameworkElement visual, Stream stream)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(visual) { Stretch = Stretch.None };
                context.DrawRectangle(brush, null, new Rect(0, 0, visual.Width, visual.Height));
                context.Close();
            }

            //dpi可以自己设定
            // 获取dpi方法：PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)visual.Width, (int)visual.Height, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(drawingVisual);
            
            PngBitmapEncoder encode = new PngBitmapEncoder();
            encode.Frames.Add(BitmapFrame.Create(bitmap));
            encode.Save(stream);
        }
    }
}
