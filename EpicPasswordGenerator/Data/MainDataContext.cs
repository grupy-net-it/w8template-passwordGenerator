using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicPasswordGenerator.Data
{
	using System.Collections.ObjectModel;
	using System.Runtime.CompilerServices;
	using Windows.UI.Xaml.Media;

	public class MainDataContext : INotifyPropertyChanged
	{
		private string appName;
		public string AppName
		{
			get { return appName; }
			set
			{
				appName = value;
				this.NotifyPropertyChanged();
			}
		}

		private Password password = Password.Instance;
		public Password Password
		{
			get { return password; }
			private set { password = value; }
		}

		public ObservableCollection<GeneratorOption> GeneratorOptionsCollection { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public MainDataContext()
		{
			// Initializing collection
			GeneratorOptionsCollection = new ObservableCollection<GeneratorOption>();

			// 16 chars, all letters, digits and special chars
			var option1 = new GeneratorOption() { Title = "16 characters", Subtitle = "All letters, digits and special chars", Length = 16, SmallLetters = true, CapitalLetters = true, Digits = true, SpecialChars = true };
			GeneratorOptionsCollection.Add(option1);

			// 8 chars, all letters and digits
			var option2 = new GeneratorOption() { Title = "8 characters", Subtitle = "All letters and digits", Length = 8, SmallLetters = true, CapitalLetters = true, Digits = true, SpecialChars = false };
			GeneratorOptionsCollection.Add(option2);

			// 6 chars, all letters, digits and special chars
			var option3 = new GeneratorOption() { Title = "6 characters", Subtitle = "Small letters and digits", Length = 6, SmallLetters = true, CapitalLetters = false, Digits = true, SpecialChars = false };
			GeneratorOptionsCollection.Add(option3);

			// 20 chars, all letters, digits and special chars
			var option4 = new GeneratorOption() { Title = "20 characters", Subtitle = "All letters, digits and special chars", Length = 20, SmallLetters = true, CapitalLetters = true, Digits = true, SpecialChars = true };
			GeneratorOptionsCollection.Add(option4);

			// 16 chars, all letters, digits and special chars
			var option5 = new GeneratorOption() { Title = "8 characters", Subtitle = "Small letters only", Length = 8, SmallLetters = true, CapitalLetters = false, Digits = false, SpecialChars = false };
			GeneratorOptionsCollection.Add(option5);

			// 16 chars, all letters, digits and special chars
			var option6 = new GeneratorOption() { Title = "4 characters", Subtitle = "Small letters only", Length = 4, SmallLetters = true, CapitalLetters = false, Digits = false, SpecialChars = false };
			GeneratorOptionsCollection.Add(option6);
		}

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
