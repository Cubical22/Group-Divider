#include <iostream>
using namespace std;

int goal = 30;
int dividers[] = {1,2,3};
const int length = sizeof(dividers)/sizeof(dividers[0]);

int getOverallSum(int *multipliers) {
    int overallSum = 0;
    for (int i = 0; i < length; i++) {
        overallSum += *(multipliers + i) * dividers[i];
    }

    return overallSum;
}

void setFailedAndBelowToZero(int *multipliers, int failedStateCount) {
    for (int i = failedStateCount; i >= 0; i--) {
        *(multipliers + i) = 0;
    }
}

void logSuccessCase(int *multipliers) {
    cout<<"success)";

    for (int i = 0; i < length; i++) {
        cout<<" "<<dividers[i]<<": "<<*(multipliers + i)<<" |";
    }

    cout<<"\n";
}

int main() {
    int multipliers[length], failedStateCount = 0;

    // filling the mutipliers array from zeros
    for (int i = 0; i < length; i++) {
        multipliers[i] = 0;
    }


    // starting the main loop of the app

    int successCount = 0;

    while (true) {
        if (failedStateCount >= length) {
            break;
        }

        multipliers[failedStateCount]++;
        int overallSum = getOverallSum(multipliers);

        if (overallSum >= goal) {
            if (overallSum == goal) {
                // sucess state happens here
                successCount++;
                logSuccessCase(multipliers);
            }
            
            // failed state happens here
            setFailedAndBelowToZero(multipliers, failedStateCount);
            failedStateCount++;
            continue;
        }

        failedStateCount = 0;
    }

    cout<<"there were a totall number of "<<successCount<<" success cases";
}