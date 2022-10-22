﻿using System;
using Dalamud.Configuration;

namespace FakeName;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public bool Enabled { get; set; } = false;

    public string FakeNameText { get; set; } = "";

    internal void SaveConfig()
    {
        Service.Interface.SavePluginConfig(this);
    }
}