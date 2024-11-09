using SOHNE.Accessibility.Colorblindness;

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Codice.CM.WorkspaceServer.Tree.Changes;
using System.Collections;

public class PostProcessingController : MonoBehaviour {

    public Material material;

    public Text EffectName;
    public Text EffectDescription;

    void Start() {
        // Obter o componente de volume
        Volume volume = GetComponent<Volume>();


        int randomValue = Random.Range(1, 8);

        setShaderNull();

        if (randomValue == 1) {//Glaucoma
            setVignette();
            EffectName.text = "Glaucoma";
            EffectDescription.text = "Afetados gradativamente perdem visão periférica, enxergando através de um “túnel”. Pode causar perda total de visão. ";
            Debug.Log("Chamando Glaucoma");
        }
        if (randomValue == 2) {//Catarata
            EffectName.text = "Catarata";
            EffectDescription.text = "Afetados sentem certo nível de embaçamento na visão, sensibilidade à luz e dificuldade de enxerga à noite.";
            setBloom(volume);
            Debug.Log("Chamando catarata");
        }
        if (randomValue == 3) {//Degeneração Macular 
            setDegeneracaoMacular();
            EffectName.text = "Degeneração Macular";
            EffectDescription.text = "Afetados podem sentir um embaçamento/distorção da visão. Afeta principalmente pessoas mais velhas";
            Debug.Log("Chamando Degeneração macular");
        }
        if (randomValue == 4) {//Protanopia                
            Colorblindness.Instance.Change(1);
            EffectName.text = "Protanopia";
            EffectDescription.text = "Afetados têm dificuldade em perceber tons de vermelho, levando à confusão entre vermelho e verde.";
            Debug.Log("Chamando Protanopia");
        }
        if (randomValue == 5) {//Deuteranopia
            Colorblindness.Instance.Change(3);
            EffectName.text = "Deuteranopia";
            EffectDescription.text = "Afetados têm dificuldade em perceber tons de verde, levando à confusão entre verde e vermelho";
            Debug.Log("Chamando Deuteranopia");
        }
        if (randomValue == 6) {//Tritanopia
            Colorblindness.Instance.Change(5);
            EffectDescription.text = "Afetados têm dificuldade em distinguir entre azul e amarelo, podendo também afetar a percepção de tons de verde e roxo.";
            EffectName.text = "Tritanopia";
            Debug.Log("Chamando Tritanopia");
        }
        if (randomValue == 7) {//Acromatopsia
            Colorblindness.Instance.Change(7);
            EffectDescription.text = "Afetados têm dificuldade em perceber cores.";
            EffectName.text = "Acromatopsia";
            Debug.Log("Chamando Acromatopsia");
        }
        StartCoroutine(cleanText());
    }


    private void setVignette() {
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 0);
        material.SetFloat("_CutoffSize", 0.2f);
    }

    private void setDegeneracaoMacular() {
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 1);
        material.SetFloat("_CutoffSize", 0.1f);
    }

    private void setShaderNull() {
        material.SetInt("_IsEnabled", 0);
        material.SetInt("_MinusOne", 0);
    }

    private void setBloom(Volume volume) {
        Bloom bloom;

        if (volume.profile.TryGet<Bloom>(out bloom)) {
            Debug.Log("Carregando bloom");
        }

        bloom.active = true;
        bloom.intensity.overrideState = true;
        bloom.intensity.value = 2.2f;
        bloom.threshold.overrideState = true;
        bloom.threshold.value = 0.0f;
    }

    IEnumerator cleanText() {
        yield return new WaitForSeconds(5);

        EffectName.text = "";
        EffectDescription.text = "";
    }
}
