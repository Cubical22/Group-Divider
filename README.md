## The GroupDivider Algoritm
this is a simple algorithm I made in 3 diffrent programming languages.
I've looked up around the Internet and sadly have found no source code or anything
on this algorithm. so I decided to mke it myself.
## What's the purpose?
well, the entire purpose of this algorythm is to seperate a number into different smaller peaces
in a way that they all some up to the `goal` value. for example:
    
    > Imagine the `goal` value being 10 and the `dividers` being '2 and 5'
    
    > the result is, two success points:
        1. 2: 5 | 5: 0 (2 * 5 = 10)
        2. 2: 0 | 5: 2 (5 * 2 = 10)

normally this would be an easy approach. Just make two nested for loops to test every posiiblity.
but this approach raises three problems:
    1. what would be the limit of this loops.
    2. so many nested for loops at once. imagin making this for 10 dividers.
    3. It's S L O W.

this was my approach to solve all 3 problems at once:
## The functionality
it's rather simple and easy to undrestand since the code is pretty clear.
the most important point it the `failedStateCount` variable.
there exists two (what I like to call them) 'states':
    1. fail state 2. success state
> the fail state is used to keep track of how many times the sum of all values gets over the `goal` in a row.
this is pretty important, cause if it failes once and then on the next loop it doesn't, then the `failStateCount` resets back to 0.
This variable is used mainly to choose which multiplier we would like to increase by 1, and it is also used to stop the while loop after there are no more possibilities.

> the success state just does the counting of all possiblities and printing all of them to the screen.

on each loop, first thing checking the `failedStateCount` being less than the length of our dividers. next up adding one to a multiplier value, based on the `failedStateCount` variable. Hopefully you see what's going on under the hood. after that, we check ... if there is a success state or there is no state at all (meaning that the sum is less than our goal) we reset the `failedStateCount` back to 0.
one important thing to mention is that every time we add to the `failedStateCount` variable, meaning we move on to the next index, we also set all the values, including our currently working index (based on the `failedStateCount` variable) back into zero, and we do this before updating the `failedStateCount`. If we were to do it after, this would be excluding

# Using this project
the algorithm is made in three different languages
    python  java  javascript
to use each version, perform as mentioned:
    python:
        > on the `main` directory, run `python index.py` on the terminal
    javascript:
        > using `NodeJS`, on the `main` directory, run `node index.js` on the terminal
    java:
        > on the `javaOutput` directory, you have two options:
            1. run `javac Index.java` and then `java Index` or ...
            2. use the cmd I have already setup for you. just run `run cmd` or `run.cmd`
            no difference
