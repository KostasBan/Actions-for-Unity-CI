using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.RemoteConfig;
using System.Threading.Tasks;

public class RemoteConfigManager : MonoBehaviour
{
    public TMP_Text _environmentVisualizer = null;
    public struct userAttributes
    {
    }

    public struct appAttributes
    {
        public string appVersion;
    }

    // Start is called before the first frame update
    void Awake()
    {
        // Add a listener to apply settings when successfully retrieved:
        ConfigManager.FetchCompleted += ApplyRemoteSettings;

        TextAsset text = (TextAsset)Resources.Load("environment", typeof(TextAsset));
        EnvironmentId environment = (EnvironmentId)JsonUtility.FromJson<EnvironmentId>(text.text);

        // Set the environment ID:
        ConfigManager.SetEnvironmentID(environment.id);

        // Fetch configuration settings from the remote service:
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        switch (configResponse.requestOrigin)
        {
            case ConfigOrigin.Default:
                Debug.Log("No settings loaded this session; using default values.");
                break;
            case ConfigOrigin.Cached:
                Debug.Log("No settings loaded this session; using cached values from a previous session.");
                break;
            case ConfigOrigin.Remote:
                Debug.Log("New settings loaded this session; update values accordingly.");
                _environmentVisualizer.text = ConfigManager.appConfig.GetString("Environment");
                break;
        }
    }
}

