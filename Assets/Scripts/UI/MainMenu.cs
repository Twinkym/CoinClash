using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoinClash.UI
{
    ///<summary>
    /// MainMenu gestiona la interfaz del menú principal.
    ///</summary>
    
    public class MainMenu : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private AudioSource backgroundMusic;

        public void PlayGame()
        {
            SceneManager.LoadScene("GamePlay");
        }

        public void OpenSettings()
        {
            Debug.Log("Abrir configuración");
            SceneManager.LoadScene("Settings");
        }
        public void OpenCredits()
        {
            Debug.Log("Abrir créditos");
            SceneManager.LoadScene("Credits");
        }

        public void QuitGame()
        {
            Debug.Log("Salir del juego");
            Application.Quit();
        }
        public void ToggleMusic()
        {
            if (backgroundMusic != null)
            {
                Debug.LogWarning("MainMenu: No se asignó el AudioSource de música de fondo en el inspector.");
                return;
            }
            backgroundMusic.mute = !backgroundMusic.mute;            
        }
        
    }
}
