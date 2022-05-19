using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Common.CustomControls.Controls.ResizableControl.Thumbs
{
   public class MoveThumb : Thumb
   {
      #region Constructor

      public MoveThumb()
      {
         DragDelta += MoveThumb_DragDelta;
      }

      #endregion Constructor

      #region Private Methods

      private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
      {
         var item = DataContext as Control;

         if (item is null)
            return;

         var left = Canvas.GetLeft(item);
         var top = Canvas.GetTop(item);

         Canvas.SetLeft(item, left + e.HorizontalChange);
         Canvas.SetTop(item, top + e.VerticalChange);
      }

      #endregion Private Methods
   }
}
