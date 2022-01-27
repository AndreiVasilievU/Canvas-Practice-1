using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(TestInside);
    }

    public void Test()
    {
        print("Button CLICK!!!!");
    }

    private void TestInside()
    {
        print("Button CLICK INSIDE!!!!");
        button.onClick.RemoveAllListeners();
    }
}
