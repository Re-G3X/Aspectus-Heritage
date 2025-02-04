using System;
using SOHNE.Accessibility.Colorblindness;

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using Random = UnityEngine.Random;

public class PostProcessingController : MonoBehaviour {

    public Material material;

    public Text EffectName;
    public Text EffectDescription;

    private Volume _volume;
    private Coroutine _hideText;

    public void Start()
    {
	    // Obter o componente de volume
	    _volume = GetComponent<Volume>();

        SetNewRandomCondition();
    }

	private void SetNewRandomCondition()
    {
	    SetShaderNull();
	    int randomValue = Random.Range(1, 8);
	    Debug.Log(randomValue);

	    switch (randomValue)
	    {
		    case 1: //Glaucoma
			    SetVignette();
			    EffectName.text = "Glaucoma";
			    EffectDescription.text = "Afetados gradativamente perdem vis�o perif�rica, enxergando atrav�s de um �t�nel�. Pode causar perda total de vis�o. ";
			    Debug.Log("Chamando Glaucoma");
			    break;
		    case 2: //Catarata
			    EffectName.text = "Catarata";
			    EffectDescription.text = "Afetados sentem certo n�vel de emba�amento na vis�o, sensibilidade � luz e dificuldade de enxerga � noite.";
			    SetBloom();
			    Debug.Log("Chamando catarata");
			    break;
		    case 3: //Degenera��o Macular 
			    SetDegeneracaoMacular();
			    EffectName.text = "Degenera��o Macular";
			    EffectDescription.text = "Afetados podem sentir um emba�amento/distor��o da vis�o. Afeta principalmente pessoas mais velhas";
			    Debug.Log("Chamando Degenera��o macular");
			    break;
		    case 4: //Protanopia                
			    Colorblindness.Instance.Change(1);
			    EffectName.text = "Protanopia";
			    EffectDescription.text = "Afetados t�m dificuldade em perceber tons de vermelho, levando � confus�o entre vermelho e verde.";
			    Debug.Log("Chamando Protanopia");
			    break;
		    case 5: //Deuteranopia
			    Colorblindness.Instance.Change(3);
			    EffectName.text = "Deuteranopia";
			    EffectDescription.text = "Afetados t�m dificuldade em perceber tons de verde, levando � confus�o entre verde e vermelho";
			    Debug.Log("Chamando Deuteranopia");
			    break;
		    case 6: //Tritanopia
			    Colorblindness.Instance.Change(5);
			    EffectDescription.text = "Afetados t�m dificuldade em distinguir entre azul e amarelo, podendo tamb�m afetar a percep��o de tons de verde e roxo.";
			    EffectName.text = "Tritanopia";
			    Debug.Log("Chamando Tritanopia");
			    break;
		    case 7: //Acromatopsia
			    Colorblindness.Instance.Change(7);
			    EffectDescription.text = "Afetados t�m dificuldade em perceber cores.";
			    EffectName.text = "Acromatopsia";
			    Debug.Log("Chamando Acromatopsia");
			    break;
	    }

	    _hideText = StartCoroutine(CleanText());
    }

    private void SetVignette() {
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 0);
        material.SetFloat("_CutoffSize", 0.2f);
    }

    private void SetDegeneracaoMacular() {
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 1);
        material.SetFloat("_CutoffSize", 0.1f);
    }

    private void SetShaderNull() {
        material.SetInt("_IsEnabled", 0);
        material.SetInt("_MinusOne", 0);
    }

    private void SetBloom() {
        Bloom bloom;

        if (_volume.profile.TryGet<Bloom>(out bloom)) {
            Debug.Log("Carregando bloom");
        }

        bloom.active = true;
        bloom.intensity.overrideState = true;
        bloom.intensity.value = 2.2f;
        bloom.threshold.overrideState = true;
        bloom.threshold.value = 0.0f;
    }

    private IEnumerator CleanText() {
        yield return new WaitForSeconds(5);

        EffectName.text = "";
        EffectDescription.text = "";
    }
}
