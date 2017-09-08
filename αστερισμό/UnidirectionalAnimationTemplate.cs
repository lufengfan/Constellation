using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace αστερισμό.Media.Animation
{
    public class UnidirectionalAnimationTemplate<T> : AnimationTimeline
    {
        /// <summary>
        /// <see cref="ColorAnimation"/>
        /// </summary>
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register(nameof(From), typeof(Box<T>), typeof(UnidirectionalAnimationTemplate<T>), new PropertyMetadata(Box<T>.NonValue));
        public Box<T> From
        {
            get => (Box<T>)this.GetValue(UnidirectionalAnimationTemplate<T>.FromProperty);
            set => this.SetValue(UnidirectionalAnimationTemplate<T>.FromProperty, value);
        }

        public static readonly DependencyProperty ToProperty = DependencyProperty.Register(nameof(To), typeof(Box<T>), typeof(UnidirectionalAnimationTemplate<T>), new PropertyMetadata(Box<T>.NonValue));
        public Box<T> To
        {
            get => (Box<T>)this.GetValue(UnidirectionalAnimationTemplate<T>.ToProperty);
            set => this.SetValue(UnidirectionalAnimationTemplate<T>.ToProperty, value);
        }

        public static readonly DependencyProperty ByProperty = DependencyProperty.Register(nameof(By), typeof(Box<T>), typeof(UnidirectionalAnimationTemplate<T>), new PropertyMetadata(Box<T>.NonValue));
        public Box<T> By
        {
            get => (Box<T>)this.GetValue(UnidirectionalAnimationTemplate<T>.ByProperty);
            set => this.SetValue(UnidirectionalAnimationTemplate<T>.ByProperty, value);
        }

        /// <summary>
        /// 当在派生类中重写时获取 <see cref="Type"/> 属性进行动画处理。
        /// </summary>
        /// <value>
        /// 此动画进行动画处理的属性的类型。
        /// </value>
        public override Type TargetPropertyType => typeof(T);

        private IUnidirectionalProvider<T> provider;

        public UnidirectionalAnimationTemplate(IUnidirectionalProvider<T> provider) =>
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));

        /// <summary>
        /// 在派生类中实现时创建的新实例 <see cref="Freezable"/> 派生的类。
        /// </summary>
        /// <returns>新实例。</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new UnidirectionalAnimationTemplate<T>(this.provider);
        }

        /// <summary>
        /// 获取动画的当前值。
        /// </summary>
        /// <param name="defaultOriginValue">如果动画不具有其自己的起始值，则为动画提供原始值。 如果此动画是组合链中的第一个正在进行处理的动画，则为该属性的基础值；否则，它将返回前一动画链中的值。</param>
        /// <param name="defaultDestinationValue">如果动画没有自己的目标值，则为提供给动画的目标值。</param>
        /// <param name="animationClock">动画将使用可以生成 <see cref="Clock.CurrentTime"/> 或 <see cref="Clock.CurrentProgress"/> 值的 <see cref="AnimationClock"/> 来生成其输出值。</param>
        /// <returns>此动画应为该属性的当前值的值。</returns>
        public sealed override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            return this.GetCurrentValue((T)defaultOriginValue, (T)defaultDestinationValue, animationClock);
        }

        /// <summary>
        /// 获取动画的当前值。
        /// </summary>
        /// <param name="defaultOriginValue">如果动画不具有其自己的起始值，则为动画提供原始值。 如果此动画是组合链中的第一个正在进行处理的动画，则为该属性的基础值；否则，它将返回前一动画链中的值。</param>
        /// <param name="defaultDestinationValue">如果动画没有自己的目标值，则为提供给动画的目标值。</param>
        /// <param name="animationClock">动画将使用可以生成 <see cref="Clock.CurrentTime"/> 或 <see cref="Clock.CurrentProgress"/> 值的 <see cref="AnimationClock"/> 来生成其输出值。</param>
        /// <returns>此动画应为该属性的当前值的值。</returns>
        public virtual T GetCurrentValue(T defaultOriginValue, T defaultDestinationValue, AnimationClock animationClock)
        {
            return this.provider.GetProgressValue(this.From.GetValueOrDefault(defaultOriginValue), this.To.GetValueOrDefault(defaultDestinationValue), animationClock.CurrentProgress.Value);
        }
    }
}
