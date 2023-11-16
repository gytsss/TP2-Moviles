using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPlugin : MonoBehaviour
{
    private const string packageName = "com.godoy.mylibrary";
    const string className = packageName + ".GodoyLogger";


    class AlertViewCallBack : AndroidJavaProxy
    {
        private System.Action<int> alertHandler;

        public AlertViewCallBack(System.Action<int> alertHandlerIn) : base(className + "$AlertViewCallBack")
        {
            alertHandler = alertHandlerIn;
        }

        public void onButtonTapped(int index)
        {
            Debug.Log("Button tapped: " + index);
            if (alertHandler != null)
                alertHandler(index);
        }
    }

    AndroidJavaClass _pluginClass;
    AndroidJavaObject _pluginInstance;

    [SerializeField] private TextMeshProUGUI label;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _pluginClass = new AndroidJavaClass(className);

            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            _pluginClass.SetStatic<AndroidJavaObject>("mainActivity", activity);

            _pluginInstance = _pluginClass.CallStatic<AndroidJavaObject>("getInstance");
        }
    }

    public void RunPlugin()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string text = "UnityLog";

            _pluginInstance.Call("logFromUnity", text);

            Debug.Log(text);
        }
    }

    void showAlertDialog(string[] strings, System.Action<int> handler = null)
    {
        if (strings.Length < 3)
        {
            Debug.LogError("AlertView requieres at least 3 strings");
            return;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            _pluginInstance.Call("showAlertView", new object[] { strings, new AlertViewCallBack(handler) });

        }
        else
            Debug.Log("AlertView not supported on this platform");
    }

    public void ShowAlert()
    {
        Debug.Log("ShowAlert()");
        if (Application.platform == RuntimePlatform.Android)
        {
            showAlertDialog(new string[] { "Delete File", "Are you sure you want to delete the file?", "Cancel", "OK" },
                (int obj) => { Debug.Log("Local Handler called: " + obj); });
        }
    }

    public void ReadLogs()
    {
        label.text = "Read";
        if (Application.platform == RuntimePlatform.Android)
        {
            label.text = _pluginInstance.Call<string>("ReadFile");
            _pluginInstance.Call("debugLog", label.text);
        }
        Debug.Log("ReadFile");
    }

}
