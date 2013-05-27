using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace EpicPasswordGenerator.Converters
{
	class BoolTocheckConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var Value = (bool) value;

			return (Value)?Visibility.Visible:Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
