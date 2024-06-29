using SOHNE.Accessibility.Colorblindness;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour {

    public Material material;

    void Start() {
        // Obter o componente de volume
        Volume volume = GetComponent<Volume>();


        int randomValue = Random.Range(1, 8);

        setShaderNull();

        if (randomValue == 1) {//Glaucoma
            setVignette(); 
            Debug.Log("Chamando Glaucoma");
        }
        if (randomValue == 2) {//Catarata
            setBloom(volume);
            Debug.Log("Chamando catarata");
        }
        if (randomValue == 3) {//Degeneração Macular 
            setDegeneracaoMacular();            
            Debug.Log("Chamando Degeneração macular");
        }
        if (randomValue == 4) {//Protanopia                
            Colorblindness.Instance.Change(1);
            Debug.Log("Chamando Protanopia");
        }
        if (randomValue == 5) {//Deuteranopia
            Colorblindness.Instance.Change(3);
            Debug.Log("Chamando Deuteranopia");
        }
        if (randomValue == 6) {//Tritanopia
            Colorblindness.Instance.Change(5);
            Debug.Log("Chamando Tritanopia");
        }
        if (randomValue == 7) {//Acromatopsia
            Colorblindness.Instance.Change(7);
            Debug.Log("Chamando Acromatopsia");
        }
    }    

    private void setVignette() {        
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 0);
        material.SetFloat("_CutoffSize", 0.2f);
    }

    private void setDegeneracaoMacular() {
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 1);
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
}
