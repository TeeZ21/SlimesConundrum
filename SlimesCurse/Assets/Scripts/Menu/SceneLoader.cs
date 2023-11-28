using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _fade = null;
    private float _transitionTime = 1f;

    public IEnumerator Load(int levelIndex)
    {
        _fade.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
