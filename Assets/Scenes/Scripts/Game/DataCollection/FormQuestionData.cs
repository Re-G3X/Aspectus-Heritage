using UnityEngine;

namespace Game.DataCollection
{
    [CreateAssetMenu]
    public class FormQuestionData : ScriptableObject
    {
        [TextArea]
        public string question;
        public string[] answers = new string[5];
    }
}
