using System;
using SOHNE.Accessibility.Colorblindness;

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using Random = UnityEngine.Random;
using TMPro;

public class PostProcessingController : MonoBehaviour {

    public Material material;

    public GameObject EffectName;
    public GameObject EffectDescription;
    
    private TextMeshProUGUI _effectName;
    private TextMeshProUGUI _effectDescription;

    [SerializeField] private Volume _volume;
	private Coroutine _hideText;

    public void Start()
    {
	    // Obter o componente de volume
	    _volume = GetComponent<Volume>();
	    _effectName = EffectName.GetComponent<TextMeshProUGUI>();
	    _effectDescription = EffectDescription.GetComponent<TextMeshProUGUI>();
        SetNewRandomCondition();
    }

	private void SetNewRandomCondition()
    {
	    SetShaderNull();
		int randomValue = Random.Range(1, 7);
	    Debug.Log(randomValue);

	    switch (randomValue)
	    {
		    case 1: //Glaucoma
			    SetVignette();
			    _effectName.text = "Glaucoma";
			    _effectDescription.text = "Afetados gradativamente perdem visão periférica, enxergando através de um 'túnel'. Pode causar perda total de visão. ";
			    Debug.Log("Chamando Glaucoma");
			    break;
		  /*  case 2: //Catarata
                Debug.Log("Chamando catarata1");

                foreach (var component in _volume.profile.components) {
                    Debug.Log("Override: " + component.name);
                }


                _effectName.text = "Catarata";
			    _effectDescription.text = "Afetados sentem certo nível de embaçamento na visão, sensibilidade à luz e dificuldade de enxerga à noite.";
			    SetBloom();
			    Debug.Log("Chamando catarata");
			    break;*/
		    case 2: //Degenera��o Macular 
			    SetDegeneracaoMacular();
			    _effectName.text = "Degeneração Macular";
			    _effectDescription.text = "Afetados podem sentir um embaçamento/distorção da visão. Afeta principalmente pessoas mais velhas";
			    Debug.Log("Chamando Degeneração macular");
			    break;
		    case 3: //Protanopia                
			    Colorblindness.Instance.Change(1);
			    _effectName.text = "Protanopia";
			    _effectDescription.text = "Afetados têm dificuldade em perceber tons de vermelho, levando à confusão entre vermelho e verde.";
			    Debug.Log("Chamando Protanopia");
			    break;
		    case 4: //Deuteranopia
			    Colorblindness.Instance.Change(3);
			    _effectName.text = "Deuteranopia";
			    _effectDescription.text = "Afetados têm dificuldade em perceber tons de verde, levando à confusão entre verde e vermelho";
			    Debug.Log("Chamando Deuteranopia");
			    break;
		    case 5: //Tritanopia
			    Colorblindness.Instance.Change(5);
			    _effectDescription.text = "Afetados têm dificuldade em distinguir entre azul e amarelo, podendo também afetar a percepção de tons de verde e roxo.";
			    _effectName.text = "Tritanopia";
			    Debug.Log("Chamando Tritanopia");
			    break;
		    case 6: //Acromatopsia
			    Colorblindness.Instance.Change(7);
			    _effectDescription.text = "Afetados têm dificuldade em perceber cores.";
			    _effectName.text = "Acromatopsia";
			    Debug.Log("Chamando Acromatopsia");
			    break;
	    }

	    _hideText = StartCoroutine(CleanText());
    }

    private void SetVignette() {
        Colorblindness.Instance.Change(0);
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 0);
        material.SetFloat("_CutoffSize", 0.2f);
    }

    private void SetDegeneracaoMacular() {
        Colorblindness.Instance.Change(0);
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 1);
        material.SetFloat("_CutoffSize", 0.1f);
    }

    private void SetShaderNull() {
        Colorblindness.Instance.Change(0);
        material.SetInt("_IsEnabled", 0);
        material.SetInt("_MinusOne", 0);
    }

    private void SetBloom() {
        Bloom bloom;
        if (_volume.profile.TryGet(out bloom)) {
            Debug.Log("Carregando bloom");

            bloom.active = true;
            bloom.intensity.overrideState = true;
            bloom.intensity.value = 2.2f;
            bloom.threshold.overrideState = true;
            bloom.threshold.value = 0.0f;
        }
        else {
            Debug.LogWarning("Bloom não encontrado no Volume Profile!");
        }
    }

    private IEnumerator CleanText() {
        yield return new WaitForSeconds(5);

        _effectName.text = "";
        _effectDescription.text = "";
    }
}
