# Developing the car/Driver

## The car

To develop the car we need to create a new sprite 2D object called `Car` or the name you want to give to it.\
Then create new script called `Driver.cs` and attach it to the car object.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 150;
    [SerializeField] float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(6.19f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
```

this script will allow the car to move forward and backward and turn left and right.
Attach the script to the car object and set the `steerSpeed` and `moveSpeed` values to your liking.