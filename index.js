const goal = 30;
const dividers = [1,2,3];

function divideByGroup(goal, dividers) {
    const multipliers = generateZeros(dividers.length);
    let failedStateCount = 0;

    let successCount = 0;

    while (true) {
        if (failedStateCount >= multipliers.length) {
            // this means the algorithm is done and that the end of the run
            break;
        }

        multipliers[failedStateCount]++;
        const overallSum = calcSum(dividers, multipliers);

        if (overallSum === goal) {
            // the sum of all values add up to the goal
            successCount++;
            logSuccessState(dividers, multipliers);
        } else if (overallSum > goal) {
            // a fail state happens
            resetAllNumbersBellowFailedStated(failedStateCount, multipliers);
            failedStateCount++;
            continue;
        }

        failedStateCount = 0;
    }

    console.log(`the number of successful attempts is ${successCount}`);
}

function calcSum(dividers, multipliers) {
    let overallSum = 0;

    dividers.forEach((divider, index) => {
        overallSum += divider * multipliers[index];
    });

    return overallSum;
}

function generateZeros(count) {
    const returnArray = [];
    for (let i = 0; i < count; i++) {
        returnArray.push(0);
    }

    return returnArray;
}

function resetAllNumbersBellowFailedStated(index, multipliers) {
    for (let i = index; i >= 0; i--) {
        multipliers[i] = 0;
    }
}

function logSuccessState(dividers, multipliers) {
    let outString = 'success|';
    dividers.forEach((divider, index)=>{
       outString += ` ${divider}: ${multipliers[index]} |`;
    });

    console.log(outString);
}

divideByGroup(goal, dividers);