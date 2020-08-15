using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private GameObject fadeObject;
    [SerializeField] private GameObject canvas;
    [SerializeField] private float fadeTime;

    private Image _image;

    // Start is called before the first frame update
    private void Start()
    {
        _image = fadeObject.GetComponent<Image>();
    }

    // Function to fade between scenes
    public IEnumerator Fade()
    {
        var wait = new WaitForSeconds( 1f ) ;
        
        // Check if Canvas is active
        if (canvas.activeInHierarchy) yield break;
        
        // Activate canvas and start Fading 
        canvas.SetActive(true);
        _image.DOFade(1, fadeTime / 2); // Fade time can be changed
        yield return wait;
        
        // Finishing fading and deactivating Canvas 
        _image.DOFade(0, fadeTime);
        yield return wait;
        canvas.SetActive(false);


    }
    
    
}
