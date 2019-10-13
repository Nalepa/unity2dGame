using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButtonBehaviour : MonoBehaviour
{
    int bestCoins, bestTreasures;
    public int maxCoins, maxTreasures, lvlNumber;
    public TextMeshProUGUI levelName, bestScores;
    // Start is called before the first frame update
    void Start()
    {
        bestCoins = PlayerPrefs.GetInt("lvl" + lvlNumber + "BestCoins");
        bestTreasures = PlayerPrefs.GetInt("lvl" + lvlNumber + "BestTreasures");
        levelName.text = "Level " + lvlNumber;
        bestScores.text = "Coins: " + bestCoins + " / " + maxCoins + "\nTreasures: " + bestTreasures + " / " + maxTreasures;
    }
    public void LoadScene() => SceneManager.LoadScene(lvlNumber);
}
