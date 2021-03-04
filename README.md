# Ozow.Sort

## Solution structure

The solution consists of three projects:
1. `Ozow.Sort` - the  class library that contains string sorting logic
2. `Ozow.Sort.Console` - the console entry point that prompts for the string input, executes sorting logic, and outputs the result
3. `Ozow.Sort.Tests` - the xUnit test project. Contains unit tests for the sorting logic

## Sorting algorithm

The sorting logic is implemented in the `Ozow.Sort.Sorter` class. It defines the `Sort` public method.

The `Sort` method iterates through each character of the input string, filters out non-english characters, makes them lowercase and orders them.

The sorting algorithm does not use a conventional method, such as quick sort or insertion sort, but takes advantage of the fact that there is a limited set of possible characters. 

There are 26 possible values each character may have (`a` to `z`). The algorithm counts how many times each character appears in the input string, and then outputs each character the same amount of times, in the alphabetic order.

To count occurance of each characters, `Dictionary<char, int>` class is used, which is essentially a type-safe hashtable.

## Complexity

The average and the worst time complexity of the implemented sorting algorithm is linear: `O(n)`.

Each iteration `i`, from 0 to n-1 inclusive, the search and insertion is performed on the hashtable:

![](https://latex.codecogs.com/gif.latex?%5Csum_%7Bi%3D0%7D%5E%7Bn-1%7D%28O%28search%29%20&plus;%20O%28insert%29%29)

Average complexity of the algorithm is `O(n)`, as average search and insert complexity of a hashtable is O(1):

![](https://latex.codecogs.com/gif.latex?%5Csum_%7Bi%3D0%7D%5E%7Bn-1%7D%28O%28search%29%20&plus;%20O%28insert%29%29%20%3D%20%5Csum_%7Bi%3D0%7D%5E%7Bn-1%7D%28O%281%29%20&plus;%20O%281%29%29%20%3D%20O%282n%29%20%3D%20O%28n%29)

Worst complexity of algorithm is also `O(n)`, as the worst search and insert complexity of a hashtable is O(n), however the maximum amount of keys in the hashtable, used in the implementation, is 26:

![](https://latex.codecogs.com/gif.latex?%5Csum_%7Bi%3D0%7D%5E%7Bn-1%7D%28O%28search%29%20&plus;%20O%28insert%29%29%20%3D%20%5Csum_%7Bi%3D0%7D%5E%7Bn-1%7D%28O%2826%29%20&plus;%20O%2826%29%29%20%3D%20O%2852n%29%20%3D%20O%28n%29)

## Suggested enhancements

The are three possible enhancements that could be made to the code:

1. Refactor the `Sorter` class: extract the `Dictionary` operating logic into a separate class, that would only be responsible for character counting logic, encapsulating all details.
2. To further optimize the performance, it may be possible to process the string in parallel by spawning multiple threads and allocating a substring to each of them. Each thread then may either operate on a shared thread safe dictionary, or have its own individual dictionary instance, which will be merged with other threads' instances at the end.
3. Add input validation to the console class.
