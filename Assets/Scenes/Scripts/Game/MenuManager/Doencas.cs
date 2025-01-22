using Game.Events;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class Doencas : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI TextDialogue;
    void Start()
    {
        TextDialogue = GetComponent<TextMeshProUGUI>();
        int randomValue = Random.Range(1, 3);

        if (randomValue == 1) {//Glaucoma
            TextDialogue.text = "O glaucoma é uma descrição genérica para um grupo de doenças que afetam a visão ao causar danos no nervo óptico," +
                " um nervo logo atrás do olho. Ela age de maneira progressiva, geralmente começando pela perda do campo visual periférico. Isso significa que " +
                "a pessoa pode não notar a redução da visão inicialmente, pois a visão central, usada para atividades como leitura, permanece intacta nos estágios iniciais.";         
        }
        if (randomValue == 2) {//Glaucoma
            TextDialogue.text = "A degeneração macular relacionada à idade (DMRI) é uma doença ocular que afeta a mácula, a parte central da retina responsável pela visão detalhada e central.";
        }
    }


}
