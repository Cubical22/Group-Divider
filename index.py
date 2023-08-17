goal = 10
dividers = (1,2,3)

def divideByGroup(goal, dividers):
    multipliers = createZeros(len(dividers))
    failedStateCount = 0

    successCount = 0

    while True:
        if failedStateCount >= len(multipliers):
            # algorithm is done
            break

        multipliers[failedStateCount] += 1
        overallSum = getOverallSum(dividers=dividers, multipliers=multipliers)

        if overallSum == goal:
            # success state happens
            successCount+=1
            logSuccess(dividers=dividers, multipliers=multipliers)
        elif overallSum > goal:
            # fail state happens
            resetAllBelowFailedState(failedStateCount, multipliers=multipliers)
            failedStateCount+=1
            continue

        failedStateCount = 0

    print(f'the number of success attempts is {successCount}')


def createZeros(count):
    returnArr = []
    for _ in range(count):
        returnArr.append(0)

    return returnArr

def getOverallSum(dividers, multipliers):
    overallSum = 0
    for (index, divider) in enumerate(dividers):
        overallSum += divider * multipliers[index]

    return overallSum

def resetAllBelowFailedState(index,multipliers):
    for i in range(0,index + 1):
        multipliers[i] = 0

def logSuccess(dividers, multipliers):
    outString = 'sucess)'
    for (index, divider) in enumerate(dividers):
        outString += f' {divider}: {multipliers[index]} |'

    print(outString)

if __name__ == "__main__":
    divideByGroup(goal=goal, dividers=dividers)