using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using Unity.AI.Navigation;

public class MazeGenerator3D : MonoBehaviour
{
    [Header("Maze Settings")]
    public int width = 15;
    public int depth = 15;
    public float cellSize = 1.0f;

    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public GameObject keyPrefab;
    public GameObject exitPrefab;

    [Header("NavMesh")]
    public NavMeshSurface navSurface;

    private int[,] maze;

    void Start()
    {
        GenerateMaze();
        BuildMaze();
        PlaceKeyAndExit();
        BakeNavMesh();
    }

    // 迷路生成
    void GenerateMaze()
    {
        maze = new int[width, depth];
        for (int x = 0; x < width; x++)
            for (int z = 0; z < depth; z++)
                maze[x, z] = 1; // 1 = 壁

        Vector2Int start = new Vector2Int(1, 1);
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(start);
        maze[start.x, start.y] = 0;

        System.Random rand = new System.Random();

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Pop();
            foreach (Vector2Int dir in Shuffle(new Vector2Int[] {
                new Vector2Int(1,0), new Vector2Int(-1,0),
                new Vector2Int(0,1), new Vector2Int(0,-1)
            }, rand))
            {
                Vector2Int next = current + dir * 2;
                if (IsInBounds(next) && maze[next.x, next.y] == 1)
                {
                    maze[current.x + dir.x, current.y + dir.y] = 0;
                    maze[next.x, next.y] = 0;
                    stack.Push(next);
                }
            }
        }
    }

    // 壁と床を生成
    void BuildMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                Vector3 pos = new Vector3(x * cellSize, 0, z * cellSize);
                GameObject prefab = (maze[x, z] == 1) ? wallPrefab : floorPrefab;
                Instantiate(prefab, pos, Quaternion.identity, transform);
            }
        }
    }

    // 鍵と出口を配置
    void PlaceKeyAndExit()
    {
        Vector3 keyPos = GetRandomFloorPos();
        Vector3 exitPos = GetRandomFloorPos();

        Instantiate(keyPrefab, keyPos + Vector3.up * 0.5f, Quaternion.identity, transform);
        Instantiate(exitPrefab, exitPos + Vector3.up * 0.5f, Quaternion.identity, transform);
    }

    // NavMesh Bake
    void BakeNavMesh()
    {
        if (navSurface != null)
        {
            navSurface.BuildNavMesh();
            Debug.Log("NavMesh baked successfully!");
        }
        else
        {
            Debug.LogWarning("NavMeshSurface が設定されていません。");
        }
    }

    // 補助関数
    bool IsInBounds(Vector2Int pos)
    {
        return pos.x > 0 && pos.y > 0 && pos.x < width - 1 && pos.y < depth - 1;
    }

    Vector2Int[] Shuffle(Vector2Int[] arr, System.Random rand)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int j = rand.Next(i, arr.Length);
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
        return arr;
    }

    Vector3 GetRandomFloorPos()
    {
        List<Vector3> floors = new List<Vector3>();
        for (int x = 1; x < width - 1; x++)
        {
            for (int z = 1; z < depth - 1; z++)
            {
                if (maze[x, z] == 0)
                {
                    floors.Add(new Vector3(x * cellSize, 0, z * cellSize));
                }
            }
        }
        return floors[Random.Range(0, floors.Count)];
    }
}
