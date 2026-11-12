using UnityEngine;

public class CharacterFocusButton : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private Transform characterTransform;
    public void Focus()
    {
        if (cameraManager != null && characterTransform != null)
        {
            cameraManager.FocusOnCharacter(characterTransform);
        }
    }
}