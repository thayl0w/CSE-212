/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions))
        {
            if (directions[0]) // left is the first direction in the array
            {
                _currX--; // move left
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid location!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions))
        {
            if (directions[1]) // right is the second direction in the array
            {
                _currX++; // move right
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid location!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions))
        {
            if (directions[2]) // up is the third direction in the array
            {
                _currY--; // move up
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid location!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions))
        {
            if (directions[3]) // down is the fourth direction in the array
            {
                _currY++; // move down
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid location!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}