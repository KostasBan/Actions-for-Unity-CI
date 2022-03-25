using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Data;

namespace Assets.Scripts.Visualizers
{
    public class VersionVisualizer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ConfigSettings settings = new ConfigSettings("1.0.0");
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = settings.Version;
        }

    }
}