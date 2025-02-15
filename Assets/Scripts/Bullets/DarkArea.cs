using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkArea : MonoBehaviour
{
    
    public float fadeDuration = 3f;
    private float fadeTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fadeTimer += Time.fixedDeltaTime;

        float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
        
        if (fadeTimer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}
