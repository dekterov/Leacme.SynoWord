// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Leacme.Lib.SynoWord;

namespace Leacme.App.SynoWord {

	public class AppUI {

		private StackPanel rootPan = (StackPanel)Application.Current.MainWindow.Content;
		private Library lib = new Library();

		public AppUI() {

			var blurb1 = App.TextBlock;
			blurb1.HorizontalAlignment = HorizontalAlignment.Center;
			blurb1.Text = "Enter a term to retrieve its definition:";

			var termEl = App.HorizontalFieldWithButton;
			termEl.holder.HorizontalAlignment = HorizontalAlignment.Center;
			termEl.label.Text = "Term: ";
			termEl.field.Width = 400;
			termEl.button.Content = "Search";

			var defBx = App.TextBox;

			defBx.AcceptsReturn = true;
			defBx.TextWrapping = TextWrapping.Wrap;

			defBx.IsReadOnly = true;
			defBx.Width = 900;
			defBx.Height = 400;

			termEl.button.Click += async (z, zz) => {
				if (!string.IsNullOrWhiteSpace(termEl.field.Text)) {
					((App)Application.Current).LoadingBar.IsIndeterminate = true;
					var tmpRps = await lib.GetSearchTermResponceAsync(termEl.field.Text);
					if (tmpRps.Query.Pages.First().Key != "-1") {
						defBx.Text = tmpRps.Query.Pages.First().Value.Extract;
					} else {
						defBx.Text = "No results.";
					}
					((App)Application.Current).LoadingBar.IsIndeterminate = false;
				}
			};

			rootPan.Children.AddRange(new List<IControl> { blurb1, termEl.holder, defBx });

		}
	}
}