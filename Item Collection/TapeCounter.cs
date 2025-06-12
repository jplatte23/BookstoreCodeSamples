namespace TelemetryManagerExamples
{
    using USCG.Core.Telemetry;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine.SceneManagement;
    public class TapeCounter : MonoBehaviour
    {
        public TextMeshProUGUI tapeCountText; // Reference to the TextMeshProUGUI component
        public int tapesNeeded = 8;
        private int tapesCollected = 0; // Counter for collected tapes
        private bool isOnFirstLevel = false;
        public GameObject portal; //Reference to to portal object container
        private MetricId _tapeList = default;
        private int count = 0;

        void Start()
        {
            _tapeList = TelemetryManager.instance.CreateSampledMetric<Vector3>("TapesCollected");
            if (isOnFirstLevel)
            {
                UpdateTapeCountText(); // Initialize the text with the current tape count
            }
        }

        void Update()
        {
            if (GameObjectManager.state == "deathUI")
            {
                tapesCollected = 0;
                UpdateTapeCountText();
            }
        }

        // Call this method whenever a tape is collected
        public void CollectTape(Vector3 pos)
        {
            GameObjectManager.hasStarted = true;
            if (tapesCollected < tapesNeeded)
            {
                tapesCollected++;
                TelemetryManager.instance.AddMetricSample(_tapeList, pos);
                if (tapesCollected == tapesNeeded)
                {
                    GameObject tapeContainer = GameObject.Find("TapeContainer");
                    if (count == 0)
                    {
                        tapeContainer.SetActive(false);
                        count++;

                    }
                    SceneManager.LoadSceneAsync("Floor 2", LoadSceneMode.Additive);
                    portal.SetActive(false);
                    TurnOffFloor2Lights();
                    Debug.Log("38");
                }
                FindObjectOfType<AudioManager>().Play("cassetteTape");
                UpdateTapeCountText();
            }

        }

        void UpdateTapeCountText()
        {
            tapeCountText.text = "Tapes Collected: " + tapesCollected + " / " + tapesNeeded;
        }

        public void EnterFirstLevel()
        {
            isOnFirstLevel = true;
            UpdateTapeCountText();
        }

        private void TurnOffFloor2Lights()
        {
            GameObject lightContainerObject = GameObject.Find("LightManager2");
            if (lightContainerObject != null)
            {
                LightContainerController controller = lightContainerObject.GetComponent<LightContainerController>();
                if (controller != null)
                {
                    controller.DisableLightContainer();
                }
            }

        }
    }
}

