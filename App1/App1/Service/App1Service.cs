using App1.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Service
{
    internal class App1Service : IApp1Service
    {
        // 10℃設定時の寒すぎるMsg表示
        // Viewに委譲する処理
        public Func<bool> DisplayColdTempMessage { get; set; }

        // デバイスコントロール用model
        private IAirconController _aircon;
        private ILightController _light;
        private ITvController _tv;

        public enum FuncIndex
        {
            RoomBrightness,
            RoomTemperature,
            TVChannel,
        }

        public enum RoomBrightnessSetting
        {
            Off,
            Usugurai,
            Normal,
            Bright,
        }

        public enum RoomTemperatureSetting
        {
            Off,
            Temp10,
            Temp18,
            Temp20,
            Temp25,
            Temp27,
        }

        public enum TvChannel
        {
            Off,
            TvOsaka,
            SumTv,
            TvAsahi,
        }

        private List<(string FuncName, IReadOnlyList<string> ValueNames)> functions = new()
        {
            { ("お部屋の明るさ設定", new List<string>() { "OFF", "薄暗", "ふつう", "めっちゃあかるい" }) },
            { ("お部屋の温度設定", new List<string>() { "OFF", "10℃", "18℃", "20℃", "25℃", "27℃" }) },
            { ("テレビのチャンネル", new List<string>() { "消す", "テレビ大阪", "サンテレビ", "朝日放送"}) },
        };

        public App1Service(IAirconController aircon, ILightController light, ITvController tv)
        {
            _aircon = aircon;
            _light = light;
            _tv = tv;
        }

        public async Task InitAsync()
        {
            await Task.Run(() =>
            {
                // お部屋の明るさをアプリ起動時の状態にする
                _light.Off();
                _light.SetBrightness(0);

                // お部屋の温度設定をアプリ起動時の状態にする
                _aircon.Off();
                _aircon.SetMode(Mode.Cooler);
                _aircon.SetTemperature(25);

                // テレビのチャンネルをアプリ起動時の状態にする
                _tv.Off();
                _tv.SetChannel(6);
            });
        }

        public IReadOnlyList<(string FuncName, IReadOnlyList<string> ValueNames)> GetFuctions()
        {
            return functions;
        }

        public void SetValue(int FuncID, int ValueID)
        {
            if (FuncID == (int)FuncIndex.RoomBrightness)
            {
                SetRoomBrightness((RoomBrightnessSetting)ValueID);
            }
            else if (FuncID == (int)FuncIndex.RoomTemperature)
            {
                SetRoomTemperature((RoomTemperatureSetting)ValueID);
            }
            else if (FuncID == (int)FuncIndex.TVChannel)
            {
                SetTvChannel((TvChannel)ValueID);
            }
        }

        private void SetRoomBrightness(RoomBrightnessSetting setting)
        {
            if (setting == RoomBrightnessSetting.Off)
            {
                _light.Off();
                _light.SetBrightness(0);
            }
            else if (setting == RoomBrightnessSetting.Usugurai)
            {
                _light.On();
                _light.SetBrightness(30);
            }
            else if (setting == RoomBrightnessSetting.Normal)
            {
                _light.On();
                _light.SetBrightness(70);
            }
            else if (setting == RoomBrightnessSetting.Bright)
            {
                _light.On();
                _light.SetBrightness(100);
            }
            else
            {
                throw new InvalidOperationException("RoomBrightness の設定値がおかしい");
            }
        }

        private void SetRoomTemperature(RoomTemperatureSetting setting)
        {
            if (setting == RoomTemperatureSetting.Off)
            {
                _aircon.Off();
                _aircon.SetTemperature(25);
            }
            else if (setting == RoomTemperatureSetting.Temp10)
            {
                var yesno = DisplayColdTempMessage.Invoke();

                if (yesno)
                {
                    _aircon.On();
                    _aircon.SetMode(Mode.Cooler);
                    _aircon.SetTemperature(10);
                }
            }
            else if (setting == RoomTemperatureSetting.Temp18)
            {
                _aircon.On();
                _aircon.SetMode(Mode.Cooler);
                _aircon.SetTemperature(18);
            }
            else if (setting == RoomTemperatureSetting.Temp20)
            {
                _aircon.On();
                _aircon.SetMode(Mode.Cooler);
                _aircon.SetTemperature(20);
            }
            else if (setting == RoomTemperatureSetting.Temp25)
            {
                _aircon.On();
                _aircon.SetMode(Mode.Heater);
                _aircon.SetTemperature(25);
            }
            else if (setting == RoomTemperatureSetting.Temp27)
            {
                _aircon.On();
                _aircon.SetMode(Mode.Heater);
                _aircon.SetTemperature(27);
            }
            else
            {
                throw new InvalidOperationException("RoomTemperatureSetting の設定値がおかしい");
            }
        }

        private void SetTvChannel(TvChannel setting)
        {
            if (setting == TvChannel.Off)
            {
                _tv.Off();
                _tv.SetChannel(19);//デフォルトはテレビ大阪
            }
            else if (setting == TvChannel.TvOsaka)
            {
                _tv.On();
                _tv.SetChannel(19);
            }
            else if (setting == TvChannel.SumTv)
            {
                _tv.On();
                _tv.SetChannel(36);
            }
            else if (setting == TvChannel.TvAsahi)
            {
                _tv.On();
                _tv.SetChannel(6);
            }
            else
            {
                throw new InvalidOperationException("TvChannel の設定値がおかしい");
            }
        }
    }
}
