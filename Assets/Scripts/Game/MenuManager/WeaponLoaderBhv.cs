using Game.Events;
using Game.ExperimentControllers;
using Game.LevelSelection;
using Game.NarrativeGenerator;
using MyBox;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

namespace Game.MenuManager {
    public class WeaponLoaderBhv : MonoBehaviour, IMenuPanel {
        [SerializeField] private GameObject previousPanel;
        [SerializeField] private Button button;
        [SerializeField] private SceneReference levelToLoad;
        [SerializeField] private GeneratorSettings settings;
        [field: SerializeField] public SelectedLevels Selected { get; set; }

        [field: SerializeField] public ProjectileTypeSO chosenProjectile { get; set; } // A referência ao SO da arma
        [SerializeField] private ProjectileTypeSO defaultProjectile; // A referência ao SO da arma padrão

        private bool isProjectileChosen;
        private bool isQuestGenerated;

        protected void OnEnable() {
            // Carregar a arma padrão automaticamente
            LoadDefaultWeapon();

            // Iniciar o processo de geração de quest
            QuestGeneratorManager.QuestLineCreatedEventHandler += EnableNextButton;
        }

        protected void OnDisable() {
            QuestGeneratorManager.QuestLineCreatedEventHandler -= EnableNextButton;
        }

        private void LoadDefaultWeapon() {
            if (defaultProjectile != null) {
                // Aqui estamos carregando a arma padrão, a partir do SO configurado no Inspector
                Debug.Log("Carregando arma padrão");

                // Copiar os dados da arma padrão para o 'chosenProjectile'
                chosenProjectile.Copy(defaultProjectile);
                isProjectileChosen = true;
            }
            else {
                Debug.LogError("Default projectile not assigned!");
            }

            //Após carregar a arma, se a quest já foi gerada, habilite o botão
           // if (isQuestGenerated) {
            button.interactable = false;
           // }
        }

        private void EnableNextButton(object sender, QuestLineCreatedEventArgs args) {
            Debug.Log("Conteúdo criado e botão habilitado");
            isQuestGenerated = true;

            if (isQuestGenerated = true & isProjectileChosen) {
                GoToNext();
            }
        }

        public void GoToNext() {
            if (Selected.selectedIndex == -1) {
                Selected.SelectLevel(null);
            }

            switch (settings.GameType) {
                case Enums.GameType.Platformer:
                    SceneManager.LoadScene("Dungeon");
                    break;
                case Enums.GameType.TopDown:
                    SceneManager.LoadScene("LevelWithEnemies");
                    break;
            }
            //SceneManager.LoadScene(levelToLoad.SceneName);
            gameObject.SetActive(false);
        }

        public void GoToPrevious() {
            previousPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
