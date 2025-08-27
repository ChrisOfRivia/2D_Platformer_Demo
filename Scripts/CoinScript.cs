using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private CoinPouch coin;  
    [SerializeField] private TextMeshProUGUI coinText; 

    private void Update()
    {
        coinText.text = coin.coins.ToString();
    }

}
