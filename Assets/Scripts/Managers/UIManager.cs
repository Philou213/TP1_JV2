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
    [SerializeField] TextMeshProUGUI victoryText;

    public void UpdateLivesText(int lives)
    {
        if (lives <= 0)
        {
            ShowGameOverText();
        } 
        else 
        { 
            livesText.SetText(lives.ToString()); 
        }
    }

    public void UpdateMultishootText(int multishootTime)
    {
        multishootText.SetText(multishootTime.ToString());
    }

    public void UpdateMissileText(int nbMissiles)
    {
        missilesText.SetText(nbMissiles.ToString());
    }

    public void ShowGameOverText()
    {
        HideHud();
        gameoverText.transform.parent.gameObject.SetActive(true);
    }

    public void ShowVictoryText()
    {
        HideHud();
        victoryText.transform.parent.gameObject.SetActive(true);
    }

    private void HideHud()
    {
        livesText.transform.parent.gameObject.SetActive(false);
        multishootText.transform.parent.gameObject.SetActive(false);
        missilesText.transform.parent.gameObject.SetActive(false);
    }
}
