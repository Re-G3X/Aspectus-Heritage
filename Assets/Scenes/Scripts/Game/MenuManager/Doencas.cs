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
        int randomValue = Random.Range(1, 12);

        if (randomValue == 1) {//Glaucoma
            TextDialogue.text = "O glaucoma é uma descrição genérica para um grupo de doenças que afetam a visão ao causar danos no nervo óptico," +
                " um nervo logo atrás do olho. Ela age de maneira progressiva, geralmente começando pela perda do campo visual periférico. Isso significa que " +
                "a pessoa pode não notar a redução da visão inicialmente, pois a visão central, usada para atividades como leitura, permanece intacta nos estágios iniciais.";         
        }
        if (randomValue == 2) {//degeneração macular
            TextDialogue.text = "A degeneração macular relacionada à idade (DMRI) é uma doença ocular que afeta a mácula, a parte central da retina responsável pela visão detalhada e central.";
        }
        if(randomValue == 3) {//Glaucoma 
            TextDialogue.text = "Existem alguns tipos de glaucoma, como o de ângulo aberto, ângulo fechado e tensão normal. Não se sabe ao certo a causa da doença, mas a suspeita mais comum "+
                "é o acúmulo de pressão ocular, resultando nos danos ao nervo óptico.";
        }
        if (randomValue == 4) {//degenração macular
            TextDialogue.text = "A degeneração macular pode ser detectado através do exame do olho dilatado. Atualmente, não há como curar a DRMI, apenas "+
                "tratamentos para retardar o progresso. Existem os métodos de prevenção, sendo eles, não fumar, exercícios regulares, manter níveis de pressão de sangue e colesterol regulares" +
                ",se alimentar de maneira saudável, incluindo verduras e peixe";
        }
        if (randomValue == 5) {//catarata
            TextDialogue.text = "Os sintomas da catarata podem incluir: visão embaçada ou turva, cores desbotadas, dificuldade em enxergar no escuro ou fontes ou de luz muito fortes, entre outros.";
        }
        if (randomValue == 6) {//catarata
            TextDialogue.text = "A catarata pode ser causada por uma gama de possibilidades,incluindo: histórico familiar com a doença, problemas " +
                "de saúde como diabetes, ferimentos na área ocular, uso de esteroides, fumar e expor os olhos por muito tempo no sol.";
        }
        if (randomValue == 7) {//daltonismo 
            TextDialogue.text = "O daltonismo é uma condição genética que afeta a percepção das cores, tornando difícil distinguir certas tonalidades. Essa " +
                "condição ocorre devido a alterações nos cones da retina, responsáveis pela percepção das cores. Embora o daltonismo não tenha cura, ele geralmente não" +
                " afeta a visão geral nem causa outros problemas oculares. Existem ferramentas, como óculos ou aplicativos, que podem ajudar" +
                " a melhorar a percepção das cores em alguns casos.";
        }
        if (randomValue == 8) {//daltonismo Protanopia
            TextDialogue.text = "O daltanoismo protanopia é causado por uma deficiência em um dos cones, especificamente no que é chamado " +
                "de cone L, que é responsável por capturar os comprimentos de onda longos.  ";
        }
        if (randomValue == 9) {//daltonismo Deuteranopia
            TextDialogue.text = "O daltonismo deuteranopia é causado por uma deficiências nas células chamadas de cone M, responsável por recolher " +
                "as informações dos comprimentos de onda médios.";
        }
        if (randomValue == 10) {
            TextDialogue.text = "\r\nO Daltonismo Tritanopia é uma forma rara de daltonismo, em que a pessoa tem dificuldade " +
                "em perceber as cores azul e amarela, sendo incapaz de distinguir entre essas tonalidades. Esse tipo de deficiência é causado por uma falha nos cones sensíveis à luz azul na retina.";
        }
        if (randomValue == 11) {
            TextDialogue.text = "A Acromatopsia é uma condição rara em que a pessoa não consegue perceber nenhuma cor, vendo o mundo" +
                " em tons de cinza. Isso ocorre devido à falta de células cones funcionais na retina, responsáveis pela percepção das cores.";
        }

    }


}
