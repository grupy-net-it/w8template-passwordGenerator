using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EpicPasswordGenerator
{
	using EpicPasswordGenerator.Common;
	using EpicPasswordGenerator.Data;
	using Windows.UI.Popups;

	/// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : LayoutAwarePage
    {
		public MainPage Instance { get; private set; }

	    public MainPage()
	    {
	        this.InitializeComponent();
	        var context = new MainDataContext
                {
                    AppName = "Epic Password Generator",
                    Password = { Length = 10, SmallLetters = true, CapitalLetters = true, Digits = true }
                };

	        context.Password.Generate();
	        this.DataContext = context;

	        if (Instance == null)
	        {
	            Instance = this;
	        }
	    }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

		async private void GenerateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				(DataContext as MainDataContext).Password.Generate();
			}
			catch (ArgumentOutOfRangeException)
			{
				var dialog = new MessageDialog("You must select at least one checkbox.");
				dialog.ShowAsync();
			}
		}

		private void GridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			Password.Instance.LoadOptions(e.ClickedItem as GeneratorOption);
		}
    }
}
