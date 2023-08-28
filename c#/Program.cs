using System;

namespace GroupDivider
{
    class GroupDivider {
        static void Main(String[] args) {
            const int goal = 30;
            int[] dividers = {1,2,3};
            byte failedStateCount = 0;
            byte successCases = 0;

            int[] multipliers = SetZeros(dividers.Length);

            // the main loop starts here
            while (true) {
                if (failedStateCount >= multipliers.Length) { // there are no more values to cycle through
                    break;
                }

                multipliers[failedStateCount]++;
                int overallSum = GetOverallSum(dividers, multipliers);

                if (overallSum == goal) {
                    // the success case
                    successCases++;
                    logSuccess(dividers, multipliers);
                } else if (overallSum > goal) {
                    // the failed case
                    for (int i = failedStateCount; i >= 0; i--) {
                        multipliers[i] = 0;
                    } // this loop resets all the values below the current target to 0
                    failedStateCount++;

                    continue;
                }

                failedStateCount = 0;
            }

            Console.Write("the number of successfull cases is: [" + successCases + "]");
        }

        static int[] SetZeros(int count) {
            int[] multipliers = new int[count];
            for (int i = 0; i < count; i++) {
                multipliers[i] = 0;
            }
            return multipliers;
        }

        static int GetOverallSum(int[] dividers, int[] multipliers) {
            int overallSum = 0;
            for (int i = 0; i < dividers.Length; i++) {
                overallSum += multipliers[i] * dividers[i];
            }
            return overallSum;
        }

        static void logSuccess(int[] dividers, int[] multipliers) {
            string outLog = "success)";
            for (int i = 0; i < dividers.Length; i++) {
                outLog += " " + dividers[i] + ": " + multipliers[i] + " |";
            }
            Console.WriteLine(outLog);
        }
    }
}