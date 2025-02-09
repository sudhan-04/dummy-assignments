# MEMORY OPTIMIZATION 
## CODE SNIPPET
```
public class MemoryEater
{
    List<int[]> memAlloc = new List<int[]>();

    public void Allocate()
    {
        while (true)
        {
            memAlloc.Add(new int[1000]);
            // Assume memAlloc variable is used only within this loop. 
            Thread.Sleep(10); 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MemoryEater me = new MemoryEater();
        me.Allocate();
    }
}
```
## MEMORY ISSUES
- Generally, when an array is initialized memory is allocated in the heap according to the size of the array and the variable data type.
- In the above code snippet, the `Allocate` method continuously allocates memory by adding new integer arrays `(int[1000])` to the `memAlloc` list without any termination or cleanup. 
- For each loop iteration, the `Allocate` method creates a new array of size 4 Kilobytes (1000 * 4 Bytes = 4 KB) which is then stored in the heap memory.
- Since the break condition of the loop is defined as `While(true)` , the loop continues forever which results in infinite memory allocation.
- After a certain point, `OutOfMemoryException` is set to occur due to the continuous memory allocation without any cleanup. 
## POSSIBLE APPROACHES
### LIMITED MEMORY ALLOCATION
-  One of the main reasons for the infinite memory allocation lies in infinite loop iteration.
-  The Memory optimization can be performed by  `limiting`  the number of loop iterations.
- Before the allocation starts, the number of iterations/ the number of arrays that must be added to the List `memAlloc` can be taken from the user.
- This could result in limited memory allocation since the array creation is terminated after the number of iterations.
### USING BLOCK ( IDisposable INTERFACE)
- The `Dispose` method of the `IDisposable` interface is implemented to dispose the `unmanaged resources` like files or database.
- But in the above code snippet, arrays are created which results in the memory allocation of the heap memory.
- Heap memory is one of the managed resources which is handled by the `Garbage Collector` and the array memory can only be handled by the GC.
- Therefore the `Using` block which implements the `Dispose` method proves to be useless in this scenario since memory allocation only happens in the managed memory.
### LARGE OBJECT HEAPS (LOH) 
- Large Object Heaps (LOH) are objects which exceed the memory size of `85,000` bytes and is stored in the managed memory.
- `LOH` causes a lot of memory issues such as memory fragmentation and memory leaks since they are pinned down on the Heap memory causing the GC unable to perform operations on them.
- In the above code snippet, each new array is of size 4 Kilobytes (1000 * 4 Bytes = 4 KB) which are then added to the list.
- Each object has size less than the required memory of the LOH (85000 Bytes).
- The `List<int[]>` itself is a small object, as it only holds references to arrays.
- Therefore, there is no possible case of the LOH creation in the above code snippet and therefore the possibility of LOH can be ignored.
### ArrayPool
- `ArrayPool` allows memory to be borrowed from the available shared pool of memory.
- The maximum size of the pre-defined shared pool that can be `rented` is about `4 KB`.
- In the code snippet, the array created in the previous loop iteration is not cleared till the loop ends.
- Therefore, simply `returning` the array to the `memory pool` overwrites the previous array created which is not a desirable outcome.
- In this scenario, ArrayPool cannot be used to optimize the memory since it results in creation of new arrays same as the infinite memory allocation glitch.
### GC.Collect()
- After the loop ends, the arrays become `unreferenced objects` which can be cleaned up to free memory.
- Therefore, the `Garbage Collector` can be forced to free up memory through `GC.Collect()` method.
## CHALLENGES
- The arrays stay inside the `scope` and therefore are continuously `referenced`, which prevents them from being cleaned up. 
- Handling the managed memory can only be performed by the `Garbage Collector` which can clean only the unreferenced objects.
- The memory allocation graph shown in the visual studio diagnostic tools does not portray the exact `deviations` in the heap memory size.
- It is uncertain when the GC.Collect() method will perform the garbage collection of the unreferenced variables after it is called.
## IMPLEMENTED SOLUTION
### LIMITED LOOP ITERATIONS WITH GARBAGE COLLECTION
- From the above explanation, it can be noted that limiting the number of loop iterations and performing `garbage collection` proves to be the best and most viable approach to clear out the memory issue problem.
- `GC.GetTotalMemory()` is used to derive the exact heap size and it is compared with the Diagnostic tool for more accuracy.
- `Thread.Sleep()` is implemented to introduce certain delay between the call of the GC and the calculation of the heap size to ensure that GC has completed the garbage collection. 

  ![task 2 p1](https://github.com/user-attachments/assets/351fc64b-72cf-40d4-88e9-8ac544d18112)

  ![task2 p2](https://github.com/user-attachments/assets/8d68d248-9c38-44cd-bd70-075bc90cc1bd)

  ![task-2 p2](https://github.com/user-attachments/assets/9bcc3422-8f42-4a23-bd2c-0bcfa0288f90)

## REFERENCES
- https://www.geeksforgeeks.org/garbage-collection-in-c-sharp-dot-net-framework/
- https://learn.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1?view=net-9.0
- https://stackoverflow.com/questions/58873582/what-is-arraypool-in-netcore-c-sharp
- https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/unmanaged

