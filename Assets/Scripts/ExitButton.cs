using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject confirmationWindow;

    public void ShowConfirmationWindow()
    {
        confirmationWindow.SetActive(true);
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void CancelExit()
    {
        confirmationWindow.SetActive(false);
    }
}
