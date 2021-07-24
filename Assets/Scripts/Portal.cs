using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Portal : Interactable
{
    public string sceneName;
    private BoxCollider2D boxCollider;

    public override void Interact()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
