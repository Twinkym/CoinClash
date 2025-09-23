using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoinClash.Core
{
    ///<summary>
    /// GameManager gestiona el estado general del juego.
    /// - Singleton.
    /// - Persistencia entre escenas.
    /// - Reinicio del juego.
    ///</summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            // Implementar patrón Singleton
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        /// <summary>
        /// Reinicia el juego recargando la escena actual.
        /// </summary>
        public void RestartGame()
        {
            // Resetea monedas.
            CoinManager.Instance?.Reset();

            // Recarga la escena actual.
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        /// <summary>
        /// Carga la escena indicada por nombre.
        /// </summary>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
