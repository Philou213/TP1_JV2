using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI multishootText;
    [SerializeField] TextMeshProUGUI missilesText;
    //[SerializeField] TextMeshProUGUI gameoverText;

    public void UpdateLivesText(int lives)
    {
        livesText.SetText(lives.ToString());
    }

    public void UpdateMultishootText(int multishootTime)
    {
        multishootText.SetText(multishootTime.ToString());
    }

    public void UpdateMissileText(int nbMissiles)
    {
        missilesText.SetText(nbMissiles.ToString());
    }
}
