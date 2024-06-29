using SOHNE.Accessibility.Colorblindness;
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour {

    public Material material;
<<<<<<< Updated upstream
=======
    public Text text;
>>>>>>> Stashed changes

    void Start() {
        // Obter o componente de volume
        Volume volume = GetComponent<Volume>();


        int randomValue = Random.Range(1, 8);

        setShaderNull();

<<<<<<< Updated upstream
        if (randomValue == 1) {//Glaucoma
            setVignette(); 
            Debug.Log("Chamando Glaucoma");
        }
        if (randomValue == 2) {//Catarata
=======

        if (randomValue == 1) {//Glaucoma
            setVignette();
            text.text = "Glaucoma";
            Debug.Log("Chamando Glaucoma");
        }
        if (randomValue == 2) {//Catarata
            text.text = "Catarata";
>>>>>>> Stashed changes
            setBloom(volume);
            Debug.Log("Chamando catarata");
        }
        if (randomValue == 3) {//Degeneração Macular 
<<<<<<< Updated upstream
            setDegeneracaoMacular();            
=======
            setDegeneracaoMacular();
            text.text = "Degeneração Macular";
>>>>>>> Stashed changes
            Debug.Log("Chamando Degeneração macular");
        }
        if (randomValue == 4) {//Protanopia                
            Colorblindness.Instance.Change(1);
<<<<<<< Updated upstream
=======
            text.text = "Protanopia";
>>>>>>> Stashed changes
            Debug.Log("Chamando Protanopia");
        }
        if (randomValue == 5) {//Deuteranopia
            Colorblindness.Instance.Change(3);
<<<<<<< Updated upstream
=======
            text.text = "Deuteranopia";
>>>>>>> Stashed changes
            Debug.Log("Chamando Deuteranopia");
        }
        if (randomValue == 6) {//Tritanopia
            Colorblindness.Instance.Change(5);
<<<<<<< Updated upstream
=======
            text.text = "Tritanopia";
>>>>>>> Stashed changes
            Debug.Log("Chamando Tritanopia");
        }
        if (randomValue == 7) {//Acromatopsia
            Colorblindness.Instance.Change(7);
<<<<<<< Updated upstream
=======
            text.text = "Acromatopsia";
>>>>>>> Stashed changes
            Debug.Log("Chamando Acromatopsia");
        }
    }    

<<<<<<< Updated upstream
    private void setVignette() {        
=======
    private void setVignette() {
>>>>>>> Stashed changes
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 0);
        material.SetFloat("_CutoffSize", 0.2f);
    }

    private void setDegeneracaoMacular() {
        material.SetInt("_IsEnabled", 1);
        material.SetInt("_MinusOne", 1);
<<<<<<< Updated upstream
=======
        material.SetFloat("_CutoffSize", 0.01f);
>>>>>>> Stashed changes
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
