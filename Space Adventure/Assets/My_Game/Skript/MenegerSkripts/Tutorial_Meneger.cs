using UnityEngine;

public class Tutorial_Meneger : MonoBehaviour
{
    [Header("Slider variabls")]
    [SerializeField] private GameObject[] _image;
    [SerializeField] private bool[] _isActiveImage;
    private int _numberSwitch = 1;

    [Header("Save variabls")]
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField] private string _keyTutorial;
    [SerializeField] private int _isStateSave = 1;

    private void Start()
    {
        LoadTutorial();
    }

    #region SliderImage
    public void ButtonSlider()
    {
        SliderImage();
    }

    private void SliderImage()
    {
        for (int i = 1; i < _isActiveImage.Length; i++)
        {
            if (_numberSwitch >= _isActiveImage.Length)
            {
                for (int j = 0; j < _isActiveImage.Length; j++)
                {
                    _isActiveImage[j] = false;
                    if (_image[j])
                    {
                        _image[j].SetActive(false);
                    }
                }
                _numberSwitch = 1;
                _image[0].SetActive(true);
                _isActiveImage[0] = true;
                break;
            }
            else
            {
                if (!_isActiveImage[i])
                {
                    if (i != 0)
                    {
                        _image[i - 1].SetActive(false);
                    }
                    _image[i].SetActive(true);
                    _numberSwitch++;
                    _isActiveImage[i] = true;
                    break;
                }
            }
        }
    }
    #endregion

    #region SaveTutorial

    public void ModePanel()
    {
        if (_isStateSave == 1)
        {
            _isStateSave = 0;
        }
        else
        {
            _isStateSave = 1;
        }
    }

    public void SaveTutorial()
    {
        PlayerPrefs.SetInt(_keyTutorial, _isStateSave);
        PlayerPrefs.Save();
    }

    private void LoadTutorial()
    {
        if (PlayerPrefs.HasKey(_keyTutorial))
        {
            _isStateSave = PlayerPrefs.GetInt(_keyTutorial);
        }
        if (_isStateSave == 1)
        {
            _panelTutorial.SetActive(true);
            _image[0].SetActive(true);
        }
        else
        {
            _panelTutorial.SetActive(false);
        }
    }

    public void DeleteKey()
    {
        PlayerPrefs.DeleteKey(_keyTutorial);
    }
    #endregion
}
