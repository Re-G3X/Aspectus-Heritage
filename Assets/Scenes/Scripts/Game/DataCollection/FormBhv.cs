using System.Collections.Generic;
using Game.Events;
using UnityEditor;
using UnityEngine;

namespace Game.DataCollection
{
    public class FormBhv : MonoBehaviour
    {

        public FormQuestionsData questionsData;
        public GameObject questionPrefab;
        public RectTransform questionsPanel;
        public RectTransform submitButton;
        public float extraQuestionsPanelHeight = 100;
        private List<FormQuestionBhv> questions = new List<FormQuestionBhv>();
        public int formID; //0 for pretest, 1 for posttest

        public static event FormAnsweredEvent PreTestFormQuestionAnsweredEventHandler;
        public static event FormAnsweredEvent PostTestFormQuestionAnsweredEventHandler;

        // Use this for initialization
        void Start()
        {
            foreach (FormQuestionData q in questionsData.questions)
            {
                GameObject g = Instantiate(questionPrefab);
                g.GetComponent<FormQuestionBhv>().LoadData(q);
                g.transform.SetParent(questionsPanel);
                questions.Add(g.GetComponent<FormQuestionBhv>());
            }
            float panelHeight = questionsData.questions.Count
                                * questionPrefab.GetComponent<RectTransform>().rect.height;
            panelHeight += extraQuestionsPanelHeight;
            questionsPanel.sizeDelta = new Vector2(0.0f, panelHeight);
            submitButton.SetAsLastSibling();
        }

        public void Submit() {
        #if UNITY_EDITOR
                    AssetDatabase.SaveAssetIfDirty(questionsData);
        #endif

            // Lista de respostas como strings
            List<string> answers = new List<string>();

            foreach (FormQuestionBhv q in questions) {
                // Aqui, pegamos a primeira resposta
                answers.Add(q.questionData.answers[0]);  // Pegando a primeira resposta como string

                q.ResetToggles();
            }

            // Convertendo List<string> para List<int>, se necessário
            List<int> intAnswers = new List<int>();
            foreach (var answer in answers) {
                int parsedAnswer;
                // Tenta converter a string para inteiro, se não conseguir, usa -1 ou algum valor padrão
                if (int.TryParse(answer, out parsedAnswer)) {
                    intAnswers.Add(parsedAnswer);
                }
                else {
                    intAnswers.Add(-1);  // Adiciona -1 caso não seja possível converter
                }
            }

            // Invocando o evento com List<int> convertido
            if (formID == 1) {
                PostTestFormQuestionAnsweredEventHandler?.Invoke(null, new FormAnsweredEventArgs(formID, intAnswers));
            }
            else {
                PreTestFormQuestionAnsweredEventHandler?.Invoke(this, new FormAnsweredEventArgs(formID, intAnswers));
            }
        }

    }
}
