## The GroupDivider Algorithm
This is a simple algorithm I made in 6 different programming languages.
I've looked up around the Internet and sadly have found no source code or anything
on this algorithm. so I decided to make it myself.
## What's the purpose?
well, the entire purpose of this algorithm is to separate a number into different smaller fractions
in a way that they all sum up to the `goal` value. for example:
    
    > Imagine the `goal` value being 10 and the `dividers` being '2 and 5'
    
    > The result is, two success points:
        1. 2: 5 | 5: 0 (2 * 5 = 10)
        2. 2: 0 | 5: 2 (5 * 2 = 10)

normally this would be an easy approach. Just make two nested for-loops to test every possibility.
but this approach raises three problems:
    
    1. finding out the limit of this loops.
    
    2. so many nested for loops at once. imagine making this for 10 dividers.
    
    3. It's S L O W.

this was my approach, solving all 3 problems at once:
## The functionality
it's rather simple and easy to understand since the code is pretty clear.
the most important point is the `failedStateCount` variable.
there are two (what I like to call them) 'states':
    1. fail state 2. success state
> The fail state is used to keep track of how many times the sum of all values gets over the `goal` in a row.
this is pretty important, cause if it fails once and then on the next loop it doesn't, then the `failStateCount` resets 
back to 0.
This variable is used mainly to choose which multiplier we would like to increase by 1,
and it is also used to stop the while loop after there are no more possibilities.

> The success state just does the counting of all possibilities and printing all of them to the screen.

on each loop, the first thing is checking if the `failedStateCount` is less than the length of our dividers. next up adding one to a multiplier value, based on the `failedStateCount` variable. Hopefully, you see what's going on under the hood. after that, we check ... if there is a success state or there is no state at all (meaning that the sum is less than our goal) we reset the `failedStateCount` back to 0.
one important thing to mention is that every time we add to the `failedStateCount` variable, meaning we move on to the next index, we also set all the values, including our currently working index (based on the `failedStateCount` variable) back into zero, and we do this before updating the `failedStateCount`. If we were to do it after, this would be excluding

Have a look:

![algo-image](https://github.com/Cubical22/Group-Divider/blob/main/Algorithm-Flowchart.png?raw=true)

# Using this project
the algorithm is made in six different languages
    python  java javascript C++ C# PHP
to use each version, perform as mentioned:
    
Python:
> On the `main` directory, run `python index.py` on the terminal

JavaScript:
> Using `NodeJS`, on the `main` directory, run `node index.js` on the terminal

Java:
> On the `java` directory, you have two options:
    1. run `javac Index.java` and then `java Index` or ...
    2. use the cmd I have already set up for you. just run `run cmd` or `run.cmd`
    no difference

C++:
> On the `Cpp` directory, assuming you have gcc and/or g++ installed (check by running `gcc --version` or `g++ --version` in cmd), you just simply run `g++ index.cpp`
to compile the code. There is also a pre-compiled version on the directory, called `index.exe`. To use, just run `index.exe` in your terminal/command line

C#:
> On the `c#` directory, assuming you already have either a c# compiler or .Net installed on you local machine, run `dotnet run` to start the project, or use you prefered compiler as you wish

PHP:
> On the `php` directory, assuming you have php installed on your local machine, run `php index.php` and, that's all
