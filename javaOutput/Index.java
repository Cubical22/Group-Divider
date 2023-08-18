public class Index {
    final static int goal = 30;
    final static int[] dividers = new int[]{1,2,3};

    public static void main(String[] args) {
        int failedStateCount = 0;
        int[] multipliers = returnZeros(dividers.length);

        int successCount = 0;

        while (true) {
            if (failedStateCount >= dividers.length) {
                // the algorithm is over
                break;
            }

            multipliers[failedStateCount]++;
            int overallSum = getOverallSum(dividers, multipliers);

            if (overallSum == goal) {
                // the success state
                successCount++;
                logSuccessFulCases(dividers, multipliers);
            } else if (overallSum > goal) {
                // the fail state
                setFailedStateAndBellowToZero(failedStateCount, multipliers);
                failedStateCount++;
                continue;
            }

            failedStateCount = 0;
        }

        System.out.println("there were " + successCount + " successful cases");
    }

    static int[] returnZeros(int count) {
        int[] returnArr = new int[count];
        for (int i = 0; i < count; i++) {
            returnArr[i] = 0;
        }

        return returnArr;
    }

    static int getOverallSum(int[] dividers,int[] multipliers) {
        int overallSum = 0;
        for (int i = 0; i < dividers.length; i++) {
            overallSum += dividers[i] * multipliers[i];
        }

        return overallSum;
    }

    static void setFailedStateAndBellowToZero(int index, int[] multipliers) {
        for (int i = index; i >= 0; i--) {
            multipliers[i] = 0;
        }
    }

    static void logSuccessFulCases(int[] dividers, int[] multipliers) {
        String outString = "success)";
        for (int i = 0; i < dividers.length; i++) {
            outString += " " + dividers[i] + ": " + multipliers[i] + " |";
        }

        System.out.println(outString);
    }
}
