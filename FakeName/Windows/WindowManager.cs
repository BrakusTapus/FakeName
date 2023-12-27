using Dalamud.Interface.Windowing;
using System;

namespace FakeName.Windows;

internal class WindowManager : IDisposable
{
    internal readonly WindowSystem WindowSystem = new("FakeName");
    internal ConfigWindow ConfigWindow { get; }

    public WindowManager()
    {
        ConfigWindow = new ConfigWindow();
        WindowSystem.AddWindow(ConfigWindow);

        Service.Interface.UiBuilder.Draw += DrawUi;
        Service.Interface.UiBuilder.OpenConfigUi += ToggleConfigWindow;
    }

    public void Dispose()
    {
        Service.Interface.UiBuilder.Draw -= DrawUi;
        Service.Interface.UiBuilder.OpenConfigUi -= ConfigWindow.Open;
        WindowSystem.RemoveAllWindows();
    }

    private void DrawUi()
    {
        WindowSystem.Draw();
    }

    public void ToggleConfigWindow()
    {
        ConfigWindow.IsOpen = !ConfigWindow.IsOpen;
    }

}
