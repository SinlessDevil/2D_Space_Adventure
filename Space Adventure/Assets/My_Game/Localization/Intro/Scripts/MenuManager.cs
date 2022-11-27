using UnityEngine;
using MyGame.Localization;

public class MenuManager : MonoBehaviour
{
    #region Public Methods
    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
        Debug.Log("Language - English!");
    }

    public void SetRussian()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Russian);
        LocalizeImage.SetCurrentLanguage();
        Debug.Log("Language - Russian!");
    }

    public void SetUkrainian()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Ukrainian);
        LocalizeImage.SetCurrentLanguage();
        Debug.Log("Language - Ukrainian!");
    }

    #endregion
}
