using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Data
{
    public class ConfigSettings
    {
        private string _version;

        public ConfigSettings(string version)
        {
            _version = version;
        }

        public string Version => _version;
    }
}