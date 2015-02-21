using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PacketViewer
{
    class InputValueBox
    {
        protected MainWindow MainWindow;

        public string Result;

        protected Window Window;
        protected TextBox TextBox;

        public InputValueBox(MainWindow mainWindow, string title, string label, string def = "")
        {
            MainWindow = mainWindow;

            Grid grid = new Grid
            {
                Margin = new Thickness(15),
            };

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Label textLabel = new Label
            {
                Content = label,
                Margin = new Thickness(0, 0, 15, 0)
            };
            textLabel.SetValue(Grid.ColumnProperty, 0);
            textLabel.SetValue(Grid.RowProperty, 0);

            grid.Children.Add(textLabel);

            TextBox = new TextBox
            {
                Text = def,
                Width = 160,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
            };
            TextBox.SetValue(Grid.ColumnProperty, 1);
            TextBox.SetValue(Grid.RowProperty, 0);

            grid.Children.Add(TextBox);

            Button cancelButton = new Button
            {
                Width = 80,
                Height = 26,
                Margin = new Thickness(0, 15, 0, 0),
                Content = "Cancel",
                HorizontalAlignment = HorizontalAlignment.Right
            };
            cancelButton.SetValue(Grid.ColumnProperty, 1);
            cancelButton.SetValue(Grid.RowProperty, 1);

            cancelButton.Click += Cancel;
            grid.Children.Add(cancelButton);

            Button okButton = new Button
            {
                Width = 60,
                Height = 26,
                Margin = new Thickness(0, 15, 90, 0),
                Content = "Ok",
                HorizontalAlignment = HorizontalAlignment.Right
            };
            okButton.SetValue(Grid.ColumnProperty, 1);
            okButton.SetValue(Grid.RowProperty, 1);

            okButton.Click += Ok;
            grid.Children.Add(okButton);

            Window = new Window
            {
                Title = title,
                Left = mainWindow.Left + Mouse.GetPosition(mainWindow).X,
                Top = mainWindow.Top + Mouse.GetPosition(mainWindow).Y,
                SizeToContent = SizeToContent.WidthAndHeight,
                Content = grid,
                ResizeMode = ResizeMode.NoResize,
            };
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            Result = TextBox.Text;
            Window.Close();
        }

        public bool Show()
        {
            Result = null;
            Window.ShowDialog();
            return Result != null;
        }
    }
}
