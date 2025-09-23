using System;
using UnityEngine;

namespace CoinClash.Core
{

    /// <summary>
    /// CoinManager se encarga de gestionar la cantidad de monedas del jugador.
    /// Implementa un patrón Singleton seguro y dispara eventos cuando el valor cambia.
    /// Cumple con principios SOLID para escalabilidad y testeabilidad.
    /// </summary>


    public class CoinManager : MonoBehaviour
    {

        // Instancia Singleton segura.
        public static CoinManager Instance { get; private set; }

        // Evento que notifica cambios en el número de monedas.
        public event Action<int> OnCoinsChanged;

        // Cantidad de monedas del jugador.
        private int _coins;

        /// <summary>
        /// Obtiene la cantidad actual de monedas.
        /// </summary>
        public int Coins => _coins;

        private void Awake()
        {
            // Garantizar Singleton.
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);

            // Inicialización (luego se podrá cargar desde archivo de guardado)
            _coins = 0;
        }

        /// <summary>
        /// Añade monedas al contador y dispara evento.
        /// </summary>
        public void AddCoins(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning("Se intentó añadir una cantidad de monedas no válida:" + amount + "La cantidad de monedas debe ser positiva.!");
                return;
            }

            _coins += amount;
            OnCoinsChanged?.Invoke(_coins);
        }

        /// <summary>
        /// Resta monedas al contador si hay saldo suficiente. true si la operación fue exitosa, false en caso contrario.
        /// </summary>
        public bool SpendCoins(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning("Se intentó restar una cantidad de monedas no válida: " + amount + ". La cantidad de monedas debe ser positiva.");
                return false;
            }
            if (_coins < amount)
            {
                return false;
            }

            _coins -= amount;
            OnCoinsChanged?.Invoke(_coins);
            return true;
        }

        /// <summary>
        /// Resetea el contador de monedas a cero. (por ejemplo, al reiniciar el juego)
        /// </summary>
        public void Reset()
        {
            _coins = 0;
            OnCoinsChanged?.Invoke(_coins);
        }
    }
}
