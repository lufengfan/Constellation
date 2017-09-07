using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static PInvoke.User32;

namespace αστερισμό
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AllowsPenetrate = true;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            int i = 0;
            timer.Tick += (_sender, _e) =>
            {
                if (++i == 5)
                {
                    i = 0;
                    this.update();
                }

                //var pos = GetCursorPos();
                //this.lblMousePosition.Content = $"{pos.x},{pos.y}";
            };
            timer.Start();
        }

        public void update()
        {
            List<LightBall> list = new List<LightBall>();

            foreach (var ball in this.balls)
            {
                double left = (double)ball.Ball.GetValue(Canvas.LeftProperty);
                double top = (double)ball.Ball.GetValue(Canvas.TopProperty);
                if ((left < 0 || left > this.Width) ||
                    (top < 0 || top > this.Height)
                )
                {
                    this.canvas.Children.Remove(ball.Ball);
                    list.Add(ball);
                }
                else
                {
                    var action = new Action<LightBall, double, double>((_ball, _left, _top) =>
                    {
                        _ball.Ball.SetValue(Canvas.LeftProperty, _left + _ball.Speed.X);
                        _ball.Ball.SetValue(Canvas.TopProperty, _top + _ball.Speed.Y);
                    });
                    this.Dispatcher.BeginInvoke(action, ball, left, top);
                }
            }
            foreach (var ball in list)
                this.balls.Remove(ball);

            this.DropLightBalls();
        }

        #region AllowsPenetrate
        /// <summary>
        /// 标识 <see cref="AllowsPenetrate"/> 依赖属性。
        /// </summary>
        public static readonly DependencyProperty AllowsPenetrateProperty = DependencyProperty.Register(nameof(AllowsPenetrate), typeof(bool), typeof(MainWindow), new PropertyMetadata(false, AllowsPenetratePropertyChangedCallback));

        /// <summary>
        /// 获取或设置一个值，该值指示窗口的工作区是否支持鼠标穿透。这是依赖项属性。
        /// </summary>
        /// <value>
        /// 如果窗口支持鼠标穿透则为 true ；否则为 false 。
        /// </value>
        public bool AllowsPenetrate
        {
            get => (bool)this.GetValue(MainWindow.AllowsPenetrateProperty);
            set => this.SetValue(MainWindow.AllowsPenetrateProperty, value);
        }

        private SetWindowLongFlags normalGWLEx;
        private static void AllowsPenetratePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow window = (MainWindow)d;
            IntPtr hWnd = new WindowInteropHelper(window).Handle;
            if ((bool)e.NewValue)
            {
                var oldGWLEx = SetWindowLong(hWnd, WindowLongIndexFlags.GWL_EXSTYLE, SetWindowLongFlags.WS_EX_TRANSPARENT | SetWindowLongFlags.WS_EX_LAYERED);
                if (oldGWLEx == 0)
                    ;
                else
                    window.normalGWLEx = (SetWindowLongFlags)oldGWLEx;
            }
            else
                SetWindowLong(hWnd, WindowLongIndexFlags.GWL_EXSTYLE, window.normalGWLEx);
        }
        #endregion

        class LightBall
        {
            public Ellipse Ball { get; set; }
            public Vector Speed { get; set; }
        }
        List<LightBall> balls = new List<LightBall>();
        Random random = new Random();
        double density = 15000;
        private void DropLightBalls()
        {
            int count = (int)(this.Height * this.Width / this.density);
            if (this.balls.Count < count)
            {
                double speed = this.random.NextDouble() * 3 + 2;
                double direction = this.random.NextDouble() * 2 * Math.PI;
                Vector Speed = new Vector(speed * Math.Sin(direction), speed * Math.Cos(direction));
                Color color = Color.FromRgb((byte)this.random.Next(byte.MinValue, byte.MaxValue), (byte)this.random.Next(byte.MinValue, byte.MaxValue), (byte)this.random.Next(byte.MinValue, byte.MaxValue));
                Ellipse Ball = new Ellipse()
                {
                    Width = 2.5,
                    Height = 2.5,
                    Fill = new SolidColorBrush(color),
                    Effect = new DropShadowEffect()
                    {
                        BlurRadius = 15,
                        Color = color,
                        RenderingBias = RenderingBias.Performance,
                        ShadowDepth = 0
                    }
                };

                //Color colorFrom = ((DropShadowEffect)Ball.Effect).Color;
                //Color colorTo = Color.FromRgb((byte)this.random.Next(byte.MinValue, byte.MaxValue), (byte)this.random.Next(byte.MinValue, byte.MaxValue), (byte)this.random.Next(byte.MinValue, byte.MaxValue));
                //ColorAnimation colorAnimation = new ColorAnimation()
                //{
                //    From = colorFrom,
                //    To = colorTo,
                //    Duration = new Duration(new TimeSpan(
                //        (long)(new System.Windows.Media.Media3D.Vector3D(colorFrom.R, colorFrom.G, colorFrom.B) - new System.Windows.Media.Media3D.Vector3D(colorTo.R, colorTo.G, colorTo.B)).Length
                //    ))
                //};
                //Storyboard.SetTarget(colorAnimation, Ball.Effect);
                //Storyboard.SetTargetProperty(colorAnimation, new PropertyPath(DropShadowEffect.ColorProperty));
                //Storyboard storyboard = new Storyboard();
                //storyboard.Children.Add(colorAnimation);
                //storyboard.Begin(Ball);

                Ball.SetValue(Canvas.LeftProperty, this.Width / 2);
                Ball.SetValue(Canvas.TopProperty, this.Height / 2);

                this.canvas.Children.Add(Ball);
                this.balls.Add(new LightBall() { Ball = Ball, Speed = Speed });
            }
        }
    }
}
