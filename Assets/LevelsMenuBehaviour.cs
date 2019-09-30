using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelsMenuBehaviour : MonoBehaviour
{
    const int numberOfLevels = 1;
    int[] bestCoins;
    int[] maxCoins;
    int[] bestTreasures;
    int[] maxTreasures;
    public TextMeshPro[] text;
    // Start is called before the first frame update
    void Start()
    {
        bestCoins = new int[numberOfLevels];
        bestCoins = new int[numberOfLevels];
        for(int i = 0 ; i < bestCoins.Length; i++)
            text[i].text = bestCoins[i] + " / " + maxCoins[i] + "\n" + bestTreasures[i] + " / " + maxTreasures[i];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
