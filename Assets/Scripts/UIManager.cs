using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI multishootText;
    [SerializeField] TextMeshProUGUI missilesText;
    [SerializeField] TextMeshProUGUI gameoverText;

    public void UpdateLivesText(int lives)
    {
        livesText.SetText(lives.ToString());
    }

    public void UpdateMultishootText(int multishootTime)
    {
        if (multishootTime > 0) 
        {
            multishootText.transform.parent.gameObject.SetActive(true);
            multishootText.SetText(multishootTime.ToString());
        }
        else
        {
            multishootText.transform.parent.gameObject.SetActive(false);
        }

    }

    public void UpdateMissileText(int nbMissiles)
    {
        if (nbMissiles > 0)
        {
            missilesText.transform.parent.gameObject.SetActive(true);
            missilesText.SetText(nbMissiles.ToString());
        }
        else
        {
            missilesText.transform.parent.gameObject.SetActive(false);
        }
    }

    public void ShowGameOverText()
    {
        gameoverText.gameObject.SetActive(true);
    }
}
