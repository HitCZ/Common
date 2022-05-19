using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Common.CustomControls.Controls.ResizableControl.Thumbs
{
    public class ResizeThumb : Thumb
    {

        #region Constructor

        public ResizeThumb()
        {
            DragDelta += ResizeThumb_DragDelta;
        }

        #endregion Constructor

        #region Private Methods

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (DataContext is not Control item)
                return;

            double deltaVertical;
            double deltaHorizontal;

            switch (VerticalAlignment)
            {
                case VerticalAlignment.Bottom:
                    deltaVertical = Math.Min(-e.VerticalChange, item.ActualHeight - item.MinHeight);
                    item.Height -= deltaVertical;
                    break;
                case VerticalAlignment.Top:
                    deltaVertical = Math.Min(e.VerticalChange, item.ActualHeight - item.MinHeight);
                    Canvas.SetTop(item, Canvas.GetTop(item) + deltaVertical);
                    item.Height -= deltaVertical;
                    break;
            }

            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    deltaHorizontal = Math.Min(e.HorizontalChange, item.ActualWidth - item.MinWidth);
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + deltaHorizontal);
                    item.Width -= deltaHorizontal;
                    break;
                case HorizontalAlignment.Right:
                    deltaHorizontal = Math.Min(-e.HorizontalChange, item.ActualWidth - item.MinWidth);
                    item.Width -= deltaHorizontal;
                    break;
            }

            e.Handled = true;
        }

        #endregion Private Methods
    }
}
