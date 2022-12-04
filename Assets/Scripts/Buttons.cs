using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private static int _index;

    [SerializeField]
    private Slider _slider;

    [Space, SerializeField]
    private Button _switchButton;
    [SerializeField]
    private Button _closeButton;

    [Space, SerializeField]
    private GameObject[] _planes;

    [Space, SerializeField]
    private Canvas _startButtonCanvas;

    private void SwitchExercise(int previosIndex)
    {
        _planes[previosIndex].SetActive(false);
        _planes[_index].SetActive(true);

        if (_index == _planes.Length - 1)
        {
            _switchButton.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(true);
        }
    }

    public void ForwardSwitch()
    {
        if (_index < _planes.Length - 1)
        {
            _index++;
            SwitchExercise(_index - 1);
            _slider.value = _index + 1;
        }
    }

    public void BackSwitch()
    {
        if(_index > 0)
        {
            if (_index == _planes.Length - 1)
            {
                _switchButton.gameObject.SetActive(true);
                _closeButton.gameObject.SetActive(false);
            }

            _index--;
            SwitchExercise(_index + 1);
            _slider.value = _index + 1;
        }
    }

    public void StartExercise()
    {
        _index = 0;
        _planes[_index].SetActive(true);
        _startButtonCanvas.gameObject.SetActive(false);
    }

    public void CloseApp()
        => Application.Quit();
}
