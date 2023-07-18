using App1.Interface;
using App1.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    internal class MainWindowViewModel
    {
        IApp1Service _app1Service;

        public MainWindowViewModel(IApp1Service app1Service)
        {
            _app1Service = app1Service;
        }

        internal void OnInit(Action<int, string, IReadOnlyList<string>, int, Action<int, int>> addSettingItem)
        {
            // モデルから、設定項目にどういう項目があるかを読み込む
            var funcList = _app1Service.GetFuctions();

            // 設定項目を画面に入れる(アプリ起動時に全部0orOFFにする仕様)
            funcList.Select((Value, index) => (Value, index)).ToList().ForEach(x =>
            {
                var functionID = x.index;
                var functionName = x.Value.FuncName;
                var valueList = x.Value.ValueNames.Select(x => x).ToArray();

                // 設定項目を画面にセット
                addSettingItem(functionID, functionName, valueList, 0, SelectionChanged);

                // 初期値は固定でindex=0
                _app1Service.SetValue(functionID, 0);
            });
        }

        internal void SelectionChanged(int funcID, int valueID)
        {
            _app1Service.SetValue(funcID, valueID);
        }
    }
}
