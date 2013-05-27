using EpicPasswordGenerator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpicPasswordGenerator
{
	public class Password : Singleton<Password>, INotifyPropertyChanged
	{
		private string content;
		public string Content
		{
			get { return content; }
			set
			{
				content = value;
				this.NotifyPropertyChanged();
				this.Length = value.Length;
			}
		}

		private int length;
		public int Length
		{
			get { return length; }
			set
			{
				this.length = value;
				//this.GeneratePassword();
				this.NotifyPropertyChanged();
			}
		}

		private bool smallLetters;
		public bool SmallLetters
		{
			get { return smallLetters; }
			set 
			{ 
				smallLetters = value;
				NotifyPropertyChanged();
			}
		}

		private bool capitalLetters;
		public bool CapitalLetters
		{
			get { return capitalLetters; }
			set
			{
				capitalLetters = value;
				NotifyPropertyChanged();
			}
		}

		private bool digits;
		public bool Digits
		{
			get { return digits; }
			set
			{
				digits = value;
				NotifyPropertyChanged();
			}
		}

		private bool specialChars;
		public bool SpecialChars
		{
			get { return specialChars; }
			set
			{
				specialChars = value;
				NotifyPropertyChanged();
			}
		}

		public void Generate()
		{
			// Initialize temporary variables
			Random rand = new Random();
			StringBuilder tempString = new StringBuilder();
			List<Char> charactersList = new List<Char>();

			if (CapitalLetters == true) // [A - Z]
			{
				for (char c = 'A'; c <= 'Z'; c++)
					charactersList.Add(c);
			}

			if (SmallLetters == true) // [a - z]
			{
				for (char c = 'a'; c <= 'z'; c++)
					charactersList.Add(c);
			}

			if (Digits == true) // [0 - 9]
			{
				for (char c = '0'; c <= '9'; c++)
					charactersList.Add(c);
			}

			if (SpecialChars == true) // Special
			{
				charactersList.Add('-');
				charactersList.Add('_');
				charactersList.Add('!');
				charactersList.Add('$');
				charactersList.Add('%');
				charactersList.Add('&');
			}

			// Generate password
			for (uint i = 0; i < this.Length; i++)
			{
				tempString.Append(charactersList[rand.Next(charactersList.Count)]);
			}

			// Push generated password
			Content = tempString.ToString();

		}

		public void LoadOptions(GeneratorOption option)
		{
			this.Length = option.Length;
			this.SmallLetters = option.SmallLetters;
			this.CapitalLetters = option.SmallLetters;
			this.Digits = option.Digits;
			this.SpecialChars = option.SpecialChars;
			Generate();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}
