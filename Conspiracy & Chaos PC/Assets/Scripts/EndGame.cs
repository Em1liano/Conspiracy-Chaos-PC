using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        AnalyticsResult result = Analytics.CustomEvent("Przejście gry");


        yield return new WaitForSeconds(5f);
        Analytics.FlushEvents();
        Application.Quit();
    }
}
