using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string name)
    {
        StartCoroutine(FadeOut(name));
    }

    IEnumerator FadeIn()
    {
        float time = 1;
        float alpha;
        while (time > 0)
        {
            time -= Time.deltaTime * 1;
            alpha = curve.Evaluate(time);
            img.color = new Color(0, 0, 0, alpha);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0;
        float alpha;
        while (time < 1)
        {
            time += Time.deltaTime * 1;
            alpha = curve.Evaluate(time);
            img.color = new Color(0, 0, 0, alpha);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

}
