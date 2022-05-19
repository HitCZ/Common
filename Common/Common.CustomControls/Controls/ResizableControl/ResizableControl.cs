using System.Windows;
using System.Windows.Controls;

namespace Common.CustomControls.Controls.ResizableControl
{
    public class ResizableControl : ContentControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty CanResizeProperty = DependencyProperty.Register(
            nameof(CanResize), typeof(bool), typeof(ResizableControl));

        public bool CanResize
        {
            get => (bool)GetValue(CanResizeProperty);
            set => SetValue(CanResizeProperty, value);
        }

        public static readonly DependencyProperty CanMoveProperty = DependencyProperty.Register(
            nameof(CanMove), typeof(bool), typeof(ResizableControl));

        public bool CanMove
        {
            get => (bool)GetValue(CanMoveProperty);
            set => SetValue(CanMoveProperty, value);
        }

        #endregion Dependency Properties

        #region Constructor

        static ResizableControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizableControl), new FrameworkPropertyMetadata(typeof(ResizableControl)));
        }

        #endregion Constructor
    }
}
