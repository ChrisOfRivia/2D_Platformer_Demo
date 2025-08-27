using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas deathScreen;
    [SerializeField] private CoinPouch coin;  // Reference to CoinPouch script
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        if (deathScreen != null)
        {
            deathScreen.enabled = false;
        }
    }

    private void Update()
    {
        // Update the coin text UI
        coinText.text = coin.coins.ToString();
    }

    public void RetryLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
