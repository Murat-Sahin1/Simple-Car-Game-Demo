using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text EnergyText;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady"; //DateTime when our energy is regenereted (We'll convert it)


    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0).ToString();

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if(energy == 0)
        {
            string energyReadyTime = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if(energyReadyTime == string.Empty) { return;}

            DateTime energyReady = DateTime.Parse(energyReadyTime);

            if(DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        EnergyText.text = $"Play ({energy})";
    }

    public void Play()
    {
        if(energy < 1)
        {
            GetComponent<Button>().interactable = false;
            EnergyText.text = $"No Energy! ({energy})";
            return;
        }

        energy--;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy == 0)
        {
            DateTime whenEnergyWillBeRestored = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, whenEnergyWillBeRestored.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(whenEnergyWillBeRestored);
#endif
        }
        SceneManager.LoadScene(1);
    }
}
