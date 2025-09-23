using TMPro;
using UnityEngine.UI;
using UnityEngine;
using CoinClash.Core;




namespace CoinClash.UI
{
    ///<summary>
    /// UIManager gestiona la interfaz principal del juego.
    /// Escucha cambios de monedas y actualiza el texto.
    ///<summary>
    public class CounterManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TMP_Text coinsText;
        [SerializeField] private Button addCoinButton;

        private void Awake()
        {
            if (coinsText == null)
                UnityEngine.Debug.LogError("UIManager: No se asignó el TMP_Text de monedas en el inspector.");
            if (addCoinButton == null)
                UnityEngine.Debug.LogError("UIManager: No se asignó el Button de monedas en el inspector.");
        }

        private void OnEnable()
        {
            // Suscribirse al evento del CoinManager
            if (CoinManager.Instance != null)
                CoinManager.Instance.OnCoinsChanged += UpdateCoinsUI;

            // Suscribirse al botón de prueba
            addCoinButton?.onClick.AddListener(() => CoinManager.Instance.AddCoins(10));
        }

        private void OnDisable()
        {
            // Desuscubrirse para evitar fugas de memoria.
            if (CoinManager.Instance != null)
                CoinManager.Instance.OnCoinsChanged -= UpdateCoinsUI;

            addCoinButton?.onClick.RemoveAllListeners();

        }

        ///<summary>
        /// Actualiza el texto de monedas en la UI.
        /// </summary>
        private void UpdateCoinsUI(int newCoinsValue)
        {
            coinsText.text = $"Monedas: {newCoinsValue}"; 
        }
   
    }

}