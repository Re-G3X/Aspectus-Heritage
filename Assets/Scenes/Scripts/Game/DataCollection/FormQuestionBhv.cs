using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.DataCollection {
    public class FormQuestionBhv : MonoBehaviour {
        public Toggle[] toggles;          // Array de toggles
        public Text questionText;         // Texto da pergunta
        public Text descriptionText;      // Texto da descrição

        public FormQuestionData questionData; // Dados da questão

        void Awake() {
            // Obtendo todos os toggles filhos do GameObject
            toggles = GetComponentsInChildren<Toggle>().ToArray<Toggle>();
        }

        // Use this for initialization
        void Start() {
            // Aqui estamos assumindo que questionData.answers tem 5 respostas
            // Atribuir cada valor da lista answers para cada Toggle
            UpdateToggleLabels();
        }

        // Método para atualizar os textos das labels dos toggles
        public void UpdateToggleLabels() {
            // Verifica se questionData tem pelo menos 5 respostas para preencher as labels dos 5 toggles
            if (questionData.answers.Length >= 5) {
                for (int i = 0; i < toggles.Length && i < questionData.answers.Length; i++) {
                    // Para cada toggle, vamos pegar o componente Text filho e atualizar o texto
                    Text labelText = toggles[i].GetComponentInChildren<Text>();

                    if (labelText != null) {
                        // Atribui a resposta da lista para a label do Toggle
                        labelText.text = questionData.answers[i];
                    }
                }
            }
        }

        public void ChangeValue(Toggle selected) {
            if (!selected.isOn) {
                // Quando o toggle não estiver ativado, limpa as respostas (ou define como "nenhuma resposta")
                questionData.answers = new string[5];  // Limpando as respostas (ou pode colocar um valor como "Nenhuma resposta")
            }
            else {
                // Desmarcando os outros toggles quando um é selecionado
                foreach (Toggle t in toggles) {
                    if (t != selected) {
                        t.isOn = false;
                    }
                }

                // A resposta agora é atribuída como a string do toggle selecionado
                string selectedAnswer = selected.GetComponentInChildren<Text>().text;

                // Aqui você precisa determinar qual posição da lista vai ser preenchida
                // Vamos colocar a resposta no primeiro espaço da lista (você pode ajustar conforme necessário)
                questionData.answers[0] = selectedAnswer;
            }
        }

        public void ResetToggles() {
            foreach (Toggle t in toggles) {
                t.isOn = false;
            }
        }

        public void LoadData(FormQuestionData q) {
            questionData = q;
            questionText.text = q.question;

            // Atualizar as labels dos toggles com as respostas
            UpdateToggleLabels();
        }
    }
}
