using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Hazard : MonoBehaviour
{
    public GameObject destructedObject;

    public enum obstacles { AllHigh, AllHighMedium, AllUnder, BigCenter, BigNormalCenter, HyperSpeedCube, NormalCenter,
    ObstacleLLeft, ObstacleLRight, ObstacleT };
    public obstacles obstacle;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Player.instance.isInvulnerable)
        return;

        if (other.CompareTag("Player"))
        {
            if (Player.instance.isShieldActive)
            {
                return;
            }
            else if (SpeedValue.instance.isOnHyperSpeed == true)
            {
                HyperImpact();
            }
            else
            {
                AnalyticsResult analyticsResult = Analytics.CustomEvent(
                    "LevelLose",
                    new Dictionary<string, object>
                    {
                        {"Level: ", PlayerPrefs.GetInt("levelAt") },
                        {"Hazard: ", obstacle },
                        {"Speed: ", SpeedValue.instance.speed },
                        {"Time: ", Mathf.RoundToInt(GameManager.instance.timer)}
                    }                    
                    );
                Debug.Log("Time: " + Mathf.RoundToInt(GameManager.instance.timer));
                Debug.Log("Analytic result: " + analyticsResult);
                GameCanvas.instance.LoseMenu();
            }
            
        }
        if (other.CompareTag("Shield"))
        {
            // Voltar aqui que isto é má logica
            Shield.instance.ExpandShield();
            Destroy(gameObject);           
        }
    }

    private void HyperImpact()
    {
        Instantiate(destructedObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
