using UnityEngine;
using System.Diagnostics;

namespace ezweededit
{
    public class GUI
    {
        private bool showGUI = false;
        private Rect windowRect = new Rect(20, 20, 300, 265);

        public int HarvestQuantity { get; private set; } = 1;
        public int QualityIndex { get; private set; } = 2;
        private string[] qualityOptions = System.Enum.GetNames(typeof(ScheduleOne.ItemFramework.EQuality));

        public void OnGUI()
        {
            if (showGUI)
            {
                windowRect = UnityEngine.GUI.Window(0, windowRect, DrawWindow, "Easy Weed Editor");
            }
        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                showGUI = !showGUI;
            }
        }

        private void DrawWindow(int windowID)
        {
            GUILayout.Label("Welcome to Easy Weed Editor");

            GUILayout.Label("Harvest Quantity:");
            HarvestQuantity = Mathf.RoundToInt(GUILayout.HorizontalSlider(HarvestQuantity, 1, 453));
            GUILayout.Label($"Current Quantity: {HarvestQuantity}");

            GUILayout.Label("Product Quality:");
            QualityIndex = GUILayout.SelectionGrid(QualityIndex, qualityOptions, 3);
            GUILayout.Label($"Selected Quality: {qualityOptions[QualityIndex]}");

            if (GUILayout.Button("Apply Changes"))
            {
                Core.Instance.LoggerInstance.Msg($"Selected Quantity: {HarvestQuantity}, Quality: {qualityOptions[QualityIndex]}");
            }

            if (GUILayout.Button("Join Our Discord"))
            {
                OpenUrl("https://discord.gg/4H2RasTvqR");
            }

            UnityEngine.GUI.DragWindow();
        }

        private void OpenUrl(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
