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

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(10);
            //timer.Tick += (_sender, _e) =>
            //{
            //    var pos = GetCursorPos();
            //    this.lblMousePosition.Content = $"{pos.x},{pos.y}";
            //};
            //timer.Start();
            this.DropLightBalls();
        }

        public void update()
        {
            lock (this.balls)
            {
                this.DropLightBalls(); 
            }
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
                if (oldGWLEx != 0)
                    window.normalGWLEx = (SetWindowLongFlags)oldGWLEx;
            }
            else
                SetWindowLong(hWnd, WindowLongIndexFlags.GWL_EXSTYLE, window.normalGWLEx);
        }
        #endregion

        class LightBall : IDisposable
        {
            private MainWindow mainWindow;
            private DispatcherTimer timer;

            private Ellipse ball;
            public Ellipse Ball
            {
                get => this.ball;
                set
                {
                    if (this.ball != null && this.mainWindow.canvas.Children.Contains(this.ball))
                        this.mainWindow.canvas.Children.Remove(this.ball);

                    this.ball = value;
                }
            }

            public double Radius
            {
                get => this.ball.Width / 2;
                set
                {
                    this.ball.Height = value * 2;
                    this.ball.Width = value * 2;
                }
            }
            
            public Vector Speed { get; set; }

            public TimeSpan Interval
            {
                get => this.timer.Interval;
                set => this.timer.Interval = value;
            }

            public LightBall(MainWindow mainWindow)
            {
                this.mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
                //this.timer = new DispatcherTimer()
                //{
                //    Interval = TimeSpan.FromMilliseconds(50)
                //};
                //this.timer.Tick += this.timer_Tick;
                this.timer = new DispatcherTimer(TimeSpan.FromMilliseconds(50), DispatcherPriority.Normal,this.timer_Tick, this.mainWindow.Dispatcher);
            }

            private void timer_Tick(object sender, EventArgs e)
            {
                double left = (double)this.Ball.GetValue(Canvas.LeftProperty);
                double top = (double)this.Ball.GetValue(Canvas.TopProperty);
                if ((left < 0 || left > this.mainWindow.Width) ||
                    (top < 0 || top > this.mainWindow.Height)
                )
                {
                    this.Dispose();
                }
                else
                {
                    this.Ball.SetValue(Canvas.LeftProperty, left + this.Speed.X);
                    this.Ball.SetValue(Canvas.TopProperty, top + this.Speed.Y);
                }
            }

            public void Release()
            {
                this.mainWindow.canvas.Children.Add(this.ball);
                this.timer.Start();
            }

            public void Capture()
            {
                this.timer.Stop();
                this.mainWindow.canvas.Children.Remove(this.ball);
            }

            public event EventHandler Disposed;

            #region IDisposable Support
            private bool disposedValue = false; // 要检测冗余调用

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 释放托管状态(托管对象)。
                        this.Capture();
                        this.mainWindow.balls.Remove(this);

                        // 补充缺失的球。
                        this.mainWindow.DropLightBalls();
                    }

                    // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                    // TODO: 将大型字段设置为 null。
                    this.Disposed?.Invoke(this, new EventArgs());
                    this.Disposed = null;

                    this.Ball = null;
                    this.mainWindow = null;
                    this.timer = null;

                    disposedValue = true;
                }
            }

            // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
            // ~LightBall() {
            //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            //   Dispose(false);
            // }

            // 添加此代码以正确实现可处置模式。
            public void Dispose()
            {
                // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
                Dispose(true);
                // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
        List<LightBall> balls = new List<LightBall>();
        Random random = new Random();
        double density = 150000 / 2.5;
        private void DropLightBalls()
        {
            int count = (int)(this.Height * this.Width / this.density);
            while (this.balls.Count < count)
            {
                double speed = this.random.NextDouble() * 2 + 1;
                double direction = this.random.NextDouble() * 2 * Math.PI;
                Vector Speed = new Vector(speed * Math.Sin(direction), speed * Math.Cos(direction));
                Color color = Color.FromRgb((byte)this.random.Next(byte.MinValue, byte.MaxValue), (byte)this.random.Next(byte.MinValue, byte.MaxValue), (byte)this.random.Next(byte.MinValue, byte.MaxValue));
                double radius = this.random.NextDouble() * 3.5 + 1.5;
                Ellipse Ball = new Ellipse()
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Fill = new SolidColorBrush(color),
                    Effect = new DropShadowEffect()
                    {
                        BlurRadius = radius * this.random.Next(5, 9),
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

                Point enterPoint;
                if (this.random.Next(0, 2) == 0)
                { // 上下边界
                    double x = this.random.NextDouble() * this.Width;
                    if (Math.Cos(direction) > 0)
                        enterPoint = new Point(x, 0);
                    else
                        enterPoint = new Point(x, this.Height);
                }
                else
                { // 左右边界
                    double y = this.random.NextDouble() * this.Height;
                    if (Math.Sin(direction) > 0)
                        enterPoint = new Point(0, y);
                    else
                        enterPoint = new Point(this.Width, y);
                }
                Ball.SetValue(Canvas.LeftProperty, enterPoint.X);
                Ball.SetValue(Canvas.TopProperty, enterPoint.Y);
                
                var lightBall = new LightBall(this) { Ball = Ball, Speed = Speed };
                this.balls.Add(lightBall);
                lightBall.Release();
            }

            this.ConnectLightBalls();
        }

        class LightBallConnection : IDisposable
        {
            private MainWindow mainWindow;
            private DispatcherTimer timer;

            private LightBall lightBall1;
            public LightBall LightBall1
            {
                get => this.lightBall1;
                set
                {
                    if (this.lightBall1!=null)
                        this.lightBall1.Disposed -= this.lightBall_Disposed;

                    if (value != null)
                        value.Disposed += this.lightBall_Disposed;

                    this.lightBall1 = value;
                }
            }
            private LightBall lightBall2;
            public LightBall LightBall2
            {
                get => this.lightBall2;
                set
                {
                    if (this.lightBall2 != null)
                        this.lightBall2.Disposed -= this.lightBall_Disposed;

                    if (value != null)
                        value.Disposed += this.lightBall_Disposed;

                    this.lightBall2 = value;
                }
            }
            public Line Connection { get; } = new Line()
            {
                StrokeThickness = 1.5
            };

            public TimeSpan Interval
            {
                get => this.timer.Interval;
                set => this.timer.Interval = value;
            }

            public double LargeDistance { get; set; } = 150;
            public double SmallDistance { get; set; } = 100;

            public LightBallConnection(MainWindow mainWindow)
            {
                this.mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
                this.timer = new DispatcherTimer(TimeSpan.FromMilliseconds(50), DispatcherPriority.Normal, this.timer_Tick, this.mainWindow.Dispatcher);
                this.timer.Start();
            }

            private void lightBall_Disposed(object sender, EventArgs e)
            {
                this.Dispose();
            }

            bool isReleased = false;
            private void timer_Tick(object sender, EventArgs e)
            {
                Ellipse ball1 = this.LightBall1.Ball;
                Ellipse ball2 = this.LightBall2.Ball;
                double x1 = (double)ball1.GetValue(Canvas.LeftProperty) + this.LightBall1.Radius;
                double y1 = (double)ball1.GetValue(Canvas.TopProperty) + this.LightBall1.Radius;
                double x2 = (double)ball2.GetValue(Canvas.LeftProperty) + this.LightBall2.Radius;
                double y2 = (double)ball2.GetValue(Canvas.TopProperty) + this.LightBall2.Radius;

                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                double distance = (point1 - point2).Length;
                if (distance > this.LargeDistance)
                {
                    this.Connection.Opacity = 0;

                    if (this.isReleased)
                        this.Capture();
                }
                else
                {
                    if (distance > this.SmallDistance)
                        this.Connection.Opacity = (this.LargeDistance - distance) / (this.LargeDistance - this.SmallDistance) * 0.5;
                    else
                        this.Connection.Opacity = 0.5;

                    this.Connection.X1 = x1;
                    this.Connection.Y1 = y1;
                    this.Connection.X2 = x2;
                    this.Connection.Y2 = y2;
                    
                    if (!this.isReleased)
                        this.Release();
                }
            }

            public void Capture()
            {
                this.isReleased = false;
                //this.timer.Stop();
                this.mainWindow.canvas.Children.Remove(this.Connection);
            }

            public void Release()
            {
                this.Connection.Stroke = new LinearGradientBrush()
                {
                    GradientStops = new GradientStopCollection(new GradientStop[]
                    {
                        new GradientStop(((SolidColorBrush)this.LightBall1.Ball.Fill).Color, 0),
                        new GradientStop(((SolidColorBrush)this.LightBall2.Ball.Fill).Color, 1)
                    })
                };

                this.mainWindow.canvas.Children.Add(this.Connection);
                //this.timer.Start();
                this.isReleased = true;
            }

            #region IDisposable Support
            private bool disposedValue = false; // 要检测冗余调用

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 释放托管状态(托管对象)。
                        this.timer.Stop();
                        this.Capture();
                        this.mainWindow.connections.Remove(this);
                    }

                    // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                    // TODO: 将大型字段设置为 null。
                    //this.Connection = null;
                    this.mainWindow = null;
                    this.timer = null;

                    disposedValue = true;
                }
            }

            // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
            // ~LightBallConnection() {
            //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            //   Dispose(false);
            // }

            // 添加此代码以正确实现可处置模式。
            public void Dispose()
            {
                // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
                Dispose(true);
                // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
        private List<LightBallConnection> connections = new List<LightBallConnection>();
        private void ConnectLightBalls()
        {
            var combinations = SamLu.Math.Combination.GetCombinationsWithRank(this.balls, 2);
            foreach (var combination in combinations)
            {
                if (this.connections.Any(_connection =>
                    (_connection.LightBall1 == combination[0] && _connection.LightBall2 == combination[1]) ||
                    (_connection.LightBall1 == combination[1] && _connection.LightBall2 == combination[0])
                ))
                    continue;
                // else
                var connection = new LightBallConnection(this)
                {
                    LightBall1 = combination[0],
                    LightBall2 = combination[1]
                };
                connection.Release();
            }
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
