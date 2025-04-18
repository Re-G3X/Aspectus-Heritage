using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace SOHNE.Accessibility.Colorblindness {
    public enum ColorblindTypes {
        Normal = 0,
        Protanopia,
        Protanomaly,
        Deuteranopia,
        Deuteranomaly,
        Tritanopia,
        Tritanomaly,
        Achromatopsia,
        Achromatomaly,
    }

    public class Colorblindness : MonoBehaviour {
        public KeyCode changeKey = KeyCode.F1;

        public static Colorblindness Instance { get; private set; }

        private Volume[] volumes;
        private int maxType;
        private int _currentType = 0;

        private int currentType {
            get => _currentType;
            set {
                if (value >= maxType)
                    _currentType = 0;
                else
                    _currentType = value;
            }
        }

        #region Unity Lifecycle

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this) {
                Destroy(gameObject);
                return;
            }

            maxType = (int)System.Enum.GetValues(typeof(ColorblindTypes)).Cast<ColorblindTypes>().Last();
        }

        private void OnEnable() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start() {
            if (PlayerPrefs.HasKey("Accessibility.ColorblindType"))
                currentType = PlayerPrefs.GetInt("Accessibility.ColorblindType");
            else
                PlayerPrefs.SetInt("Accessibility.ColorblindType", 0);

            SearchVolumes();
            Change(currentType); 
        }

        private void Update() {
            if (Input.GetKeyDown(changeKey))
                InitChange();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            SearchVolumes();
            Change(currentType); 
        }

        #endregion

        #region Volume Management

        private void SearchVolumes() {
            volumes = GameObject.FindObjectsOfType<Volume>();
        }

        #endregion

        #region Filtro Daltonismo

        public void Change(int filterIndex = -1) {
            filterIndex = filterIndex <= -1 ? PlayerPrefs.GetInt("Accessibility.ColorblindType") : filterIndex;
            currentType = Mathf.Clamp(filterIndex, 0, maxType);
            StartCoroutine(ApplyFilter());
        }

        private void InitChange() {
            if (volumes == null || volumes.Length == 0) return;

#if UNITY_EDITOR
            Debug.Log($"[Colorblindness] Filtro alterado para: {(ColorblindTypes)currentType} ({currentType}/{maxType})");
#endif

            PlayerPrefs.SetInt("Accessibility.ColorblindType", currentType);
            StartCoroutine(ApplyFilter());

            currentType++;
        }

        private IEnumerator ApplyFilter() {
            string filterName = ((ColorblindTypes)currentType).ToString();
            ResourceRequest loadRequest = Resources.LoadAsync<VolumeProfile>($"Colorblind/{filterName}");

            yield return loadRequest;

            var loadedProfile = loadRequest.asset as VolumeProfile;

            if (loadedProfile == null) {
                Debug.LogError($"[Colorblindness] Falha ao carregar perfil: Colorblind/{filterName}");
                yield break;
            }

            foreach (var volume in volumes) {
                // ⚠️ Evita modificar perfil original diretamente
                VolumeProfile profileInstance = Instantiate(loadedProfile);
                volume.profile = profileInstance;

                Debug.Log($"[Colorblindness] Filtro aplicado: {filterName} com {profileInstance.components.Count} componentes");
            }
        }

        #endregion
    }
}
