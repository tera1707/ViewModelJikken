using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using App1.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Windowing;

namespace App1
{
    public sealed partial class MainWindow : Window
    {
        MainWindowViewModel vm;

        public MainWindow()
        {
            this.InitializeComponent();

            vm = (MainWindowViewModel)GetViewModel();

            SetWindowSize(300, 300);
        }

        private void SetWindowSize(int width, int height)
        {
            // ウインドウサイズを小さく
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            var op = OverlappedPresenter.Create();
            appWindow.SetPresenter(op);
            appWindow.Resize(new Windows.Graphics.SizeInt32(width, height));
        }

        object GetViewModel()
        {
            return Ioc.Default.GetRequiredService<MainWindowViewModel>();
        }

        private void spSettings_Loaded(object sender, RoutedEventArgs e)
        {
            vm.OnInit(AddSettingItem);
        }

        private void AddSettingItem(int funcID, string funcName, IReadOnlyList<string> values, int selectedIndex, Action<int, int> selectioinChanged)
        {
            var combo = new ComboBox() { Header = funcName, ItemsSource = values, SelectedIndex = selectedIndex, Margin = new Thickness(10), Tag = funcID };
            combo.SelectionChanged += (s,e) =>
            {
                if (s is ComboBox cb)
                {
                    selectioinChanged((int)cb.Tag, cb.SelectedIndex);
                }
            };

            // stackPanelに、設定のコンボボックスを追加
            spSettings.Children.Add(combo);
        }
    }
}
