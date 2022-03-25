using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts.Data;

public class SimpleTest
{
    private ConfigSettings _settings;
    // A Test behaves as an ordinary method
    [Test]
    public void SimpleTestSimplePasses()
    {
        string vesrion = "1.0.0";
        _settings = new ConfigSettings(vesrion);
        Assert.AreEqual(vesrion, _settings.Version);
    }

}
