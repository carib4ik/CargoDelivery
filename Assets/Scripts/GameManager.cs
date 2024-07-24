using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private Draw _drawer;
    [SerializeField] private BoxController _boxController;
    [SerializeField] private CanvasFadeIn _canvasFadeIn;

    private void Start()
    {
        _drawer.MoveRope += _movementController.Move;
        _movementController.Finishing += _boxController.DropDown;
        _boxController.FinishGame += _canvasFadeIn.FadeInCanvas;
    }
}
