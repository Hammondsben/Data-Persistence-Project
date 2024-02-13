using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private InputField playerNameField;
    [SerializeField] private Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = $"Best Score: {GameManager.Instance.bestScore}";
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyUp(KeyCode.Return))
        {
            GameManager.Instance.getPlayerName(playerNameField.text);
        }
    }

    public void whenStartPressed()
    {
        SceneManager.LoadScene(1);
    }
    public void whenQuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }
}
