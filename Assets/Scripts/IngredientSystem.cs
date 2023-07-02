using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSystem : MonoBehaviour
{

	public GameObject[] ingredients;
    public GameObject result;
    public GameObject player;

	private int index = 1;
	private GameObject current;
	private bool collides = false;

    void Start()
    {
        RandomizePosition();
        current = Instantiate(ingredients[0], transform.position, transform.rotation);
        current.transform.parent = this.transform;
    }

    void Update()
    {
        if (!collides)
        {
	        return;
        }


        // Switch to next ingredient
		Destroy(current);
        if (index < ingredients.Length)
        {
            RandomizePosition();
            current = Instantiate(ingredients[index++], transform.position, transform.rotation);
            current.transform.parent = this.transform;
        }
        else
        {
            Destroy(player.transform.GetChild(0).gameObject);
            current = Instantiate(result, player.transform.position, player.transform.rotation);
            current.transform.parent = player.transform;
            Destroy(this);
        }
    }

    void RandomizePosition()
    {
        Vector3 position;
    
        RaycastHit hit;
        while (true) {
            int x = Random.Range(-4, 4) * 5;
            int z = Random.Range(-4, 4) * 5;
            position = new Vector3(x, 1, z);

            if (!Physics.Raycast(position - Vector3.up * 2, Vector3.up, out hit, 6))
            {
                break;
            }
        }
    
        transform.position = position;
        int rotation = Random.Range(0, 3) * 90;
        transform.Rotate(0, rotation, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        collides = true;
    }

    void OnTriggerExit(Collider other)
    {
        collides = false;
    }
}


