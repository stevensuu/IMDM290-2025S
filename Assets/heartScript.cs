using UnityEngine;

public class heartScript : MonoBehaviour
{
    public GameObject objPrefab;
    public int points = 1000;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        
        // continuously destroy prev cube obj
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (float i = 0; i < Mathf.PI * 2; i += Mathf.PI * 2 / points)
        {
            float x = Mathf.Sqrt(2) * Mathf.Pow(Mathf.Sin(i), 3); 
            float y = -Mathf.Pow(Mathf.Cos(i), 3) - Mathf.Pow(Mathf.Cos(i), 2) + 2 * Mathf.Cos(i);
            float z = Mathf.Sin(timer + i) * 3f; 

            Vector3 pos = new Vector3(x, y, z);
            GameObject obj = Instantiate(objPrefab, pos, objPrefab.transform.rotation, transform);

            float lerp = Mathf.PingPong(timer, 1f); 
            Color newColor = Color.Lerp(Color.red, Color.green, lerp);
            MeshRenderer mR = obj.GetComponent<MeshRenderer>(); 
            mR.material.color = newColor;
        }
    }
}
