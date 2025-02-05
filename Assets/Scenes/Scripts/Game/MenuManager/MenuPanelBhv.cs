using MyBox;
using UnityEngine;
using UnityEngine.SceneManagement;  // Para carregar cenas

namespace Game.MenuManager {
    public class MenuPanelBhv : MonoBehaviour, IMenuPanel {
        [SerializeField] private SceneReference sceneToLoad;  // Nome da cena a ser carregada

        // Método para carregar a próxima cena
        public void GoToNext() {
            if (sceneToLoad != null && !string.IsNullOrEmpty(sceneToLoad.SceneName)) {
                // Carrega a cena especificada se for válida
                SceneManager.LoadScene(sceneToLoad.SceneName);
            }
            else {
                Debug.LogError("Cena não especificada ou SceneReference inválido.");
            }
        }

        // Método para carregar a cena anterior (ou qualquer outra lógica que desejar para cenas anteriores)
        public void GoToPrevious() {
            // Carregar uma cena anterior ou lógica adicional
            // Exemplo de carga de uma cena anterior
            SceneManager.LoadScene("CenaAnterior");
        }
    }
}
