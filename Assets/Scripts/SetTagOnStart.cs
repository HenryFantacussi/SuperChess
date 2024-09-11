using UnityEngine;

public class SetTagOnStart : MonoBehaviour
{
    public string tagName = "Casa"; // Nome da tag que voc� deseja aplicar

    private void Start()
    {
        // Verifica se a tag existe
        if (TagIsValid(tagName))
        {
            // Define a tag do GameObject
            gameObject.tag = tagName;
        }
        else
        {
            Debug.LogWarning("A tag especificada n�o existe. Certifique-se de que a tag est� criada.");
        }
    }

    private bool TagIsValid(string tag)
    {
        // Verifica se a tag est� definida nas tags do Unity
        foreach (string existingTag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (existingTag == tag)
            {
                return true;
            }
        }
        return false;
    }
}
