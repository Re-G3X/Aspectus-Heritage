using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour {

    void Start() {
        // Obter o componente de volume
        Volume volume = GetComponent<Volume>();

        int randomValue = Random.Range(1, 5);        

        if (randomValue == 1) {//Glaucoma
            setVignette(volume);
        }
        if (randomValue == 2) {//Catarata
            setBloom(volume);
        }
        if (randomValue == 3) {
            Debug.Log("Essa função ainda não foi criada 3");
        }
        if (randomValue == 4) {
            Debug.Log("Essa função ainda não foi criada 4");
        }
        if (randomValue == 5) {
            Debug.Log("Essa função ainda não foi criada 5");
        }
    }

    private void setVignette(Volume volume) {
        Vignette vignette;
        
        if (volume.profile.TryGet<Vignette>(out vignette)) {
            Debug.Log("Carregando Vignette");
        }

        vignette.active = true;
        vignette.intensity.overrideState = true;
        vignette.intensity.value = 1.0f;
        vignette.smoothness.overrideState = true;
        vignette.smoothness.value = 1.0f;
        vignette.rounded.overrideState = true;
    }

    private void setBloom(Volume volume) {
        Bloom bloom;

        if (volume.profile.TryGet<Bloom>(out bloom)) {
            Debug.Log("Carregando bloom");
        }

        bloom.active = true;
        bloom.intensity.overrideState = true;
        bloom.intensity.value = 2.0f;
        bloom.threshold.overrideState = true;
        bloom.threshold.value = 0.0f;
    }
}
