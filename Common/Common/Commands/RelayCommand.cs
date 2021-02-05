using System;
using System.Globalization;
using System.Windows.Input;

namespace Common.Commands
{
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action executeAction;
        private readonly Func<bool> canExecuteFunc;

        #endregion Fields

        #region Constructors

        public RelayCommand(Action executeAction)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
        }

        public RelayCommand(Action executeAction, Func<bool> canExecuteFunc) : this(executeAction)
        {
            this.canExecuteFunc = canExecuteFunc ?? throw new ArgumentNullException(nameof(canExecuteFunc));
        }

        #endregion Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc is null || canExecuteFunc();
        }

        public void Execute(object parameter)
        {
            executeAction();
        }

        public event EventHandler CanExecuteChanged;

        #endregion ICommand Members
    }

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> executeAction;
        private readonly Predicate<T> canExecutePredicate;

        #endregion Fields

        #region Constructors

        public RelayCommand(Action<T> executeAction)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
        }

        public RelayCommand(Action<T> executeAction, Predicate<T> canExecutePredicate) : this(executeAction)
        {
            this.canExecutePredicate = canExecutePredicate ?? throw new ArgumentNullException(nameof(canExecutePredicate));
        }

        #endregion Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (canExecutePredicate is null)
                return true;
            return TryConvertToType(parameter, out var convertedValue) && canExecutePredicate(convertedValue);
        }

        public void Execute(object parameter)
        {
            var isTypeValid = TryConvertToType(parameter, out var convertedValue);

            if (isTypeValid)
                executeAction(convertedValue);
        }

        public event EventHandler CanExecuteChanged;

        #endregion ICommand Members

        #region Private Methods

        private bool TryConvertToType(object parameter, out T convertedValue)
        {
            if (parameter is null && typeof(T).IsValueType)
            {
                convertedValue = default;
                return false;
            }
            if (parameter is null || parameter is T)
            {
                convertedValue = (T)parameter;
                return true;
            }

            try
            {
                convertedValue = (T)Convert.ChangeType(parameter, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                convertedValue = default;
                return false;
            }

            return true;
        }

        #endregion Private Methods
    }
}
