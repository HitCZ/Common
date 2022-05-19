using Common.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Common.CustomControls.Controls
{
    public class NumericTextBox : TextBox
    {
        #region Constructors

        public NumericTextBox()
        {
            Text = "0";
            PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var isNumber = e.Text.IsNumber();

            if (!isNumber)
                e.Handled = true;
        }

        #endregion Constructors

    }
}
