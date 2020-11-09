using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace UpdateFocusedControl
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify using pre-made PropertyChangedEventArgs
        /// </summary>
        /// <param name="args"></param>
        protected void NotifyPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        /// <summary>
        /// Creates PropertyChangedEventArgs
        /// </summary>
        /// <param name="propertyExpression">Expression to make PropertyChangedEventArgs out of</param>
        /// <returns>PropertyChangedEventArgs</returns>
        public static PropertyChangedEventArgs CreateArgs<T>(Expression<Func<T, object>> propertyExpression)
        {
            return new PropertyChangedEventArgs(GetPropertyName(propertyExpression));
        }

        /// <summary>
        /// Creates PropertyChangedEventArgs
        /// </summary>
        /// <param name="propertyExpression">Expression to make PropertyChangedEventArgs out of</param>
        /// <returns>PropertyChangedEventArgs</returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
        {
            var lambda = propertyExpression as LambdaExpression;

            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = lambda.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            if (memberExpression != null)
            {
                var propertyInfo = memberExpression.Member as PropertyInfo;

                if (propertyInfo != null) return propertyInfo.Name;
            }

            return null;
        }

        #endregion

    }
}