using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SaveQuits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.quitting += QuitLevel;
    }


    private void QuitLevel()
    {
        //Analytics.CustomEvent("GameQuit" + PlayerPrefs.GetInt("levelAt"));

        AnalyticsResult analyticsResult = Analytics.CustomEvent(
                    "GameQuit",
                    new Dictionary<string, object>
                    {
                        {"Level: ", PlayerPrefs.GetInt("levelAt") + 1 }
                    }
                    );

    }
}
