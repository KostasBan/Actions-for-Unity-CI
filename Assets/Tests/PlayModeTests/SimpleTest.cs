using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Visualizers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SimpleTest
{
    public static string _scene = "SampleScene";

    private VersionVisualizer _versionText;
    private bool _sceneLoaded;

    [OneTimeSetUp]
    public void SetUp()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(_scene, LoadSceneMode.Additive);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _sceneLoaded = true;
        _versionText = GameObject.FindObjectOfType<VersionVisualizer>();
    }

    [UnityTest, Order(0)]
    public IEnumerator TestMonoIsntNull()
    {
        yield return new WaitWhile(() => _sceneLoaded == false);
        Assert.That(_versionText, Is.Not.Null);
    }

}
