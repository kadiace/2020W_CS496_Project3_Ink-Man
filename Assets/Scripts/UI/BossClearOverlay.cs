using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class BossClearOverlay : MonoBehaviour
    {
        static BossClearOverlay instance;
        GUIStyle titleStyle;
        GUIStyle buttonStyle;

        public static void Show()
        {
            if (instance != null)
                return;

            var root = new GameObject("BossClearOverlay");
            instance = root.AddComponent<BossClearOverlay>();
            instance.BuildUI();
        }

        void BuildUI()
        {
            EnsureEventSystem();

            var canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 1000;

            gameObject.AddComponent<CanvasScaler>();
            gameObject.AddComponent<GraphicRaycaster>();

            var panel = CreateUIObject("Panel", gameObject.transform);
            var panelImage = panel.AddComponent<Image>();
            panelImage.color = new Color(0f, 0f, 0f, 0.75f);
            StretchToParent(panel.GetComponent<RectTransform>());

            var title = CreateUIObject("Title", panel.transform);
            var titleText = title.AddComponent<Text>();
            titleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            titleText.text = "Thanks for playing!";
            titleText.alignment = TextAnchor.MiddleCenter;
            titleText.fontSize = 72;
            titleText.color = Color.white;

            var titleRect = title.GetComponent<RectTransform>();
            titleRect.anchorMin = new Vector2(0.5f, 0.66f);
            titleRect.anchorMax = new Vector2(0.5f, 0.66f);
            titleRect.pivot = new Vector2(0.5f, 0.5f);
            titleRect.sizeDelta = new Vector2(1100f, 180f);
            titleRect.anchoredPosition = Vector2.zero;

            var buttonObject = CreateUIObject("BackToMainButton", panel.transform);
            var buttonImage = buttonObject.AddComponent<Image>();
            buttonImage.color = new Color(0.95f, 0.95f, 0.95f, 1f);

            var button = buttonObject.AddComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(BackToMain);

            var buttonRect = buttonObject.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0.5f, 0.4f);
            buttonRect.anchorMax = new Vector2(0.5f, 0.4f);
            buttonRect.pivot = new Vector2(0.5f, 0.5f);
            buttonRect.sizeDelta = new Vector2(360f, 100f);
            buttonRect.anchoredPosition = Vector2.zero;

            var buttonLabel = CreateUIObject("Label", buttonObject.transform);
            var labelText = buttonLabel.AddComponent<Text>();
            labelText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            labelText.text = "Back to Main";
            labelText.alignment = TextAnchor.MiddleCenter;
            labelText.fontSize = 36;
            labelText.color = new Color(0.1f, 0.1f, 0.1f, 1f);
            StretchToParent(buttonLabel.GetComponent<RectTransform>());

            Debug.Log("BossClearOverlay.BuildUI");
        }

        void OnGUI()
        {
            EnsureGuiStyles();

            var width = Screen.width;
            var height = Screen.height;

            var titleRect = new Rect(0f, height * 0.26f, width, 90f);
            GUI.Label(titleRect, "Thanks for playing!", titleStyle);

            var buttonWidth = 320f;
            var buttonHeight = 80f;
            var buttonRect = new Rect((width - buttonWidth) * 0.5f, height * 0.42f, buttonWidth, buttonHeight);
            if (GUI.Button(buttonRect, "Back to Main", buttonStyle))
                BackToMain();
        }

        void EnsureGuiStyles()
        {
            if (titleStyle != null && buttonStyle != null)
                return;

            titleStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 48,
                alignment = TextAnchor.MiddleCenter,
                normal = { textColor = Color.white }
            };

            buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 28,
                alignment = TextAnchor.MiddleCenter
            };
        }

        static GameObject CreateUIObject(string name, Transform parent)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            obj.AddComponent<RectTransform>();
            return obj;
        }

        static void StretchToParent(RectTransform rectTransform)
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.anchoredPosition = Vector2.zero;
        }

        static void EnsureEventSystem()
        {
            if (FindObjectOfType<EventSystem>() != null)
                return;

            var eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }

        void BackToMain()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
