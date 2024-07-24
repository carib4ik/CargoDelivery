using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private Draw _drawer;

    private void Start()
    {
        _drawer.MoveRope += _movementController.Move;
    }
}
